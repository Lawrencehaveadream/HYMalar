using System;
using System.Drawing;
using System.Windows.Forms;
using CommonRs;
using ConfigSpace;
using System.IO;
using System.Collections.Generic;
using System.Resources;
using System.ComponentModel;
using System.Reflection;
using Device;
using HZZH.Logic.Commmon;
using HZZH.Communal.Control;

namespace MyControl
{
    public partial class InputOutput : Form, IDisposable
    {
        public InputOutput(List<InputClass> inputs, List<OutputClass> outputs)
        {
            InitializeComponent();
            Initializel();
        }
        private readonly List<InputClass> inputClasses = DeviceRsDef.InputList;
        private readonly List<OutputClass> outputClasses = DeviceRsDef.OutputList;
        void Initializel()
        {
            timer1.Enabled = true;
            timer1.Interval = 200;
            //输入初始化
            doubleBufferListview1.BeginUpdate();
            doubleBufferListview1.Items.Clear();
            foreach (var input in inputClasses)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(input.description);
                if (input.Value)
                {
                    item.SubItems.Add( "ON");
                }
                else
                {
                    item.SubItems.Add("OFF");
                }

                item.SubItems[0].Text = input.CardName + ":" + ((input.Xnum + 1).ToString());
                item.SubItems[2].ForeColor = input.Value ? Color.Black : Color.Red;
                doubleBufferListview1.Items.Add(item);
            }
            doubleBufferListview1.EndUpdate();
            //输出初始化
            doubleBufferListview2.BeginUpdate();
            doubleBufferListview2.Items.Clear();
            foreach (var output in outputClasses)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add(output.description);
                if (output.Value)
                {
                    item.SubItems.Add("ON");
                }
                else
                {
                    item.SubItems.Add("OFF");
                }
                item.SubItems[0].Text = output.CardName + ":" + (output.Ynum + 1).ToString();
                item.SubItems[2].ForeColor = output.Value ? Color.Black : Color.Red;
                doubleBufferListview2.Items.Add(item);
                
            }
            doubleBufferListview2.EndUpdate();
        }
        /// <summary>
        /// 刷新输入状态并显示
        /// </summary>
        private void RefreshInstatus()
        {

            doubleBufferListview1.BeginUpdate();
            for (int i = 0; i < doubleBufferListview1.Items.Count; i++)
            {
                if (inputClasses[i].Value)
                {
                    doubleBufferListview1.Items[i].SubItems[2].Text = "ON";
                    doubleBufferListview1.Items[i].BackColor = Color.Green;
                    doubleBufferListview1.Items[i].SubItems[2].ForeColor = Color.Black;
                }
                else
                {
                    doubleBufferListview1.Items[i].SubItems[2].Text = "OFF";
                    doubleBufferListview1.Items[i].BackColor = SystemColors.ControlDarkDark;
                    doubleBufferListview1.Items[i].SubItems[2].ForeColor = Color.Red;

                }

            }
            doubleBufferListview1.EndUpdate();
        }
        /// <summary>
        /// 刷新输出状态并显示
        /// </summary>
        private void RefreshOutstatus()
        {

            doubleBufferListview2.BeginUpdate();
            for (int i = 0; i < doubleBufferListview2.Items.Count - 1; i++)
            {
                if (outputClasses[i].Value)
                {
                    doubleBufferListview2.Items[i].SubItems[2].Text = "ON";
                    doubleBufferListview2.Items[i].BackColor = Color.Green;
                    doubleBufferListview2.Items[i].SubItems[2].ForeColor = Color.Black;
                }
                else
                {
                    doubleBufferListview2.Items[i].SubItems[2].Text = "OFF";
                    doubleBufferListview2.Items[i].BackColor = SystemColors.ControlDarkDark;
                    doubleBufferListview2.Items[i].SubItems[2].ForeColor = Color.Red;
                }

            }
            doubleBufferListview2.EndUpdate();
        }
        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var num = doubleBufferListview2.SelectedItems[0].SubItems[2];
            if (num.Text == "OFF")
            {
                num.Text = "ON";
                doubleBufferListview2.SelectedItems[0].BackColor = Color.Green;
                DeviceRsDef.OutputList[Convert.ToInt32(doubleBufferListview2.SelectedItems[0].Text.Substring(3))-1].ON();
                doubleBufferListview2.SelectedItems[0].SubItems[2].ForeColor = Color.Black;
            }
            else
            {
                num.Text = "OFF";
                doubleBufferListview2.SelectedItems[0].BackColor = Color.SlateGray;
                DeviceRsDef.OutputList[Convert.ToInt32(doubleBufferListview2.SelectedItems[0].Text.Substring(3))-1].OFF();

                doubleBufferListview2.SelectedItems[0].SubItems[1].BackColor = Color.Red;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshInstatus();
            RefreshOutstatus();
        }

        private void doubleBufferListview2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    } 
}
