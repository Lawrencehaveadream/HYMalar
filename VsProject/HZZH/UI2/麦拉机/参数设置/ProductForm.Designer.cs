using HzControl.Communal.Controls;

namespace HZZH.UI2.麦拉机.参数设置
{
    partial class ProductForm
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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点0");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("产品树", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加产品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除产品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.阵列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修正点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.定位点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Xpos = new HzControl.Communal.Controls.MyTextBox();
            this.Ypos = new HzControl.Communal.Controls.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Mark1X = new HzControl.Communal.Controls.MyTextBox();
            this.Mark1Y = new HzControl.Communal.Controls.MyTextBox();
            this.Mark2Y = new HzControl.Communal.Controls.MyTextBox();
            this.Mark2X = new HzControl.Communal.Controls.MyTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Obtain1 = new System.Windows.Forms.Button();
            this.Locate1 = new System.Windows.Forms.Button();
            this.Obtain2 = new System.Windows.Forms.Button();
            this.Locate2 = new System.Windows.Forms.Button();
            this.Obtain4 = new System.Windows.Forms.Button();
            this.Locate4 = new System.Windows.Forms.Button();
            this.Obtain3 = new System.Windows.Forms.Button();
            this.Locate3 = new System.Windows.Forms.Button();
            this.BackCTY = new HzControl.Communal.Controls.MyTextBox();
            this.CodeY = new HzControl.Communal.Controls.MyTextBox();
            this.CodeX = new HzControl.Communal.Controls.MyTextBox();
            this.BackCTX = new HzControl.Communal.Controls.MyTextBox();
            this.compensateValue = new HzControl.Communal.Controls.MyTextBox();
            this.BtncompensateNegY = new System.Windows.Forms.Button();
            this.BtncompensatePosY = new System.Windows.Forms.Button();
            this.BtncompensatePosX = new System.Windows.Forms.Button();
            this.BtncompensateNegX = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.Step = new HzControl.Communal.Controls.MyTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.Speed = new HzControl.Communal.Controls.MyTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.borderPanel3 = new HzControl.Communal.Controls.BorderPanel();
            this.borderPanel2 = new HzControl.Communal.Controls.BorderPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Z1pos = new HzControl.Communal.Controls.MyTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Z2pos = new HzControl.Communal.Controls.MyTextBox();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.borderPanel4 = new HzControl.Communal.Controls.BorderPanel();
            this.borderPanel5 = new HzControl.Communal.Controls.BorderPanel();
            this.Lcheck = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.BtncompensatePosR = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
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
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.treeView1.HideSelection = false;
            this.treeView1.Indent = 40;
            this.treeView1.ItemHeight = 30;
            this.treeView1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode3.Name = "节点0";
            treeNode3.Text = "节点0";
            treeNode4.Name = "节点0";
            treeNode4.Text = "产品树";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(166, 349);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加产品ToolStripMenuItem,
            this.删除产品ToolStripMenuItem,
            this.阵列ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // 添加产品ToolStripMenuItem
            // 
            this.添加产品ToolStripMenuItem.Name = "添加产品ToolStripMenuItem";
            this.添加产品ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加产品ToolStripMenuItem.Text = "添加产品";
            this.添加产品ToolStripMenuItem.Click += new System.EventHandler(this.添加产品ToolStripMenuItem_Click);
            // 
            // 删除产品ToolStripMenuItem
            // 
            this.删除产品ToolStripMenuItem.Name = "删除产品ToolStripMenuItem";
            this.删除产品ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除产品ToolStripMenuItem.Text = "删除产品";
            this.删除产品ToolStripMenuItem.Click += new System.EventHandler(this.删除产品ToolStripMenuItem_Click);
            // 
            // 阵列ToolStripMenuItem
            // 
            this.阵列ToolStripMenuItem.Name = "阵列ToolStripMenuItem";
            this.阵列ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.阵列ToolStripMenuItem.Text = "阵列";
            this.阵列ToolStripMenuItem.Click += new System.EventHandler(this.阵列ToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip2;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(165, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 50;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(255)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.Size = new System.Drawing.Size(730, 351);
            this.dataGridView1.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "编号";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "X";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Y";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "R";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 125;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Z";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加点ToolStripMenuItem,
            this.删除点ToolStripMenuItem,
            this.修正点ToolStripMenuItem,
            this.定位点ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(113, 92);
            // 
            // 添加点ToolStripMenuItem
            // 
            this.添加点ToolStripMenuItem.Name = "添加点ToolStripMenuItem";
            this.添加点ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.添加点ToolStripMenuItem.Text = "添加点";
            this.添加点ToolStripMenuItem.Click += new System.EventHandler(this.添加点ToolStripMenuItem_Click);
            // 
            // 删除点ToolStripMenuItem
            // 
            this.删除点ToolStripMenuItem.Name = "删除点ToolStripMenuItem";
            this.删除点ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.删除点ToolStripMenuItem.Text = "删除点";
            this.删除点ToolStripMenuItem.Click += new System.EventHandler(this.删除点ToolStripMenuItem_Click);
            // 
            // 修正点ToolStripMenuItem
            // 
            this.修正点ToolStripMenuItem.Name = "修正点ToolStripMenuItem";
            this.修正点ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.修正点ToolStripMenuItem.Text = "修正点";
            this.修正点ToolStripMenuItem.Click += new System.EventHandler(this.修正点ToolStripMenuItem_Click);
            // 
            // 定位点ToolStripMenuItem
            // 
            this.定位点ToolStripMenuItem.Name = "定位点ToolStripMenuItem";
            this.定位点ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.定位点ToolStripMenuItem.Text = "定位点";
            this.定位点ToolStripMenuItem.Click += new System.EventHandler(this.定位点ToolStripMenuItem_Click);
            // 
            // Xpos
            // 
            this.Xpos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Xpos.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Xpos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.Xpos.Format = "F2";
            this.Xpos.KeyBoard = false;
            this.Xpos.Location = new System.Drawing.Point(353, 404);
            this.Xpos.Name = "Xpos";
            this.Xpos.Size = new System.Drawing.Size(134, 33);
            this.Xpos.TabIndex = 4;
            this.Xpos.Text = "666.666";
            this.Xpos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ypos
            // 
            this.Ypos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Ypos.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Ypos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.Ypos.Format = "F2";
            this.Ypos.KeyBoard = false;
            this.Ypos.Location = new System.Drawing.Point(496, 404);
            this.Ypos.Name = "Ypos";
            this.Ypos.Size = new System.Drawing.Size(134, 33);
            this.Ypos.TabIndex = 5;
            this.Ypos.Text = "666.666";
            this.Ypos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.label1.Location = new System.Drawing.Point(275, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 89;
            this.label1.Text = "当前位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(270, 455);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 27);
            this.label4.TabIndex = 92;
            this.label4.Text = "Mark1";
            // 
            // Mark1X
            // 
            this.Mark1X.BackColor = System.Drawing.Color.Gray;
            this.Mark1X.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Mark1X.Format = "F2";
            this.Mark1X.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.Mark1X.Location = new System.Drawing.Point(353, 452);
            this.Mark1X.Name = "Mark1X";
            this.Mark1X.Size = new System.Drawing.Size(134, 33);
            this.Mark1X.TabIndex = 93;
            this.Mark1X.Text = "666.666";
            this.Mark1X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mark1X.MouseLeave += new System.EventHandler(this.Mark1X_MouseLeave);
            // 
            // Mark1Y
            // 
            this.Mark1Y.BackColor = System.Drawing.Color.Gray;
            this.Mark1Y.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Mark1Y.Format = "F2";
            this.Mark1Y.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.Mark1Y.Location = new System.Drawing.Point(496, 452);
            this.Mark1Y.Name = "Mark1Y";
            this.Mark1Y.Size = new System.Drawing.Size(134, 33);
            this.Mark1Y.TabIndex = 94;
            this.Mark1Y.Text = "666.666";
            this.Mark1Y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mark1Y.MouseLeave += new System.EventHandler(this.Mark1X_MouseLeave);
            // 
            // Mark2Y
            // 
            this.Mark2Y.BackColor = System.Drawing.Color.Gray;
            this.Mark2Y.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Mark2Y.Format = "F2";
            this.Mark2Y.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.Mark2Y.Location = new System.Drawing.Point(496, 511);
            this.Mark2Y.Name = "Mark2Y";
            this.Mark2Y.Size = new System.Drawing.Size(134, 33);
            this.Mark2Y.TabIndex = 97;
            this.Mark2Y.Text = "666.666";
            this.Mark2Y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mark2Y.MouseLeave += new System.EventHandler(this.Mark1X_MouseLeave);
            // 
            // Mark2X
            // 
            this.Mark2X.BackColor = System.Drawing.Color.Gray;
            this.Mark2X.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Mark2X.Format = "F2";
            this.Mark2X.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.Mark2X.Location = new System.Drawing.Point(353, 511);
            this.Mark2X.Name = "Mark2X";
            this.Mark2X.Size = new System.Drawing.Size(134, 33);
            this.Mark2X.TabIndex = 96;
            this.Mark2X.Text = "666.666";
            this.Mark2X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mark2X.MouseLeave += new System.EventHandler(this.Mark1X_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(270, 514);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 27);
            this.label5.TabIndex = 95;
            this.label5.Text = "Mark2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.label10.Location = new System.Drawing.Point(551, 374);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 27);
            this.label10.TabIndex = 107;
            this.label10.Text = "Y";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.label11.Location = new System.Drawing.Point(409, 374);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 27);
            this.label11.TabIndex = 106;
            this.label11.Text = "X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(275, 571);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 27);
            this.label8.TabIndex = 109;
            this.label8.Text = "回拍位";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(275, 634);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 27);
            this.label9.TabIndex = 112;
            this.label9.Text = "扫码位";
            // 
            // Obtain1
            // 
            this.Obtain1.BackColor = System.Drawing.Color.Transparent;
            this.Obtain1.FlatAppearance.BorderSize = 2;
            this.Obtain1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Obtain1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Obtain1.ForeColor = System.Drawing.Color.Black;
            this.level13333.SetLevel(this.Obtain1, "");
            this.Obtain1.Location = new System.Drawing.Point(659, 446);
            this.Obtain1.Name = "Obtain1";
            this.Obtain1.Size = new System.Drawing.Size(89, 45);
            this.Obtain1.TabIndex = 118;
            this.Obtain1.Text = "获取";
            this.Obtain1.UseVisualStyleBackColor = false;
            this.Obtain1.Click += new System.EventHandler(this.Obtain1_Click);
            // 
            // Locate1
            // 
            this.Locate1.BackColor = System.Drawing.Color.Transparent;
            this.Locate1.FlatAppearance.BorderSize = 2;
            this.Locate1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Locate1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Locate1.ForeColor = System.Drawing.Color.Black;
            this.level13333.SetLevel(this.Locate1, "");
            this.Locate1.Location = new System.Drawing.Point(773, 446);
            this.Locate1.Name = "Locate1";
            this.Locate1.Size = new System.Drawing.Size(89, 45);
            this.Locate1.TabIndex = 117;
            this.Locate1.Text = "执行";
            this.Locate1.UseVisualStyleBackColor = false;
            this.Locate1.Click += new System.EventHandler(this.Locate1_Click);
            // 
            // Obtain2
            // 
            this.Obtain2.BackColor = System.Drawing.Color.Transparent;
            this.Obtain2.FlatAppearance.BorderSize = 2;
            this.Obtain2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Obtain2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Obtain2.ForeColor = System.Drawing.Color.Black;
            this.level13333.SetLevel(this.Obtain2, "");
            this.Obtain2.Location = new System.Drawing.Point(659, 505);
            this.Obtain2.Name = "Obtain2";
            this.Obtain2.Size = new System.Drawing.Size(89, 45);
            this.Obtain2.TabIndex = 120;
            this.Obtain2.Text = "获取";
            this.Obtain2.UseVisualStyleBackColor = false;
            this.Obtain2.Click += new System.EventHandler(this.Obtain2_Click);
            // 
            // Locate2
            // 
            this.Locate2.BackColor = System.Drawing.Color.Transparent;
            this.Locate2.FlatAppearance.BorderSize = 2;
            this.Locate2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Locate2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Locate2.ForeColor = System.Drawing.Color.Black;
            this.level13333.SetLevel(this.Locate2, "");
            this.Locate2.Location = new System.Drawing.Point(773, 505);
            this.Locate2.Name = "Locate2";
            this.Locate2.Size = new System.Drawing.Size(89, 45);
            this.Locate2.TabIndex = 119;
            this.Locate2.Text = "执行";
            this.Locate2.UseVisualStyleBackColor = false;
            this.Locate2.Click += new System.EventHandler(this.Locate2_Click);
            // 
            // Obtain4
            // 
            this.Obtain4.BackColor = System.Drawing.Color.Transparent;
            this.Obtain4.FlatAppearance.BorderSize = 2;
            this.Obtain4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Obtain4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Obtain4.ForeColor = System.Drawing.Color.Black;
            this.level13333.SetLevel(this.Obtain4, "");
            this.Obtain4.Location = new System.Drawing.Point(659, 623);
            this.Obtain4.Name = "Obtain4";
            this.Obtain4.Size = new System.Drawing.Size(89, 45);
            this.Obtain4.TabIndex = 130;
            this.Obtain4.Text = "获取";
            this.Obtain4.UseVisualStyleBackColor = false;
            this.Obtain4.Click += new System.EventHandler(this.Obtain4_Click);
            // 
            // Locate4
            // 
            this.Locate4.BackColor = System.Drawing.Color.Transparent;
            this.Locate4.FlatAppearance.BorderSize = 2;
            this.Locate4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Locate4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Locate4.ForeColor = System.Drawing.Color.Black;
            this.level13333.SetLevel(this.Locate4, "");
            this.Locate4.Location = new System.Drawing.Point(773, 623);
            this.Locate4.Name = "Locate4";
            this.Locate4.Size = new System.Drawing.Size(89, 45);
            this.Locate4.TabIndex = 129;
            this.Locate4.Text = "执行";
            this.Locate4.UseVisualStyleBackColor = false;
            this.Locate4.Click += new System.EventHandler(this.Locate4_Click);
            // 
            // Obtain3
            // 
            this.Obtain3.BackColor = System.Drawing.Color.Transparent;
            this.Obtain3.FlatAppearance.BorderSize = 2;
            this.Obtain3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Obtain3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Obtain3.ForeColor = System.Drawing.Color.Black;
            this.level13333.SetLevel(this.Obtain3, "");
            this.Obtain3.Location = new System.Drawing.Point(659, 564);
            this.Obtain3.Name = "Obtain3";
            this.Obtain3.Size = new System.Drawing.Size(89, 45);
            this.Obtain3.TabIndex = 128;
            this.Obtain3.Text = "获取";
            this.Obtain3.UseVisualStyleBackColor = false;
            this.Obtain3.Click += new System.EventHandler(this.Obtain3_Click);
            // 
            // Locate3
            // 
            this.Locate3.BackColor = System.Drawing.Color.Transparent;
            this.Locate3.FlatAppearance.BorderSize = 2;
            this.Locate3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Locate3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Locate3.ForeColor = System.Drawing.Color.Black;
            this.level13333.SetLevel(this.Locate3, "");
            this.Locate3.Location = new System.Drawing.Point(773, 564);
            this.Locate3.Name = "Locate3";
            this.Locate3.Size = new System.Drawing.Size(89, 45);
            this.Locate3.TabIndex = 127;
            this.Locate3.Text = "执行";
            this.Locate3.UseVisualStyleBackColor = false;
            this.Locate3.Click += new System.EventHandler(this.Locate3_Click);
            // 
            // BackCTY
            // 
            this.BackCTY.BackColor = System.Drawing.Color.Gray;
            this.BackCTY.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.BackCTY.Format = "F2";
            this.BackCTY.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.BackCTY.Location = new System.Drawing.Point(496, 570);
            this.BackCTY.Name = "BackCTY";
            this.BackCTY.Size = new System.Drawing.Size(134, 33);
            this.BackCTY.TabIndex = 122;
            this.BackCTY.Text = "666.666";
            this.BackCTY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BackCTY.MouseLeave += new System.EventHandler(this.Mark1X_MouseLeave);
            // 
            // CodeY
            // 
            this.CodeY.BackColor = System.Drawing.Color.Gray;
            this.CodeY.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.CodeY.Format = "F2";
            this.CodeY.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.CodeY.Location = new System.Drawing.Point(496, 629);
            this.CodeY.Name = "CodeY";
            this.CodeY.Size = new System.Drawing.Size(134, 33);
            this.CodeY.TabIndex = 124;
            this.CodeY.Text = "666.666";
            this.CodeY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CodeY.MouseLeave += new System.EventHandler(this.Mark1X_MouseLeave);
            // 
            // CodeX
            // 
            this.CodeX.BackColor = System.Drawing.Color.Gray;
            this.CodeX.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.CodeX.Format = "F2";
            this.CodeX.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.CodeX.Location = new System.Drawing.Point(353, 629);
            this.CodeX.Name = "CodeX";
            this.CodeX.Size = new System.Drawing.Size(134, 33);
            this.CodeX.TabIndex = 123;
            this.CodeX.Text = "666.666";
            this.CodeX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CodeX.MouseLeave += new System.EventHandler(this.Mark1X_MouseLeave);
            // 
            // BackCTX
            // 
            this.BackCTX.BackColor = System.Drawing.Color.Gray;
            this.BackCTX.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.BackCTX.Format = "F2";
            this.BackCTX.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.BackCTX.Location = new System.Drawing.Point(353, 570);
            this.BackCTX.Name = "BackCTX";
            this.BackCTX.Size = new System.Drawing.Size(134, 33);
            this.BackCTX.TabIndex = 121;
            this.BackCTX.Text = "666.666";
            this.BackCTX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BackCTX.MouseLeave += new System.EventHandler(this.Mark1X_MouseLeave);
            // 
            // compensateValue
            // 
            this.compensateValue.BackColor = System.Drawing.Color.Gray;
            this.compensateValue.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.compensateValue.Format = "F2";
            this.compensateValue.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.compensateValue.KeyBoard = false;
            this.compensateValue.Location = new System.Drawing.Point(97, 628);
            this.compensateValue.Name = "compensateValue";
            this.compensateValue.Size = new System.Drawing.Size(62, 38);
            this.compensateValue.TabIndex = 135;
            this.compensateValue.Text = "0.1";
            this.compensateValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.compensateValue.DoubleClick += new System.EventHandler(this.BtncompensateValue_DoubleClick);
            // 
            // BtncompensateNegY
            // 
            this.BtncompensateNegY.BackColor = System.Drawing.Color.Transparent;
            this.BtncompensateNegY.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtncompensateNegY.BackgroundImage")));
            this.BtncompensateNegY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtncompensateNegY.FlatAppearance.BorderSize = 0;
            this.BtncompensateNegY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtncompensateNegY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.BtncompensateNegY, "");
            this.BtncompensateNegY.Location = new System.Drawing.Point(104, 551);
            this.BtncompensateNegY.Name = "BtncompensateNegY";
            this.BtncompensateNegY.Size = new System.Drawing.Size(45, 61);
            this.BtncompensateNegY.TabIndex = 134;
            this.BtncompensateNegY.Tag = "-2";
            this.BtncompensateNegY.Text = "Y";
            this.BtncompensateNegY.UseVisualStyleBackColor = false;
            this.BtncompensateNegY.Click += new System.EventHandler(this.BtncompensatePosX_Click);
            // 
            // BtncompensatePosY
            // 
            this.BtncompensatePosY.BackColor = System.Drawing.Color.Transparent;
            this.BtncompensatePosY.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtncompensatePosY.BackgroundImage")));
            this.BtncompensatePosY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtncompensatePosY.FlatAppearance.BorderSize = 0;
            this.BtncompensatePosY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtncompensatePosY.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.BtncompensatePosY, "");
            this.BtncompensatePosY.Location = new System.Drawing.Point(104, 448);
            this.BtncompensatePosY.Name = "BtncompensatePosY";
            this.BtncompensatePosY.Size = new System.Drawing.Size(45, 61);
            this.BtncompensatePosY.TabIndex = 133;
            this.BtncompensatePosY.Tag = "2";
            this.BtncompensatePosY.Text = "Y";
            this.BtncompensatePosY.UseVisualStyleBackColor = false;
            this.BtncompensatePosY.Click += new System.EventHandler(this.BtncompensatePosX_Click);
            // 
            // BtncompensatePosX
            // 
            this.BtncompensatePosX.BackColor = System.Drawing.Color.Transparent;
            this.BtncompensatePosX.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtncompensatePosX.BackgroundImage")));
            this.BtncompensatePosX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtncompensatePosX.FlatAppearance.BorderSize = 0;
            this.BtncompensatePosX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtncompensatePosX.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.BtncompensatePosX, "");
            this.BtncompensatePosX.Location = new System.Drawing.Point(147, 507);
            this.BtncompensatePosX.Name = "BtncompensatePosX";
            this.BtncompensatePosX.Size = new System.Drawing.Size(61, 45);
            this.BtncompensatePosX.TabIndex = 132;
            this.BtncompensatePosX.Tag = "1";
            this.BtncompensatePosX.Text = "X";
            this.BtncompensatePosX.UseVisualStyleBackColor = false;
            this.BtncompensatePosX.Click += new System.EventHandler(this.BtncompensatePosX_Click);
            // 
            // BtncompensateNegX
            // 
            this.BtncompensateNegX.BackColor = System.Drawing.Color.Transparent;
            this.BtncompensateNegX.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtncompensateNegX.BackgroundImage")));
            this.BtncompensateNegX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtncompensateNegX.FlatAppearance.BorderSize = 0;
            this.BtncompensateNegX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtncompensateNegX.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.BtncompensateNegX, "");
            this.BtncompensateNegX.Location = new System.Drawing.Point(45, 507);
            this.BtncompensateNegX.Name = "BtncompensateNegX";
            this.BtncompensateNegX.Size = new System.Drawing.Size(61, 45);
            this.BtncompensateNegX.TabIndex = 131;
            this.BtncompensateNegX.Tag = "-1";
            this.BtncompensateNegX.Text = "X";
            this.BtncompensateNegX.UseVisualStyleBackColor = false;
            this.BtncompensateNegX.Click += new System.EventHandler(this.BtncompensatePosX_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(81, 416);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 27);
            this.label13.TabIndex = 138;
            this.label13.Text = "点位微调";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label21.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(1298, 598);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 27);
            this.label21.TabIndex = 146;
            this.label21.Text = "步长";
            // 
            // Step
            // 
            this.Step.BackColor = System.Drawing.Color.Gray;
            this.Step.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Step.Format = "F2";
            this.Step.InputType = HzControl.Communal.Controls.MyTextBox.eInputType.Float;
            this.Step.Location = new System.Drawing.Point(1354, 594);
            this.Step.Name = "Step";
            this.Step.Size = new System.Drawing.Size(88, 34);
            this.Step.TabIndex = 145;
            this.Step.Text = "1";
            this.Step.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label20.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(1297, 407);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 27);
            this.label20.TabIndex = 144;
            this.label20.Text = "速度";
            // 
            // Speed
            // 
            this.Speed.BackColor = System.Drawing.Color.Gray;
            this.Speed.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Speed.Format = "F2";
            this.Speed.Location = new System.Drawing.Point(1354, 404);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(88, 34);
            this.Speed.TabIndex = 143;
            this.Speed.Text = "100";
            this.Speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.button2.Location = new System.Drawing.Point(1196, 555);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 105);
            this.button2.TabIndex = 142;
            this.button2.Tag = "-2";
            this.button2.Text = "Y";
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
            this.button5.Location = new System.Drawing.Point(1196, 374);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 105);
            this.button5.TabIndex = 141;
            this.button5.Tag = "2";
            this.button5.Text = "Y";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
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
            this.button7.Location = new System.Drawing.Point(1274, 477);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(105, 80);
            this.button7.TabIndex = 140;
            this.button7.Tag = "1";
            this.button7.Text = "X";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.Transparent;
            this.button19.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button19.BackgroundImage")));
            this.button19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button19.FlatAppearance.BorderSize = 0;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button19, "");
            this.button19.Location = new System.Drawing.Point(1093, 477);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(105, 80);
            this.button19.TabIndex = 139;
            this.button19.Tag = "-1";
            this.button19.Text = "X";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button19.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // borderPanel3
            // 
            this.borderPanel3.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel3.BorderLineWidth = 2;
            this.borderPanel3.Location = new System.Drawing.Point(895, 351);
            this.borderPanel3.Name = "borderPanel3";
            this.borderPanel3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel3.Size = new System.Drawing.Size(1, 335);
            this.borderPanel3.TabIndex = 138;
            // 
            // borderPanel2
            // 
            this.borderPanel2.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel2.BorderLineWidth = 2;
            this.borderPanel2.Location = new System.Drawing.Point(259, 351);
            this.borderPanel2.Name = "borderPanel2";
            this.borderPanel2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel2.Size = new System.Drawing.Size(1, 335);
            this.borderPanel2.TabIndex = 139;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.label6.Location = new System.Drawing.Point(1375, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 39);
            this.label6.TabIndex = 147;
            this.label6.Text = "轴动";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.label7.Location = new System.Drawing.Point(694, 375);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 27);
            this.label7.TabIndex = 149;
            this.label7.Text = "Z1";
            // 
            // Z1pos
            // 
            this.Z1pos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Z1pos.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Z1pos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.Z1pos.Format = "F2";
            this.Z1pos.KeyBoard = false;
            this.Z1pos.Location = new System.Drawing.Point(639, 404);
            this.Z1pos.Name = "Z1pos";
            this.Z1pos.Size = new System.Drawing.Size(117, 33);
            this.Z1pos.TabIndex = 148;
            this.Z1pos.Text = "666.666";
            this.Z1pos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.label12.Location = new System.Drawing.Point(806, 377);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 27);
            this.label12.TabIndex = 151;
            this.label12.Text = "Z2";
            // 
            // Z2pos
            // 
            this.Z2pos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Z2pos.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold);
            this.Z2pos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(221)))));
            this.Z2pos.Format = "F2";
            this.Z2pos.KeyBoard = false;
            this.Z2pos.Location = new System.Drawing.Point(763, 404);
            this.Z2pos.Name = "Z2pos";
            this.Z2pos.Size = new System.Drawing.Size(122, 33);
            this.Z2pos.TabIndex = 150;
            this.Z2pos.Text = "666.666";
            this.Z2pos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.Transparent;
            this.button20.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button20.BackgroundImage")));
            this.button20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button20.FlatAppearance.BorderSize = 0;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button20, "");
            this.button20.Location = new System.Drawing.Point(902, 555);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(80, 105);
            this.button20.TabIndex = 153;
            this.button20.Tag = "3";
            this.button20.Text = "Z1";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button20.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.Transparent;
            this.button21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button21.BackgroundImage")));
            this.button21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button21.FlatAppearance.BorderSize = 0;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button21, "");
            this.button21.Location = new System.Drawing.Point(902, 374);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(80, 105);
            this.button21.TabIndex = 152;
            this.button21.Tag = "-3";
            this.button21.Text = "Z1";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button21.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.Transparent;
            this.button22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button22.BackgroundImage")));
            this.button22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button22.FlatAppearance.BorderSize = 0;
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button22, "");
            this.button22.Location = new System.Drawing.Point(998, 555);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(80, 105);
            this.button22.TabIndex = 155;
            this.button22.Tag = "4";
            this.button22.Text = "Z2";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button22.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.Transparent;
            this.button23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button23.BackgroundImage")));
            this.button23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button23.FlatAppearance.BorderSize = 0;
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button23, "");
            this.button23.Location = new System.Drawing.Point(998, 374);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(80, 105);
            this.button23.TabIndex = 154;
            this.button23.Tag = "-4";
            this.button23.Text = "Z2";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button23.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button17_MouseUp);
            // 
            // borderPanel4
            // 
            this.borderPanel4.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel4.BorderLineWidth = 2;
            this.borderPanel4.Location = new System.Drawing.Point(0, 351);
            this.borderPanel4.Name = "borderPanel4";
            this.borderPanel4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel4.Size = new System.Drawing.Size(896, 2);
            this.borderPanel4.TabIndex = 139;
            // 
            // borderPanel5
            // 
            this.borderPanel5.BorderColor = System.Drawing.SystemColors.Control;
            this.borderPanel5.BorderLineWidth = 2;
            this.borderPanel5.Location = new System.Drawing.Point(165, 17);
            this.borderPanel5.Name = "borderPanel5";
            this.borderPanel5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borderPanel5.Size = new System.Drawing.Size(1, 335);
            this.borderPanel5.TabIndex = 140;
            // 
            // Lcheck
            // 
            this.Lcheck.AutoSize = true;
            this.Lcheck.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.Lcheck.Location = new System.Drawing.Point(1093, 373);
            this.Lcheck.Name = "Lcheck";
            this.Lcheck.Size = new System.Drawing.Size(81, 35);
            this.Lcheck.TabIndex = 156;
            this.Lcheck.Text = "点动";
            this.Lcheck.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 2;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button6, "");
            this.button6.Location = new System.Drawing.Point(54, 362);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(145, 48);
            this.button6.TabIndex = 157;
            this.button6.Text = "Mark扫描";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // BtncompensatePosR
            // 
            this.BtncompensatePosR.BackColor = System.Drawing.Color.Transparent;
            this.BtncompensatePosR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtncompensatePosR.BackgroundImage")));
            this.BtncompensatePosR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtncompensatePosR.FlatAppearance.BorderSize = 0;
            this.BtncompensatePosR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtncompensatePosR.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.BtncompensatePosR, "");
            this.BtncompensatePosR.Location = new System.Drawing.Point(177, 575);
            this.BtncompensatePosR.Name = "BtncompensatePosR";
            this.BtncompensatePosR.Size = new System.Drawing.Size(66, 65);
            this.BtncompensatePosR.TabIndex = 196;
            this.BtncompensatePosR.Tag = "3";
            this.BtncompensatePosR.Text = "R";
            this.BtncompensatePosR.UseVisualStyleBackColor = false;
            this.BtncompensatePosR.Click += new System.EventHandler(this.BtncompensatePosX_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(895, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 351);
            this.panel1.TabIndex = 197;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.level13333.SetLevel(this.button8, "");
            this.button8.Location = new System.Drawing.Point(12, 580);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(66, 65);
            this.button8.TabIndex = 201;
            this.button8.Tag = "-3";
            this.button8.Text = "R";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.BtncompensatePosX_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 783);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.BtncompensatePosR);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.Lcheck);
            this.Controls.Add(this.borderPanel5);
            this.Controls.Add(this.borderPanel4);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Z2pos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Z1pos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.borderPanel2);
            this.Controls.Add(this.borderPanel3);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.Step);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.compensateValue);
            this.Controls.Add(this.BtncompensateNegY);
            this.Controls.Add(this.BtncompensatePosY);
            this.Controls.Add(this.BtncompensatePosX);
            this.Controls.Add(this.BtncompensateNegX);
            this.Controls.Add(this.Obtain4);
            this.Controls.Add(this.Locate4);
            this.Controls.Add(this.Obtain3);
            this.Controls.Add(this.Locate3);
            this.Controls.Add(this.BackCTY);
            this.Controls.Add(this.CodeY);
            this.Controls.Add(this.CodeX);
            this.Controls.Add(this.BackCTX);
            this.Controls.Add(this.Obtain2);
            this.Controls.Add(this.Locate2);
            this.Controls.Add(this.Obtain1);
            this.Controls.Add(this.Locate1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Mark1Y);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Mark2Y);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Mark2X);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Mark1X);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ypos);
            this.Controls.Add(this.Xpos);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Name = "ProductForm";
            this.Text = "Product";
            this.Load += new System.EventHandler(this.Product_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.treeView1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.Xpos, 0);
            this.Controls.SetChildIndex(this.Ypos, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.Mark1X, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.Mark2X, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.Mark2Y, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.Mark1Y, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.Locate1, 0);
            this.Controls.SetChildIndex(this.Obtain1, 0);
            this.Controls.SetChildIndex(this.Locate2, 0);
            this.Controls.SetChildIndex(this.Obtain2, 0);
            this.Controls.SetChildIndex(this.BackCTX, 0);
            this.Controls.SetChildIndex(this.CodeX, 0);
            this.Controls.SetChildIndex(this.CodeY, 0);
            this.Controls.SetChildIndex(this.BackCTY, 0);
            this.Controls.SetChildIndex(this.Locate3, 0);
            this.Controls.SetChildIndex(this.Obtain3, 0);
            this.Controls.SetChildIndex(this.Locate4, 0);
            this.Controls.SetChildIndex(this.Obtain4, 0);
            this.Controls.SetChildIndex(this.BtncompensateNegX, 0);
            this.Controls.SetChildIndex(this.BtncompensatePosX, 0);
            this.Controls.SetChildIndex(this.BtncompensatePosY, 0);
            this.Controls.SetChildIndex(this.BtncompensateNegY, 0);
            this.Controls.SetChildIndex(this.compensateValue, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.button19, 0);
            this.Controls.SetChildIndex(this.button7, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.Speed, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.Step, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.borderPanel3, 0);
            this.Controls.SetChildIndex(this.borderPanel2, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.Z1pos, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.Z2pos, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.button21, 0);
            this.Controls.SetChildIndex(this.button20, 0);
            this.Controls.SetChildIndex(this.button23, 0);
            this.Controls.SetChildIndex(this.button22, 0);
            this.Controls.SetChildIndex(this.borderPanel4, 0);
            this.Controls.SetChildIndex(this.borderPanel5, 0);
            this.Controls.SetChildIndex(this.Lcheck, 0);
            this.Controls.SetChildIndex(this.button6, 0);
            this.Controls.SetChildIndex(this.BtncompensatePosR, 0);
            this.Controls.SetChildIndex(this.button8, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private HzControl.Communal.Controls.MyTextBox Xpos;
        private HzControl.Communal.Controls.MyTextBox Ypos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private HzControl.Communal.Controls.MyTextBox Mark1X;
        private HzControl.Communal.Controls.MyTextBox Mark1Y;
        private HzControl.Communal.Controls.MyTextBox Mark2Y;
        private HzControl.Communal.Controls.MyTextBox Mark2X;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Obtain1;
        private System.Windows.Forms.Button Locate1;
        private System.Windows.Forms.Button Obtain2;
        private System.Windows.Forms.Button Locate2;
        private System.Windows.Forms.Button Obtain4;
        private System.Windows.Forms.Button Locate4;
        private System.Windows.Forms.Button Obtain3;
        private System.Windows.Forms.Button Locate3;
        private HzControl.Communal.Controls.MyTextBox BackCTY;
        private HzControl.Communal.Controls.MyTextBox CodeY;
        private HzControl.Communal.Controls.MyTextBox CodeX;
        private HzControl.Communal.Controls.MyTextBox BackCTX;
        private HzControl.Communal.Controls.MyTextBox compensateValue;
        private System.Windows.Forms.Button BtncompensateNegY;
        private System.Windows.Forms.Button BtncompensatePosY;
        private System.Windows.Forms.Button BtncompensatePosX;
        private System.Windows.Forms.Button BtncompensateNegX;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private HzControl.Communal.Controls.MyTextBox Speed;
        private BorderPanel borderPanel3;
        private BorderPanel borderPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private HzControl.Communal.Controls.MyTextBox Z1pos;
        private System.Windows.Forms.Label label12;
        private HzControl.Communal.Controls.MyTextBox Z2pos;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private BorderPanel borderPanel4;
        private BorderPanel borderPanel5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加产品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除产品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 阵列ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 添加点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修正点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 定位点ToolStripMenuItem;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button BtncompensatePosR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.Button button7;
        public System.Windows.Forms.Button button19;
        public System.Windows.Forms.CheckBox Lcheck;
        public MyTextBox Step;
        public System.Windows.Forms.Button button20;
        public System.Windows.Forms.Button button21;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button8;
    }
}