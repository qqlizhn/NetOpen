using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace netOpen
{
    public delegate bool PreRemoveTab(int indx);
    public partial class MyTabControl :TabControl
    {
        public PreRemoveTab PreRemoveTabPage;
        private int CrossSize = 16;
        public event Action<bool> TabPageClosedNow;

        public MyTabControl() : base()
            {
                PreRemoveTabPage = null;
                //this.DrawMode = TabDrawMode.OwnerDrawFixed;
            }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            LinearGradientBrush gradSel = new LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.ControlDark,LinearGradientMode.Vertical);
            LinearGradientBrush gradHov = new LinearGradientBrush(e.Bounds, SystemColors.ControlLight, SystemColors.ControlLightLight, LinearGradientMode.Vertical);

            if (e.State == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }
            else if (e.State == DrawItemState.HotLight)
            {
                e.Graphics.FillRectangle(gradHov, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(gradHov, e.Bounds);
            }
            if (this.TabPages[e.Index].Text[this.TabPages[e.Index].Text.Length - 1] != ' ')
                this.TabPages[e.Index].Text += " ";

            Rectangle r = e.Bounds;
            r = this.GetTabRect(e.Index);
            e.Graphics.DrawImage(Properties.Resources.bigX, r.X + 2, 5);
           
            r.Offset(2, 5);
            r.Width = CrossSize;
            r.Height = CrossSize;
            Brush b = new SolidBrush(Color.Black);
            Pen p = new Pen(b);
            
            string titel = this.TabPages[e.Index].Text;
            Font f = this.Font;
            e.Graphics.DrawString(titel, f, b, new PointF(r.X+CrossSize , r.Y-3));
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point p = e.Location;
            for (int i = 0; i < TabCount; i++)
            {
                Rectangle r = GetTabRect(i);
                r.Offset(6, 1);
                r.Width = CrossSize;
                r.Height = CrossSize;
                if (r.Contains(p))
                {
                    if (this.TabPages.Count > 1)
                    {
                        CloseTab(i);
                        //TabPageClosedNow(true);
                    }
                }
            }
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            Point p = MousePosition;
            p=PointToClient(p);
            for (int i = 0; i < TabCount; i++)
            {
                Rectangle r = GetTabRect(i);
                r.Offset(6, 1);
                r.Width = CrossSize;
                r.Height = CrossSize;
                if (r.Contains(p)&&TabPages.Count>1)
                {
                    //MessageBox.Show(TabPages.Count.ToString());
                    this.TabPages[i].ImageIndex = 10;
                }
                else this.TabPages[i].ImageIndex = 11;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point p = MousePosition;
            p = PointToClient(p);
            for (int i = 0; i < TabCount; i++)
            {
                Rectangle r = GetTabRect(i);
                r.Offset(6, 1);
                r.Width = CrossSize;
                r.Height = CrossSize;
                if (r.Contains(p) && TabPages.Count > 1)
                {
                    if (this.TabPages[i].ImageIndex != 10) this.TabPages[i].ImageIndex=10;
                }
                else if (this.TabPages[i].ImageIndex != 11) this.TabPages[i].ImageIndex=11;
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            for (int i = 0; i < TabCount; i++)
            {
                 if (this.TabPages[i].ImageIndex != 11) this.TabPages[i].ImageIndex = 11;
            }
        }

        private void CloseTab(int i)
        {
            if (PreRemoveTabPage != null)
            {
                bool closeIt = PreRemoveTabPage(i);
                if (!closeIt)
                    return;
            }
            TabPages.Remove(TabPages[i]);
        }
    }
}
