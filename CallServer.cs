using System.Net.Sockets;
using System.Threading;
using System.Text;
using System;

namespace PORTTechnologySimulator
{
    class CallServer
    {
        private TcpListener m_listener;
        private bool m_stop;
        private Thread m_thread;
        
        public delegate void StatusEventHandler(string data);
        public event StatusEventHandler Status;

        public void StartCommunication(int localPort)
        {
            if (m_listener != null)
            {
                StopCommunication();
            }
            
            m_stop = false;
            m_listener = new TcpListener(System.Net.IPAddress.Any, localPort);
            m_listener.Start();

            OnStatus("Listening on port " + localPort.ToString());

            m_thread = new Thread(WaitConnections);
            m_thread.Start();
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

            if (message.Length >= 5)
            {
                reply.Append(message.Substring(0, 3));

                switch (message.Substring(3, 2))
                {
                    case "00":
                        OnStatus("Recognized: I'm Alive");
                        reply.Append("01");
                        break;

                    case "12":
                        OnStatus("Recognized: Call by profile");

                        var chunk = message.Substring(5).Split('|');
                        try
                        {
                            OnStatus("    Terminal ID: " + chunk[0]);
                            OnStatus("    Profile: " + chunk[1]);
                            OnStatus("    User Number: " + chunk[2]);

                            reply.Append("03");
                        }
                        catch (Exception)
                        {

                            reply.Append("0700|Incorrect message format");
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
