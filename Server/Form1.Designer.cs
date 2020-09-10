namespace Server
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_getready = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(96, 42);
            this.txt_ip.Margin = new System.Windows.Forms.Padding(6);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(254, 35);
            this.txt_ip.TabIndex = 1;
            this.txt_ip.Text = "192.168.0.15";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(474, 42);
            this.txt_port.Margin = new System.Windows.Forms.Padding(6);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(254, 35);
            this.txt_port.TabIndex = 3;
            this.txt_port.Text = "5000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // txt_getready
            // 
            this.txt_getready.Location = new System.Drawing.Point(768, 42);
            this.txt_getready.Margin = new System.Windows.Forms.Padding(6);
            this.txt_getready.Name = "txt_getready";
            this.txt_getready.Size = new System.Drawing.Size(148, 46);
            this.txt_getready.TabIndex = 4;
            this.txt_getready.Text = "Ready";
            this.txt_getready.UseVisualStyleBackColor = true;
            this.txt_getready.Click += new System.EventHandler(this.txt_getready_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(756, 374);
            this.btn_start.Margin = new System.Windows.Forms.Padding(6);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(186, 62);
            this.btn_start.TabIndex = 7;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // txt_msg
            // 
            this.txt_msg.Location = new System.Drawing.Point(42, 124);
            this.txt_msg.Margin = new System.Windows.Forms.Padding(6);
            this.txt_msg.Multiline = true;
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_msg.Size = new System.Drawing.Size(896, 216);
            this.txt_msg.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 472);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txt_getready);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button txt_getready;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox txt_msg;
    }
}

