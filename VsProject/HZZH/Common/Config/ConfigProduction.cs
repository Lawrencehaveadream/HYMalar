using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSpace
{
    [Serializable]
    public class ConfigProduction : Config
    {
        private static string _name = "Production.config";
        //用户配置文件的相对路径
        private static string _configName = string.Format("{0}", ConfigDirectory + "\\" + _name);

        public List<Productions> Production { set; get; } //月份

        public class Productions
        {
            public int Year { set; get; }            //年份
            public List<double> GoodProduct { set; get; }//良品
            public List<double> BadProduct { set; get; }//不良品

            public Productions()
            {
                Year = DateTime.Now.Year;
                GoodProduct = new List<double>();
                BadProduct = new List<double>();

                for (int i = 0; i < 31; i++)
                {
                    GoodProduct.Add(0);
                    BadProduct.Add(0);
                }
            }
        }


        public ConfigProduction()
        {
            Production = new List<Productions>();
        }

        /// <summary>
        /// 方法：保存产量配置
        /// </summary>
        public void Save()
        {
            try
            {
                CommonRs.Serialization.SaveToFile(this, _configName);
            }
            catch (Exception ex)
            {
                CommonRs.LogWriter.WriteException(ex);
                CommonRs.LogWriter.WriteLog(string.Format("错误：保存配置文件[{0}]失败!\n异常描述:{1}\n时间：{2}", _name, ex.Message, System.DateTime.Now.ToString("yyyyMMddhhmmss")));
                throw ex;
            }
        }

        /// <summary>
        /// 方法：加载产量配置
        /// </summary>
        /// <returns></returns>
        public static ConfigProduction Load()
        {
            try
            {
                ConfigProduction rt = (ConfigProduction)CommonRs.Serialization.LoadFromFile(typeof(ConfigProduction), _configName);
                if (rt == null)
                {
                    rt = new ConfigProduction();
                }
                return rt;
            }
            catch (Exception ex)
            {
                CommonRs.LogWriter.WriteException(ex);
                CommonRs.LogWriter.WriteLog(string.Format("错误：加载配置文件[{0}]失败!\n异常描述:{1}\n时间：{2}", _name, ex.Message, System.DateTime.Now.ToString("yyyyMMddhhmmss")));
                throw new CommonRs.LoadException(_name, ex.Message);
            }
        }
    }
}
