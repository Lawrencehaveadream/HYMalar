using System;
using System.Windows.Forms;

namespace HZZH.Communal.Tools
{
    public class YieldButton:Button
    {
        public YieldButton() : base()
        {
            base.Font = new System.Drawing.Font("黑体", 16);
            Width = 78;
            Height = 78;
            base.Text = "产量记录";
            base.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            YieldInformation.Showx();
        }
    }
}
