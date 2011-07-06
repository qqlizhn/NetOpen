using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Design;
//using System.ServiceModel.Dispatcher;

namespace netOpen
{
    public partial class NonGlassAb : Form
    {
        int colorR = 94;
        bool grew=false,opac=false;
        double step = 0.05;
        Graphics gg;
        Bitmap drawing = null;

        public NonGlassAb()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //Do nothing
        }

        private void Close_Click(object sender, EventArgs e)
        {
            OpacityT.Start();
           // this.Text = "Timer Stoped";
        }

        public void DrawFormBackgroud(Graphics g, Rectangle r)
        {
            drawing = new Bitmap(this.Width, this.Height, g);
            gg = Graphics.FromImage(drawing);

            Rectangle shadowRect = new Rectangle(r.X, r.Y, r.Width, 100);
            Rectangle shadowDownRect = new Rectangle(r.X,r.Height-65, r.Width, 65);
            Rectangle gradRect = new Rectangle(r.X, r.Y + 99, r.Width, r.Height-158);
            //LinearGradientBrush shadow = new LinearGradientBrush(shadowRect, Color.FromArgb(30, 41, 61), Color.FromArgb(47, 64, 94), LinearGradientMode.Vertical);
            LinearGradientBrush shadowUP = new LinearGradientBrush(shadowRect, Color.FromArgb(30, 61, 41), Color.FromArgb(47, colorR, 64), LinearGradientMode.Vertical);
            LinearGradientBrush shadowDown = new LinearGradientBrush(shadowDownRect, Color.FromArgb(49, colorR + 1, 66), Color.FromArgb(255, 255, 255), LinearGradientMode.Vertical);
            //LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.FromArgb(47, 64, 94), Color.FromArgb(49, 66, 95), LinearGradientMode.Vertical);
            LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.Green, Color.DarkGreen, LinearGradientMode.Vertical);
            LinearGradientBrush CirclGrad = new LinearGradientBrush(gradRect, Color.FromArgb(0, 67, 125, 98), Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical);
            ColorBlend blend = new ColorBlend();
            ColorBlend ShBlend = new ColorBlend();

            // Set multi-color gradient
            blend.Positions = new[] { 0.0f, 0.35f, 0.5f, 0.65f, 1.0f };
            ShBlend.Positions = new[] {0.0f,0.75f,1.0f};
            //blend.Colors = new[] { Color.FromArgb(47, 64, 94), Color.FromArgb(64, 88, 126), Color.FromArgb(66, 90, 129), Color.FromArgb(64, 88, 126), Color.FromArgb(49, 66, 95) };
            ShBlend.Colors = new[] { Color.FromArgb(49, colorR + 1, 66), Color.FromArgb(66, colorR + 90, 90),Color.WhiteSmoke };
            shadowDown.InterpolationColors = ShBlend;
            blend.Colors = new[] { Color.FromArgb(47, colorR, 64), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(66, colorR + 35, 90), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(49, colorR + 1, 66) };
            grad.InterpolationColors = blend;
            Font myf = new System.Drawing.Font(this.Font.FontFamily, 21);
            Font myf2 = new System.Drawing.Font(this.Font.FontFamily, 22);
           // Font myf2 = new System.Drawing.Font(this.Font.FontFamily, 16);
            // Draw basic gradient and shadow
            //gg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gg.FillRectangle(grad, gradRect);
            gg.FillRectangle(shadowUP, shadowRect);
            gg.FillRectangle(shadowDown, shadowDownRect);
            //gg.DrawString("Добавить один ПК", myf, Brushes.Black, new PointF(55, 15));
            //gg.DrawLine(Pens.Black, 0, inY, this.Width, inY);
            gg.TextRenderingHint = TextRenderingHint.AntiAlias;
            gg.DrawString("netOpen " + Application.ProductVersion.ToString(), myf2, shadowUP, new PointF(Width / 2 - 125, 255));
            gg.DrawString("netOpen " + Application.ProductVersion.ToString(), myf, Brushes.White, new PointF(Width / 2 - 120, 255));

           // gg.DrawString("Ковальчуку Вячеславу", myf2, shadowUP, new PointF(Width / 2 - 125, 255));

            gg.DrawString("Разработчик:", this.Font, Brushes.Black, 25, 300);
            gg.DrawString("Контактная иформация:", this.Font, Brushes.Black, 25, 300 + this.Font.Size + 5);
            //gg.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
            gg.DrawString("Филиппов Сергей", this.Font, Brushes.DarkSlateGray, 200, 300);
            gg.DrawString("fenriv@gmail.com", this.Font, Brushes.DarkSlateGray, 200, 300 + this.Font.Size + 5);
            /*gg.DrawString("0.7", myf2, Brushes.Black, new PointF(Width / 2+40, 255));
            gg.DrawString("0.7", myf, Brushes.White, new PointF(Width / 2+40 , 255));*/
            gg.DrawImage(Properties.Resources.Earth200, 35, 0);
            gg.FillEllipse(CirclGrad, 100, 100, 100, 100);

