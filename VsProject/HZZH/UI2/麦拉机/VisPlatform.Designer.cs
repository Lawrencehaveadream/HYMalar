using HzControl.Communal.Controls;

namespace HZZH.UI2.麦拉机
{
    partial class VisPlatform
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
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1243, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 685);
            this.panel1.TabIndex = 2;
            // 
            // borderPanel2
            // 
            this.borderPanel2.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel2.BorderLineWidth = 2;
            this.borderPanel2.Location = new System.Drawing.Point(0, 0);
            this.borderPanel2.Name = "borderPanel2";
            this.borderPanel2.Size = new System.Drawing.Size(2, 689);
            this.borderPanel2.TabIndex = 3;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.FlatAppearance.BorderSize = 3;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.button11, "");
            this.button11.Location = new System.Drawing.Point(11, 554);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(186, 68);
            this.button11.TabIndex = 8;
            this.button11.Tag = "BackCTForm";
            this.button11.Text = "回拍设置";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.FlatAppearance.BorderSize = 3;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.button10, "");
            this.button10.Location = new System.Drawing.Point(11, 377);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(186, 68);
            this.button10.TabIndex = 7;
            this.button10.Tag = "CodeForm";
            this.button10.Text = "二维码";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.FlatAppearance.BorderSize = 3;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.button9, "");
            this.button9.Location = new System.Drawing.Point(11, 200);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(186, 68);
            this.button9.TabIndex = 6;
            this.button9.Tag = "DownVisForm";
            this.button9.Text = "下相机模板";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.BorderSize = 3;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("微软雅黑", 22.2F, System.Drawing.FontStyle.Bold);
            this.level13333.SetLevel(this.button6, "");
            this.button6.Location = new System.Drawing.Point(11, 23);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(186, 68);
            this.button6.TabIndex = 4;
            this.button6.Tag = "VisForm";
            this.button6.Text = "上相机模板";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // VisPlatform
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1450, 783);
            this.Controls.Add(this.panel1);
            this.Name = "VisPlatform";
            this.Text = "VisPlatform";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private BorderPanel borderPanel2;
    }
}