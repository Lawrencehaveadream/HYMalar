using HZZH.Communal.Control;
using HZZH.UI2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HzControl.Communal.Controls
{
    [ProvideProperty("Level",typeof(Button))]
    public class Level : Component, IExtenderProvider
    {
        private Hashtable hashtable = new Hashtable();
        public Level()
        {

        }
        public Level(IContainer container) : this()
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            container.Add(this);
        }
        // 提供Getter部分.
        public string GetLevel(Button ctrl)
        {
            if (hashtable.Contains(ctrl))
            {
                return (string)hashtable[ctrl];
            }
            else
            {
                return string.Empty;
            }
        }

        // 提供Setter部分.
        public void SetLevel(Button ctrl, string value)
        {
            if (ctrl == null) return;

            if (string.IsNullOrEmpty(value))
            {
                hashtable.Remove(ctrl);
            }
            else
            {
                if (!hashtable.ContainsKey(ctrl))
                {
                    ctrl.Disposed += Ctrl_Disposed;
                }
                hashtable[ctrl] = value;
            }
        }
        private void Ctrl_Disposed(object sender, EventArgs e)
        {
            hashtable.Remove(sender);
        }
        public bool CanExtend(object extendee)
        {
            return extendee is Button;
        }
        /// <summary>
        /// 与何值进行比较
        /// </summary>
        /// <param name="dataSource"></param>
        public void ComparetoWhichData(object dataSource)
        {
            foreach (Button item in hashtable.Keys)
            {
                int CurrentLevelnum = Convert.ToInt32(dataSource);
                int SetLevelnum = Convert.ToInt32(GetLevel(item));
                
                
                if (CurrentLevelnum >= SetLevelnum)
                {
                    item.Enabled = true;
                    
                }
                else
                {
                    item.Enabled = false;
                }
            }
        }
    }
}
