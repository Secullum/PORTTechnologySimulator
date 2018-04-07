namespace PORTTechnologySimulator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCallServerLog = new System.Windows.Forms.TextBox();
            this.btnCallStartStop = new System.Windows.Forms.Button();
            this.txtCallLocalPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvDbUsers = new System.Windows.Forms.DataGridView();
            this.txtDbServerLog = new System.Windows.Forms.TextBox();
            this.btnDbStartStop = new System.Windows.Forms.Button();
            this.txtDbLocalPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDbUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(683, 539);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCallServerLog);
            this.tabPage1.Controls.Add(this.btnCallStartStop);
            this.tabPage1.Controls.Add(this.txtCallLocalPort);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(675, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Call Interface";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtCallServerLog
            // 
            this.txtCallServerLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCallServerLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCallServerLog.Location = new System.Drawing.Point(22, 60);
            this.txtCallServerLog.Multiline = true;
            this.txtCallServerLog.Name = "txtCallServerLog";
            this.txtCallServerLog.ReadOnly = true;
            this.txtCallServerLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCallServerLog.Size = new System.Drawing.Size(625, 435);
            this.txtCallServerLog.TabIndex = 3;
            // 
            // btnCallStartStop
            // 
            this.btnCallStartStop.Location = new System.Drawing.Point(218, 11);
            this.btnCallStartStop.Name = "btnCallStartStop";
            this.btnCallStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnCallStartStop.TabIndex = 2;
            this.btnCallStartStop.Text = "Start";
            this.btnCallStartStop.UseVisualStyleBackColor = true;
            this.btnCallStartStop.Click += new System.EventHandler(this.btnCallStartStop_Click);
            // 
            // txtCallLocalPort
            // 
            this.txtCallLocalPort.Location = new System.Drawing.Point(111, 13);
            this.txtCallLocalPort.Name = "txtCallLocalPort";
            this.txtCallLocalPort.Size = new System.Drawing.Size(85, 20);
            this.txtCallLocalPort.TabIndex = 1;
            this.txtCallLocalPort.Text = "5050";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Port";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvDbUsers);
            this.tabPage2.Controls.Add(this.txtDbServerLog);
            this.tabPage2.Controls.Add(this.btnDbStartStop);
            this.tabPage2.Controls.Add(this.txtDbLocalPort);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(675, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Database Interface";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvDbUsers
            // 
            this.dgvDbUsers.AllowUserToAddRows = false;
            this.dgvDbUsers.AllowUserToDeleteRows = false;
            this.dgvDbUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDbUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDbUsers.Location = new System.Drawing.Point(22, 53);
            this.dgvDbUsers.Name = "dgvDbUsers";
            this.dgvDbUsers.ReadOnly = true;
            this.dgvDbUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvDbUsers.Size = new System.Drawing.Size(625, 210);
            this.dgvDbUsers.TabIndex = 6;
            // 
            // txtDbServerLog
            // 
            this.txtDbServerLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDbServerLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDbServerLog.Location = new System.Drawing.Point(22, 285);
            this.txtDbServerLog.Multiline = true;
            this.txtDbServerLog.Name = "txtDbServerLog";
            this.txtDbServerLog.ReadOnly = true;
            this.txtDbServerLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDbServerLog.Size = new System.Drawing.Size(625, 210);
            this.txtDbServerLog.TabIndex = 5;
            // 
            // btnDbStartStop
            // 
            this.btnDbStartStop.Location = new System.Drawing.Point(218, 11);
            this.btnDbStartStop.Name = "btnDbStartStop";
            this.btnDbStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnDbStartStop.TabIndex = 4;
            this.btnDbStartStop.Text = "Start";
            this.btnDbStartStop.UseVisualStyleBackColor = true;
            this.btnDbStartStop.Click += new System.EventHandler(this.btnDbStartStop_Click);
            // 
            // txtDbLocalPort
            // 
            this.txtDbLocalPort.Location = new System.Drawing.Point(111, 13);
            this.txtDbLocalPort.Name = "txtDbLocalPort";
            this.txtDbLocalPort.Size = new System.Drawing.Size(85, 20);
            this.txtDbLocalPort.TabIndex = 3;
            this.txtDbLocalPort.Text = "4040";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Local Port";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 563);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "PORT Technology Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDbUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtCallLocalPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDbLocalPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCallStartStop;
        private System.Windows.Forms.TextBox txtCallServerLog;
        private System.Windows.Forms.TextBox txtDbServerLog;
        private System.Windows.Forms.Button btnDbStartStop;
        private System.Windows.Forms.DataGridView dgvDbUsers;
    }
}

