using HZZH.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HZZH.Logic.Project
{
    public class TeacherRect : ProductBase
    {
        /// <summary>
        /// 上料产品示教矩形
        /// </summary>
        public RectangleR PrdRect { get; set; }
        /// <summary>
        /// 贴附位置示教矩形
        /// </summary>
        public RectangleR StkRect { get; set; }
        /// <summary>
        /// 示教吸嘴对位矩形
        /// </summary>
        public RectangleR MchnTeachRect { get; set; }
        /// <summary>
        /// 下相机示教对位矩形
        /// </summary>
        public RectangleR DownCamTeachRect { get; set; }

        public TeacherRect()
        {
            PrdRect = new RectangleR();
            StkRect = new RectangleR();
            MchnTeachRect = new RectangleR();
            DownCamTeachRect = new RectangleR();
        }
    }

    public class RectangleR
    {
        /// <summary>
        /// 中心点X
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// 中心点Y
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// 角度，以长轴水平，逆时针旋转为正
        /// </summary>
        public double Angle { get; set; }
        /// <summary>
        /// 长轴
        /// </summary>
        public double MajorAxis { get; set; }
        /// <summary>
        /// 短轴
        /// </summary>
        public double MinorAxis { get; set; }
    }

}
