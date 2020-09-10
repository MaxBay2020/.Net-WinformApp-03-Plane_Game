namespace PlaneGame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_getready = new System.Windows.Forms.Button();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.lb_port = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.lb_ip = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_getready
            // 
            this.txt_getready.Location = new System.Drawing.Point(225, 224);
            this.txt_getready.Name = "txt_getready";
            this.txt_getready.Size = new System.Drawing.Size(74, 23);
            this.txt_getready.TabIndex = 9;
            this.txt_getready.Text = "Start";
            this.txt_getready.UseVisualStyleBackColor = true;
            this.txt_getready.Click += new System.EventHandler(this.txt_getready_Click);
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(170, 168);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(129, 21);
            this.txt_port.TabIndex = 8;
            this.txt_port.Text = "5000";
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Location = new System.Drawing.Point(129, 171);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(35, 12);
            this.lb_port.TabIndex = 7;
            this.lb_port.Text = "Port:";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(170, 116);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(129, 21);
            this.txt_ip.TabIndex = 6;
            this.txt_ip.Text = "192.168.0.15";
            // 
            // lb_ip
            // 
            this.lb_ip.AutoSize = true;
            this.lb_ip.Location = new System.Drawing.Point(141, 119);
            this.lb_ip.Name = "lb_ip";
            this.lb_ip.Size = new System.Drawing.Size(23, 12);
            this.lb_ip.TabIndex = 5;
            this.lb_ip.Text = "IP:";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 811);
            this.Controls.Add(this.txt_getready);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.lb_port);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.lb_ip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button txt_getready;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Label lb_ip;
        private System.Windows.Forms.Timer timer2;
    }
}

