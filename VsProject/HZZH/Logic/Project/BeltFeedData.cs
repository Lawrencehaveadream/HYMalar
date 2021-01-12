using HZZH.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.Project
{
    /// <summary>
    /// 上下料 参数
    /// </summary>
    [Serializable]
    public class BeltFeedDataDef : ProductBase
    {
        /// <summary>
        /// 进料感应到之后的延时时间
        /// </summary>
        public uint TrackDelay { get; set; }
        /// <summary>
        /// 上板超时时间,单位S
        /// </summary>
        public float FeedTimeOut { get; set; }
        /// <summary>
        /// 顶料On延时
        /// </summary>
        public int RiseOnDelay { get; set; }
        /// <summary>
        /// 顶料Off延时
        /// </summary>
        public float RiseOffDelay { get; set; }
        /// <summary>
        /// 构造器
        /// </summary>
        public BeltFeedDataDef()
        {

        }
    }
}
