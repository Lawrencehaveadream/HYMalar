namespace HZZH.UI2.麦拉机.参数设置
{
    partial class AxisPara
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
            this.panelforAxisPara = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelforAxisPara
            // 
            this.panelforAxisPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelforAxisPara.Location = new System.Drawing.Point(0, 0);
            this.panelforAxisPara.Name = "panelforAxisPara";
            this.panelforAxisPara.Size = new System.Drawing.Size(1262, 685);
            this.panelforAxisPara.TabIndex = 3;
            // 
            // AxisPara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 783);
            this.Controls.Add(this.panelforAxisPara);
            this.Name = "AxisPara";
            this.Text = "AxisPara";
            this.Load += new System.EventHandler(this.AxisPara_Load);
            this.Controls.SetChildIndex(this.panelforAxisPara, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelforAxisPara;
    }
}