using System.Net.Sockets;
using System.Threading;
using System.Text;
using System;
using System.Data;

namespace PORTTechnologySimulator
{
    class DbServer
    {
        private TcpListener m_listener;
        private bool m_stop;
        private Thread m_thread;

        public DataTable ListOfUsers;
        public delegate void StatusEventHandler(string data);
        public event StatusEventHandler Status;

        public void StartCommunication(int localPort)
        {
            if (m_listener != null)
            {
                StopCommunication();
            }

            CreateDatatable();
            
            m_stop = false;
            m_listener = new TcpListener(System.Net.IPAddress.Any, localPort);
            m_listener.Start();

            OnStatus("Listening on port " + localPort.ToString());

            m_thread = new Thread(WaitConnections);
            m_thread.Start();
        }

        private void CreateDatatable()
        {
            ListOfUsers = new DataTable();
            ListOfUsers.Columns.Add("PersonID", typeof(int));
            ListOfUsers.Columns.Add("FamilyName", typeof(string));
            ListOfUsers.Columns.Add("FirstName", typeof(string));
            ListOfUsers.Columns.Add("Company", typeof(string));
            ListOfUsers.Columns.Add("Enterprise", typeof(string));
            ListOfUsers.Columns.Add("Department", typeof(string));
            ListOfUsers.Columns.Add("ProfileName", typeof(string));
            ListOfUsers.Columns.Add("Badge1", typeof(string));
            ListOfUsers.Columns.Add("Badge2", typeof(string));
            ListOfUsers.Columns.Add("Badge3", typeof(string));
            ListOfUsers.Columns.Add("StartDateTime", typeof(DateTime));
            ListOfUsers.Columns.Add("EndDateTime", typeof(DateTime));
            ListOfUsers.Columns.Add("Phone", typeof(string));
            ListOfUsers.Columns.Add("ZoneAlways", typeof(string));
            ListOfUsers.Columns.Add("ZoneNone", typeof(string));

            ListOfUsers.PrimaryKey = new DataColumn[] { ListOfUsers.Columns[0] };
        }

