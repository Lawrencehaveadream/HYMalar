using CommonRs;
using HalconDotNet;
using HzControl.Communal.Controls;
using HzVision;
using HZZH.Database;
using HZZH.Logic.Commmon;
using HZZH.Logic.LogicMain;
using HZZH.Logic.Project;
using HZZH.UI2.上料机;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;

namespace HZZH.UI2.麦拉机.参数设置
{
    public partial class ProductForm : MenuForm
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        protected override void OnShown()
        {
            base.OnShown();
            camera1.ID = 0;
            RefreshTreeView();
        }
        private void Product_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            RefreshTreeView();
            if (Database.Product.Inst.Stickdata.TrayData.ProductList.Count > 0)
            {
                RefreshTableList();
            }
            InitVisionControl();
        }
        private void Disenabled()
        {
            Mark1X.Enabled = Mark1Y.Enabled = Mark2X.Enabled = Mark2Y.Enabled = false;
            BackCTX.Enabled = BackCTY.Enabled = CodeX.Enabled = CodeY.Enabled = false;
            Obtain1.Enabled = Obtain2.Enabled = Obtain3.Enabled = Obtain4.Enabled = false;
            Locate1.Enabled = Locate2.Enabled = Locate3.Enabled = Locate4.Enabled = false;
        }
        private void Enable()
        {
            Mark1X.Enabled = Mark1Y.Enabled = Mark2X.Enabled = Mark2Y.Enabled = true;
            BackCTX.Enabled = BackCTY.Enabled = CodeX.Enabled = CodeY.Enabled = true;
            Obtain1.Enabled = Obtain2.Enabled = Obtain3.Enabled = Obtain4.Enabled = true;
            Locate1.Enabled = Locate2.Enabled = Locate3.Enabled = Locate4.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Xpos.Text = DeviceRsDef.Axis_X.currPos.ToString();
            Ypos.Text = DeviceRsDef.Axis_Y.currPos.ToString();
            Z1pos.Text = DeviceRsDef.Axis_Z1.currPos.ToString();
            Z2pos.Text = DeviceRsDef.Axis_Z2.currPos.ToString();
            if (Database.Product.Inst.Stickdata.TrayData.ProductList.Count > 0)
            {
                Enable();
            }
            else
            {
                Disenabled();
            }
        }
        private void Locate1_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(Mark1X.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(Mark1Y.Text);
            TaskMain.move.Start();
        }

        private void Locate2_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(Mark2X.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(Mark2Y.Text);
            TaskMain.move.Start();
        }

        private void Locate3_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(BackCTX.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(BackCTY.Text);
            TaskMain.move.Start();
        }

        private void Locate4_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = (float)Convert.ToDouble(CodeX.Text);
            TaskMain.move.targetPos.Y = (float)Convert.ToDouble(CodeY.Text);
            TaskMain.move.Start();
        }
        #region 轴动
        public void button17_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Lcheck.Checked)
            {
                switch (Convert.ToInt32(((Button)sender).Tag))
                {
                    case 1:
                        CTRCard.Axis_X.MC_Stop();
                        break;
                    case 2:
                        CTRCard.Axis_Y.MC_Stop();
                        break;
                    case 3:
                        CTRCard.Axis_Z[0].MC_Stop();
                        break;
                    case 4:
                        CTRCard.Axis_Z[1].MC_Stop();
                        break;
                    case -1:
                        CTRCard.Axis_X.MC_Stop();
                        break;
                    case -2:
                        CTRCard.Axis_Y.MC_Stop();
                        break;
                    case -3:
                        CTRCard.Axis_Z[0].MC_Stop();
                        break;
                    case -4:
                        CTRCard.Axis_Z[1].MC_Stop();
                        break;
                }
            }
        }
        public void button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Lcheck.Checked)
            {
                switch (Convert.ToInt32(((Button)sender).Tag))
                {
                    case 1:
                        CTRCard.Axis_X.MC_MoveSpd((float)Convert.ToDouble(Speed.Text));
                        break;
                    case 2:
                        CTRCard.Axis_Y.MC_MoveSpd((float)Convert.ToDouble(Speed.Text));
                        break;
                    case 3:
                        CTRCard.Axis_Z[0].MC_MoveSpd((float)Convert.ToDouble(Speed.Text));
                        break;
                    case 4:
                        CTRCard.Axis_Z[1].MC_MoveSpd((float)Convert.ToDouble(Speed.Text));
                        break;
                    case -1:
                        CTRCard.Axis_X.MC_MoveSpd(-(float)Convert.ToDouble(Speed.Text));
                        break;
                    case -2:
                        CTRCard.Axis_Y.MC_MoveSpd(-(float)Convert.ToDouble(Speed.Text));
                        break;
                    case -3:
                        CTRCard.Axis_Z[0].MC_MoveSpd(-(float)Convert.ToDouble(Speed.Text));
                        break;
                    case -4:
                        CTRCard.Axis_Z[1].MC_MoveSpd(-(float)Convert.ToDouble(Speed.Text));
                        break;
                }
            }
            if (Lcheck.Checked)
            {
                switch (Convert.ToInt32(((Button)sender).Tag))
                {
                    case 1:
                        CTRCard.Axis_X.MC_MoveRel((float)Convert.ToDouble(Step.Text));
                        break;
                    case 2:
                        CTRCard.Axis_Y.MC_MoveRel((float)Convert.ToDouble(Step.Text));
                        break;
                    case 3:
                        CTRCard.Axis_Z[0].MC_MoveRel((float)Convert.ToDouble(Step.Text));
                        break;
                    case 4:
                        CTRCard.Axis_Z[1].MC_MoveRel((float)Convert.ToDouble(Step.Text));
                        break;
                    case -1:
                        CTRCard.Axis_X.MC_MoveRel(-(float)Convert.ToDouble(Step.Text));
                        break;
                    case -2:
                        CTRCard.Axis_Y.MC_MoveRel(-(float)Convert.ToDouble(Step.Text));
                        break;
                    case -3:
                        CTRCard.Axis_Z[0].MC_MoveRel(-(float)Convert.ToDouble(Step.Text));
                        break;
                    case -4:
                        CTRCard.Axis_Z[1].MC_MoveRel(-(float)Convert.ToDouble(Step.Text));
                        break;
                }
            }
        }
        #endregion
        #region 产品
        private Hashtable NodesStatus = new Hashtable();
        private string SelectNodeFullPath = string.Empty;
        public static int product_num = 0;
        private Frm_ThreePArray frm_ThreePArray;
        public static bool flag_Arry = false;
        /// <summary>
        /// 获取节点
        /// </summary>
        /// <param name="nodes"> </param>
        private void GetTreeNodesStatus(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.IsExpanded)
                {
                    NodesStatus[node.FullPath] = true;
                }
                else
                {
                    NodesStatus.Remove(node.FullPath);
                }
                if (node.IsSelected)
                {
                    SelectNodeFullPath = node.FullPath;
                }
                GetTreeNodesStatus(node.Nodes);
            }
        }
        /// <summary>
        /// 设置节点
        /// </summary>
        /// <param name="nodes"> </param>
        private void SetTreeNodesStatus(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (NodesStatus[node.FullPath] != null)
                {
                    node.Expand();
                }
                if (node.FullPath == SelectNodeFullPath)
                {
                    treeView1.SelectedNode = node;
                }
                SetTreeNodesStatus(node.Nodes);
            }
        }

        /// <summary>
        /// 更新树形表
        /// </summary>
        public void RefreshTreeView()
        {
            try
            {
                if (Database.Product.Inst.Stickdata.TrayData.ProductList == null) return;
                //GetTreeNodesStatus(treeView1.Nodes);
                treeView1.Nodes.Clear();
                for (int i = 0; i < Database.Product.Inst.Stickdata.TrayData.ProductList.Count; i++)
                {
                    TreeNode TreeNodeTerm = new TreeNode("产品" + (i + 1));
                    treeView1.Nodes.Add(TreeNodeTerm);
                }
                if (Database.Product.Inst.Stickdata.TrayData.ProductList.Count >= 1)
                {
                    treeView1.SelectedNode = treeView1.Nodes[0];
                }
                //SetTreeNodesStatus(treeView1.Nodes);
            }
            catch (Exception ex)  
            {
                
            }
        }

        private void 添加产品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductDef product = new ProductDef();
            Database.Product.Inst.Stickdata.TrayData.ProductList.Add(product);
            RefreshTreeView();
            product_num = 0;
        }
        private void 删除产品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nn = Database.Product.Inst.Stickdata.TrayData.ProductList.Count;
            if (nn > 0)
            {
                if (product_num < nn && product_num > -1)
                    Database.Product.Inst.Stickdata.TrayData.ProductList.RemoveAt(product_num);
                else
                    Database.Product.Inst.Stickdata.TrayData.ProductList.RemoveAt(nn - 1);
            }
            RefreshTreeView();
            product_num = 0;
        }
        private void 阵列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag_Arry = true;
            if (frm_ThreePArray == null || !frm_ThreePArray.Created)
            {
                frm_ThreePArray = new Frm_ThreePArray();
                ((Button)frm_ThreePArray.Controls["buttonArr"]).Click += (s, ea) =>
                {
                    int index = product_num;
                    if (index > -1 && Database.Product.Inst.Stickdata.TrayData.ProductList.Count > 0)
                    {
                        Database.Product.Inst.Stickdata.TrayData.ProductList.RemoveAt(index);
                        for (int i = 0; i < frm_ThreePArray.tempProduct.Count; i++)
                        {
                            Database.Product.Inst.Stickdata.TrayData.ProductList.Add(frm_ThreePArray.tempProduct[i].Clone());
                        }
                    }
                    RefreshTreeView();
                };
            }
            //frm_ThreePArray.Owner = this;
            frm_ThreePArray.Show();
            frm_ThreePArray.BringToFront();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode != null)
                {
                    Point ClickPoint = new Point(e.X, e.Y);
                    TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);

                    string str = CurrentNode.Text;
                    if (str.IndexOf("产品") != -1)
                    {
                        string str1 = str.Substring(2);
                        int n = Convert.ToInt32(str1);
                        product_num = n - 1;
                        RefreshTableList();
                    }
                    else
                    {
                        product_num = -1;
                        ProductDef _product = new ProductDef();
                        RefreshTableList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        PointF4 Mark1;
        PointF4 Mark2;
        PointF2 Code;
        PointF2 BackCT;
        private void RefreshTableList()
        {
            var Product = Database.Product.Inst.Stickdata.TrayData.ProductList[product_num];
            Mark1 = Product.MarkPoint[0];
            Mark2 = Product.MarkPoint[1];
            Code = Product.CodePoint2;
            BackCT = Product.BackCT;


            Mark1X.Text = Mark1.X.ToString();
            Mark1Y.Text = Mark1.Y.ToString();
            Mark2X.Text = Mark2.X.ToString();
            Mark2Y.Text = Mark2.Y.ToString();
            BackCTX.Text = BackCT.X.ToString();
            BackCTY.Text = BackCT.Y.ToString();
            CodeX.Text = Code.X.ToString();
            CodeY.Text = Code.Y.ToString();
            
            dataGridView1.AutoGenerateColumns = false;
            BindingSource source = new BindingSource();
            source.DataSource = Product.SiteList;
            dataGridView1.DataSource = source;
            dataGridView1.Columns[0].DataPropertyName = "SitePoint_num";
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Format = "0";
            dataGridView1.Columns[1].DataPropertyName = "X";
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Format = "00.000";
            dataGridView1.Columns[2].DataPropertyName = "Y";
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Format = "00.000";
            dataGridView1.Columns[3].DataPropertyName = "R";
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Format = "00.000";
            dataGridView1.Columns[4].DataPropertyName = "Z";
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "00.000";

        }
        private void SaveProductData(ProductDef product)
        {
            Mark1 = product.MarkPoint[0];
            Mark2 = product.MarkPoint[1];
            Code = product.CodePoint2;
            BackCT = product.BackCT;
            
            Mark1.X = (float)Convert.ToDouble(Mark1X.Text);    
            Mark1.Y = (float)Convert.ToDouble(Mark1Y.Text); 
            Mark2.X = (float)Convert.ToDouble(Mark2X.Text); 
            Mark2.Y = (float)Convert.ToDouble(Mark2Y.Text);
            BackCT.X = (float)Convert.ToDouble(BackCTX.Text);
            BackCT.Y = (float)Convert.ToDouble(BackCTY.Text); 
            Code.X = (float)Convert.ToDouble(CodeX.Text); 
            Code.Y = (float)Convert.ToDouble(CodeY.Text); 
        }
        #endregion

        private void 添加点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int type = 0;

            if (Database.Product.Inst.Stickdata.TrayData.ProductList.Count < 1)
            {
                ProductDef product = new ProductDef();
                Database.Product.Inst.Stickdata.TrayData.ProductList.Add(product);
                product_num = 0;
                RefreshTreeView();
            }

            PointF4 point = new PointF4();
            HTuple X = new HTuple();
            HTuple Y = new HTuple();

            if (TaskMain.sticklogic.markscan.GetDone &&
                TaskMain.sticklogic.markscan.MarkResult.Count > 0 &&
                TaskMain.sticklogic.markscan.MarkResult.Count >= (product_num * 2 + 1))
            {
                //VisionProject.Instance.SetBenchmark1(Database.Product.Inst.Stickdata.TrayData.ProductList[product_num].MarkPoint[0].X,
                //    Database.Product.Inst.Stickdata.TrayData.ProductList[product_num].MarkPoint[0].Y,
                //    Database.Product.Inst.Stickdata.TrayData.ProductList[product_num].MarkPoint[0].R,
                //    0, Database.Product.Inst.Stickdata.TrayData.MarkMode == 0 ? false : true);

                //VisionProject.Instance.SetBenchmark1(Database.Product.Inst.Stickdata.TrayData.ProductList[product_num].MarkPoint[1].X,
                //    Database.Product.Inst.Stickdata.TrayData.ProductList[product_num].MarkPoint[1].Y,
                //    Database.Product.Inst.Stickdata.TrayData.ProductList[product_num].MarkPoint[1].R,
                //    1, Database.Product.Inst.Stickdata.TrayData.MarkMode == 0 ? false : true);


                //VisionProject.Instance.SetBenchmark2(TaskMain.sticklogic.markscan.MarkResult[product_num * 2].X,
                //TaskMain.sticklogic.markscan.MarkResult[product_num * 2].Y,
                //    TaskMain.sticklogic.markscan.MarkResult[product_num * 2].R,
                //    0, Database.Product.Inst.Stickdata.TrayData.MarkMode == 0 ? false : true);

                //VisionProject.Instance.SetBenchmark2(TaskMain.sticklogic.markscan.MarkResult[product_num * 2 + 1].X,
                //    TaskMain.sticklogic.markscan.MarkResult[product_num * 2 + 1].Y,
                //    TaskMain.sticklogic.markscan.MarkResult[product_num * 2 + 1].R,
                //    1, Database.Product.Inst.Stickdata.TrayData.MarkMode == 0 ? false : true);

                //VisionProject.Instance.ReverseTransPoint2d(DeviceRsDef.Axis_X.currPos, DeviceRsDef.Axis_Y.currPos,
                //    out X, out Y, Database.Product.Inst.Stickdata.TrayData.MarkMode == 0 ? false : true);

            }
            else
            {
                MessageBox.Show("先扫描mark点");
                return;
            }

            SitePoint site = new SitePoint();
            site.X = X[0].F;
            site.Y = Y[0].F;
            site.Z = 1f;
            site.R = 0;
            site.LableType = type;
            site.Product_num = product_num;
            site.SitePoint_num = Database.Product.Inst.Stickdata.TrayData.ProductList[product_num].SiteList.Count;

            Database.Product.Inst.Stickdata.TrayData.ProductList[product_num].SiteList.Add(site);
            RefreshTableList();
        }

        private void 删除点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("No data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {
                    if (dataGridView1.Rows[i].Cells[0].Selected == true)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }
                    k = i;
                }
            }
        }

        private void 修正点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (product_num != 0)
                {
                    return;
                }
                if (dataGridView1.CurrentRow == null) return;
                int num = dataGridView1.CurrentRow.Index;
                PointF4 point = new PointF4();
                point.X = DeviceRsDef.Axis_X.currPos;
                point.Y = DeviceRsDef.Axis_Y.currPos;
                point.Z = 1f;
                point.R = 0;
                if (MessageBox.Show("修改前，请确保定位到了需要校阵的点", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value = point.X.ToString("f2");
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value = point.Y.ToString("f2");
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[3].Value = point.R.ToString("f2");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private PointF4 Point_revise = new PointF4();
        private void 定位点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SitePoint site = new SitePoint();

            int num = dataGridView1.CurrentRow.Index;
            site = Database.Product.Inst.Stickdata.TrayData.ProductList[product_num].SiteList[num].Clone();
            TaskMain.move.targetPos.X = site.X;
            TaskMain.move.targetPos.Y = site.Y;
            TaskMain.move.Start();

            Point_revise.X = site.X;
            Point_revise.Y = site.Y;
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
        }
        private void Mark1X_MouseLeave(object sender, EventArgs e)
        {
            if (Database.Product.Inst.Stickdata.TrayData.ProductList.Count > 0)
            {
                SaveProductData(Database.Product.Inst.Stickdata.TrayData.ProductList[product_num]);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TaskMain.sticklogic.markscan.Start();
        }

        private void Obtain1_Click(object sender, EventArgs e)
        {
            Mark1X.Text = DeviceRsDef.Axis_X.currPos.ToString();
            Mark1Y.Text = DeviceRsDef.Axis_Y.currPos.ToString();
            SaveProductData(Database.Product.Inst.Stickdata.TrayData.ProductList[product_num]);
        }

        private void Obtain2_Click(object sender, EventArgs e)
        {
            Mark2X.Text = DeviceRsDef.Axis_X.currPos.ToString();
            Mark2Y.Text = DeviceRsDef.Axis_Y.currPos.ToString();
            SaveProductData(Database.Product.Inst.Stickdata.TrayData.ProductList[product_num]);
        }

        private void Obtain3_Click(object sender, EventArgs e)
        {
            BackCTX.Text = DeviceRsDef.Axis_X.currPos.ToString();
            BackCTY.Text = DeviceRsDef.Axis_Y.currPos.ToString();
            SaveProductData(Database.Product.Inst.Stickdata.TrayData.ProductList[product_num]);
        }

        private void Obtain4_Click(object sender, EventArgs e)
        {
            CodeX.Text = DeviceRsDef.Axis_X.currPos.ToString();
            CodeY.Text = DeviceRsDef.Axis_Y.currPos.ToString();
            SaveProductData(Database.Product.Inst.Stickdata.TrayData.ProductList[product_num]);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            product_num = treeView1.SelectedNode.Index;
            RefreshTableList();
        }

        private void BtncompensatePosX_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Index < 0 || treeView1.SelectedNode.Index > Database.Product.Inst.Stickdata.TrayData.ProductList.Count - 1)
            {
                return;
            }
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }
            var ProductNum = treeView1.SelectedNode.Index;
            var PointNum = dataGridView1.SelectedRows[0].Index;
            switch (Convert.ToInt32(((Button)sender).Tag))
            {
                case 1:
                    Database.Product.Inst.Stickdata.TrayData.ProductList[ProductNum].SiteList[PointNum].X += Convert.ToSingle(compensateValue.Text);
                    break;
                case 2:
                    Database.Product.Inst.Stickdata.TrayData.ProductList[ProductNum].SiteList[PointNum].Y += Convert.ToSingle(compensateValue.Text);
                    break;
                case 3:
                    Database.Product.Inst.Stickdata.TrayData.ProductList[ProductNum].SiteList[PointNum].R += Convert.ToSingle(compensateValue.Text);
                    break;
                case -1:
                    Database.Product.Inst.Stickdata.TrayData.ProductList[ProductNum].SiteList[PointNum].X -= Convert.ToSingle(compensateValue.Text);
                    break;
                case -2:
                    Database.Product.Inst.Stickdata.TrayData.ProductList[ProductNum].SiteList[PointNum].Y -= Convert.ToSingle(compensateValue.Text);
                    break;
                case -3:
                    Database.Product.Inst.Stickdata.TrayData.ProductList[ProductNum].SiteList[PointNum].R -= Convert.ToSingle(compensateValue.Text);
                    break;
            }
            ((BindingSource)dataGridView1.DataSource).ResetCurrentItem();
        }
        int n = 0;
        private void BtncompensateValue_DoubleClick(object sender, EventArgs e)
        {
            n++;
            compensateValue.Text = "0.01";
            switch (n%3)
            {
                case 0:
                    compensateValue.Text = "0.01";
                    break;
                case 1:
                    compensateValue.Text = "0.1";
                    break;
                case 2:
                    compensateValue.Text = "1";
                    break;
            }
            if (n > 65500)
            {
                n = 0;
            }
        }

        HzVision.Device.MainCamera camera1;
        private void InitVisionControl()
        {
            camera1 = new HzVision.Device.MainCamera();
            for (int i = 0; i < 6; i++)
            {
                camera1.ContextMenuStrip.Items[i].Visible = false;
            }
            camera1.Draw += Camera1_Draw;
            camera1.DisplayCross = true;
            this.Disposed += (s, e) => camera1.Dispose();
            panel1.Controls.Add(camera1);
            camera1.Dock = DockStyle.Fill;
            camera1.ID = 0;
        }

  

        private void Camera1_Draw(object sender, HzVision.Device.DrawEventArgs e)
        {
            e.HWindow.SetDraw("margin");
            e.HWindow.SetColor("blue");
            e.HWindow.SetLineWidth(1);

            Product.Inst.TchRect.StkRect.X = ((HzVision.Device.MainCamera)sender).Camera.ImageSize.Width / 2.0;
            Product.Inst.TchRect.StkRect.Y = ((HzVision.Device.MainCamera)sender).Camera.ImageSize.Height / 2.0;

            double row = Product.Inst.TchRect.StkRect.Y;
            double col = Product.Inst.TchRect.StkRect.X;
            double phi = Product.Inst.TchRect.StkRect.Angle * Math.PI / 180;
            double length1 = Math.Max(1, Product.Inst.TchRect.StkRect.MajorAxis);
            double length2 = Math.Max(1, Product.Inst.TchRect.StkRect.MinorAxis);
            e.HWindow.DispRectangle2(row, col, phi, length1, length2);
        }
    }
}
