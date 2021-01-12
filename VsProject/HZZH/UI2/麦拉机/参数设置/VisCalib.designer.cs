namespace HZZH.UI2.麦拉机.参数设置
{
    partial class VisCalib
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisCalib));
            this.mainCamera1 = new HzVision.Device.MainCamera();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.myTextBox1 = new HzControl.Communal.Controls.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Bt_Z_jogNeg = new System.Windows.Forms.Button();
            this.Bt_Z_jogPos = new System.Windows.Forms.Button();
            this.Z_currPos = new System.Windows.Forms.Label();
            this.Bt_X_jogPos = new System.Windows.Forms.Button();
            this.Bt_X_jogNeg = new System.Windows.Forms.Button();
            this.Bt_Y_jogNeg = new System.Windows.Forms.Button();
            this.Bt_Y_jogPos = new System.Windows.Forms.Button();
            this.X_currPos = new System.Windows.Forms.Label();
            this.Y_currPos = new System.Windows.Forms.Label();
            this.borderPanel1 = new HzControl.Communal.Controls.BorderPanel();
            this.myTextBox2 = new HzControl.Communal.Controls.MyTextBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.borderPanel2 = new HzControl.Communal.Controls.BorderPanel();
            this.myTextBox3 = new HzControl.Communal.Controls.MyTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.borderPanel1.SuspendLayout();
            this.borderPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnVision
            // 
            this.BtnVision.FlatAppearance.BorderSize = 3;
            // 
            // BtnCard
            // 
            this.BtnCard.FlatAppearance.BorderSize = 3;
            // 
            // BtnMachine
            // 
            this.BtnMachine.FlatAppearance.BorderSize = 3;
            // 
            // mainCamera1
            // 
            this.mainCamera1.BackColor = System.Drawing.Color.Black;
            this.mainCamera1.BorderColor = System.Drawing.Color.Black;
            this.mainCamera1.DisplayCross = true;
            this.mainCamera1.ID = 0;
            this.mainCamera1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.mainCamera1.Location = new System.Drawing.Point(12, 12);
            this.mainCamera1.Name = "mainCamera1";
            this.mainCamera1.Size = new System.Drawing.Size(1059, 667);
            this.mainCamera1.TabIndex = 3;
            this.mainCamera1.WindowSize = new System.Drawing.Size(1059, 667);
            this.mainCamera1.Draw += new System.EventHandler<HzVision.Device.DrawEventArgs>(this.mainCamera1_Draw);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("宋体", 15F);
            this.level13333.SetLevel(this.button8, "");
            this.button8.Location = new System.Drawing.Point(1081, 12);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(171, 63);
            this.button8.TabIndex = 4;
            this.button8.Text = "左上角";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("宋体", 15F);
            this.level13333.SetLevel(this.button9, "");
            this.button9.Location = new System.Drawing.Point(1269, 12);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(171, 63);
            this.button9.TabIndex = 5;
            this.button9.Text = "右下角";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("宋体", 15F);
            this.level13333.SetLevel(this.button10, "");
            this.button10.Location = new System.Drawing.Point(1081, 90);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(359, 63);
            this.button10.TabIndex = 6;
            this.button10.Text = "设定高度";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("宋体", 15F);
            this.level13333.SetLevel(this.button11, "");
            this.button11.Location = new System.Drawing.Point(1081, 168);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(359, 63);
            this.button11.TabIndex = 7;
            this.button11.Text = "设定模板";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("宋体", 15F);
            this.level13333.SetLevel(this.button12, "");
            this.button12.Location = new System.Drawing.Point(1081, 308);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(359, 63);
            this.button12.TabIndex = 8;
            this.button12.Text = "执行标定";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // myTextBox1
            // 
            this.myTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myTextBox1.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.myTextBox1.Format = "F2";
            this.myTextBox1.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.myTextBox1.Location = new System.Drawing.Point(1232, 251);
            this.myTextBox1.MIN = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.Size = new System.Drawing.Size(135, 44);
            this.myTextBox1.TabIndex = 9;
            this.myTextBox1.Text = "1";
            this.myTextBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.myTextBox1.TextChanged += new System.EventHandler(this.myTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 18F);
            this.label1.Location = new System.Drawing.Point(1096, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "移动间距：";
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("宋体", 15F);
            this.level13333.SetLevel(this.button13, "");
            this.button13.Location = new System.Drawing.Point(1081, 388);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(359, 63);
            this.button13.TabIndex = 11;
            this.button13.Text = "测试标定";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 12F);
            this.label2.Location = new System.Drawing.Point(1131, 465);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 32);
            this.label2.TabIndex = 12;
            this.label2.Text = "缩放sx：              缩放sy：\r\n角度r：                误差:\r\n";
            // 
            // Bt_Z_jogNeg
            // 
            this.Bt_Z_jogNeg.FlatAppearance.BorderSize = 0;
            this.Bt_Z_jogNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Z_jogNeg.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_Z_jogNeg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_Z_jogNeg.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Z_jogNeg.Image")));
            this.level13333.SetLevel(this.Bt_Z_jogNeg, "");
            this.Bt_Z_jogNeg.Location = new System.Drawing.Point(205, 22);
            this.Bt_Z_jogNeg.Name = "Bt_Z_jogNeg";
            this.Bt_Z_jogNeg.Size = new System.Drawing.Size(50, 38);
            this.Bt_Z_jogNeg.TabIndex = 308;
            this.Bt_Z_jogNeg.Tag = "2";
            this.Bt_Z_jogNeg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Bt_Z_jogNeg.UseVisualStyleBackColor = true;
            // 
            // Bt_Z_jogPos
            // 
            this.Bt_Z_jogPos.FlatAppearance.BorderSize = 0;
            this.Bt_Z_jogPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Z_jogPos.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_Z_jogPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_Z_jogPos.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Z_jogPos.Image")));
            this.level13333.SetLevel(this.Bt_Z_jogPos, "");
            this.Bt_Z_jogPos.Location = new System.Drawing.Point(205, 104);
            this.Bt_Z_jogPos.Name = "Bt_Z_jogPos";
            this.Bt_Z_jogPos.Size = new System.Drawing.Size(50, 38);
            this.Bt_Z_jogPos.TabIndex = 309;
            this.Bt_Z_jogPos.Tag = "2";
            this.Bt_Z_jogPos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Bt_Z_jogPos.UseVisualStyleBackColor = true;
            // 
            // Z_currPos
            // 
            this.Z_currPos.AutoSize = true;
            this.Z_currPos.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Z_currPos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Z_currPos.Location = new System.Drawing.Point(190, 75);
            this.Z_currPos.Name = "Z_currPos";
            this.Z_currPos.Size = new System.Drawing.Size(80, 16);
            this.Z_currPos.TabIndex = 310;
            this.Z_currPos.Text = "Z:000.000";
            // 
            // Bt_X_jogPos
            // 
            this.Bt_X_jogPos.BackColor = System.Drawing.Color.Transparent;
            this.Bt_X_jogPos.FlatAppearance.BorderSize = 0;
            this.Bt_X_jogPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_X_jogPos.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_X_jogPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_X_jogPos.Image = ((System.Drawing.Image)(resources.GetObject("Bt_X_jogPos.Image")));
            this.level13333.SetLevel(this.Bt_X_jogPos, "");
            this.Bt_X_jogPos.Location = new System.Drawing.Point(134, 63);
            this.Bt_X_jogPos.Name = "Bt_X_jogPos";
            this.Bt_X_jogPos.Size = new System.Drawing.Size(50, 38);
            this.Bt_X_jogPos.TabIndex = 303;
            this.Bt_X_jogPos.Tag = "0";
            this.Bt_X_jogPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bt_X_jogPos.UseVisualStyleBackColor = false;
            // 
            // Bt_X_jogNeg
            // 
            this.Bt_X_jogNeg.BackColor = System.Drawing.Color.Transparent;
            this.Bt_X_jogNeg.FlatAppearance.BorderSize = 0;
            this.Bt_X_jogNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_X_jogNeg.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_X_jogNeg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_X_jogNeg.Image = ((System.Drawing.Image)(resources.GetObject("Bt_X_jogNeg.Image")));
            this.level13333.SetLevel(this.Bt_X_jogNeg, "");
            this.Bt_X_jogNeg.Location = new System.Drawing.Point(28, 63);
            this.Bt_X_jogNeg.Name = "Bt_X_jogNeg";
            this.Bt_X_jogNeg.Size = new System.Drawing.Size(50, 38);
            this.Bt_X_jogNeg.TabIndex = 305;
            this.Bt_X_jogNeg.Tag = "0";
            this.Bt_X_jogNeg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bt_X_jogNeg.UseVisualStyleBackColor = false;
            // 
            // Bt_Y_jogNeg
            // 
            this.Bt_Y_jogNeg.BackColor = System.Drawing.Color.Transparent;
            this.Bt_Y_jogNeg.FlatAppearance.BorderSize = 0;
            this.Bt_Y_jogNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Y_jogNeg.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_Y_jogNeg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_Y_jogNeg.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Y_jogNeg.Image")));
            this.level13333.SetLevel(this.Bt_Y_jogNeg, "");
            this.Bt_Y_jogNeg.Location = new System.Drawing.Point(82, 104);
            this.Bt_Y_jogNeg.Name = "Bt_Y_jogNeg";
            this.Bt_Y_jogNeg.Size = new System.Drawing.Size(50, 38);
            this.Bt_Y_jogNeg.TabIndex = 304;
            this.Bt_Y_jogNeg.Tag = "1";
            this.Bt_Y_jogNeg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Bt_Y_jogNeg.UseVisualStyleBackColor = false;
            // 
            // Bt_Y_jogPos
            // 
            this.Bt_Y_jogPos.BackColor = System.Drawing.Color.Transparent;
            this.Bt_Y_jogPos.FlatAppearance.BorderSize = 0;
            this.Bt_Y_jogPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Y_jogPos.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_Y_jogPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_Y_jogPos.Image = ((System.Drawing.Image)(resources.GetObject("Bt_Y_jogPos.Image")));
            this.level13333.SetLevel(this.Bt_Y_jogPos, "");
            this.Bt_Y_jogPos.Location = new System.Drawing.Point(82, 22);
            this.Bt_Y_jogPos.Name = "Bt_Y_jogPos";
            this.Bt_Y_jogPos.Size = new System.Drawing.Size(50, 38);
            this.Bt_Y_jogPos.TabIndex = 302;
            this.Bt_Y_jogPos.Tag = "1";
            this.Bt_Y_jogPos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Bt_Y_jogPos.UseVisualStyleBackColor = false;
            // 
            // X_currPos
            // 
            this.X_currPos.AutoSize = true;
            this.X_currPos.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.X_currPos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.X_currPos.Location = new System.Drawing.Point(13, 111);
            this.X_currPos.Name = "X_currPos";
            this.X_currPos.Size = new System.Drawing.Size(72, 16);
            this.X_currPos.TabIndex = 306;
            this.X_currPos.Text = "X000.000";
            // 
            // Y_currPos
            // 
            this.Y_currPos.AutoSize = true;
            this.Y_currPos.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Y_currPos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Y_currPos.Location = new System.Drawing.Point(13, 17);
            this.Y_currPos.Name = "Y_currPos";
            this.Y_currPos.Size = new System.Drawing.Size(72, 16);
            this.Y_currPos.TabIndex = 307;
            this.Y_currPos.Text = "Y000.000";
            // 
            // borderPanel1
            // 
            this.borderPanel1.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel1.BorderLineWidth = 2;
            this.borderPanel1.Controls.Add(this.myTextBox2);
            this.borderPanel1.Controls.Add(this.checkBox6);
            this.borderPanel1.Controls.Add(this.Bt_Z_jogNeg);
            this.borderPanel1.Controls.Add(this.Bt_Z_jogPos);
            this.borderPanel1.Controls.Add(this.Z_currPos);
            this.borderPanel1.Controls.Add(this.Bt_X_jogPos);
            this.borderPanel1.Controls.Add(this.Bt_X_jogNeg);
            this.borderPanel1.Controls.Add(this.Bt_Y_jogNeg);
            this.borderPanel1.Controls.Add(this.Bt_Y_jogPos);
            this.borderPanel1.Controls.Add(this.X_currPos);
            this.borderPanel1.Controls.Add(this.Y_currPos);
            this.borderPanel1.Location = new System.Drawing.Point(1539, 737);
            this.borderPanel1.Name = "borderPanel1";
            this.borderPanel1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel1.Size = new System.Drawing.Size(372, 155);
            this.borderPanel1.TabIndex = 311;
            // 
            // myTextBox2
            // 
            this.myTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myTextBox2.Font = new System.Drawing.Font("黑体", 16F);
            this.myTextBox2.Format = "F2";
            this.myTextBox2.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.myTextBox2.Location = new System.Drawing.Point(277, 104);
            this.myTextBox2.MIN = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.myTextBox2.Name = "myTextBox2";
            this.myTextBox2.Size = new System.Drawing.Size(88, 35);
            this.myTextBox2.TabIndex = 312;
            this.myTextBox2.Text = "1.00";
            this.myTextBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox6.Location = new System.Drawing.Point(307, 79);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(48, 16);
            this.checkBox6.TabIndex = 313;
            this.checkBox6.Text = "点动";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // borderPanel2
            // 
            this.borderPanel2.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel2.BorderLineWidth = 2;
            this.borderPanel2.Controls.Add(this.myTextBox3);
            this.borderPanel2.Controls.Add(this.checkBox1);
            this.borderPanel2.Controls.Add(this.button2);
            this.borderPanel2.Controls.Add(this.button5);
            this.borderPanel2.Controls.Add(this.label3);
            this.borderPanel2.Controls.Add(this.button6);
            this.borderPanel2.Controls.Add(this.button7);
            this.borderPanel2.Controls.Add(this.button14);
            this.borderPanel2.Controls.Add(this.button15);
            this.borderPanel2.Controls.Add(this.label4);
            this.borderPanel2.Controls.Add(this.label5);
            this.borderPanel2.Location = new System.Drawing.Point(1075, 524);
            this.borderPanel2.Name = "borderPanel2";
            this.borderPanel2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel2.Size = new System.Drawing.Size(372, 155);
            this.borderPanel2.TabIndex = 312;
            // 
            // myTextBox3
            // 
            this.myTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myTextBox3.Font = new System.Drawing.Font("黑体", 16F);
            this.myTextBox3.Format = "F2";
            this.myTextBox3.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.myTextBox3.Location = new System.Drawing.Point(277, 104);
            this.myTextBox3.MIN = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.myTextBox3.Name = "myTextBox3";
            this.myTextBox3.Size = new System.Drawing.Size(88, 35);
            this.myTextBox3.TabIndex = 312;
            this.myTextBox3.Text = "1.00";
            this.myTextBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox1.Location = new System.Drawing.Point(307, 79);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 313;
            this.checkBox1.Text = "点动";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.level13333.SetLevel(this.button2, "");
            this.button2.Location = new System.Drawing.Point(205, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 38);
            this.button2.TabIndex = 308;
            this.button2.Tag = "2";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.level13333.SetLevel(this.button5, "");
            this.button5.Location = new System.Drawing.Point(205, 104);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 38);
            this.button5.TabIndex = 309;
            this.button5.Tag = "2";
            this.button5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(190, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 310;
            this.label3.Text = "Z:000.000";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.level13333.SetLevel(this.button6, "");
            this.button6.Location = new System.Drawing.Point(134, 63);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 38);
            this.button6.TabIndex = 303;
            this.button6.Tag = "0";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.level13333.SetLevel(this.button7, "");
            this.button7.Location = new System.Drawing.Point(28, 63);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 38);
            this.button7.TabIndex = 305;
            this.button7.Tag = "0";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Transparent;
            this.button14.FlatAppearance.BorderSize = 0;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button14.Image = ((System.Drawing.Image)(resources.GetObject("button14.Image")));
            this.level13333.SetLevel(this.button14, "");
            this.button14.Location = new System.Drawing.Point(82, 104);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(50, 38);
            this.button14.TabIndex = 304;
            this.button14.Tag = "1";
            this.button14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button14.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Transparent;
            this.button15.FlatAppearance.BorderSize = 0;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button15.Image = ((System.Drawing.Image)(resources.GetObject("button15.Image")));
            this.level13333.SetLevel(this.button15, "");
            this.button15.Location = new System.Drawing.Point(82, 22);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(50, 38);
            this.button15.TabIndex = 302;
            this.button15.Tag = "1";
            this.button15.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button15.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(13, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 306;
            this.label4.Text = "X000.000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(13, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 307;
            this.label5.Text = "Y000.000";
            // 
            // VisCalib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 783);
            this.Controls.Add(this.borderPanel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myTextBox1);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.mainCamera1);
            this.Name = "VisCalib";
            this.Text = "VisCalib";
            this.Load += new System.EventHandler(this.VisCalib_Load);
            this.Controls.SetChildIndex(this.mainCamera1, 0);
            this.Controls.SetChildIndex(this.button8, 0);
            this.Controls.SetChildIndex(this.button9, 0);
            this.Controls.SetChildIndex(this.button10, 0);
            this.Controls.SetChildIndex(this.button11, 0);
            this.Controls.SetChildIndex(this.button12, 0);
            this.Controls.SetChildIndex(this.myTextBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.button13, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.borderPanel2, 0);
            this.borderPanel1.ResumeLayout(false);
            this.borderPanel1.PerformLayout();
            this.borderPanel2.ResumeLayout(false);
            this.borderPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HzVision.Device.MainCamera mainCamera1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private HzControl.Communal.Controls.MyTextBox myTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Bt_Z_jogNeg;
        private System.Windows.Forms.Button Bt_Z_jogPos;
        private System.Windows.Forms.Label Z_currPos;
        private System.Windows.Forms.Button Bt_X_jogPos;
        private System.Windows.Forms.Button Bt_X_jogNeg;
        private System.Windows.Forms.Button Bt_Y_jogNeg;
        private System.Windows.Forms.Button Bt_Y_jogPos;
        private System.Windows.Forms.Label X_currPos;
        private System.Windows.Forms.Label Y_currPos;
        private HzControl.Communal.Controls.BorderPanel borderPanel1;
        private System.Windows.Forms.CheckBox checkBox6;
        private HzControl.Communal.Controls.MyTextBox myTextBox2;
        private HzControl.Communal.Controls.BorderPanel borderPanel2;
        private HzControl.Communal.Controls.MyTextBox myTextBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}