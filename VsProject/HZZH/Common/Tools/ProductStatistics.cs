using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonRs
{
    /// <summary>
    /// 产能统计
    /// </summary>
    [Serializable]
    public class ProductStatistics
    {
        /// <summary>
        /// 总产量
        /// </summary>
        public int Yield { get; set; } //总产量
        /// <summary>
        /// 产量
        /// </summary>
        public int Production { get; set; }   //产量
        /// <summary>
        /// 批次产量
        /// </summary>
        public int BatchProduction { get; set; }   //批次产量
        /// <summary>
        /// 批次产量设定
        /// </summary>
        public int BatchProductionSet { get; set; }   //批次产量设定
        /// <summary>
        /// 弃料数量
        /// </summary>
        public int GiveUpNum { get; set; }   //弃料数量
        /// <summary>
        /// OK数量
        /// </summary>
        public int OkCount { get; set; }   //OK数量
        /// <summary>
        /// NG数量
        /// </summary>
        public int NgCount { get; set; }   //NG数量
        /// <summary>
        /// 每小时产能
        /// </summary>
        public int UPH { get; set; }     //每小时常能
        /// <summary>
        /// 循环时间S
        /// </summary>
        public float CycleTime { get; set; }   //循环时间S
        /// <summary>
        /// 运行时间
        /// </summary>
        public float RunTime { get; set; }   //运行时间
        /// <summary>
        /// 停机时间
        /// </summary>
        public float StopTime { get; set; }   //停机时间
        /// <summary>
        /// 错误停止时间
        /// </summary>
        public float ErrorStopTime { get; set; }

        public ProductStatistics()
        {

        }
        private System.DateTime et;
        private System.DateTime tm;
        private TimeSpan singleTimeSpan;
        private List<float> CycleTimeBuff = new List<float>();

        //求平均值
        private float AvgCaculate(List<float> val, int num)
        {
            float avg = 0;
            for (int i = 0; i < num; i++)
            {
                if (val.Count < num)
                {
                    val.Add(CycleTime);
                }
            }
            if (val.Count > num)
            {
                val.RemoveAt(num);
            }

            for (int i = 0; i < val.Count; i++)
            {
                avg += val[i];
            }
            avg = avg / val.Count;
            return avg;
        }
        //产量计数，并计算UPH
        public void ProductCount()
        {
            singleTimeSpan = DateTime.Now.Subtract(et);
            CycleTime = (float)singleTimeSpan.TotalMilliseconds;
            CycleTimeBuff.Insert(0, CycleTime);

            UPH = (int)(3600 * 1000 / AvgCaculate(CycleTimeBuff,20));//计算UPH
            et = DateTime.Now;

            Yield++;
            Production++;
        }
        public void ProductCount(int num)
        {
            singleTimeSpan = System.DateTime.Now.Subtract(et);
            CycleTime = (float)singleTimeSpan.TotalMilliseconds;
            CycleTimeBuff.Insert(0, CycleTime);

            UPH = num*(int)(3600 * 1000 / AvgCaculate(CycleTimeBuff, 20));//计算UPH
            et = DateTime.Now;

            Yield+= num;
            Production+= num;
        }
        public void GiveUpNumCount()
        {
            GiveUpNum++;
        }

        public void GiveUpNumClean()
        {
            GiveUpNum = 0;
        }

        public void ProductClear()
        {
            Yield = 0;
            Production = 0;
            GiveUpNum = 0;
        }

    }
}
