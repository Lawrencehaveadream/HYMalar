using HzControl.Communal.Controls;

namespace HZZH.UI2.上料机
{
    partial class MainRunForm
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button9 = new System.Windows.Forms.Button();
            this.FsmSta = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.borderPanel2 = new HzControl.Communal.Controls.BorderPanel();
            this.borderPanel1 = new HzControl.Communal.Controls.BorderPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.userBingData1 = new HzControl.Communal.Controls.UserBingData(this.components);
            this.yieldButton1 = new HZZH.Communal.Tools.YieldButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.level1 = new HzControl.Communal.Controls.Level(this.components);
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.UPH = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.borderPanel3 = new HzControl.Communal.Controls.BorderPanel();
            this.ProductName = new System.Windows.Forms.Label();
            this.borderPanel4 = new HzControl.Communal.Controls.BorderPanel();
            this.Yield = new System.Windows.Forms.Label();
            this.RNuuzleBan = new System.Windows.Forms.CheckBox();
            this.LNuuzleBan = new System.Windows.Forms.CheckBox();
            this.borderPanel5 = new HzControl.Communal.Controls.BorderPanel();
            this.borderPanel1.SuspendLayout();
            this.borderPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button9.FlatAppearance.BorderSize = 2;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level1.SetLevel(this.button9, "2");
            this.button9.Location = new System.Drawing.Point(1279, 339);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(159, 68);
            this.button9.TabIndex = 23;
            this.button9.Tag = "WarnList";
            this.button9.Text = "报警记录";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // FsmSta
            // 
            this.FsmSta.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FsmSta.ForeColor = System.Drawing.Color.Yellow;
            this.FsmSta.Location = new System.Drawing.Point(996, 151);
            this.FsmSta.Name = "FsmSta";
            this.FsmSta.Size = new System.Drawing.Size(262, 72);
            this.FsmSta.TabIndex = 14;
            this.FsmSta.Text = "停止状态";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Location = new System.Drawing.Point(635, 332);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 448);
            this.panel2.TabIndex = 3;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.button5.FlatAppearance.BorderSize = 3;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.level1.SetLevel(this.button5, "0");
            this.button5.Location = new System.Drawing.Point(1278, 667);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(159, 94);
            this.button5.TabIndex = 7;
            this.button5.Tag = "ProductForm";
            this.button5.Text = "系统设置";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Yellow;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Olive;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level1.SetLevel(this.button3, "1");
            this.button3.Location = new System.Drawing.Point(1278, 231);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 68);
            this.button3.TabIndex = 5;
            this.button3.Text = "复位";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level1.SetLevel(this.button2, "1");
            this.button2.Location = new System.Drawing.Point(1278, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 68);
            this.button2.TabIndex = 4;
            this.button2.Text = "停止";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level1.SetLevel(this.button1, "1");
            this.button1.Location = new System.Drawing.Point(1278, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 68);
            this.button1.TabIndex = 3;
            this.button1.Text = "启动";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(2, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 448);
            this.panel1.TabIndex = 2;
            // 
            // borderPanel2
            // 
            this.borderPanel2.BackColor = System.Drawing.Color.White;
            this.borderPanel2.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel2.BorderLineWidth = 2;
            this.borderPanel2.Location = new System.Drawing.Point(1261, 1);
            this.borderPanel2.Name = "borderPanel2";
            this.borderPanel2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel2.Size = new System.Drawing.Size(5, 781);
            this.borderPanel2.TabIndex = 2;
            // 
            // borderPanel1
            // 
            this.borderPanel1.BackColor = System.Drawing.Color.SlateGray;
            this.borderPanel1.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel1.BorderLineWidth = 0;
            this.borderPanel1.Controls.Add(this.label10);
            this.borderPanel1.Controls.Add(this.label9);
            this.borderPanel1.Location = new System.Drawing.Point(0, 286);
            this.borderPanel1.Name = "borderPanel1";
            this.borderPanel1.Size = new System.Drawing.Size(1263, 47);
            this.borderPanel1.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(911, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 29);
            this.label10.TabIndex = 23;
            this.label10.Text = "下相机";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(157, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 29);
            this.label9.TabIndex = 22;
            this.label9.Text = "上相机";
            // 
            // yieldButton1
            // 
            this.yieldButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.yieldButton1.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.yieldButton1.FlatAppearance.BorderSize = 2;
            this.yieldButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yieldButton1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level1.SetLevel(this.yieldButton1, "1");
            this.yieldButton1.Location = new System.Drawing.Point(1279, 447);
            this.yieldButton1.Name = "yieldButton1";
            this.yieldButton1.Size = new System.Drawing.Size(159, 68);
            this.yieldButton1.TabIndex = 26;
            this.yieldButton1.Text = "生产记录";
            this.yieldButton1.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(37, 162);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(165, 46);
            this.checkBox1.TabIndex = 27;
            this.checkBox1.Text = "老化模式";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level1.SetLevel(this.button7, "2");
            this.button7.Location = new System.Drawing.Point(1079, 15);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(159, 68);
            this.button7.TabIndex = 16;
            this.button7.Text = "产量清零";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.level1.SetLevel(this.button6, "2");
            this.button6.Location = new System.Drawing.Point(434, 14);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(159, 69);
            this.button6.TabIndex = 15;
            this.button6.Tag = "ProductSwitchForm";
            this.button6.Text = "产品切换";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.ForestGreen;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level1.SetLevel(this.button4, "1");
            this.button4.Location = new System.Drawing.Point(1279, 556);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 68);
            this.button4.TabIndex = 34;
            this.button4.Tag = "WarnList";
            this.button4.Text = "保存";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // UPH
            // 
            this.UPH.AutoSize = true;
            this.UPH.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UPH.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.UPH.Location = new System.Drawing.Point(684, 26);
            this.UPH.Name = "UPH";
            this.UPH.Size = new System.Drawing.Size(115, 40);
            this.UPH.TabIndex = 12;
            this.UPH.Text = "UPH：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(316, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 42);
            this.label4.TabIndex = 10;
            this.label4.Text = "吸嘴贴合周期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(30, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 40);
            this.label2.TabIndex = 9;
            this.label2.Text = "调用的工程：";
            // 
            // borderPanel3
            // 
            this.borderPanel3.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel3.BorderLineWidth = 0;
            this.borderPanel3.Controls.Add(this.ProductName);
            this.borderPanel3.Controls.Add(this.borderPanel4);
            this.borderPanel3.Controls.Add(this.label2);
            this.borderPanel3.Controls.Add(this.button6);
            this.borderPanel3.Controls.Add(this.button7);
            this.borderPanel3.Controls.Add(this.UPH);
            this.borderPanel3.Location = new System.Drawing.Point(0, 1);
            this.borderPanel3.Name = "borderPanel3";
            this.borderPanel3.Size = new System.Drawing.Size(1263, 101);
            this.borderPanel3.TabIndex = 25;
            // 
            // ProductName
            // 
            this.ProductName.AutoSize = true;
            this.ProductName.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProductName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ProductName.Location = new System.Drawing.Point(207, 21);
            this.ProductName.Name = "ProductName";
            this.ProductName.Size = new System.Drawing.Size(74, 40);
            this.ProductName.TabIndex = 33;
            this.ProductName.Text = "000";
            // 
            // borderPanel4
            // 
            this.borderPanel4.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel4.BorderLineWidth = 2;
            this.borderPanel4.Location = new System.Drawing.Point(0, 93);
            this.borderPanel4.Name = "borderPanel4";
            this.borderPanel4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel4.Size = new System.Drawing.Size(1266, 2);
            this.borderPanel4.TabIndex = 32;
            // 
            // Yield
            // 
            this.Yield.AutoSize = true;
            this.Yield.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold);
            this.Yield.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Yield.Location = new System.Drawing.Point(316, 135);
            this.Yield.Name = "Yield";
            this.Yield.Size = new System.Drawing.Size(114, 42);
            this.Yield.TabIndex = 29;
            this.Yield.Text = "产量：";
            // 
            // RNuuzleBan
            // 
            this.RNuuzleBan.AutoSize = true;
            this.RNuuzleBan.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RNuuzleBan.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RNuuzleBan.ForeColor = System.Drawing.Color.White;
            this.RNuuzleBan.Location = new System.Drawing.Point(647, 202);
            this.RNuuzleBan.Name = "RNuuzleBan";
            this.RNuuzleBan.Size = new System.Drawing.Size(197, 46);
            this.RNuuzleBan.TabIndex = 30;
            this.RNuuzleBan.Text = "右吸嘴禁用";
            this.RNuuzleBan.UseVisualStyleBackColor = true;
            this.RNuuzleBan.CheckedChanged += new System.EventHandler(this.RNuuzleBan_CheckedChanged);
            // 
            // LNuuzleBan
            // 
            this.LNuuzleBan.AutoSize = true;
            this.LNuuzleBan.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LNuuzleBan.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LNuuzleBan.ForeColor = System.Drawing.Color.White;
            this.LNuuzleBan.Location = new System.Drawing.Point(647, 135);
            this.LNuuzleBan.Name = "LNuuzleBan";
            this.LNuuzleBan.Size = new System.Drawing.Size(197, 46);
            this.LNuuzleBan.TabIndex = 31;
            this.LNuuzleBan.Text = "左吸嘴禁用";
            this.LNuuzleBan.UseVisualStyleBackColor = true;
            this.LNuuzleBan.CheckedChanged += new System.EventHandler(this.LNuuzleBan_CheckedChanged);
            // 
            // borderPanel5
            // 
            this.borderPanel5.BorderColor = System.Drawing.Color.DarkGray;
            this.borderPanel5.BorderLineWidth = 2;
            this.borderPanel5.Location = new System.Drawing.Point(1265, 644);
            this.borderPanel5.Name = "borderPanel5";
            this.borderPanel5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel5.Size = new System.Drawing.Size(185, 1);
            this.borderPanel5.TabIndex = 33;
            // 
            // MainRunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1450, 783);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.borderPanel5);
            this.Controls.Add(this.LNuuzleBan);
            this.Controls.Add(this.RNuuzleBan);
            this.Controls.Add(this.Yield);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yieldButton1);
            this.Controls.Add(this.borderPanel3);
            this.Controls.Add(this.borderPanel2);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.FsmSta);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.borderPanel1);
            this.Name = "MainRunForm";
            this.Text = "逻辑主窗体";
            this.Load += new System.EventHandler(this.MainRunForm_Load);
            this.borderPanel1.ResumeLayout(false);
            this.borderPanel1.PerformLayout();
            this.borderPanel3.ResumeLayout(false);
            this.borderPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private HzControl.Communal.Controls.UserBingData userBingData1;
        private BorderPanel borderPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label FsmSta;
        private BorderPanel borderPanel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Timer timer1;
        private Communal.Tools.YieldButton yieldButton1;
        private System.Windows.Forms.CheckBox checkBox1;
        private HzControl.Communal.Controls.Level level1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label UPH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private BorderPanel borderPanel3;
        private System.Windows.Forms.Label Yield;
        private System.Windows.Forms.CheckBox RNuuzleBan;
        private System.Windows.Forms.CheckBox LNuuzleBan;
        private BorderPanel borderPanel4;
        private System.Windows.Forms.Label ProductName;
        private BorderPanel borderPanel5;
        private System.Windows.Forms.Button button4;
    }
}