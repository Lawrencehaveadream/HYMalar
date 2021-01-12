using HzControl.Communal.Controls;
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

namespace HZZH.UI2.麦拉机
{
    public partial class VisPlatform : MenuForm
    {
        public VisPlatform()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }
        protected override void OnShown()
        {
            base.OnShown();
            base.BtnVision.BackColor = Color.FromArgb(0, 147, 221);
            foreach (var item in UserBingData.GetControls<Button>(this.panel1))
            {
                if (item.Tag.ToString() == this.GetType().Name)
                {
                    item.BackColor = Color.FromArgb(0, 147, 221);
                    item.Focus();
                }
            }
        }
    }
}