            g.DrawImageUnscaled(drawing, 0, 0);
            gg.Dispose();

            // Draw checkers
            //g.FillRectangle(checkers, r);
        }
        public void DrawButtonBackgroud(Graphics g, Rectangle r)
        {
            drawing = new Bitmap(this.Width, this.Height, g);
            gg = Graphics.FromImage(drawing);

            //Rectangle shadowRect = new Rectangle(r.X, r.Y, r.Width, 5);
            Rectangle shadowDownRect = new Rectangle(r.X, r.Y, r.Width, r.Height);
            Rectangle gradRect = new Rectangle(r.X-2, r.Y, r.Width+2, r.Height-2);
            
            //LinearGradientBrush shadowUP = new LinearGradientBrush(shadowRect, Color.FromArgb(30, 61, 41), Color.FromArgb(47, colorR, 64), LinearGradientMode.Vertical);
            LinearGradientBrush shadowDown = new LinearGradientBrush(shadowDownRect, Color.FromArgb(66, colorR + 90, 90), Color.FromArgb(255, 255, 255), LinearGradientMode.Vertical);
            
            LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.Green, Color.DarkGreen, LinearGradientMode.Vertical);
            //LinearGradientBrush CirclGrad = new LinearGradientBrush(gradRect, Color.FromArgb(0, 67, 125, 98), Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical);
            ColorBlend blend = new ColorBlend();
            ColorBlend ShBlend = new ColorBlend();

            // Set multi-color gradient
            blend.Positions = new[] { 0.0f, 0.35f, 0.5f, 0.65f, 1.0f };
            //ShBlend.Positions = new[] {0,0f, 0.25f ,1.0f };
            ShBlend.Positions = new[] { 0.0f, 0.25f, 1.0f };

            //ShBlend.Colors = new[] { Color.FromArgb(66, colorR + 90, 90), Color.FromArgb(66, colorR + 90, 90), Color.WhiteSmoke };
            ShBlend.Colors = new[] { Color.FromArgb(67, colorR + 91, 91), Color.FromArgb(66, colorR + 90, 90), Color.WhiteSmoke };
            shadowDown.InterpolationColors = ShBlend;
            blend.Colors = new[] { Color.FromArgb(47, colorR, 64), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(66, colorR + 35, 90), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(49, colorR + 1, 66) };
            grad.InterpolationColors = blend;
            Font myf = new System.Drawing.Font(this.Font.FontFamily, 21);

            // Draw basic gradient and shadow
           // gg.FillRectangle(grad, gradRect);
            //gg.FillRectangle(shadowUP, shadowRect);
            gg.FillRectangle(shadowDown, shadowDownRect);
            gg.DrawRectangle(Pens.Black, gradRect);
            gg.TextRenderingHint = TextRenderingHint.AntiAlias;
            gg.DrawString("Закрыть", this.Font, SystemBrushes.ControlText, new PointF(10, 5));

            g.DrawImageUnscaled(drawing, 0, 0);
            gg.Dispose();

            // Draw checkers
            //g.FillRectangle(checkers, r);
        }

        private void NonGlassAb_Paint(object sender, PaintEventArgs e)
        {
            DrawFormBackgroud(e.Graphics, e.ClipRectangle);
        }

        private void NonGlassAb_FormClosing(object sender, FormClosingEventArgs e)
        {
            OptData.Default.MainForm.Enabled = true;
        }

        private void drawT_Tick(object sender, EventArgs e)
        {
            //this.Text = "Timer running";
            if (!grew)
            {
                if (colorR == 160) { grew = true; }
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
            Close.Invalidate();
            //this.Refresh();
        }

        private void NonGlassAb_Load(object sender, EventArgs e)
        {
            OpacityT.Start();
            drawT.Start();
            
        }

        private void Close_Paint(object sender, PaintEventArgs e)
        {
            DrawButtonBackgroud(e.Graphics, e.ClipRectangle);
        }

        private void OpacityT_Tick(object sender, EventArgs e)
        {
            if (!opac)
            {
                if (this.Opacity + step > 0.99) { this.Opacity = 1; OpacityT.Stop(); opac = true; }
                else this.Opacity += step;
            }
            else
            {
                if (this.Opacity - step < 0.01) { this.Opacity = 0; OpacityT.Stop(); drawT.Stop(); this.Close(); }
                else this.Opacity -= step;
            }
            //this.Text = "Timer Op is Running, and opacity=" + this.Opacity.ToString();
        }
    }
}
