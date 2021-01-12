using HalconDotNet;
using ProVision.InteractiveROI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.Tool.Model;

namespace HzVision
{
    public partial class Frm_CheckStick : Form
    {
        public Frm_CheckStick()
        {
            InitializeComponent();
        }

        private HWndCtrller hWndCtrller = null;
        ROI rOI = null;
        ROICtrller ctrller = new ROICtrller();


        private void Frm_CheckStick_Load(object sender, EventArgs e)
        {
            hWndCtrller = new HWndCtrllerEx(hWindowControl1);
            hWndCtrller.ChangeGraphicSettings("DrawMode", "margin");
            hWndCtrller.ChangeGraphicSettings("Color", "green");

            ((HWndCtrllerEx)hWndCtrller).Paint += Frm_CheckStick_Paint;
            hWindowControl1.SizeChanged += (s, ev) => { hWndCtrller.Repaint(); };

            hWindowControl1.HMouseMove += HWindowControl1_HMouseMove;
            hWindowControl1.HMouseUp += HWindowControl1_HMouseUp;
            hWindowControl1.HMouseWheel += HWindowControl1_HMouseWheel;
            hWndCtrller.RegisterROICtroller(ctrller);


            ShapeModel model = VisionProject.Instance.visionTool.checkStick.Location;
            if (model.ModelImg != null && model.ModelImg.IsInitialized())
            {
                hWndCtrller.AddIconicVar(model.ModelImg.Clone());
                hWndCtrller.Repaint();
            }
            hWindowControl1.HalconWindow.SetColor("blue");
            foreach (var item in VisionProject.Instance.visionTool.checkStick.CheckRegion)
            {
                if (item != null && item.IsInitialized())
                {
                    this.hWindowControl1.HalconWindow.DispObj(item);
                }
            }
            trackBar1.Value = (int)VisionProject.Instance.visionTool.checkStick.Threshold;
            DrawRegionCtrlFlag = 0;

            if (VisionProject.Instance.visionApi.CheckStick.Count == 4)
            {
                label3.Text = string.Format("上:X={0:0.00},Y={1:0.00},R={2:0.00}",
                    VisionProject.Instance.visionApi.CheckStick[0].X,
                    VisionProject.Instance.visionApi.CheckStick[0].Y,
                    VisionProject.Instance.visionApi.CheckStick[0].R);
                label5.Text = string.Format("下:X={0:0.00},Y={1:0.00},R={2:0.00}",
                    VisionProject.Instance.visionApi.CheckStick[1].X,
                    VisionProject.Instance.visionApi.CheckStick[1].Y,
                    VisionProject.Instance.visionApi.CheckStick[1].R);
                label4.Text = string.Format("左:X={0:0.00},Y={1:0.00},R={2:0.00}",
                    VisionProject.Instance.visionApi.CheckStick[2].X,
                    VisionProject.Instance.visionApi.CheckStick[2].Y,
                    VisionProject.Instance.visionApi.CheckStick[2].R);
                label6.Text = string.Format("右:X={0:0.00},Y={1:0.00},R={2:0.00}",
                    VisionProject.Instance.visionApi.CheckStick[3].X,
                    VisionProject.Instance.visionApi.CheckStick[3].Y,
                    VisionProject.Instance.visionApi.CheckStick[3].R);
            }
        }

        private void Frm_CheckStick_Paint(object sender, EventArgs e)
        {
            if (DrawRegionCtrlFlag > 0)
            {
                hWindowControl1.HalconWindow.SetColor("blue");
                foreach (var item in VisionProject.Instance.visionTool.checkStick.CheckRegion)
                {
                    if (item != null && item.IsInitialized())
                    {
                        this.hWindowControl1.HalconWindow.DispObj(item);
                    }
                }
            }
        }

        private void HWindowControl1_HMouseWheel(object sender, HMouseEventArgs e)
        {
            hWndCtrller.SetViewMode(HWndCtrller.MODE_VIEW_ZOOM);
        }

