using HzVision.Device;
using HZZH.UI2.上料机;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace HZZH.UI2.麦拉机.参数设置
{
    public partial class VisForm2 : MenuForm
    {
        public VisForm2()
        {
            InitializeComponent();

            Vision.VisionProject.Instance.InitVisionProject();
            Database.Product.Inst.LoadEvent += Inst_LoadEvent;
            Database.Product.Inst.SaveEvent += Inst_SaveEvent;
            if (Database.Product.Inst.FilePath != null)
            {
                Vision.VisionProject.Instance.LoadTool(Database.Product.Inst.FilePath + "vis.tool");
            }
        }

        private void VisForm2_Load(object sender, EventArgs e)
        {
            InitVisionControl();
        }

        void Inst_SaveEvent(object sender, EventArgs e)
        {
            Vision.VisionProject.Instance.SaveTool(Database.Product.Inst.FilePath + "vis.tool");
        }

        void Inst_LoadEvent(object sender, EventArgs e)
        {
            Vision.VisionProject.Instance.LoadTool(Database.Product.Inst.FilePath + "vis.tool");
        }


        MainCamera camera1;
        MainCamera camera2;
        private void InitVisionControl()
        {
            camera1 = new MainCamera();
            this.Disposed += (s, e) => camera1.Dispose();
            panel1.Controls.Add(camera1);
            camera1.Dock = DockStyle.Fill;
            camera1.ID = 0;

            camera2 = new MainCamera();
            this.Disposed += (s, e) => camera2.Dispose();
            panel2.Controls.Add(camera2);
            camera2.Dock = DockStyle.Fill;
            camera2.ID = 1;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            HImage hImage = CameraMgr.Inst[0].GetCurrentImage();
            Vision.VisionProject.Instance.SetTempleteModel(0, hImage);
            Vision.VisionProject.Instance.DisplayShapeModel(0, this.hWindowControl1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HImage hImage = CameraMgr.Inst[0].GetCurrentImage();
            Vision.VisionProject.Instance.SetTempleteModel(1, hImage);
            Vision.VisionProject.Instance.DisplayShapeModel(1, this.hWindowControl2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HImage hImage = CameraMgr.Inst[0].GetCurrentImage();
            Vision.VisionProject.Instance.SetTempleteModel(2, hImage);
            Vision.VisionProject.Instance.DisplayShapeModel(2, this.hWindowControl3);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            HImage hImage = CameraMgr.Inst[1].GetCurrentImage();
            Vision.VisionProject.Instance.SetTempleteModel(3, hImage);
            Vision.VisionProject.Instance.DisplayShapeModel(3, this.hWindowControl4);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            VisCalib calib = (VisCalib)FrmMgr.GetFormInst<VisCalib>(0);
            calib.CalibSetData = new CalibSet()
            {
                PlatformMove = Vision.Logic.MotionPlatform.MotionPlat,
                GetImage = HzVision.Device.CameraMgr.Inst[0],
                Calib = Vision.VisionProject.Instance.Tool.Calibs[0]
            };
            FrmMgr.Show("VisCalib," + 0);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            VisCalib calib = (VisCalib)FrmMgr.GetFormInst<VisCalib>(1);
            calib.CalibSetData = new CalibSet()
            {
                PlatformMove = Vision.Logic.MotionPlatform.MotionPlat,
                GetImage = HzVision.Device.CameraMgr.Inst[1],
                Calib = Vision.VisionProject.Instance.Tool.Calibs[1]
            };
            FrmMgr.Show("VisCalib," + 1);
        }

        protected override void OnShown()
        {
            base.OnShown();
            Vision.VisionProject.Instance.DisplayShapeModel(0, this.hWindowControl1);
            Vision.VisionProject.Instance.DisplayShapeModel(1, this.hWindowControl2);
            Vision.VisionProject.Instance.DisplayShapeModel(2, this.hWindowControl3);
            Vision.VisionProject.Instance.DisplayShapeModel(3, this.hWindowControl4);
        }
    }
}
