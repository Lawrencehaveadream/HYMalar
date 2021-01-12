using HZZH.Database;
using HZZH.UI.DerivedControl;
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
    public partial class CardMenu : MenuForm
    {
        public CardMenu()
        {
            InitializeComponent();
        }
        protected override void OnShown()
        {
            base.OnShown();
            BtnCard.BackColor = Color.FromArgb(0, 147, 221);
            foreach (var item in HzControl.Communal.Controls.UserBingData.GetControls<Button>(this.CardBtnpanel))
            {
                if (item.Tag.ToString() == this.GetType().Name)
                {
                    item.BackColor = Color.FromArgb(0, 147, 221);
                    item.Focus();
                }
            }
        }
        private void ClientAxis_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
            
            
        }

        private void IOBtn_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }

        private void AxisParaBtn_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }

        private void CardMenu_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                timer1.Enabled = true;
                timer1.Interval = 500;
                if (Database.Product.Inst.OperiterLevel < 4)
                {
                    AxisParaBtn.Visible = false;
                }
                else
                {
                    AxisParaBtn.Visible = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                level13333.ComparetoWhichData(Product.Inst.OperiterLevel);
            }
            
        }
    }
}
