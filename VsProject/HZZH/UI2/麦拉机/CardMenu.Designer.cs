using HzControl.Communal.Controls;

namespace HZZH.UI2.麦拉机
{
    partial class CardMenu
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
            this.CardBtnpanel = new System.Windows.Forms.Panel();
            this.borderPanel2 = new BorderPanel();
            this.AxisParaBtn = new System.Windows.Forms.Button();
            this.IOBtn = new System.Windows.Forms.Button();
            this.ClientAxis = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CardBtnpanel.SuspendLayout();
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
            // CardBtnpanel
            // 
            this.CardBtnpanel.Controls.Add(this.borderPanel2);
            this.CardBtnpanel.Controls.Add(this.AxisParaBtn);
            this.CardBtnpanel.Controls.Add(this.IOBtn);
            this.CardBtnpanel.Controls.Add(this.ClientAxis);
            this.CardBtnpanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CardBtnpanel.Location = new System.Drawing.Point(1262, 0);
            this.CardBtnpanel.Name = "CardBtnpanel";
            this.CardBtnpanel.Size = new System.Drawing.Size(188, 685);
            this.CardBtnpanel.TabIndex = 2;
            // 
            // borderPanel2
            // 
            this.borderPanel2.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel2.BorderLineWidth = 2;
            this.borderPanel2.Location = new System.Drawing.Point(1, 0);
            this.borderPanel2.Name = "borderPanel2";
            this.borderPanel2.Size = new System.Drawing.Size(2, 689);
            this.borderPanel2.TabIndex = 3;
            // 
            // AxisParaBtn
            // 
            this.AxisParaBtn.FlatAppearance.BorderSize = 3;
            this.AxisParaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AxisParaBtn.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.AxisParaBtn, "4");
            this.AxisParaBtn.Location = new System.Drawing.Point(18, 295);
            this.AxisParaBtn.Name = "AxisParaBtn";
            this.AxisParaBtn.Size = new System.Drawing.Size(157, 67);
            this.AxisParaBtn.TabIndex = 2;
            this.AxisParaBtn.Tag = "AxisPara";
            this.AxisParaBtn.Text = "轴配置";
            this.AxisParaBtn.UseVisualStyleBackColor = true;
            this.AxisParaBtn.Click += new System.EventHandler(this.AxisParaBtn_Click);
            // 
            // IOBtn
            // 
            this.IOBtn.FlatAppearance.BorderSize = 3;
            this.IOBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IOBtn.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.IOBtn, "2");
            this.IOBtn.Location = new System.Drawing.Point(18, 167);
            this.IOBtn.Name = "IOBtn";
            this.IOBtn.Size = new System.Drawing.Size(157, 67);
            this.IOBtn.TabIndex = 1;
            this.IOBtn.Tag = "IOPart";
            this.IOBtn.Text = "IO参数";
            this.IOBtn.UseVisualStyleBackColor = true;
            this.IOBtn.Click += new System.EventHandler(this.IOBtn_Click);
            // 
            // ClientAxis
            // 
            this.ClientAxis.FlatAppearance.BorderSize = 3;
            this.ClientAxis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientAxis.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.ClientAxis, "3");
            this.ClientAxis.Location = new System.Drawing.Point(18, 39);
            this.ClientAxis.Name = "ClientAxis";
            this.ClientAxis.Size = new System.Drawing.Size(157, 67);
            this.ClientAxis.TabIndex = 0;
            this.ClientAxis.Tag = "AxisClient";
            this.ClientAxis.Text = "轴参数";
            this.ClientAxis.UseVisualStyleBackColor = true;
            this.ClientAxis.Click += new System.EventHandler(this.ClientAxis_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CardMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1450, 783);
            this.Controls.Add(this.CardBtnpanel);
            this.Name = "CardMenu";
            this.Text = "CardMenu";
            this.Load += new System.EventHandler(this.CardMenu_Load);
            this.Controls.SetChildIndex(this.CardBtnpanel, 0);
            this.CardBtnpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CardBtnpanel;
        private System.Windows.Forms.Button ClientAxis;
        private System.Windows.Forms.Button AxisParaBtn;
        private System.Windows.Forms.Button IOBtn;
        private BorderPanel borderPanel2;
        private System.Windows.Forms.Timer timer1;
    }
}