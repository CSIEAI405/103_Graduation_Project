namespace POVPatternGenerater
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.bntBrowse = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnShowIP = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemoteIPPart1 = new System.Windows.Forms.TextBox();
            this.txtRemoteIPPart2 = new System.Windows.Forms.TextBox();
            this.txtRemoteIPPart3 = new System.Windows.Forms.TextBox();
            this.txtRemoteIPPart4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarFileTransfer = new System.Windows.Forms.ToolStripProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bntBrowse
            // 
            this.bntBrowse.Location = new System.Drawing.Point(361, 12);
            this.bntBrowse.Name = "bntBrowse";
            this.bntBrowse.Size = new System.Drawing.Size(75, 23);
            this.bntBrowse.TabIndex = 0;
            this.bntBrowse.Text = "Browse";
            this.bntBrowse.UseVisualStyleBackColor = true;
            this.bntBrowse.Click += new System.EventHandler(this.bntBrowse_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(50, 76);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(212, 76);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "File:";
            // 
            // lblFileName
            // 
            this.lblFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFileName.Location = new System.Drawing.Point(79, 16);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(276, 18);
            this.lblFileName.TabIndex = 4;
            this.lblFileName.Text = "Select file......";
            // 
            // btnShowIP
            // 
            this.btnShowIP.Location = new System.Drawing.Point(293, 75);
            this.btnShowIP.Name = "btnShowIP";
            this.btnShowIP.Size = new System.Drawing.Size(75, 23);
            this.btnShowIP.TabIndex = 6;
            this.btnShowIP.Text = "Show IP";
            this.btnShowIP.UseVisualStyleBackColor = true;
            this.btnShowIP.Click += new System.EventHandler(this.btnShowIP_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "RemoteIP:";
            // 
            // txtRemoteIPPart1
            // 
            this.txtRemoteIPPart1.Location = new System.Drawing.Point(230, 48);
            this.txtRemoteIPPart1.Name = "txtRemoteIPPart1";
            this.txtRemoteIPPart1.Size = new System.Drawing.Size(41, 22);
            this.txtRemoteIPPart1.TabIndex = 8;
            // 
            // txtRemoteIPPart2
            // 
            this.txtRemoteIPPart2.Location = new System.Drawing.Point(277, 47);
            this.txtRemoteIPPart2.Name = "txtRemoteIPPart2";
            this.txtRemoteIPPart2.Size = new System.Drawing.Size(41, 22);
            this.txtRemoteIPPart2.TabIndex = 9;
            // 
            // txtRemoteIPPart3
            // 
            this.txtRemoteIPPart3.Location = new System.Drawing.Point(324, 47);
            this.txtRemoteIPPart3.Name = "txtRemoteIPPart3";
            this.txtRemoteIPPart3.Size = new System.Drawing.Size(41, 22);
            this.txtRemoteIPPart3.TabIndex = 10;
            // 
            // txtRemoteIPPart4
            // 
            this.txtRemoteIPPart4.Location = new System.Drawing.Point(371, 47);
            this.txtRemoteIPPart4.Name = "txtRemoteIPPart4";
            this.txtRemoteIPPart4.Size = new System.Drawing.Size(41, 22);
            this.txtRemoteIPPart4.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mode:";
            // 
            // comboMode
            // 
            this.comboMode.FormattingEnabled = true;
            this.comboMode.Location = new System.Drawing.Point(89, 50);
            this.comboMode.Name = "comboMode";
            this.comboMode.Size = new System.Drawing.Size(75, 20);
            this.comboMode.TabIndex = 5;
            this.comboMode.SelectedIndexChanged += new System.EventHandler(this.comboMode_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(418, 76);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(41, 22);
            this.txtPort.TabIndex = 15;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBarFileTransfer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 163);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(506, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(129, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBarFileTransfer
            // 
            this.toolStripProgressBarFileTransfer.Name = "toolStripProgressBarFileTransfer";
            this.toolStripProgressBarFileTransfer.Size = new System.Drawing.Size(100, 16);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(131, 76);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 17;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 185);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRemoteIPPart4);
            this.Controls.Add(this.txtRemoteIPPart3);
            this.Controls.Add(this.txtRemoteIPPart2);
            this.Controls.Add(this.txtRemoteIPPart1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShowIP);
            this.Controls.Add(this.comboMode);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.bntBrowse);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
           
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntBrowse;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnShowIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemoteIPPart1;
        private System.Windows.Forms.TextBox txtRemoteIPPart2;
        private System.Windows.Forms.TextBox txtRemoteIPPart3;
        private System.Windows.Forms.TextBox txtRemoteIPPart4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarFileTransfer;
        private System.Windows.Forms.Button btnStop;
    }
}

