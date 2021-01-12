using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommonRs;
using SqliteDataBase;

namespace ConfigSpace
{
    /// <summary>
    /// 配置文件统一操作类
    /// </summary>
    public class ConfigHandle : Config
    {
        #region Singleton
        static object _syncObj = new object();
        static ConfigHandle _instance;
        public static ConfigHandle Instance
        {
            get
            {
                lock (_syncObj)
                {
                    if (_instance == null)
                    { _instance = new ConfigHandle(); }
                }
                return _instance;
            }
        }
        #endregion                     

        /// <summary>
        /// 属性:系统配置
        /// </summary>
        public ConfigSystem SystemDefine { set; get; }
        /// <summary>
        /// 属性:用户配置
        /// </summary>
        public ConfigUser UserDefine { set; get; }

        /// <summary>
        /// 属性:报警配置
        /// </summary>
        public ConfigAlarm AlarmDefine { set; get; }



        /// <summary>
        /// 加载所有配置
        /// </summary>
        public void Load()
        {
            try
            {
                LoadEquipmentConfig();
            }
            catch (Exception ex)
            {
                LogWriter.WriteException(ex);
                LogWriter.WriteLog(string.Format("错误：加载配置文件失败!\n异常描述:{0}\n时间：{1}", ex.Message, System.DateTime.Now.ToString("yyyyMMddhhmmss")));
            }
        }

        public void Save()
        {
            try
            {
                SaveEquipmentConfig();
            }
            catch (Exception ex)
            {
                LogWriter.WriteException(ex);
                LogWriter.WriteLog(string.Format("错误：加载配置文件失败!\n异常描述:{0}\n时间：{1}", ex.Message, System.DateTime.Now.ToString("yyyyMMddhhmmss")));
            }
        }
        private void LoadEquipmentConfig()
        {
            var va = HzControl.Communal.Tools.Serialization.LoadFromXml(typeof(ConfigHandle), Application.StartupPath + "\\config\\配置文件", true) as ConfigHandle;
            
            if (va.UserDefine == null)
            {
                va.UserDefine = new ConfigUser();
            }
            Instance.UserDefine = va.UserDefine;
        }
        public void SaveEquipmentConfig()
        {
            HzControl.Communal.Tools.Serialization.SaveToXml(Instance, Application.StartupPath + "\\config\\配置文件", true);
        }
    }
}
