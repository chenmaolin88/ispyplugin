namespace Plugins
{
    partial class Configure
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
            this.button1 = new System.Windows.Forms.Button();
            this.tcpDisconnect = new System.Windows.Forms.RadioButton();
            this.Connect = new System.Windows.Forms.RadioButton();
            this.interverSet = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.alertSet = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.interverSet)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 2;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tcpDisconnect
            // 
            this.tcpDisconnect.AutoSize = true;
            this.tcpDisconnect.Location = new System.Drawing.Point(106, 76);
            this.tcpDisconnect.Name = "tcpDisconnect";
            this.tcpDisconnect.Size = new System.Drawing.Size(71, 16);
            this.tcpDisconnect.TabIndex = 5;
            this.tcpDisconnect.Text = "断开连接";
            this.tcpDisconnect.UseVisualStyleBackColor = true;
            // 
            // Connect
            // 
            this.Connect.AutoSize = true;
            this.Connect.Checked = true;
            this.Connect.Location = new System.Drawing.Point(213, 76);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(47, 16);
            this.Connect.TabIndex = 6;
            this.Connect.TabStop = true;
            this.Connect.Text = "连接";
            this.Connect.UseVisualStyleBackColor = true;
            // 
            // interverSet
            // 
            this.interverSet.Location = new System.Drawing.Point(106, 98);
            this.interverSet.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.interverSet.Name = "interverSet";
            this.interverSet.Size = new System.Drawing.Size(59, 21);
            this.interverSet.TabIndex = 7;
            this.interverSet.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "时间间隔：";
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(106, 9);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(100, 21);
            this.ip.TabIndex = 9;
            this.ip.Text = "127.0.0.1";
            // 
            // port
            // 
            this.port.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.port.Location = new System.Drawing.Point(106, 47);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(56, 21);
            this.port.TabIndex = 10;
            this.port.Text = "9988";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "服务器地址：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "端口：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "报警提示语：";
            // 
            // alertSet
            // 
            this.alertSet.Location = new System.Drawing.Point(106, 131);
            this.alertSet.Name = "alertSet";
            this.alertSet.Size = new System.Drawing.Size(162, 21);
            this.alertSet.TabIndex = 14;
            this.alertSet.Text = "注意，有预警!";
            // 
            // Configure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 203);
            this.Controls.Add(this.alertSet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.port);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.interverSet);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.tcpDisconnect);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Configure";
            this.Text = "配置";
            this.Load += new System.EventHandler(this.Configure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.interverSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton tcpDisconnect;
        private System.Windows.Forms.RadioButton Connect;
        private System.Windows.Forms.NumericUpDown interverSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox alertSet;
    }
}