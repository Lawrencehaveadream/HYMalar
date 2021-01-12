using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HZZH.Communal.Tools
{
    public partial class YieldInformation : Form
    {
        /// <summary>
        /// 属性：产量信息
        /// </summary>
        public ConfigProduction Production { set; get; }
        
        static int month = DateTime.Now.Month;
        static int day = DateTime.Now.Day;
        static int year = DateTime.Now.Year;


        List<double> GoodProduct = null;
        List<double> BadProduct = null;
        List<ConfigProduction.Productions> productions = null;
        public YieldInformation()
        {
            this.Production = ConfigProduction.Load();
            productions = Production.Production;
            if (productions.Count == 0)
            {
                for (int i = 0; i < 12; i++)
                {
                    productions.Add(new ConfigProduction.Productions());
                }
            }
            if (productions[month - 1].Year != year)
            {
                for (int i = 0; i < productions[month - 1].GoodProduct.Count; i++)
                {
                    productions[month - 1].GoodProduct[i] = 0;
                }
                for (int i = 0; i < productions[month - 1].BadProduct.Count; i++)
                {
                    productions[month - 1].BadProduct[i] = 0;
                }
                productions[month - 1].Year = year;
            }
            for (int i = 0; i < productions.Count; i++)
            {
                if (productions[i].Year == 0)
                {
                    productions[i].Year = year;
                }
            }
            GoodProduct = productions[month - 1].GoodProduct;
            BadProduct = productions[month - 1].BadProduct;
            InitializeComponent();
            shouChart();
            AddCombox1();
            comboBox1.SelectedIndex = month - 1;
        }

        private static YieldInformation instance;
        private static readonly object locker = new object();
        public static YieldInformation Instance()
        {
            if (instance == null)
            {
                object locker = YieldInformation.locker;
                lock (locker)
                {
                    if (instance == null || instance.Created == false)
                    {
                        instance = new YieldInformation();
                    }
                }
            }
            return instance;
        }

        public void AddCombox1()
        {
            for (int i = 0; i < productions.Count; i++)
            {
                comboBox1.Items.Add(productions[i].Year + "年" + (i + 1) + "月");
            }
        }

        

        /// <summary>
        /// 设置图像
        /// </summary>
        public void shouChart()
        {
            // 设置曲线的样式
            // 画样条曲线（Spline）
            chart1.Series[0].ChartType = SeriesChartType.Column;
            // 线宽2个像素
            chart1.Series[0].BorderWidth = 1;
            // 线的颜色：红色
            chart1.Series[0].Color = System.Drawing.Color.Blue;
            // 图示上的文字
            chart1.Series[0].LegendText = "良品";
            chart1.Series[1].ChartType = SeriesChartType.Column;
            chart1.Series[1].BorderWidth = 1;
            chart1.Series[1].Color = System.Drawing.Color.Red;
            chart1.Series[1].LegendText = "不良品";
            // 在chart中显示数据
            chart1.Series[0].Points.DataBindY(GoodProduct);
            chart1.Series[1].Points.DataBindY(BadProduct);
            // 设置显示范围
            ChartArea chartArea = chart1.ChartAreas[0];
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 31;
            chart1.ChartAreas[0].AxisY.Minimum = 0d;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            //滚动条
            chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
            chart1.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;
            chart1.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(165)), ((System.Byte)(191)), ((System.Byte)(228)));
            chart1.ChartAreas[0].CursorX.AutoScroll = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Position = 1;
            chart1.ChartAreas[0].AxisX.ScaleView.Size = 10;
            chart1.ChartAreas[0].AxisX.ScrollBar.ButtonColor = System.Drawing.Color.Silver;
            chart1.ChartAreas[0].AxisX.ScrollBar.LineColor = System.Drawing.Color.Black;
            //显示数据
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series[1].IsValueShownAsLabel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Production.Production[month - 1].GoodProduct[day - 1] > 0 ||
                Production.Production[month - 1].BadProduct[day - 1] > 0)
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                GoodProduct = Production.Production[comboBox1.SelectedIndex].GoodProduct;
                BadProduct = Production.Production[comboBox1.SelectedIndex].BadProduct;
                chart1.Series[0].Points.DataBindY(GoodProduct);
                chart1.Series[1].Points.DataBindY(BadProduct);
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series[1].IsValueShownAsLabel = true;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].IsValueShownAsLabel = false;
            chart1.Series[1].IsValueShownAsLabel = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ConfigProduction.Productions> productions = Production.Production;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            GoodProduct = productions[comboBox1.SelectedIndex].GoodProduct;
            BadProduct = productions[comboBox1.SelectedIndex].BadProduct;
            chart1.Series[0].Points.DataBindY(GoodProduct);
            chart1.Series[1].Points.DataBindY(BadProduct);
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 32;
                    break;
                case 1:
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 30;
                    break;
                case 2:
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 32;
                    break;
                case 3:
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 31;
                    break;
                case 4:
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 32;
                    break;
                case 5:
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 31;
                    break;
                case 6:
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 32;
                    break;
                case 7:
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 32;
                    break;
                case 8:
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 31;
                    break;
                case 9:
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 32;
                    break;
                case 10:
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 31;
                    break;
                case 11:
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 32;
                    break;
                default:
                    break;
            }
        }


        public static bool Showx()
        {
            
            if (Instance().ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            else {
                return true;
            }
            
        }
    }
}
