namespace HZZH.UI2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Downcamera = new System.Windows.Forms.Label();
            this.Upcamera = new System.Windows.Forms.Label();
            this.Card1Sta = new System.Windows.Forms.Label();
            this.AlarmBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PassWordBtn = new System.Windows.Forms.Button();
            this.LoginBtn = new HZZH.UI2.自定义控件.DoubleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.PassWordBtn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LoginBtn);
            this.panel1.Controls.Add(this.Downcamera);
            this.panel1.Controls.Add(this.Upcamera);
            this.panel1.Controls.Add(this.Card1Sta);
            this.panel1.Controls.Add(this.AlarmBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1451, 97);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(1, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Downcamera
            // 
            this.Downcamera.BackColor = System.Drawing.Color.Transparent;
            this.Downcamera.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Downcamera.Location = new System.Drawing.Point(221, 68);
            this.Downcamera.Name = "Downcamera";
            this.Downcamera.Size = new System.Drawing.Size(71, 27);
            this.Downcamera.TabIndex = 8;
            this.Downcamera.Text = "下相机";
            this.Downcamera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Downcamera.Click += new System.EventHandler(this.Downcamera_Click);
            // 
            // Upcamera
            // 
            this.Upcamera.BackColor = System.Drawing.Color.Transparent;
            this.Upcamera.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Upcamera.Location = new System.Drawing.Point(221, 38);
            this.Upcamera.Name = "Upcamera";
            this.Upcamera.Size = new System.Drawing.Size(71, 27);
            this.Upcamera.TabIndex = 7;
            this.Upcamera.Text = "上相机";
            this.Upcamera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Card1Sta
            // 
            this.Card1Sta.BackColor = System.Drawing.Color.Transparent;
            this.Card1Sta.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Card1Sta.Location = new System.Drawing.Point(221, 8);
            this.Card1Sta.Name = "Card1Sta";
            this.Card1Sta.Size = new System.Drawing.Size(71, 27);
            this.Card1Sta.TabIndex = 5;
            this.Card1Sta.Text = "控制卡";
            this.Card1Sta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlarmBtn
            // 
            this.AlarmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlarmBtn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AlarmBtn.ForeColor = System.Drawing.Color.Black;
            this.AlarmBtn.Location = new System.Drawing.Point(1159, 5);
            this.AlarmBtn.Name = "AlarmBtn";
            this.AlarmBtn.Size = new System.Drawing.Size(78, 88);
            this.AlarmBtn.TabIndex = 4;
            this.AlarmBtn.TabStop = false;
            this.AlarmBtn.Text = "报警信息";
            this.AlarmBtn.UseVisualStyleBackColor = true;
            this.AlarmBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 23.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(74, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "鸿圆机械";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(488, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mylar贴附设备";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(1323, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 42);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Text = "最小化";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1323, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 42);
            this.button1.TabIndex = 2;
            this.button1.TabStop = false;
            this.button1.Text = "退出系统";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1451, 773);
            this.panel2.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PassWordBtn
            // 
            this.PassWordBtn.FlatAppearance.BorderSize = 2;
            this.PassWordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PassWordBtn.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PassWordBtn.ForeColor = System.Drawing.Color.Black;
            this.PassWordBtn.Location = new System.Drawing.Point(1241, 5);
            this.PassWordBtn.Name = "PassWordBtn";
            this.PassWordBtn.Size = new System.Drawing.Size(78, 88);
            this.PassWordBtn.TabIndex = 11;
            this.PassWordBtn.TabStop = false;
            this.PassWordBtn.Text = "密码管理";
            this.PassWordBtn.UseVisualStyleBackColor = true;
            this.PassWordBtn.Click += new System.EventHandler(this.PassWordBtn_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.Red;
            this.LoginBtn.FlatAppearance.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginBtn.ForeColor = System.Drawing.Color.Black;
            this.LoginBtn.Location = new System.Drawing.Point(1065, 5);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(90, 88);
            this.LoginBtn.TabIndex = 9;
            this.LoginBtn.Text = "登 录";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1451, 870);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AlarmBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Downcamera;
        private System.Windows.Forms.Label Upcamera;
        private System.Windows.Forms.Label Card1Sta;
        private System.Windows.Forms.Timer timer1;
        private 自定义控件.DoubleButton LoginBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button PassWordBtn;
    }
}