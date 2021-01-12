using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HalconDotNet;
using Vision;

namespace Vision.Tool.CodeData
{
    public partial class CodeReaderControl : Form
    {

        public CodeReaderControl(CodeReader oper=null)
        {
            InitializeComponent();
            hWindowControl1.Size = splitContainer1.Panel1.ClientSize;
            hWindowControl1.Location = new Point(0, 0);


            _Operate = oper;
        }

        CodeReader _Operate;

        void InitializeDisplay()
        {
            if (_Operate != null)
            {
                this.Text = "二维码";
                _Operate.AddDisplayControl(hWindowControl1);

                InternalMethod.SetBinding(textBox43, "Text", _Operate, "DateCodeTimeOutValue");
                InternalMethod.SetBinding(numericUpDown1, "Value", _Operate, "DateCodeZoomImg");
                InternalMethod.SetBinding(checkBox1, "Checked", _Operate, "DateCodeTimeOut");
                InternalMethod.SetBinding(checkBox2, "Checked", _Operate, "UseBrighten");
                InternalMethod.SetBinding(numericUpDown2, "Value", _Operate, "UseBrightenValue");


                switch (_Operate.DateCodeRate)
                {
                    case 1: radioButton1.Select(); break;
                    case 2: radioButton2.Select(); break;
                    case 3: radioButton3.Select(); break;
                }

                if (_Operate.SearchRegion.IsInitialized())
                {
                    hWindowControl1.HalconWindow.SetDraw("margin");
                    hWindowControl1.HalconWindow.SetColor("blue");
                    hWindowControl1.HalconWindow.DispObj(_Operate.SearchRegion);
                }

            }
        }

        private void CodeReaderControl_Load(object sender, EventArgs e)
        {
            InitializeDisplay();
        }
        bool IsDrawing = false;
        private void Btn_SearchRegion_Click(object sender, EventArgs e)
        {
            if (IsDrawing) return;

            try
            {
                IsDrawing = true;
                hWindowControl1.Focus();
                double row1, col1, row2, col2;
                hWindowControl1.HalconWindow.SetDraw("margin");
                hWindowControl1.HalconWindow.SetColor("blue");
         
                hWindowControl1.HalconWindow.DrawRectangle1(out row1, out col1, out row2, out col2);

                if (_Operate != null)
                {
                    _Operate.SearchRegion.GenRectangle1(row1, col1, row2, col2);
                    hWindowControl1.HalconWindow.DispObj(_Operate.SearchRegion);
                }

            }
            catch
            {
                MessageBox.Show("绘制失败");
            }
            finally
            {
                IsDrawing = false;
            }
        }


        HImage img = new HImage();
        public void InitImage(HImage img)
        {
            this.img = new HImage(img);
            InternalMethod.KeepAspectRatio(hWindowControl1, img);
            hWindowControl1.HalconWindow.DispObj(img);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (_Operate != null)
            { _Operate.DateCodeRate = 1; }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (_Operate != null)
            { _Operate.DateCodeRate = 2; }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (_Operate != null)
            { _Operate.DateCodeRate = 3; }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox43.Enabled = checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }


        private List<string> imgNameList = new List<string>();

