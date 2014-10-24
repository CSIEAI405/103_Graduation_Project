namespace E_Home
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboControlSerialPort = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnOpenControlSerialPort = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCloseControlSerialPort = new System.Windows.Forms.Button();
            this.btnOpenSensorSerialPort = new System.Windows.Forms.Button();
            this.btnCloseSensorSerialPort = new System.Windows.Forms.Button();
            this.comboSensorSerialPort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(177, 76);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "控制串列埠：";
            // 
            // comboControlSerialPort
            // 
            this.comboControlSerialPort.FormattingEnabled = true;
            this.comboControlSerialPort.Location = new System.Drawing.Point(102, 18);
            this.comboControlSerialPort.Name = "comboControlSerialPort";
            this.comboControlSerialPort.Size = new System.Drawing.Size(69, 20);
            this.comboControlSerialPort.TabIndex = 2;
            // 
            // btnOpenControlSerialPort
            // 
            this.btnOpenControlSerialPort.Location = new System.Drawing.Point(177, 16);
            this.btnOpenControlSerialPort.Name = "btnOpenControlSerialPort";
            this.btnOpenControlSerialPort.Size = new System.Drawing.Size(75, 23);
            this.btnOpenControlSerialPort.TabIndex = 3;
            this.btnOpenControlSerialPort.Text = "Open";
            this.btnOpenControlSerialPort.UseVisualStyleBackColor = true;
            this.btnOpenControlSerialPort.Click += new System.EventHandler(this.btnOpenControlSerialPort_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(71, 76);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 22);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "1104";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "通訊埠：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(258, 76);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCloseControlSerialPort
            // 
            this.btnCloseControlSerialPort.Location = new System.Drawing.Point(258, 15);
            this.btnCloseControlSerialPort.Name = "btnCloseControlSerialPort";
            this.btnCloseControlSerialPort.Size = new System.Drawing.Size(75, 23);
            this.btnCloseControlSerialPort.TabIndex = 7;
            this.btnCloseControlSerialPort.Text = "Close";
            this.btnCloseControlSerialPort.UseVisualStyleBackColor = true;
            this.btnCloseControlSerialPort.Click += new System.EventHandler(this.btnCloseControlSerialPort_Click);
            // 
            // btnOpenSensorSerialPort
            // 
            this.btnOpenSensorSerialPort.Location = new System.Drawing.Point(177, 47);
            this.btnOpenSensorSerialPort.Name = "btnOpenSensorSerialPort";
            this.btnOpenSensorSerialPort.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSensorSerialPort.TabIndex = 8;
            this.btnOpenSensorSerialPort.Text = "Open";
            this.btnOpenSensorSerialPort.UseVisualStyleBackColor = true;
            this.btnOpenSensorSerialPort.Click += new System.EventHandler(this.btnOpenSensorSerialPort_Click);
            // 
            // btnCloseSensorSerialPort
            // 
            this.btnCloseSensorSerialPort.Location = new System.Drawing.Point(258, 47);
            this.btnCloseSensorSerialPort.Name = "btnCloseSensorSerialPort";
            this.btnCloseSensorSerialPort.Size = new System.Drawing.Size(75, 23);
            this.btnCloseSensorSerialPort.TabIndex = 9;
            this.btnCloseSensorSerialPort.Text = "Close";
            this.btnCloseSensorSerialPort.UseVisualStyleBackColor = true;
            this.btnCloseSensorSerialPort.Click += new System.EventHandler(this.btnCloseSensorSerialPort_Click);
            // 
            // comboSensorSerialPort
            // 
            this.comboSensorSerialPort.FormattingEnabled = true;
            this.comboSensorSerialPort.Location = new System.Drawing.Point(102, 49);
            this.comboSensorSerialPort.Name = "comboSensorSerialPort";
            this.comboSensorSerialPort.Size = new System.Drawing.Size(69, 20);
            this.comboSensorSerialPort.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "感測串列埠：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 102);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboSensorSerialPort);
            this.Controls.Add(this.btnCloseSensorSerialPort);
            this.Controls.Add(this.btnOpenSensorSerialPort);
            this.Controls.Add(this.btnCloseControlSerialPort);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnOpenControlSerialPort);
            this.Controls.Add(this.comboControlSerialPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "E-Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboControlSerialPort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnOpenControlSerialPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCloseControlSerialPort;
        private System.Windows.Forms.Button btnOpenSensorSerialPort;
        private System.Windows.Forms.Button btnCloseSensorSerialPort;
        private System.Windows.Forms.ComboBox comboSensorSerialPort;
        private System.Windows.Forms.Label label3;
    }
}

