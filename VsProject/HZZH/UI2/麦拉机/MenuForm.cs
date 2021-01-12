using HzControl.Communal.Controls;
using HZZH.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.UI2.上料机
{
    public partial class MenuForm : BaseSubForm
    {
        public MenuForm()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 200;
        }
        protected override void OnShown()
        {
            base.OnShown();
            foreach (var item in UserBingData.GetControls<Button>(this.borderPanel1))
            {
                if (item.Tag.ToString() == this.GetType().Name)
                {
                    item.BackColor = Color.FromArgb(0,147,221);
                    item.Focus();
                }
            }
        }
        protected override void OnHide()
        {
            base.OnHide();
            foreach (var item in UserBingData.GetControls<Button>(this.borderPanel1))
            {
                //item.BackColor = SystemColors.Control;
                SelectButton(item);
            }
        }
        private static void SelectButton(Button button)
        {
            System.Reflection.MethodInfo methodinfo = button.GetType().GetMethod("SetStyle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            methodinfo.Invoke(button, System.Reflection.BindingFlags.NonPublic, null, new object[] { ControlStyles.Selectable, false }, null);
        }
        private void button1_Click(object sender, EventArgs e)
        {
           ((麦拉机.参数设置.ProductForm)FrmMgr.GetFormInst("ProductForm")).RefreshTreeView();
            FrmMgr.Show(((Button)sender).Tag.ToString());
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }
        private void button7_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
               
        }

        private void levelButton1_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmMgr.Show(((Button)sender).Tag.ToString());
        }
    }
}
