using CommonRs;
using HZZH.Logic.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Database
{
    public class AllData
    {
        static public Product Data {get{ return Product.Inst; } }
    }
    public partial class Product
    {
        public bool IsAging { get; set; }

        /// <summary>
        /// 登录用户的等级，0:软件打开未登录状态1：操作员2：工程师3：服务商4：技术支持
        /// </summary>
        public int OperiterLevel { get; set; }
        /// <summary>
        /// 贴附数据
        /// </summary>
        public StickDataDef Stickdata { get; set; }
        /// <summary>
        /// 皮带数据
        /// </summary>
        public BeltFeedDataDef Beltdata { get; set; }
        /// <summary>
        /// 过程数据
        /// </summary>
        public ProcessDataDef ProcessData { get; set; }
        /// <summary>
        /// 产量数据
        /// </summary>
        public ProductStatistics ProductYield { get; set; }

        public TeacherRect TchRect { get; set; }

        public Product()
        {
            Stickdata = new StickDataDef();
            Beltdata = new BeltFeedDataDef();
            ProductYield = new ProductStatistics();
            TchRect = new TeacherRect();
        }
    }
    /// <summary>
    /// 过程数据
    /// </summary>
    public class ProcessDataDef : ProductBase
    {
        /// <summary>
        /// 吸嘴过程数据
        /// </summary>
        public List<NuzzleParaDef> NuzzlePara { get; set; } = new List<NuzzleParaDef>();  //
        /// <summary>
        /// 贴附过程数据
        /// </summary>
        public List<ProductDef> StickPosList { get; set; } = new List<ProductDef>();
        /// <summary>
        /// 当前哪个产品
        /// </summary>
        public int currWhichProduct { get; set; }
        public int currWhichPoint { get; set; }
        public ProcessDataDef()
        {
            currWhichProduct = 0;
            currWhichPoint = 0;
            StickPosList = new List<ProductDef>();
            for (int i = 0; i < 2; i++)
            {
                NuzzlePara.Add(new NuzzleParaDef());
            }
        }
        /// <summary>
        /// 当前贴到产品第几个贴附点
        /// </summary>
        /// <returns></returns>
        public SitePoint CurrStickWhichPoint()
        {
            if (currWhichProduct >= StickPosList.Count)
            {
                return null;
            }
            return StickPosList[currWhichProduct].SiteList[currWhichPoint];
        }

        /// <summary>
        /// 当前贴到第几个产品
        /// </summary>
        /// <returns></returns>
        public ProductDef CurrStickWhichProduct()
        {
            return StickPosList[currWhichProduct];
        }
    }


    /// <summary>
    /// 运行模式
    /// </summary>
    public enum RunMode : int
    {
        NORMAL = 0,     //正常模式
        AGING = 1,		//老化模式
        STEP = 2,       //单步
        SIGNEL = 3,    //单次
    }

}
