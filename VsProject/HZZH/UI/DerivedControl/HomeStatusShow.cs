﻿using HZZH.Logic.Commmon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.UI
{
    public partial class HomeStatusShow : Form
    {
        private List<Button> ButtonList = new List<Button>();
        public HomeStatusShow()
        {              
            InitializeComponent();
            ButtonList = new List<Button>();
            foreach (var item in typeof(HomeStatusShow).GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic))
            {
                if (item.FieldType == typeof(Button))
                {
                    ButtonList.Add((Button)item.GetValue(this));
                }
            }
            Homesta = new List<int>();
            for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
            {
                Homesta.Add(0);
            }
        }
        List<int> Homesta = new List<int>();
        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i=0;i<DeviceRsDef.AxisList.Count;i++)
            {
                if(i<ButtonList.Count)
                {
                    if (DeviceRsDef.AxisList[i].Mode == Device.AxisMode.GOHOMEMODE)
                    {
                        Homesta[i] = 1;
                    }
                    ButtonList[i].Text = DeviceRsDef.AxisList[i].AxisName;
                    if(DeviceRsDef.AxisList[i].status == Device.AxState.AXSTA_ERRSTOP)
                    {
                        ButtonList[i].BackColor = Color.Red;
                    }
                    else if (DeviceRsDef.AxisList[i].busy)
                    {
                        ButtonList[i].BackColor = Color.Yellow;
                    }            
                    else if(DeviceRsDef.AxisList[i].done == 1)
                    {
                        if (Homesta[i] == 1)
                        {
                            ButtonList[i].BackColor = Color.Green;
                        }                                            
                    }
                    else
                    {
                        if(Homesta[i] == 0)
                        {
                            ButtonList[i].BackColor = Color.Orange;
                        }                      
                    }
                }
            }
        }
        private void HomeStatusShow_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
