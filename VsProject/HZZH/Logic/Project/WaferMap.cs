using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;

namespace HZZH.Logic.Project
{
    public class WaferMap
    {
        //public readonly static string Path = AppDomain.CurrentDomain.BaseDirectory + "map\\";

        private const int WaferSize = 10;


        /// <summary>
        /// 产品ID
        /// </summary>
        public string ProductID { get; set; } = string.Empty;
        /// <summary>
        /// 晶元ID
        /// </summary>
        public string WaferID { get; set; } = string.Empty;
        /// <summary>
        /// 地图的行
        /// </summary>
        public int Row { get; set; }
        /// <summary>
        /// 地图的列
        /// </summary>
        public int Column { get; set; }


        /// <summary>
        /// 地图的数据
        /// </summary>
        public Wafer[,] Wafers { get; set; } = new Wafer[0, 0];
        public Dictionary<char, int> Statistics { get; private set; } = new Dictionary<char, int>();

        public void ReadFile(string fileName, int angle = 0)
        {
            Debug.Assert(File.Exists(fileName));
            string[] allLines = File.ReadAllLines(fileName);

            #region 晶元地图的描述信息
            int row = 0, column = 0;
            foreach (var item in allLines)
            {
                if (RegexMatchs(item, "Product").Success)
                {
                    ProductID = RegexMatchs(item, ":(.+)").Value.Remove(0, 1).Trim();
                }

                if (RegexMatchs(item, "Wafer ID").Success)
                {
                    WaferID = RegexMatchs(item, ":(.+)").Value.Remove(0, 1).Trim();
                }

                if (RegexMatchs(item, "Row").Success)
                {
                    row = Convert.ToInt32(RegexMatchs(item, ":(.+)").Value.Remove(0, 1).Trim());
                }

                if (RegexMatchs(item, "Column").Success)
                {
                    column = Convert.ToInt32(RegexMatchs(item, ":(.+)").Value.Remove(0, 1).Trim());
                }
            }

            if (row == 0 || column == 0)
            {
                var va = from n in allLines.Select(e => e.Length)
                         group n by n into g
                         orderby g.Count() descending
                         select g;
                column = va.First().Key;
                row = va.First().Count();
            }

            #endregion

            #region  晶元属于地图的字符串
            List<string> mapData = new List<string>();
            for (int r = 0; r < allLines.Length && mapData.Count < row; r++)
            {
                if (allLines[r].Length == column)
                {
                    mapData.Add(allLines[r]);
                }
            }
            #endregion

            #region  角度旋转并且重新赋值
            char[,] map = null;
            if (angle == 90)
            {
                map = new char[column, row];
                for (int r = 0; r < column; r++)
                {
                    for (int c = 0; c < row; c++)
                    {
                        map[r, c] = mapData[row - r - 1][column - c - 1];
                    }
                }
            }
            else if (angle == 180)
            {
                map = new char[row, column];
                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < column; c++)
                    {
                        map[r, c] = mapData[row - r - 1][column - c - 1];
                    }
                }
            }
            else if (angle == 270)
            {
                map = new char[column, row];
                for (int r = 0; r < column; r++)
                {
                    for (int c = 0; c < row; c++)
                    {
                        map[r, c] = mapData[row - r - 1][column - c - 1];
                    }
                }
            }
            else
            {
                map = new char[row, column];
                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < column; c++)
                    {
                        map[r, c] = mapData[r][c];
                    }
                }
            }
            this.Row = map.GetLength(0);
            this.Column = map.GetLength(1);
            #endregion

            #region 地图的字符信息转换成数据
            Wafers = new Wafer[this.Row, this.Column];
            for (int r = 0; r < Row; r++)
            {
                for (int c = 0; c < Column; c++)
                {
                    Wafer wafer = new Wafer();
                    wafer.Key = map[r, c];
                    wafer.Pixel = new PointF(c * WaferSize, r * WaferSize);
                    if (char.IsDigit(wafer.Key))
                    {
                        // 正常晶元
                        if (Statistics.ContainsKey(wafer.Key) == false)
                        {
                            Statistics[wafer.Key] = 0;
                        }
                        Statistics[wafer.Key]++;
                        wafer.Status = WaferStatus.Normal;
                        wafer.Color = Wafer.Colors[Statistics.Keys.ToList().IndexOf(wafer.Key)];
                    }
                    else if (RegexMatchs(wafer.Key.ToString(), "[-_. ]").Success)
                    {
                        // 空的
                        wafer.Status = WaferStatus.Empty;
                        wafer.Color = Wafer.EmptyColor;
                    }
                    else
                    {
                        // 坏片
                        if (Statistics.ContainsKey(wafer.Key) == false)
                        {
                            Statistics[wafer.Key] = 0;
                        }
                        Statistics[wafer.Key]++;
                        wafer.Status = WaferStatus.Bad;
                        wafer.Color = Wafer.BadColor;
                    }
                    Wafers[r, c] = wafer;
                }
            }
            #endregion
        }

        public void SaveFile(string fileName)
        {
            List<string> dat = new List<string>();
            dat.Add("Product ID: " + this.ProductID);
            dat.Add("Wafer ID: " + this.WaferID);
            dat.Add("Row : " + this.Row);
            dat.Add("Column : " + this.Column);
            dat.Add(Environment.NewLine);

            StringBuilder stringBuilder = new StringBuilder();
            for (int r = 0; r < this.Row; r++)
            {
                for (int c = 0; c < this.Column; c++)
                {
                    stringBuilder.Append(Wafers[r, c].Key);
                }
                dat.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }

            File.WriteAllLines(fileName, dat.ToArray());
        }


        public bool CanPick(int row, int col, char[] pickKey)
        {
            bool flag = false;
            if (row >= 0 && row < this.Row && col >= 0 && col < this.Column)
            {
                if (Wafers[row, col].Status == WaferStatus.Normal && pickKey.Contains(Wafers[row, col].Key))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public void PickWafer(int row, int col)
        {
            if (row >= 0 && row < this.Row && col >= 0 && col < this.Column)
            {
                Wafers[row, col].Status = WaferStatus.Empty;
                Wafers[row, col].Key = '.';
            }
        }


        private static Match RegexMatchs(string Text, string Pattern)
        {
            Match Matches = Regex.Match(
                    Text,
                    Pattern,
                    RegexOptions.IgnoreCase |         //忽略大小写  
                    RegexOptions.ExplicitCapture |    //提高检索效率  
                    RegexOptions.RightToLeft          //从左向右匹配字符串  
                    );
            return Matches;
        }



        private PictureBox pictureBox = null;
        public void SetPictureBox(PictureBox picture)
        {
            this.pictureBox = picture;
            pictureBox.Paint += PictureBox_Paint;
            pictureBox.Click += PictureBox_Click;
            pictureBox.MouseWheel += PictureBox_MouseWheel;
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Paint()
        {
            int width = Column * WaferSize;
            int height = Row * WaferSize;

            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            //graphics.DrawRectangles()


        }


    }

    public enum WaferStatus
    {
        Normal,
        Empty,
        Bad
    }

    public class Wafer
    {
        public readonly static Color[] Colors = new Color[]
        {
            Color.Green,
            Color.Blue,
            Color.DarkRed,
            Color.DeepPink,
            Color.Yellow,
            Color.Aqua,
            Color.Purple,
            Color.LightSkyBlue,
            Color.DarkSeaGreen,
            Color.Crimson,
            Color.Black
        };

        public readonly static Color EmptyColor = Color.Empty;
        public readonly static Color BadColor = Color.Red;

        public WaferStatus Status { get; set; }
        public char Key { get; set; }
        public Color Color { get; set; }
        public PointF Pixel { get; set; }
        public PointF PickPoint { get; set; }

 
    }
}
