using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.UI2.上料机.项目控件
{
    class Bancombox : ComboBox
    {
        protected override void WndProc(ref Message m)
        {
            int WM_MOUSEWHEEL = 0x020A;
            if (m.Msg == WM_MOUSEWHEEL)
                ;
            else
                base.WndProc(ref m);
        }
    }
}