        private void HWindowControl1_HMouseUp(object sender, HMouseEventArgs e)
        {
            HRegion region = null;
            if (ctrller.ROIList.Count > 0)
            {
                if (ctrller.DefineModelROI())
                {
                    region = ctrller.GetModelRegion();
                }

                if (DrawRegionCtrlFlag > 0 && DrawRegionCtrlFlag <= 4)
                {
                    if (VisionProject.Instance.visionTool.checkStick.CheckRegion[DrawRegionCtrlFlag - 1] != null)
                    {
                        VisionProject.Instance.visionTool.checkStick.CheckRegion[DrawRegionCtrlFlag - 1].Dispose();
                    }
                    VisionProject.Instance.visionTool.checkStick.CheckRegion[DrawRegionCtrlFlag - 1] = region.Clone();
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                hWndCtrller.ResetWindow();
            }

            hWndCtrller.Repaint();
            hWndCtrller.SetViewMode(HWndCtrller.MODE_VIEW_NONE);
        }

        private void HWindowControl1_HMouseMove(object sender, HMouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void hWindowControl1_HMouseDown(object sender, HMouseEventArgs e)
        {
            if (ctrller.ActiveROIIndex < 0 && rOI == null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    hWndCtrller.SetViewMode(HWndCtrller.MODE_VIEW_MOVE);
                }
            }
            rOI = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HImage hImage = VisionProject.Instance.Camera[0].GetCurrentImage();
            ctrller.Reset();
            hWndCtrller.AddIconicVar(hImage.Clone());
            DrawRegionCtrlFlag = 0;
            hWndCtrller.Repaint();

            ShapeModel model = VisionProject.Instance.visionTool.checkStick.Location;
            if (model.InputImg != null)
            {
                model.InputImg.Dispose();
            }
            model.InputImg = hImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShapeModel model = VisionProject.Instance.visionTool.checkStick.Location;
            model.ShowSetting();
        }

        int DrawRegionCtrlFlag = 0;      
        private void button1_Click(object sender, EventArgs e)
        {
            rOI = new ROIRectangle1();
            ctrller.Reset();
            ctrller.SetROISign(ROICtrller.SIGN_ROI_POS);
            ctrller.SetROIShape(rOI);

            DrawRegionCtrlFlag = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rOI = new ROIRectangle1();
            ctrller.Reset();
            ctrller.SetROISign(ROICtrller.SIGN_ROI_POS);
            ctrller.SetROIShape(rOI);

            DrawRegionCtrlFlag = 4;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rOI = new ROIRectangle1();
            ctrller.Reset();
            ctrller.SetROISign(ROICtrller.SIGN_ROI_POS);
            ctrller.SetROIShape(rOI);

            DrawRegionCtrlFlag = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rOI = new ROIRectangle1();
            ctrller.Reset();
            ctrller.SetROISign(ROICtrller.SIGN_ROI_POS);
            ctrller.SetROIShape(rOI);

            DrawRegionCtrlFlag = 3;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            VisionProject.Instance.visionTool.checkStick.Threshold = trackBar1.Value;
            CheckStick();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }


        private void CheckStick()
        {
            ShapeModel model = VisionProject.Instance.visionTool.checkStick.Location;
            if (model.ModelImg == null && model.ModelImg.IsInitialized()==false)
            {
                return;
            }

            hWndCtrller.AddIconicVar(model.ModelImg.Clone());
            hWndCtrller.ChangeGraphicSettings("Color", "blue");
            foreach (var item in VisionProject.Instance.visionTool.checkStick.CheckRegion)
            {
                if (item != null && item.IsInitialized())
                {
                    hWndCtrller.AddIconicVar(item.Clone());
                }
            }

            foreach (var item in VisionProject.Instance.visionTool.checkStick.CheckRegion)
            {
                if (item == null || item.IsInitialized() == false)
                {
                    continue;
                }

                HObject imageReduce = null;
                HOperatorSet.ReduceDomain(model.ModelImg, item, out imageReduce);
                HObject region;
                HOperatorSet.Threshold(imageReduce, out region, 0, VisionProject.Instance.visionTool.checkStick.Threshold);
                imageReduce.Dispose();
                HObject openingRegion;
                HOperatorSet.OpeningCircle(region, out openingRegion, 15);
                region.Dispose();
                HObject transRegion;
                HOperatorSet.ShapeTrans(openingRegion, out transRegion, "rectangle2");
                openingRegion.Dispose();

                hWndCtrller.ChangeGraphicSettings("Color", "yellow");
                hWndCtrller.AddIconicVar(transRegion);
                hWndCtrller.Repaint();
            }
        
        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HImage hImage = VisionProject.Instance.Camera[0].GetCurrentImage();
            ctrller.Reset();
            hWndCtrller.AddIconicVar(hImage.Clone());
            DrawRegionCtrlFlag = 0;

            VisionProject.Instance.CheckStick(this.hWindowControl1);

            if (VisionProject.Instance.visionApi.CheckStick.Count == 4)
            {
                label3.Text = string.Format("上:X={0:0.00},Y={1:0.00},R={2:0.00}",
                    VisionProject.Instance.visionApi.CheckStick[0].X, 
                    VisionProject.Instance.visionApi.CheckStick[0].Y,
                    VisionProject.Instance.visionApi.CheckStick[0].R);
                label5.Text = string.Format("下:X={0:0.00},Y={1:0.00},R={2:0.00}",
                    VisionProject.Instance.visionApi.CheckStick[1].X,
                    VisionProject.Instance.visionApi.CheckStick[1].Y,
                    VisionProject.Instance.visionApi.CheckStick[1].R);
                label4.Text = string.Format("左:X={0:0.00},Y={1:0.00},R={2:0.00}",
                    VisionProject.Instance.visionApi.CheckStick[2].X,
                    VisionProject.Instance.visionApi.CheckStick[2].Y,
                    VisionProject.Instance.visionApi.CheckStick[2].R);
                label6.Text = string.Format("右:X={0:0.00},Y={1:0.00},R={2:0.00}",
                    VisionProject.Instance.visionApi.CheckStick[3].X,
                    VisionProject.Instance.visionApi.CheckStick[3].Y,
                    VisionProject.Instance.visionApi.CheckStick[3].R);
            }

        }
    }
}
