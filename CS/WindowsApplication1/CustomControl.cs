using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;

namespace WindowsApplication1
{
    public class CustomControl : Control, IToolTipControlClient
    {

        public CustomControl()
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            MyDrawControl(e);
        }
        private void MyDrawControl(PaintEventArgs e)
        {
            DrawBackGround(e);
            DrawLine(e);
            DrawStart(e);
            DrawFinish(e);
        }

        private void DrawBackGround(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
        }
        private void DrawLine(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(ForeColor), GetLineBounds(e.Graphics));
        }

        private void DrawStart(PaintEventArgs e)
        {
            Rectangle rect = GetStartBounds(e.Graphics);
            e.Graphics.DrawString("Start", Font, new SolidBrush(ForeColor), rect);
        }

        private void DrawFinish(PaintEventArgs e)
        {
            Rectangle rect = GetFinishBounds(e.Graphics);
            e.Graphics.DrawString("Finish", Font, new SolidBrush(ForeColor), rect);
        }

        private RectangleF GetLineBounds(Graphics e)
        {
            Rectangle rect1 = GetStartBounds(e);
            Rectangle rect2 = GetFinishBounds(e);
            int lineWidth = Width - rect1.Width - rect2.Width;
            Rectangle rect = new Rectangle(rect1.Right, 0, lineWidth, Height);
            return rect;
        }


        private Rectangle GetStartBounds(Graphics g)
        {
            Size size = g.MeasureString("Start", Font).ToSize();
            return new Rectangle(0, 0, size.Width + 5, Height);
        }

        private Rectangle GetFinishBounds(Graphics g)
        {
            Size size = g.MeasureString("Finish", Font).ToSize();
            return new Rectangle(Width - size.Width, 0, size.Width + 5, Height);
        }

        public string GetHintText(Point p)
        {
            Graphics graphics = CreateGraphics();
            if (GetStartBounds(graphics).Contains(p))
                return "Start";
            if (GetFinishBounds(graphics).Contains(p))
                return "Finish";
            if (GetLineBounds(graphics).Contains(p))
                return "Line";
            return "Custom control";
        }

        #region IToolTipControlClient Members

        ToolTipControlInfo IToolTipControlClient.GetObjectInfo(Point point)
        {
            string hintText = GetHintText(point);
            ToolTipControlInfo info = new ToolTipControlInfo();
            info.Object = hintText;
            info.Text = hintText;
            info.ToolTipPosition = Control.MousePosition;
            info.Interval = 100;
            info.Title = "Custom title";
            info.ToolTipType = ToolTipType.SuperTip;
            return info;
        }



        bool IToolTipControlClient.ShowToolTips
        {
            get { return true; }
        }

        #endregion
    }
}
