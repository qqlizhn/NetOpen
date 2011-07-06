using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Diagnostics;

namespace netOpen
{
    public partial class ZaklAdd : Form
    {

        bool grew = false;
        int colorR = 94, AnimSize = 52;
        Graphics gg;
        Bitmap drawing = null;
        ZaklInfo zakl;
        Image ico;

        public ZaklAdd(string Name,string IPadr,Image icon)
        {
            InitializeComponent();
            zakl = new ZaklInfo(Name, IPadr);
            ico = icon;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {       //base.OnPaintBackground(e);    
            // Do nothing.
            //pevent.Graphics.FillRectangle(SystemBrushes.Control, 0, tableLayoutPanel1.RowStyles[0].Height, this.Width, this.Height - tableLayoutPanel1.RowStyles[0].Height);
            e.Graphics.FillRectangle(SystemBrushes.Control, 0, e.ClipRectangle.Y + AnimSize, e.ClipRectangle.Width, e.ClipRectangle.Height - AnimSize);

        }

        public void DrawFormBackgroud(Graphics g, Rectangle r)
        {

            drawing = new Bitmap(this.Width, AnimSize, g);
            gg = Graphics.FromImage(drawing);

            Rectangle shadowRect = new Rectangle(r.X, r.Y, r.Width, 10);
            Rectangle gradRect = new Rectangle(r.X, r.Y + 9, r.Width, AnimSize - 9);
            LinearGradientBrush shadow = new LinearGradientBrush(shadowRect, Color.FromArgb(30, 61, 61), Color.FromArgb(47, colorR, colorR), LinearGradientMode.Vertical);
            //LinearGradientBrush shadow = new LinearGradientBrush(shadowRect, Color.FromArgb(30, 61, 41), Color.FromArgb(47, colorR, 64), LinearGradientMode.Vertical);
            LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.FromArgb(47, 64, 94), Color.FromArgb(49, 66, 95), LinearGradientMode.Vertical);
            //LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.Green, Color.DarkGreen, LinearGradientMode.Vertical);
            ColorBlend blend = new ColorBlend();

            // Set multi-color gradient
            blend.Positions = new[] { 0.0f, 0.35f, 0.5f, 0.65f, 0.95f, 1f };
            blend.Colors = new[] { Color.FromArgb(47, colorR, colorR), Color.FromArgb(64, colorR + 22, colorR + 32), Color.FromArgb(66, colorR + 20, colorR + 35), Color.FromArgb(64, colorR + 20, colorR + 32), Color.FromArgb(49, colorR, colorR + 1), SystemColors.Control };
            //blend.Colors = new[] { Color.FromArgb(47, colorR, 64), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(66, colorR + 35, 90), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(49, colorR + 1, 66),SystemColors.Control };
            grad.InterpolationColors = blend;
            Font myf = new System.Drawing.Font(this.Font.FontFamily, 16);
            // Draw basic gradient and shadow
            //gg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gg.FillRectangle(grad, gradRect);
            gg.FillRectangle(shadow, shadowRect);
            gg.TextRenderingHint = TextRenderingHint.AntiAlias;
            gg.DrawString("Добавить в закладки", myf, Brushes.GhostWhite, new PointF(55, 10));
            gg.DrawImage(Properties.Resources.ico135, 10, 10);

            g.DrawImageUnscaled(drawing, 0, 0);
            gg.Dispose();

            // Draw checkers
            //g.FillRectangle(checkers, r);
        }

        private void TopP_Paint(object sender, PaintEventArgs e)
        {
            DrawFormBackgroud(e.Graphics, e.ClipRectangle);
        }

        private void drawT_Tick(object sender, EventArgs e)
        {
            if (!grew)
            {
                if (colorR == 140) { grew = true; }
                else
                {
                    colorR++;
                }
            }
            else
            {
                if (colorR < 74) { grew = false; }
                else
                {
                    colorR--;
                }
            }
            this.Invalidate();
            //this.Refresh();
        }

        private void ZaklAdd_Load(object sender, EventArgs e)
        {
            if (OptData.Default.ZaklData.DropDownItems.Count > 0)
            {
                foreach (ToolStripMenuItem tsm in OptData.Default.ZaklData.DropDownItems)
                {
                    if (tsm.Checked) folderL.Items.Add(tsm.Text);
                }
                folderL.SelectedIndex = 0;
            }
            else folderL.Enabled = false;
            tName.Text = zakl.name;
            drawT.Start();
            tName.Focus();
        }

        private void ZaklAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            drawT.Stop();
            OptData.Default.MainForm.Enabled = true;
        }

        private void добавитьВЗакладкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tName.TextLength>0)
            {
                char[] trimC = { ' ', '_' };
                ToolStripMenuItem mi = new ToolStripMenuItem(tName.Text.Trim());
                mi.Name = zakl.ip;
                mi.ToolTipText = zakl.ip;
                mi.Click += new EventHandler(mi_Click);
                mi.Image = ico;
                if (folderL.SelectedIndex > 0)
                {
                    ToolStripMenuItem men = (ToolStripMenuItem)OptData.Default.ZaklData.DropDownItems[folderL.SelectedIndex - 1];
                    men.DropDownItems.Add(mi);
                }
                else
                OptData.Default.ZaklData.DropDownItems.Add(mi);
                //mi.Click += new EventHandler(открытьToolStripMenuItem_Click);
            }
            this.Close();
        }

        void mi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem nmi = (ToolStripMenuItem)sender;
            try
            {
                Process pProc = new Process();
                string adr = @"\\" + nmi.Name;
                pProc.StartInfo.FileName = "explorer.exe";
                pProc.StartInfo.Arguments = adr;
                pProc.Start();
            }
            catch (Exception)
            {
                Console.WriteLine("No any selected items!");
            }
        }

        public class ZaklInfo
        {
            string namen="", ipa="";

            public ZaklInfo()
            { }

            public ZaklInfo(string Name,string Ip)
            {
                namen = Name;
                ipa = Ip;
            }

            public string name
            {
                get { return namen; }
                set { namen = value; }
            }

            public string ip
            {
                get { return ipa; }
                set { ipa = value; }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
