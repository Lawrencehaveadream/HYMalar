namespace HZZH.UI2.麦拉机.参数设置
{
    partial class AxisClient
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
            this.PanelForAxis = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // BtnVision
            // 
            this.BtnVision.FlatAppearance.BorderSize = 3;
            // 
            // BtnCard
            // 
            this.BtnCard.BackColor = System.Drawing.Color.Green;
            this.BtnCard.FlatAppearance.BorderSize = 3;
            // 
            // BtnMachine
            // 
            this.BtnMachine.FlatAppearance.BorderSize = 3;
            // 
            // PanelForAxis
            // 
            this.PanelForAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelForAxis.Location = new System.Drawing.Point(0, 0);
            this.PanelForAxis.Name = "PanelForAxis";
            this.PanelForAxis.Size = new System.Drawing.Size(1262, 685);
            this.PanelForAxis.TabIndex = 3;
            // 
            // AxisClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 783);
            this.Controls.Add(this.PanelForAxis);
            this.Name = "AxisClient";
            this.Text = "AxisClient";
            this.Load += new System.EventHandler(this.AxisClient_Load);
            this.Controls.SetChildIndex(this.PanelForAxis, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelForAxis;
    }
}