        private void WaitConnections()
        {
            var sendText = string.Empty;

            try
            {
                while (true)
                {
                    if (m_stop) {
                        break;
                    }

                    if (!m_listener.Pending())
                    {
                        Thread.Sleep(10);

                        continue;
                    }

                    TcpClient client = m_listener.AcceptTcpClient();
                    OnStatus("Client connected");

                    using (NetworkStream ns = client.GetStream())
                    {
                        while (true)
                        {
                            if (m_stop) {
                                break;
                            }

                            if (!client.Connected) {
                                break;
                            }

                            if ((client.Client.Poll(1, SelectMode.SelectRead)) && (client.Client.Available == 0)) {
                                break;
                            }

                            if (ns.DataAvailable)
                            {
                                byte[] rbuf = new byte[1000];
                                ns.Read(rbuf, 0, rbuf.Length);

                                var receivedText = Encoding.ASCII.GetString(rbuf).Replace('\0', ' ').Trim();

                                OnStatus("Received: " + receivedText);

                                sendText = ProcessIncomingMessage(receivedText);
                            }

                            if (sendText.Length != 0)
                            {
                                OnStatus("Sending: " + sendText);

                                var wbuf = Encoding.ASCII.GetBytes(sendText);
                                ns.Write(wbuf, 0, wbuf.Length);

                                sendText = "";
                            }

                            Thread.Sleep(10);
                        }
                    }

                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                OnStatus("Error: " + ex.Message);
                StopCommunication(true);
            }
        }

        public string ProcessIncomingMessage(string message)
        {
            StringBuilder reply = new StringBuilder();
            string[] chunk;
            int i;
            DataRow row;

            if (message.Length >= 5)
            {
                reply.Append(message.Substring(0, 3));

                switch (message.Substring(3, 2))
                {
                    case "00":
                        OnStatus("Recognized: I'm Alive");
                        reply.Append("01");
                        break;

                    case "06":
                        OnStatus("Recognized: Insert or Update User");

                        chunk = message.Substring(5).Split('|');
                        try
                        {
                            OnStatus("    Person ID: " + chunk[0]);
                            OnStatus("    Family name: " + chunk[1]);
                            OnStatus("    First name: " + chunk[2]);
                            OnStatus("    Company: " + chunk[3]);
                            OnStatus("    Enterprise: " + chunk[4]);
                            OnStatus("    Department: " + chunk[5]);
                            OnStatus("    Profile name: " + chunk[6]);
                            OnStatus("    Badge1: " + chunk[7]);
                            OnStatus("    Badge2: " + chunk[8]);
                            OnStatus("    Badge3: " + chunk[9]);
                            OnStatus("    Start datetime: " + chunk[10]);
                            OnStatus("    End datetime: " + chunk[11]);
                            OnStatus("    Phone: " + chunk[12]);

                            row = ListOfUsers.Rows.Find(chunk[0]);
                            if (row == null)
                            {
                                row = ListOfUsers.NewRow();
                            }

                            row["PersonID"] = Convert.ToInt32(chunk[0]);
                            row["FamilyName"] = chunk[1];
                            row["FirstName"] = chunk[2];
                            row["Company"] = chunk[3];
                            row["Enterprise"] = chunk[4];
                            row["Department"] = chunk[5];
                            row["ProfileName"] = chunk[6];
                            row["Badge1"] = chunk[7];
                            row["Badge2"] = chunk[8];
                            row["Badge3"] = chunk[9];

                            DateTime date;

                            if (!DateTime.TryParse(chunk[10], out date))
                            {
                                reply.Append("0710|Invalid date");
                                break;
                            }

                            row["StartDateTime"] = date;

                            if (!DateTime.TryParse(chunk[11], out date))
                            {
                                reply.Append("0710|Invalid date");
                                break;
                            }

                            row["EndDateTime"] = date;
                            row["Phone"] = chunk[12];

                            if (row.RowState == DataRowState.Detached)
                            {
                                ListOfUsers.Rows.Add(row);
                            }

                            reply.Append("03");
                        }
                        catch (Exception)
                        {
                            reply.Append("0700|Incorrect message format");
                        }

                        break;
                        
                    case "10":
                        OnStatus("Recognized: Edit Access Zones");

                        chunk = message.Substring(5).Split('|');

                        try
                        {
                            OnStatus("    Person ID: " + chunk[0]);

                            row = ListOfUsers.Rows.Find(chunk[0]);

                            if (row == null)
                            {
                                reply.Append("1214|User not found");
                                break;
                            }

                            for (i = 1; i < chunk.Length-1; i = i + 2)
                            {
                                OnStatus("    Zones: " + chunk[i]);
                                OnStatus("    Access: " + chunk[i + 1]);

                                if (chunk[i+1] == "Always")
                                {
                                    row["ZoneAlways"] = chunk[i];
                                }
                                else if (chunk[i+1] == "None")
                                {
                                    row["ZoneNone"] = chunk[i];
                                }
                            }

                            reply.Append("11");
                        }
                        catch (Exception)
                        {

                            reply.Append("1200|Incorrect message format");
                        }
                        
                        break;
                        
                    case "08":
                        OnStatus("Recognized: Delete User");

                        chunk = message.Substring(5).Split('|');

                        try
                        {
                            OnStatus("    Person ID: " + chunk[0]);

                            row = ListOfUsers.Rows.Find(chunk[0]);

                            if (row == null)
                            {
                                reply.Append("0914|User not found");
                                break;
                            }

                            row.Delete();

                            reply.Append("05");
                        }
                        catch (Exception)
                        {
                            reply.Append("0900|Incorrect message format");
                        }

                        break;

                    default:
                        reply.Clear();
                        break;
                }
            }

            return reply.ToString();
        }

        public void StopCommunication()
        {
            StopCommunication(false);
        }

        private void StopCommunication(bool dontStopThread)
        {
            if (m_thread != null && !dontStopThread)
            {
                m_stop = true;

                try
                {
                    m_thread.Join(10000);
                }
                catch (Exception)
                {
                }
            }

            if (m_listener != null)
            {
                m_listener.Stop();
                m_listener = null;
            }
                        
            OnStatus("Stop Listening");
        }
        
        protected virtual void OnStatus(string data)
        {
            Status?.Invoke(data);
        }
    }
}
