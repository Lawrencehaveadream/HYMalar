using System;

namespace ConfigSpace
{
    [Serializable]
    public class ConfigSystem : Config
    {
        #region 系统配置


        /// <summary>
        /// 属性：序列号(整型)
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public int SerialNo
        {
            set;
            get;
        }

        /// <summary>
        /// 属性:客户名称
        /// </summary>
        public string ClientName
        {
            set;
            get;
        }

        /// <summary>
        /// 属性:管理者账户密码
        /// </summary>
        public string AdminPW
        {
            set;
            get;
        }

        /// <summary>
        /// 属性:客户代码
        /// </summary>
        public string ClientCode
        {
            set;
            get;
        }

        /// <summary>
        /// 属性:流水日期
        /// </summary>
        public DateTime SerialDate
        {
            set;
            get;
        }

        /// <summary>
        /// 属性:流水日志保留天数
        /// </summary>
        public int RunLogDays
        {
            set;
            get;
        }

        /// <summary>
        /// 属性:流水日志行计数
        /// </summary>
        public int RunLogCount
        {
            set;
            get;
        }

        /// <summary>
        /// 流水数据保留天数
        /// </summary>
        public int RunDataDays
        {
            set;
            get;
        }

        /// <summary>
        /// 属性:流水数据行计数
        /// </summary>
        public int RunDataCount
        {
            set;
            get;
        }

        /// <summary>
        /// 属性:报警日志保留天数
        /// </summary>
        public int AlarmLogDays
        {
            set;
            get;
        }

        /// <summary>
        /// 属性:图像存储目录
        /// </summary>
        public string PictureDirectory
        {
            set;
            get;
        }

        /// <summary>
        /// 属性:日志存储目录
        /// </summary>
        public string LogDirectory
        {
            set; get;
        }

        /// <summary>
        /// 属性:程式存储目录
        /// </summary>
        public string ProjectDirectory
        {
            set;
            get;
        }

        /// <summary>
        /// 属性:流水号(字符串)
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public string GenSerialNo
        {
            get
            {
                if (DateTime.Compare(this.SerialDate.Date, DateTime.Now.Date) != 0)
                {
                    this.SerialDate = DateTime.Now.Date;
                    this.SerialNo = 0;
                }

                if (string.IsNullOrEmpty(this.ClientCode))
                {
                    this.ClientCode = "Heils";
                }

                this.SerialNo++;
                return string.Format("{0}{1}",
                                     this.SerialDate.ToString("yyMMdd"),
                                     this.SerialNo.ToString("000000"));
            }
        }

        public bool SilvePasteEn { get; set; }
        public bool SilvePastePlat1 { get; set; }
        public bool SilvePastePlat2 { get; set; }

        public bool LineGlueEn { get; set; }
        public bool LineGluePlat1 { get; set; }
        public bool LineGluePlat2 { get; set; }

        public bool FaceGlueEn { get; set; }
        public bool FaceGluePlat1 { get; set; }
        public bool FaceGluePlat2 { get; set; }

        /// <summary>
        /// 属性：出胶禁用  true：禁用
        /// </summary>
        public bool DripGlueEn { set; get; }  //出胶禁用  true：禁用
        
        #endregion

        public ConfigSystem()
        {
            ProjectDirectory = "D:\\程式\\";
            LogDirectory = @"Log\";
            PictureDirectory = "";
            ClientCode = "123456";
            ClientName = "A";
            AdminPW = "1234";
            SerialDate = DateTime.Now;
            
        }
    }
}
