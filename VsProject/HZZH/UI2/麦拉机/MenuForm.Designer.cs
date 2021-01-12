using HzControl.Communal.Controls;

namespace HZZH.UI2.上料机
{
    partial class MenuForm
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.borderPanel1 = new HzControl.Communal.Controls.BorderPanel();
            this.BtnVision = new System.Windows.Forms.Button();
            this.BtnMachine = new System.Windows.Forms.Button();
            this.levelButton1 = new System.Windows.Forms.Button();
            this.BtnCard = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.level13333 = new HzControl.Communal.Controls.Level(this.components);
            this.borderPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderSize = 3;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.button4, "");
            this.button4.Location = new System.Drawing.Point(1064, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 68);
            this.button4.TabIndex = 3;
            this.button4.Tag = "手动";
            this.button4.Text = "手 动";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 3;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.button3, "");
            this.button3.Location = new System.Drawing.Point(434, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 68);
            this.button3.TabIndex = 2;
            this.button3.Tag = "Feeder";
            this.button3.Text = "飞 达";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.button1, "");
            this.button1.Location = new System.Drawing.Point(644, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 68);
            this.button1.TabIndex = 0;
            this.button1.Tag = "ProductForm";
            this.button1.Text = "产 品";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // borderPanel1
            // 
            this.borderPanel1.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel1.BorderLineWidth = 2;
            this.borderPanel1.Controls.Add(this.BtnVision);
            this.borderPanel1.Controls.Add(this.BtnMachine);
            this.borderPanel1.Controls.Add(this.levelButton1);
            this.borderPanel1.Controls.Add(this.BtnCard);
            this.borderPanel1.Controls.Add(this.button1);
            this.borderPanel1.Controls.Add(this.button4);
            this.borderPanel1.Controls.Add(this.button3);
            this.borderPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.borderPanel1.Location = new System.Drawing.Point(0, 685);
            this.borderPanel1.Name = "borderPanel1";
            this.borderPanel1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel1.Size = new System.Drawing.Size(1450, 98);
            this.borderPanel1.TabIndex = 1;
            // 
            // BtnVision
            // 
            this.BtnVision.BackColor = System.Drawing.Color.Transparent;
            this.BtnVision.FlatAppearance.BorderSize = 3;
            this.BtnVision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVision.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.BtnVision, "");
            this.BtnVision.Location = new System.Drawing.Point(854, 16);
            this.BtnVision.Name = "BtnVision";
            this.BtnVision.Size = new System.Drawing.Size(165, 68);
            this.BtnVision.TabIndex = 9;
            this.BtnVision.Tag = "VisForm2";
            this.BtnVision.Text = "视 觉";
            this.BtnVision.UseVisualStyleBackColor = false;
            this.BtnVision.Click += new System.EventHandler(this.button5_Click);
            // 
            // BtnMachine
            // 
            this.BtnMachine.BackColor = System.Drawing.Color.Transparent;
            this.BtnMachine.FlatAppearance.BorderSize = 3;
            this.BtnMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMachine.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.BtnMachine, "");
            this.BtnMachine.Location = new System.Drawing.Point(224, 16);
            this.BtnMachine.Name = "BtnMachine";
            this.BtnMachine.Size = new System.Drawing.Size(165, 68);
            this.BtnMachine.TabIndex = 8;
            this.BtnMachine.Tag = "MachinePara";
            this.BtnMachine.Text = "机 械";
            this.BtnMachine.UseVisualStyleBackColor = false;
            this.BtnMachine.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // levelButton1
            // 
            this.levelButton1.BackColor = System.Drawing.Color.Teal;
            this.levelButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.levelButton1.FlatAppearance.BorderSize = 3;
            this.levelButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.levelButton1.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.levelButton1.ForeColor = System.Drawing.Color.Black;
            this.level13333.SetLevel(this.levelButton1, "");
            this.levelButton1.Location = new System.Drawing.Point(1274, 16);
            this.levelButton1.Name = "levelButton1";
            this.levelButton1.Size = new System.Drawing.Size(165, 68);
            this.levelButton1.TabIndex = 7;
            this.levelButton1.Tag = "MainRunForm";
            this.levelButton1.Text = "主界面";
            this.levelButton1.UseVisualStyleBackColor = false;
            this.levelButton1.Click += new System.EventHandler(this.levelButton1_Click);
            // 
            // BtnCard
            // 
            this.BtnCard.BackColor = System.Drawing.Color.Transparent;
            this.BtnCard.FlatAppearance.BorderSize = 3;
            this.BtnCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCard.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.BtnCard, "3");
            this.BtnCard.Location = new System.Drawing.Point(14, 16);
            this.BtnCard.Name = "BtnCard";
            this.BtnCard.Size = new System.Drawing.Size(165, 68);
            this.BtnCard.TabIndex = 6;
            this.BtnCard.Tag = "AxisClient";
            this.BtnCard.Text = "控制卡";
            this.BtnCard.UseVisualStyleBackColor = false;
            this.BtnCard.Click += new System.EventHandler(this.button7_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MenuForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1450, 783);
            this.Controls.Add(this.borderPanel1);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.borderPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button levelButton1;
        private BorderPanel borderPanel1;
        public HzControl.Communal.Controls.Level level13333;
        public System.Windows.Forms.Button BtnVision;
        public System.Windows.Forms.Button BtnCard;
        public System.Windows.Forms.Button BtnMachine;
        private System.Windows.Forms.Button button1;
    }
}