        public void Open(string fileName)
        {
            string[] exts = { ".bmp", ".jpg", ".jpeg", ".jpe", ".png", ".tif", ".tiff" };
            string[] file = Directory.GetFiles(fileName);
            foreach (var fi in file)
            {
                if (exts.Where(s => Path.GetExtension(fi).ToLower() == s).Count() != 0)
                {
                    imgNameList.Add(fi);
                }
            }


            if (imgNameList.Count > 0)
            {
                img.ReadImage(imgNameList[0]);
                InternalMethod.KeepAspectRatio(hWindowControl1, img);
                hWindowControl1.HalconWindow.DispObj(img);
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.InitialDirectory = Application.StartupPath;
            ofDialog.Filter = "位图文件(*.bmp)|*.bmp|PNG(*.png)|*.png|JPGE(*.jpge,*.jpg)|*.jpeg;*.jpg|所有图片|*.bmp;*.png;*.jpge;*.jpg";
            ofDialog.FilterIndex = -1;
            ofDialog.Multiselect = true;
            ofDialog.Title = "打开一张图片";

            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                string[] exts = { ".bmp", ".jpg", ".jpeg", ".jpe", ".png", ".tif", ".tiff" };
                string[] file = ofDialog.FileNames;
                imgNameList.Clear();

                foreach (var fi in file)
                {
                    if (exts.Where(s => Path.GetExtension(fi).ToLower() == s).Count() != 0)
                    {
                        imgNameList.Add(fi);
                    }
                }


                if (imgNameList.Count > 0)
                {
                    img.ReadImage(imgNameList[0]);
                    InternalMethod.KeepAspectRatio(hWindowControl1, img);
                    hWindowControl1.HalconWindow.DispObj(img);

                    toolStripProgressBar1.Maximum = imgNameList.Count;
                }  
            }

            //using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            //{
            //    if (dialog.ShowDialog() == DialogResult.OK)
            //    {
            //        string fileName = dialog.SelectedPath;
            //        try
            //        {
            //            Open(fileName);
            //        }
            //        catch (Exception exception)
            //        {
            //            MessageBox.Show(exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //            return;
            //        }

            //    }

            //}
        }



        bool TrainCodeDataState = false;
        private void TrainCodeDataPro()
        {
            TrainCodeDataState = true;

            for (int i = 0; i < imgNameList.Count && TrainCodeDataState; i++)
            {
                try
                {
                    img.ReadImage(imgNameList[i]);
                    InternalMethod.KeepAspectRatio(hWindowControl1, img);
                    hWindowControl1.HalconWindow.DispObj(img);
                    this.Invoke(new Action(() =>
                    {
                        this.Text = imgNameList[i];
                        toolStripProgressBar1.PerformStep();
                    }));
                }
                catch
                {
                    continue;
                }

                if (TrainCodeDataState)
                {
                    bool st = _Operate.FindDataCode(img, true);

                    hWindowControl1.HalconWindow.SetColor("blue");
                    hWindowControl1.HalconWindow.SetDraw("margin");
                    hWindowControl1.HalconWindow.DispObj(_Operate.SearchRegion);
                    hWindowControl1.HalconWindow.SetColor("green");
                    hWindowControl1.HalconWindow.DispObj(_Operate.DataCodeContour);
                    InternalMethod.disp_message(hWindowControl1.HalconWindow, st ? _Operate.DataCodeString : "没有找到", "image", 20, 20, st ? "green" : "red", "false");

                    Thread.Sleep(500);
                }
                else
                {
                    return;
                }

            }

            if (this.Created && TrainCodeDataState == true)
            {
                MessageBox.Show("训练完成");
            }

            TrainCodeDataState = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TrainCodeDataState)
            {
                MessageBox.Show("正在训练模板中");
                return;
            }

            if (imgNameList.Count > 0)
            {
                toolStripProgressBar1.Maximum = imgNameList.Count;
                toolStripProgressBar1.Value = 0;
            }


            this.Invoke(new Action(() =>
            {
                this.button3.Enabled = false;
                this.numericUpDown1.Enabled = false;
                button1.Enabled = false;
            }));


            new Action(() => { TrainCodeDataPro(); }).BeginInvoke((ar) =>
            {
                if (Created)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.button3.Enabled = true;
                        this.numericUpDown1.Enabled = true;
                        button1.Enabled = true;
                    }));
                }
           
            }, null);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            TrainCodeDataState = false;
        }

        private void CodeReaderControl_FormClosing(object sender, FormClosingEventArgs e)
        {          
            if (TrainCodeDataState)
            {
                TrainCodeDataState = false;
                Thread.Sleep(100);
            }
            _Operate.RemoveDisplayControl(hWindowControl1);
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = checkBox2.Checked;
        }








    }
}
