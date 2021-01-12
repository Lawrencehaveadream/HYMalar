//using HZZH.Logic.LogicMain;
using HzControl.Logic;
using HZZH.Logic.LogicMain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.UI2.上料机.参数设置
{
    public partial class 手动 : MenuForm
    {
        public 手动()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TaskMain.sticklogic.markscan.Start();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            TaskMain.feed.Start();
        }

        private void BtnTakelabel_Click(object sender, EventArgs e)
        {
            TaskMain.sticklogic.takelabel.Start();
        }

        private void BtnDownCCD_Click(object sender, EventArgs e)
        {
            TaskMain.sticklogic.downCCD.Start();
        }

        private void Btnstick_Click(object sender, EventArgs e)
        {
            TaskMain.sticklogic.stick.Start();
        }

        private void BtnFeeder_Click(object sender, EventArgs e)
        {
            TaskMain.sticklogic.feeder.Start();
        }

        private void BtnPreBelt_Click(object sender, EventArgs e)
        {
            TaskMain.prefeed.Start();
        }

        private void BtnOutBelt_Click(object sender, EventArgs e)
        {
            TaskMain.feedout.Start();
        }


        HzVision.Device.MainCamera camera1;
        HzVision.Device.MainCamera camera2;
        private void InitVisionControl()
        {
            camera1 = new HzVision.Device.MainCamera();
            this.Disposed += (s, e) => camera1.Dispose();
            panel1.Controls.Add(camera1);
            camera1.Dock = DockStyle.Fill;
            camera1.ID = 0;

            camera2 = new HzVision.Device.MainCamera();
            this.Disposed += (s, e) => camera2.Dispose();
            panel2.Controls.Add(camera2);
            camera2.Dock = DockStyle.Fill;
            camera2.ID = 1;
        }

        private void 手动_Load(object sender, EventArgs e)
        {
            InitVisionControl();
        }
    }
}
