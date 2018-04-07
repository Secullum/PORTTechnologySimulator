using System;
using System.Windows.Forms;

namespace PORTTechnologySimulator
{
    public partial class MainForm : Form
    {

        private CallServer callServer = new CallServer();
        private DbServer dbServer = new DbServer();

        public MainForm()
        {
            InitializeComponent();
            
            callServer.Status  += new CallServer.StatusEventHandler(CallServerStatus);
            dbServer.Status += new DbServer.StatusEventHandler(DbServerStatus);
        }

        private void CallServerStatus(String data)
        {
            txtCallServerLog.Invoke(new Action(() => 
            {
                txtCallServerLog.Text = txtCallServerLog.Text + DateTime.Now.ToString("HH:mm:ss fff: ") + data + "\r\n";

                txtCallServerLog.SelectionStart = txtCallServerLog.Text.Length - 1;
                txtCallServerLog.SelectionLength = 0;
                txtCallServerLog.ScrollToCaret();
            }));
        }

        private void DbServerStatus(String data)
        {
            txtDbServerLog.Invoke(new Action(() => {
                txtDbServerLog.Text = txtDbServerLog.Text + DateTime.Now.ToString("HH:mm:ss fff: ") + data + "\r\n";

                txtDbServerLog.SelectionStart = txtDbServerLog.Text.Length-1;
                txtDbServerLog.SelectionLength = 0;
                txtDbServerLog.ScrollToCaret();

                dgvDbUsers.DataSource = dbServer.ListOfUsers;
                dgvDbUsers.Invalidate();
                }));
        }

        private void btnCallStartStop_Click(object sender, EventArgs e)
        {
            if (btnCallStartStop.Text == "Start")
            {
                callServer.StartCommunication(Convert.ToInt32(txtCallLocalPort.Text));
                btnCallStartStop.Text = "Stop";
            }
            else
            {
                btnCallStartStop.Text = "Start";
                callServer.StopCommunication();
            }
        }

        private void btnDbStartStop_Click(object sender, EventArgs e)
        {
            if (btnDbStartStop.Text == "Start")
            {
                dbServer.StartCommunication(Convert.ToInt32(txtDbLocalPort.Text));
                btnDbStartStop.Text = "Stop";
            }
            else
            {
                btnDbStartStop.Text = "Start";
                dbServer.StopCommunication();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            callServer.StopCommunication();
            dbServer.StopCommunication();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
