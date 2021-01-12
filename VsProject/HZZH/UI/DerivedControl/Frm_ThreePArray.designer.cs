namespace UI
{
    partial class Frm_ThreePArray
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
            this.buttonArr = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TwoY = new HzControl.Communal.Controls.MyTextBox();
            this.TwoX = new HzControl.Communal.Controls.MyTextBox();
            this.btn_readrightup = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ThreeY = new HzControl.Communal.Controls.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ThreeX = new HzControl.Communal.Controls.MyTextBox();
            this.btn_readrightdwon = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OneY = new HzControl.Communal.Controls.MyTextBox();
            this.OneX = new HzControl.Communal.Controls.MyTextBox();
            this.btn_readleftup = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.Colum = new HzControl.Communal.Controls.MyTextBox();
            this.Row = new HzControl.Communal.Controls.MyTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonArr
            // 
            this.buttonArr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonArr.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonArr.Location = new System.Drawing.Point(714, 301);
            this.buttonArr.Name = "buttonArr";
            this.buttonArr.Size = new System.Drawing.Size(176, 87);
            this.buttonArr.TabIndex = 20;
            this.buttonArr.Text = "阵列";
            this.buttonArr.UseVisualStyleBackColor = false;
            this.buttonArr.Click += new System.EventHandler(this.buttonArr_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TwoY);
            this.groupBox3.Controls.Add(this.TwoX);
            this.groupBox3.Controls.Add(this.btn_readrightup);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(310, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 257);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "基准点";
            // 
            // TwoY
            // 
            this.TwoY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TwoY.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.TwoY.Format = "F2";
            this.TwoY.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.TwoY.Location = new System.Drawing.Point(100, 123);
            this.TwoY.Name = "TwoY";
            this.TwoY.Size = new System.Drawing.Size(131, 38);
            this.TwoY.TabIndex = 31;
            this.TwoY.Text = "888.888";
            this.TwoY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TwoX
            // 
            this.TwoX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TwoX.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.TwoX.Format = "F2";
            this.TwoX.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.TwoX.Location = new System.Drawing.Point(100, 48);
            this.TwoX.Name = "TwoX";
            this.TwoX.Size = new System.Drawing.Size(131, 38);
            this.TwoX.TabIndex = 30;
            this.TwoX.Text = "888.888";
            this.TwoX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_readrightup
            // 
            this.btn_readrightup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_readrightup.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.btn_readrightup.Location = new System.Drawing.Point(85, 189);
            this.btn_readrightup.Name = "btn_readrightup";
            this.btn_readrightup.Size = new System.Drawing.Size(125, 50);
            this.btn_readrightup.TabIndex = 19;
            this.btn_readrightup.Text = "读取";
            this.btn_readrightup.UseVisualStyleBackColor = false;
            this.btn_readrightup.Click += new System.EventHandler(this.btn_readrightup_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(46, 52);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 28);
            this.label24.TabIndex = 3;
            this.label24.Text = "X：";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.label26.Location = new System.Drawing.Point(46, 128);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 28);
            this.label26.TabIndex = 5;
            this.label26.Text = "Y：";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.label27.Location = new System.Drawing.Point(3, 45);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 28);
            this.label27.TabIndex = 25;
            this.label27.Text = "列：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.ThreeY);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.ThreeX);
            this.groupBox4.Controls.Add(this.btn_readrightdwon);
            this.groupBox4.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(613, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(283, 257);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "另一个方向";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(53, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 28);
            this.label3.TabIndex = 32;
            this.label3.Text = "X：";
            // 
            // ThreeY
            // 
            this.ThreeY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ThreeY.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.ThreeY.Format = "F2";
            this.ThreeY.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.ThreeY.Location = new System.Drawing.Point(106, 123);
            this.ThreeY.Name = "ThreeY";
            this.ThreeY.Size = new System.Drawing.Size(131, 38);
            this.ThreeY.TabIndex = 33;
            this.ThreeY.Text = "888.888";
            this.ThreeY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(53, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 28);
            this.label4.TabIndex = 33;
            this.label4.Text = "Y：";
            // 
            // ThreeX
            // 
            this.ThreeX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ThreeX.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.ThreeX.Format = "F2";
            this.ThreeX.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.ThreeX.Location = new System.Drawing.Point(106, 48);
            this.ThreeX.Name = "ThreeX";
            this.ThreeX.Size = new System.Drawing.Size(131, 38);
            this.ThreeX.TabIndex = 32;
            this.ThreeX.Text = "888.888";
            this.ThreeX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_readrightdwon
            // 
            this.btn_readrightdwon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_readrightdwon.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.btn_readrightdwon.Location = new System.Drawing.Point(81, 189);
            this.btn_readrightdwon.Name = "btn_readrightdwon";
            this.btn_readrightdwon.Size = new System.Drawing.Size(125, 50);
            this.btn_readrightdwon.TabIndex = 19;
            this.btn_readrightdwon.Text = "读取";
            this.btn_readrightdwon.UseVisualStyleBackColor = false;
            this.btn_readrightdwon.Click += new System.EventHandler(this.btn_readrightdwon_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.label28.Location = new System.Drawing.Point(199, 45);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(54, 28);
            this.label28.TabIndex = 23;
            this.label28.Text = "行：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.OneY);
            this.groupBox5.Controls.Add(this.OneX);
            this.groupBox5.Controls.Add(this.btn_readleftup);
            this.groupBox5.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.groupBox5.Location = new System.Drawing.Point(7, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(283, 257);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "一个方向";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(36, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 28);
            this.label1.TabIndex = 30;
            this.label1.Text = "X：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(36, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 28);
            this.label2.TabIndex = 31;
            this.label2.Text = "Y：";
            // 
            // OneY
            // 
            this.OneY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.OneY.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.OneY.Format = "F2";
            this.OneY.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.OneY.Location = new System.Drawing.Point(98, 123);
            this.OneY.Name = "OneY";
            this.OneY.Size = new System.Drawing.Size(131, 38);
            this.OneY.TabIndex = 29;
            this.OneY.Text = "888.888";
            this.OneY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OneX
            // 
            this.OneX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.OneX.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.OneX.Format = "F2";
            this.OneX.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.OneX.Location = new System.Drawing.Point(98, 48);
            this.OneX.Name = "OneX";
            this.OneX.Size = new System.Drawing.Size(131, 38);
            this.OneX.TabIndex = 28;
            this.OneX.Text = "888.888";
            this.OneX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_readleftup
            // 
            this.btn_readleftup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_readleftup.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.btn_readleftup.Location = new System.Drawing.Point(80, 189);
            this.btn_readleftup.Name = "btn_readleftup";
            this.btn_readleftup.Size = new System.Drawing.Size(125, 50);
            this.btn_readleftup.TabIndex = 19;
            this.btn_readleftup.Text = "读取";
            this.btn_readleftup.UseVisualStyleBackColor = false;
            this.btn_readleftup.Click += new System.EventHandler(this.btn_readleftup_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 286);
            this.panel1.TabIndex = 28;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.Colum);
            this.groupBox7.Controls.Add(this.Row);
            this.groupBox7.Controls.Add(this.label27);
            this.groupBox7.Controls.Add(this.label28);
            this.groupBox7.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.groupBox7.Location = new System.Drawing.Point(12, 292);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(394, 99);
            this.groupBox7.TabIndex = 29;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "行列选择";
            // 
            // Colum
            // 
            this.Colum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Colum.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Colum.Format = "F2";
            this.Colum.Location = new System.Drawing.Point(252, 40);
            this.Colum.Name = "Colum";
            this.Colum.Size = new System.Drawing.Size(131, 38);
            this.Colum.TabIndex = 35;
            this.Colum.Text = "2";
            this.Colum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Row
            // 
            this.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Row.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Row.Format = "F2";
            this.Row.Location = new System.Drawing.Point(58, 40);
            this.Row.Name = "Row";
            this.Row.Size = new System.Drawing.Size(131, 38);
            this.Row.TabIndex = 34;
            this.Row.Text = "4";
            this.Row.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(428, 292);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 99);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "走点方向";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.radioButton2.Location = new System.Drawing.Point(152, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(72, 32);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "纵向";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.radioButton1.Location = new System.Drawing.Point(32, 40);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 32);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "横向";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // Frm_ThreePArray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(902, 403);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.buttonArr);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_ThreePArray";
            this.Text = "三点阵列";
            this.Load += new System.EventHandler(this.Frm_DPArr_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonArr;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_readrightup;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_readrightdwon;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_readleftup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private HzControl.Communal.Controls.MyTextBox OneY;
        private HzControl.Communal.Controls.MyTextBox OneX;
        private HzControl.Communal.Controls.MyTextBox TwoY;
        private HzControl.Communal.Controls.MyTextBox TwoX;
        private HzControl.Communal.Controls.MyTextBox ThreeY;
        private HzControl.Communal.Controls.MyTextBox ThreeX;
        private HzControl.Communal.Controls.MyTextBox Colum;
        private HzControl.Communal.Controls.MyTextBox Row;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}