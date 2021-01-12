using CommonRs;

namespace ConfigSpace
{
    public interface IConfig : System.ComponentModel.INotifyPropertyChanged
    {
    }

    public class Config : IConfig
    {
        protected static string ConfigDirectory = LogWriter.ConfigDirectory;
        public Config() { }

        /// <summary>
        /// 事件：PropertyChangedEventHandler委托类型的事件
        /// </summary>
        public virtual event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 方法：调用事件
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
