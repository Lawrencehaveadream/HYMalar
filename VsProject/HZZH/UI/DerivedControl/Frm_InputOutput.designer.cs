namespace MyControl
{
    partial class InputOutput
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputOutput));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.doubleBufferListview1 = new HZZH.Communal.Control.DoubleBufferListview();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.doubleBufferListview2 = new HZZH.Communal.Control.DoubleBufferListview();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Gray.png");
            this.imageList1.Images.SetKeyName(1, "Green.png");
            this.imageList1.Images.SetKeyName(2, "buttonOFF.png");
            this.imageList1.Images.SetKeyName(3, "buttonON.png");
            this.imageList1.Images.SetKeyName(4, "NewGreen.png");
            this.imageList1.Images.SetKeyName(5, "NewBlack.png");
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "buttonOFF.png");
            this.imageList2.Images.SetKeyName(1, "buttonON.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.doubleBufferListview1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.doubleBufferListview2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 411);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // doubleBufferListview1
            // 
            this.doubleBufferListview1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.doubleBufferListview1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.doubleBufferListview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferListview1.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doubleBufferListview1.ForeColor = System.Drawing.Color.Black;
            this.doubleBufferListview1.FullRowSelect = true;
            this.doubleBufferListview1.GridLines = true;
            this.doubleBufferListview1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.doubleBufferListview1.Location = new System.Drawing.Point(2, 2);
            this.doubleBufferListview1.Margin = new System.Windows.Forms.Padding(2);
            this.doubleBufferListview1.MultiSelect = false;
            this.doubleBufferListview1.Name = "doubleBufferListview1";
            this.doubleBufferListview1.Size = new System.Drawing.Size(388, 407);
            this.doubleBufferListview1.TabIndex = 0;
            this.doubleBufferListview1.UseCompatibleStateImageBehavior = false;
            this.doubleBufferListview1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "输入端口";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "输入名称";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 280;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "状态";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // doubleBufferListview2
            // 
            this.doubleBufferListview2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.doubleBufferListview2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.doubleBufferListview2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferListview2.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doubleBufferListview2.ForeColor = System.Drawing.Color.Black;
            this.doubleBufferListview2.FullRowSelect = true;
            this.doubleBufferListview2.GridLines = true;
            this.doubleBufferListview2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.doubleBufferListview2.Location = new System.Drawing.Point(394, 2);
            this.doubleBufferListview2.Margin = new System.Windows.Forms.Padding(2);
            this.doubleBufferListview2.MultiSelect = false;
            this.doubleBufferListview2.Name = "doubleBufferListview2";
            this.doubleBufferListview2.Size = new System.Drawing.Size(388, 407);
            this.doubleBufferListview2.TabIndex = 1;
            this.doubleBufferListview2.UseCompatibleStateImageBehavior = false;
            this.doubleBufferListview2.View = System.Windows.Forms.View.Details;
            this.doubleBufferListview2.SelectedIndexChanged += new System.EventHandler(this.doubleBufferListview2_SelectedIndexChanged);
            this.doubleBufferListview2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseDoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "输出端口";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "输出名称";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 280;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "状态";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 120;
            // 
            // InputOutput
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InputOutput";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public HZZH.Communal.Control.DoubleBufferListview doubleBufferListview1;
        public HZZH.Communal.Control.DoubleBufferListview doubleBufferListview2;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.ColumnHeader columnHeader5;
        public System.Windows.Forms.ColumnHeader columnHeader6;
    }
}
