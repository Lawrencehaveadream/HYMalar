using HzControl.Communal.Controls;

namespace HZZH.UI2.麦拉机.参数设置
{
    partial class Feeder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Feeder));
            this.Obtain = new System.Windows.Forms.Button();
            this.LocateFeederPos = new System.Windows.Forms.Button();
            this.FeederPosY = new HzControl.Communal.Controls.MyTextBox();
            this.FeederPosX = new HzControl.Communal.Controls.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.YPos = new HzControl.Communal.Controls.MyTextBox();
            this.XPos = new HzControl.Communal.Controls.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RtakeZPos = new HzControl.Communal.Controls.MyTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.Step = new HzControl.Communal.Controls.MyTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.Speed = new HzControl.Communal.Controls.MyTextBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.RTakeDelay = new HzControl.Communal.Controls.MyTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LTakeDelay = new HzControl.Communal.Controls.MyTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LtakeZPos = new HzControl.Communal.Controls.MyTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.borderPanel2 = new HzControl.Communal.Controls.BorderPanel();
            this.borderPanel3 = new HzControl.Communal.Controls.BorderPanel();
            this.borderPanel4 = new HzControl.Communal.Controls.BorderPanel();
            this.borderPanel5 = new HzControl.Communal.Controls.BorderPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.FeederData = new HzControl.Communal.Controls.UserBingData(this.components);
            this.Z1Pos = new HzControl.Communal.Controls.MyTextBox();
            this.Z2Pos = new HzControl.Communal.Controls.MyTextBox();
            this.FeederRows = new HzControl.Communal.Controls.MyTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Lcheck = new System.Windows.Forms.CheckBox();
            this.FeederMode1 = new System.Windows.Forms.CheckBox();
            this.FeederMode2 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
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
            // Obtain
            // 
            this.Obtain.BackColor = System.Drawing.Color.Transparent;
            this.Obtain.FlatAppearance.BorderSize = 2;
            this.Obtain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Obtain.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Obtain.ForeColor = System.Drawing.Color.Black;
            this.level13333.SetLevel(this.Obtain, "");
            this.Obtain.Location = new System.Drawing.Point(1064, 210);
            this.Obtain.Name = "Obtain";
            this.Obtain.Size = new System.Drawing.Size(118, 65);
            this.Obtain.TabIndex = 96;
            this.Obtain.Text = "获取";
            this.Obtain.UseVisualStyleBackColor = false;
            this.Obtain.Click += new System.EventHandler(this.Obtain_Click);
            // 
            // LocateFeederPos
            // 
            this.LocateFeederPos.BackColor = System.Drawing.Color.Transparent;
            this.LocateFeederPos.FlatAppearance.BorderSize = 2;
            this.LocateFeederPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LocateFeederPos.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LocateFeederPos.ForeColor = System.Drawing.Color.Black;
            this.level13333.SetLevel(this.LocateFeederPos, "");
            this.LocateFeederPos.Location = new System.Drawing.Point(1260, 210);
            this.LocateFeederPos.Name = "LocateFeederPos";
            this.LocateFeederPos.Size = new System.Drawing.Size(114, 65);
            this.LocateFeederPos.TabIndex = 95;
            this.LocateFeederPos.Text = "执行";
            this.LocateFeederPos.UseVisualStyleBackColor = false;
            this.LocateFeederPos.Click += new System.EventHandler(this.LocateFeederPos_Click);
            // 
            // FeederPosY
            // 
            this.FeederPosY.BackColor = System.Drawing.Color.Gray;
            this.FeederData.SetBindingName(this.FeederPosY, "FeederPara.TakePos.Y");
            this.FeederPosY.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.FeederPosY.Format = "F2";
            this.FeederPosY.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.FeederPosY.Location = new System.Drawing.Point(1236, 135);
            this.FeederPosY.Name = "FeederPosY";
            this.FeederPosY.Size = new System.Drawing.Size(138, 34);
            this.FeederPosY.TabIndex = 89;
            this.FeederPosY.Text = "66.666";
            this.FeederPosY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FeederPosX
            // 
            this.FeederPosX.BackColor = System.Drawing.Color.Gray;
            this.FeederData.SetBindingName(this.FeederPosX, "FeederPara.TakePos.X");
            this.FeederPosX.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.FeederPosX.Format = "F2";
            this.FeederPosX.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.FeederPosX.Location = new System.Drawing.Point(1062, 135);
            this.FeederPosX.Name = "FeederPosX";
            this.FeederPosX.Size = new System.Drawing.Size(138, 34);
            this.FeederPosX.TabIndex = 87;
            this.FeederPosX.Text = "66.666";
            this.FeederPosX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.label2.Location = new System.Drawing.Point(1122, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 33);
            this.label2.TabIndex = 92;
            this.label2.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(900, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 40);
            this.label1.TabIndex = 88;
            this.label1.Text = "飞达取料位置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.label3.Location = new System.Drawing.Point(1289, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 33);
            this.label3.TabIndex = 93;
            this.label3.Text = "Y";
            // 
            // YPos
            // 
            this.YPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FeederData.SetBindingName(this.YPos, "");
            this.YPos.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.YPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.YPos.Format = "F2";
            this.YPos.KeyBoard = false;
            this.YPos.Location = new System.Drawing.Point(1234, 65);
            this.YPos.Name = "YPos";
            this.YPos.Size = new System.Drawing.Size(138, 34);
            this.YPos.TabIndex = 91;
            this.YPos.Text = "66.666";
            this.YPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // XPos
            // 
            this.XPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FeederData.SetBindingName(this.XPos, "");
            this.XPos.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.XPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.XPos.Format = "F2";
            this.XPos.KeyBoard = false;
            this.XPos.Location = new System.Drawing.Point(1063, 65);
            this.XPos.Name = "XPos";
            this.XPos.Size = new System.Drawing.Size(138, 34);
            this.XPos.TabIndex = 90;
            this.XPos.Text = "66.666";
            this.XPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(944, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 40);
            this.label4.TabIndex = 94;
            this.label4.Text = "当前位置";
            // 
            // RtakeZPos
            // 
            this.RtakeZPos.BackColor = System.Drawing.Color.Gray;
            this.FeederData.SetBindingName(this.RtakeZPos, "TakeLabelPara.RightTakePos_Z");
            this.RtakeZPos.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.RtakeZPos.Format = "F2";
            this.RtakeZPos.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.RtakeZPos.Location = new System.Drawing.Point(1304, 349);
            this.RtakeZPos.Name = "RtakeZPos";
            this.RtakeZPos.Size = new System.Drawing.Size(138, 34);
            this.RtakeZPos.TabIndex = 100;
            this.RtakeZPos.Text = "66.666";
            this.RtakeZPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1120, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 40);
            this.label6.TabIndex = 99;
            this.label6.Text = "右吸嘴取料高度";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label21.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(575, 550);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 40);
            this.label21.TabIndex = 109;
            this.label21.Text = "步长";
            // 
            // Step
            // 
            this.Step.BackColor = System.Drawing.Color.Gray;
            this.FeederData.SetBindingName(this.Step, "");
            this.Step.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Step.Format = "F2";
            this.Step.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.Step.Location = new System.Drawing.Point(560, 585);
            this.Step.Name = "Step";
            this.Step.Size = new System.Drawing.Size(88, 34);
            this.Step.TabIndex = 108;
            this.Step.Text = "1";
            this.Step.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(377, 551);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 40);
            this.label20.TabIndex = 107;
            this.label20.Text = "速度";
            // 
            // Speed
            // 
            this.Speed.BackColor = System.Drawing.Color.Gray;
            this.FeederData.SetBindingName(this.Speed, "");
            this.Speed.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Speed.Format = "F2";
            this.Speed.Location = new System.Drawing.Point(361, 585);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(88, 34);
            this.Speed.TabIndex = 106;
            this.Speed.Text = "100";
            this.Speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Transparent;
            this.button16.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button16.BackgroundImage")));
            this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button16.FlatAppearance.BorderSize = 0;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button16, "");
            this.button16.Location = new System.Drawing.Point(462, 528);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(80, 105);
            this.button16.TabIndex = 105;
            this.button16.Tag = "-2";
            this.button16.Text = "Y";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button16.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Transparent;
            this.button15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button15.BackgroundImage")));
            this.button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button15.FlatAppearance.BorderSize = 0;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button15, "");
            this.button15.Location = new System.Drawing.Point(461, 348);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(80, 105);
            this.button15.TabIndex = 104;
            this.button15.Tag = "2";
            this.button15.Text = "Y";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button15.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Transparent;
            this.button17.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button17.BackgroundImage")));
            this.button17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button17.FlatAppearance.BorderSize = 0;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button17, "");
            this.button17.Location = new System.Drawing.Point(541, 451);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(105, 80);
            this.button17.TabIndex = 103;
            this.button17.Tag = "1";
            this.button17.Text = "X";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button17.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Transparent;
            this.button18.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button18.BackgroundImage")));
            this.button18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button18.FlatAppearance.BorderSize = 0;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button18, "");
            this.button18.Location = new System.Drawing.Point(356, 451);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(105, 80);
            this.button18.TabIndex = 102;
            this.button18.Tag = "-1";
            this.button18.Text = "X";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button18.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // RTakeDelay
            // 
            this.RTakeDelay.BackColor = System.Drawing.Color.Gray;
            this.FeederData.SetBindingName(this.RTakeDelay, "TakeLabelPara.RightTakeDelay");
            this.RTakeDelay.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.RTakeDelay.Format = "F2";
            this.RTakeDelay.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.RTakeDelay.Location = new System.Drawing.Point(1304, 420);
            this.RTakeDelay.Name = "RTakeDelay";
            this.RTakeDelay.Size = new System.Drawing.Size(138, 34);
            this.RTakeDelay.TabIndex = 111;
            this.RTakeDelay.Text = "66.666";
            this.RTakeDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(1120, 423);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 40);
            this.label7.TabIndex = 110;
            this.label7.Text = "右吸嘴取料延时";
            // 
            // LTakeDelay
            // 
            this.LTakeDelay.BackColor = System.Drawing.Color.Gray;
            this.FeederData.SetBindingName(this.LTakeDelay, "TakeLabelPara.LiftTakeDelay");
            this.LTakeDelay.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.LTakeDelay.Format = "F2";
            this.LTakeDelay.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.LTakeDelay.Location = new System.Drawing.Point(196, 421);
            this.LTakeDelay.Name = "LTakeDelay";
            this.LTakeDelay.Size = new System.Drawing.Size(138, 34);
            this.LTakeDelay.TabIndex = 115;
            this.LTakeDelay.Text = "66.666";
            this.LTakeDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(14, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 40);
            this.label5.TabIndex = 114;
            this.label5.Text = "左吸嘴取料延时";
            // 
            // LtakeZPos
            // 
            this.LtakeZPos.BackColor = System.Drawing.Color.Gray;
            this.FeederData.SetBindingName(this.LtakeZPos, "TakeLabelPara.LiftTakePos_Z");
            this.LtakeZPos.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.LtakeZPos.Format = "F2";
            this.LtakeZPos.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.LtakeZPos.Location = new System.Drawing.Point(196, 350);
            this.LtakeZPos.Name = "LtakeZPos";
            this.LtakeZPos.Size = new System.Drawing.Size(138, 34);
            this.LtakeZPos.TabIndex = 113;
            this.LtakeZPos.Text = "66.666";
            this.LtakeZPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(12, 352);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(227, 40);
            this.label8.TabIndex = 112;
            this.label8.Text = "左吸嘴取料高度";
            // 
            // borderPanel2
            // 
            this.borderPanel2.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel2.BorderLineWidth = 2;
            this.borderPanel2.Location = new System.Drawing.Point(343, 315);
            this.borderPanel2.Name = "borderPanel2";
            this.borderPanel2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel2.Size = new System.Drawing.Size(1, 370);
            this.borderPanel2.TabIndex = 116;
            // 
            // borderPanel3
            // 
            this.borderPanel3.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel3.BorderLineWidth = 2;
            this.borderPanel3.Location = new System.Drawing.Point(1106, 317);
            this.borderPanel3.Name = "borderPanel3";
            this.borderPanel3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel3.Size = new System.Drawing.Size(1, 370);
            this.borderPanel3.TabIndex = 117;
            // 
            // borderPanel4
            // 
            this.borderPanel4.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel4.BorderLineWidth = 2;
            this.borderPanel4.Location = new System.Drawing.Point(0, 315);
            this.borderPanel4.Name = "borderPanel4";
            this.borderPanel4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel4.Size = new System.Drawing.Size(1450, 1);
            this.borderPanel4.TabIndex = 117;
            // 
            // borderPanel5
            // 
            this.borderPanel5.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel5.BorderLineWidth = 2;
            this.borderPanel5.Location = new System.Drawing.Point(858, 0);
            this.borderPanel5.Name = "borderPanel5";
            this.borderPanel5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel5.Size = new System.Drawing.Size(1, 317);
            this.borderPanel5.TabIndex = 118;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(34, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(303, 52);
            this.label9.TabIndex = 119;
            this.label9.Text = "飞达出料模式：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(34, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(303, 52);
            this.label10.TabIndex = 121;
            this.label10.Text = "飞达出标排数：";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button2, "");
            this.button2.Location = new System.Drawing.Point(134, 594);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 72);
            this.button2.TabIndex = 124;
            this.button2.Tag = "3";
            this.button2.Text = "Z";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button5, "");
            this.button5.Location = new System.Drawing.Point(134, 484);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(66, 72);
            this.button5.TabIndex = 123;
            this.button5.Tag = "-3";
            this.button5.Text = "Z";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button6, "");
            this.button6.Location = new System.Drawing.Point(1250, 594);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(66, 72);
            this.button6.TabIndex = 126;
            this.button6.Tag = "4";
            this.button6.Text = "Z";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button7, "");
            this.button7.Location = new System.Drawing.Point(1250, 484);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(66, 72);
            this.button7.TabIndex = 125;
            this.button7.Tag = "-4";
            this.button7.Text = "Z";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // Z1Pos
            // 
            this.Z1Pos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FeederData.SetBindingName(this.Z1Pos, "");
            this.Z1Pos.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Z1Pos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.Z1Pos.Format = "F2";
            this.Z1Pos.KeyBoard = false;
            this.Z1Pos.Location = new System.Drawing.Point(196, 559);
            this.Z1Pos.Name = "Z1Pos";
            this.Z1Pos.Size = new System.Drawing.Size(138, 34);
            this.Z1Pos.TabIndex = 127;
            this.Z1Pos.Text = "66.666";
            this.Z1Pos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Z2Pos
            // 
            this.Z2Pos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FeederData.SetBindingName(this.Z2Pos, "");
            this.Z2Pos.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Z2Pos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.Z2Pos.Format = "F2";
            this.Z2Pos.KeyBoard = false;
            this.Z2Pos.Location = new System.Drawing.Point(1304, 557);
            this.Z2Pos.Name = "Z2Pos";
            this.Z2Pos.Size = new System.Drawing.Size(138, 34);
            this.Z2Pos.TabIndex = 128;
            this.Z2Pos.Text = "66.666";
            this.Z2Pos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FeederRows
            // 
            this.FeederRows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FeederData.SetBindingName(this.FeederRows, "FeederPara.labelRow");
            this.FeederRows.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.FeederRows.Format = "F2";
            this.FeederRows.Location = new System.Drawing.Point(286, 143);
            this.FeederRows.Name = "FeederRows";
            this.FeederRows.Size = new System.Drawing.Size(118, 46);
            this.FeederRows.TabIndex = 132;
            this.FeederRows.Text = "2";
            this.FeederRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Lcheck
            // 
            this.Lcheck.AutoSize = true;
            this.Lcheck.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.Lcheck.Location = new System.Drawing.Point(358, 331);
            this.Lcheck.Name = "Lcheck";
            this.Lcheck.Size = new System.Drawing.Size(99, 44);
            this.Lcheck.TabIndex = 129;
            this.Lcheck.Text = "点动";
            this.Lcheck.UseVisualStyleBackColor = true;
            // 
            // FeederMode1
            // 
            this.FeederMode1.AutoSize = true;
            this.FeederMode1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FeederMode1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold);
            this.FeederMode1.Location = new System.Drawing.Point(278, 50);
            this.FeederMode1.Name = "FeederMode1";
            this.FeederMode1.Size = new System.Drawing.Size(245, 56);
            this.FeederMode1.TabIndex = 130;
            this.FeederMode1.Text = "剥标板出标";
            this.FeederMode1.UseVisualStyleBackColor = true;
            this.FeederMode1.CheckedChanged += new System.EventHandler(this.FeederMode1_CheckedChanged);
            // 
            // FeederMode2
            // 
            this.FeederMode2.AutoSize = true;
            this.FeederMode2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FeederMode2.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold);
            this.FeederMode2.Location = new System.Drawing.Point(516, 50);
            this.FeederMode2.Name = "FeederMode2";
            this.FeederMode2.Size = new System.Drawing.Size(245, 56);
            this.FeederMode2.TabIndex = 131;
            this.FeederMode2.Text = "后撤式出标";
            this.FeederMode2.UseVisualStyleBackColor = true;
            this.FeederMode2.CheckedChanged += new System.EventHandler(this.FeederMode1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(673, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 370);
            this.panel1.TabIndex = 133;
            // 
            // Feeder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1450, 783);
            this.Controls.Add(this.FeederRows);
            this.Controls.Add(this.FeederMode2);
            this.Controls.Add(this.FeederMode1);
            this.Controls.Add(this.Lcheck);
            this.Controls.Add(this.Z2Pos);
            this.Controls.Add(this.Z1Pos);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.borderPanel5);
            this.Controls.Add(this.borderPanel4);
            this.Controls.Add(this.borderPanel3);
            this.Controls.Add(this.borderPanel2);
            this.Controls.Add(this.LTakeDelay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LtakeZPos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.RTakeDelay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.Step);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.RtakeZPos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Obtain);
            this.Controls.Add(this.LocateFeederPos);
            this.Controls.Add(this.FeederPosY);
            this.Controls.Add(this.FeederPosX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.YPos);
            this.Controls.Add(this.XPos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Name = "Feeder";
            this.Text = "Feeder";
            this.Load += new System.EventHandler(this.Feeder_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.XPos, 0);
            this.Controls.SetChildIndex(this.YPos, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.FeederPosX, 0);
            this.Controls.SetChildIndex(this.FeederPosY, 0);
            this.Controls.SetChildIndex(this.LocateFeederPos, 0);
            this.Controls.SetChildIndex(this.Obtain, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.RtakeZPos, 0);
            this.Controls.SetChildIndex(this.button18, 0);
            this.Controls.SetChildIndex(this.button17, 0);
            this.Controls.SetChildIndex(this.button15, 0);
            this.Controls.SetChildIndex(this.button16, 0);
            this.Controls.SetChildIndex(this.Speed, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.Step, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.RTakeDelay, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.LtakeZPos, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.LTakeDelay, 0);
            this.Controls.SetChildIndex(this.borderPanel2, 0);
            this.Controls.SetChildIndex(this.borderPanel3, 0);
            this.Controls.SetChildIndex(this.borderPanel4, 0);
            this.Controls.SetChildIndex(this.borderPanel5, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button7, 0);
            this.Controls.SetChildIndex(this.button6, 0);
            this.Controls.SetChildIndex(this.Z1Pos, 0);
            this.Controls.SetChildIndex(this.Z2Pos, 0);
            this.Controls.SetChildIndex(this.Lcheck, 0);
            this.Controls.SetChildIndex(this.FeederMode1, 0);
            this.Controls.SetChildIndex(this.FeederMode2, 0);
            this.Controls.SetChildIndex(this.FeederRows, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Obtain;
        private System.Windows.Forms.Button LocateFeederPos;
        private HzControl.Communal.Controls.MyTextBox FeederPosY;
        private HzControl.Communal.Controls.MyTextBox FeederPosX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private HzControl.Communal.Controls.MyTextBox YPos;
        private HzControl.Communal.Controls.MyTextBox XPos;
        private System.Windows.Forms.Label label4;
        private HzControl.Communal.Controls.MyTextBox RtakeZPos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label21;
        private HzControl.Communal.Controls.MyTextBox Step;
        private System.Windows.Forms.Label label20;
        private HzControl.Communal.Controls.MyTextBox Speed;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private HzControl.Communal.Controls.MyTextBox RTakeDelay;
        private System.Windows.Forms.Label label7;
        private HzControl.Communal.Controls.MyTextBox LTakeDelay;
        private System.Windows.Forms.Label label5;
        private HzControl.Communal.Controls.MyTextBox LtakeZPos;
        private System.Windows.Forms.Label label8;
        private BorderPanel borderPanel2;
        private BorderPanel borderPanel3;
        private BorderPanel borderPanel4;
        private BorderPanel borderPanel5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private HzControl.Communal.Controls.UserBingData FeederData;
        private HzControl.Communal.Controls.MyTextBox Z1Pos;
        private HzControl.Communal.Controls.MyTextBox Z2Pos;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox Lcheck;
        private System.Windows.Forms.CheckBox FeederMode1;
        private System.Windows.Forms.CheckBox FeederMode2;
        private HzControl.Communal.Controls.MyTextBox FeederRows;
        private System.Windows.Forms.Panel panel1;
    }
}