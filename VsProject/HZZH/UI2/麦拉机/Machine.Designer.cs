using HzControl.Communal.Controls;

namespace HZZH.UI2.麦拉机
{
    partial class Machine
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.borderPanel2 = new BorderPanel();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.borderPanel2);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1256, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 685);
            this.panel1.TabIndex = 2;
            // 
            // borderPanel2
            // 
            this.borderPanel2.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel2.BorderLineWidth = 2;
            this.borderPanel2.Location = new System.Drawing.Point(0, 0);
            this.borderPanel2.Name = "borderPanel2";
            this.borderPanel2.Size = new System.Drawing.Size(2, 685);
            this.borderPanel2.TabIndex = 2;
            // 
            // button8
            // 
            this.button8.FlatAppearance.BorderSize = 3;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.button8, "");
            this.button8.Location = new System.Drawing.Point(21, 322);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(161, 69);
            this.button8.TabIndex = 1;
            this.button8.Tag = "Ratate";
            this.button8.Text = "旋转中心";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 3;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.button6, "");
            this.button6.Location = new System.Drawing.Point(21, 161);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(161, 69);
            this.button6.TabIndex = 0;
            this.button6.Tag = "MachinePara";
            this.button6.Text = "机械参数";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Machine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 783);
            this.Controls.Add(this.panel1);
            this.Name = "Machine";
            this.Text = "MachinePara";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private BorderPanel borderPanel2;
    }
}