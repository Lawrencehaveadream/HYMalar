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

namespace HZZH.UI2.麦拉机.参数设置
{
    public partial class DownVisForm : VisPlatform
    {
        public DownVisForm()
        {
            InitializeComponent();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = Database.Product.Inst.Stickdata.StickSysData.LiftDownCCDPos.X;
            TaskMain.move.targetPos.Y = Database.Product.Inst.Stickdata.StickSysData.LiftDownCCDPos.Y;
            TaskMain.move.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TaskMain.move.targetPos.X = Database.Product.Inst.Stickdata.StickSysData.RightDownCCDPos.X;
            TaskMain.move.targetPos.Y = Database.Product.Inst.Stickdata.StickSysData.RightDownCCDPos.Y;
            TaskMain.move.Start();
        }
    }
}
