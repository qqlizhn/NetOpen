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
    public partial class GlassAb : Form
    {

        private DwmApi.MARGINS m_glassMargins;
        private enum RenderMode { None, EntireWindow, TopWindow, Region };
        private RenderMode m_RenderMode;
        private Region m_blurRegion;
        public static bool IsGlass = false;
        bool opac = false;
        double step = 0.05;
        int colorR = 94;
        Graphics gg;
        Bitmap drawing = null;

        public GlassAb()
        {
            InitializeComponent();
        }

        #region Классы и функции для использования dwm в нашем приложении

        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg); // let the normal winproc process it

            if (IsGlass)
            {
                const int WM_DWMCOMPOSITIONCHANGED = 0x031E;
                const int WM_NCHITTEST = 0x84;
                const int HTCLIENT = 0x01;

                switch (msg.Msg)
                {
                    case WM_NCHITTEST:
                        if (HTCLIENT == msg.Result.ToInt32())
                        {
                            // it's inside the client area

                            // Parse the WM_NCHITTEST message parameters
                            // get the mouse pointer coordinates (in screen coordinates)
                            Point p = new Point();
                            p.X = (msg.LParam.ToInt32() & 0xFFFF);// low order word
                            p.Y = (msg.LParam.ToInt32() >> 16); // hi order word

                            // convert screen coordinates to client area coordinates
                            p = PointToClient(p);

                            // if it's on glass, then convert it from an HTCLIENT
                            // message to an HTCAPTION message and let Windows handle it from then on
                            if (PointIsOnGlass(p))
                                msg.Result = new IntPtr(2);
                        }
                        break;

                    case WM_DWMCOMPOSITIONCHANGED:
                        if (!DwmApi.DwmIsCompositionEnabled())
                        {
                            m_RenderMode = RenderMode.None;
                            m_glassMargins = null;
                            if (m_blurRegion != null)
                            {
                                m_blurRegion.Dispose();
                                m_blurRegion = null;
                            }
                        }
                        break;
                }
            }
        }

        private bool PointIsOnGlass(Point p)
        {
            // test for region or entire client area
            // or if upper window glass and inside it.
            // not perfect, but you get the idea
            return m_glassMargins != null &&
                (m_glassMargins.cyTopHeight <= 0 ||
                 m_glassMargins.cyTopHeight > p.Y);
        }

        private void ResetDwmBlurBehind()
        {
            if (DwmApi.DwmIsCompositionEnabled())
            {
                DwmApi.DWM_BLURBEHIND bbhOff = new DwmApi.DWM_BLURBEHIND();
                bbhOff.dwFlags = DwmApi.DWM_BLURBEHIND.DWM_BB_ENABLE | DwmApi.DWM_BLURBEHIND.DWM_BB_BLURREGION;
                bbhOff.fEnable = false;
                bbhOff.hRegionBlur = IntPtr.Zero;
                DwmApi.DwmEnableBlurBehindWindow(this.Handle, bbhOff);
            }
        }

        internal class DwmApi
        {
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmEnableBlurBehindWindow(
                IntPtr hWnd, DWM_BLURBEHIND pBlurBehind);

            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmExtendFrameIntoClientArea(
                IntPtr hWnd, MARGINS pMargins);

            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern bool DwmIsCompositionEnabled();

            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmEnableComposition(bool bEnable);

            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmGetColorizationColor(
                out int pcrColorization,
                [MarshalAs(UnmanagedType.Bool)]out bool pfOpaqueBlend);

            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern IntPtr DwmRegisterThumbnail(
                IntPtr dest, IntPtr source);

            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmUnregisterThumbnail(IntPtr hThumbnail);

            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmUpdateThumbnailProperties(
                IntPtr hThumbnail, DWM_THUMBNAIL_PROPERTIES props);

            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern void DwmQueryThumbnailSourceSize(
                IntPtr hThumbnail, out Size size);

            [StructLayout(LayoutKind.Sequential)]
            public class DWM_THUMBNAIL_PROPERTIES
            {
                public uint dwFlags;
                public RECT rcDestination;
                public RECT rcSource;
                public byte opacity;
                [MarshalAs(UnmanagedType.Bool)]
                public bool fVisible;
                [MarshalAs(UnmanagedType.Bool)]
                public bool fSourceClientAreaOnly;
                public const uint DWM_TNP_RECTDESTINATION = 0x00000001;
                public const uint DWM_TNP_RECTSOURCE = 0x00000002;
                public const uint DWM_TNP_OPACITY = 0x00000004;
                public const uint DWM_TNP_VISIBLE = 0x00000008;
                public const uint DWM_TNP_SOURCECLIENTAREAONLY = 0x00000010;
            }

            [StructLayout(LayoutKind.Sequential)]
            public class MARGINS
            {
                public int cxLeftWidth, cxRightWidth,
                           cyTopHeight, cyBottomHeight;

                public MARGINS(int left, int top, int right, int bottom)
                {
                    cxLeftWidth = left; cyTopHeight = top;
                    cxRightWidth = right; cyBottomHeight = bottom;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public class DWM_BLURBEHIND
            {
                public uint dwFlags;
                [MarshalAs(UnmanagedType.Bool)]
                public bool fEnable;
                public IntPtr hRegionBlur;
                [MarshalAs(UnmanagedType.Bool)]
                public bool fTransitionOnMaximized;

                public const uint DWM_BB_ENABLE = 0x00000001;
                public const uint DWM_BB_BLURREGION = 0x00000002;
                public const uint DWM_BB_TRANSITIONONMAXIMIZED = 0x00000004;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left, top, right, bottom;

                public RECT(int left, int top, int right, int bottom)
                {
                    this.left = left; this.top = top;
                    this.right = right; this.bottom = bottom;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MARGINS
        {
            public int cxLeftWidth, cxRightWidth,
                       cyTopHeight, cyBottomHeight;

            public MARGINS(int left, int top, int right, int bottom)
            {
                cxLeftWidth = left; cyTopHeight = top;
                cxRightWidth = right; cyBottomHeight = bottom;
            }
        }
        #endregion

        private void GlassAb_Load(object sender, EventArgs e)
        {
            OpacityT.Start();
            try
            {
                if (Environment.OSVersion.Version.Major > 5)
                {
                    ResetDwmBlurBehind();
                    this.Paint+=new PaintEventHandler(OnPaint);
                    m_glassMargins = new DwmApi.MARGINS(-1, 0, 0, 0);
                    m_RenderMode = RenderMode.EntireWindow;
                    IsGlass = true;
                    if (DwmApi.DwmIsCompositionEnabled()) DwmApi.DwmExtendFrameIntoClientArea(this.Handle, m_glassMargins);

                    // reset window border style in case DwmEnableBlurBehindWindow was set
                    //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
                    this.Invalidate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            //this.Text = IsGlass.ToString() + " " + Environment.OSVersion.Version.Major.ToString();
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer,true);
            //moveLine.Start();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            if (IsGlass)
            if (DwmApi.DwmIsCompositionEnabled())
            {
                switch (m_RenderMode)
                {
                    case RenderMode.EntireWindow:
                        e.Graphics.FillRectangle(Brushes.Black, this.ClientRectangle);
                        break;

                    case RenderMode.TopWindow:
                        e.Graphics.FillRectangle(Brushes.Black, Rectangle.FromLTRB(0, 0, this.ClientRectangle.Width, m_glassMargins.cyTopHeight));
                        break;

                    case RenderMode.Region:
                        if (m_blurRegion != null) e.Graphics.FillRegion(Brushes.Black, m_blurRegion);
                        break;
                }
            }
            DrawFormBackgroud(e.Graphics, e.ClipRectangle);
            // You can experiment with text colors & opacities (255 = opaque, 0-0-0 = black)
            /*using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 0)))
            {
                e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                e.Graphics.DrawString("This is writing on glass", this.Font, textBrush, 10, 10);
            }*/
        }

        public void DrawFormBackgroud(Graphics g, Rectangle r)
        {

            drawing = new Bitmap(this.Width, this.Height, g);
            gg = Graphics.FromImage(drawing);

            Rectangle shadowRect = new Rectangle(r.X, r.Y, r.Width, 10);
            Rectangle gradRect = new Rectangle(r.X, r.Y + 9, r.Width, r.Height - 90);
            //LinearGradientBrush shadow = new LinearGradientBrush(shadowRect, Color.FromArgb(30, 41, 61), Color.FromArgb(47, 64, 94), LinearGradientMode.Vertical);
            LinearGradientBrush shadow = new LinearGradientBrush(shadowRect, Color.FromArgb(200,47, 61, 41), Color.FromArgb(100,47, 64, 41), LinearGradientMode.Vertical);
            //LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.FromArgb(47, 64, 94), Color.FromArgb(49, 66, 95), LinearGradientMode.Vertical);
            LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.Green, Color.DarkGreen, LinearGradientMode.Vertical);
            LinearGradientBrush CirclGrad = new LinearGradientBrush(gradRect, Color.FromArgb(0,67,125,98), Color.FromArgb(0,0,0,0), LinearGradientMode.Vertical);
            ColorBlend blend = new ColorBlend();

            // Set multi-color gradient
            blend.Positions = new[] { 0.0f, 0.35f, 0.5f, 0.65f, 1.0f };
            //blend.Colors = new[] { Color.FromArgb(47, 64, 94), Color.FromArgb(64, 88, 126), Color.FromArgb(66, 90, 129), Color.FromArgb(64, 88, 126), Color.FromArgb(49, 66, 95) };
            blend.Colors = new[] { Color.FromArgb(47, colorR, 64), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(66, colorR + 35, 90), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(49, colorR + 1, 66) };
            grad.InterpolationColors = blend;
            Font myf = new System.Drawing.Font(this.Font.FontFamily, 21);
            Font myf2 = new System.Drawing.Font(this.Font.FontFamily, 22);
            //Font myf2 = new System.Drawing.Font(this.Font.FontFamily, 16);
            // Draw basic gradient and shadow
            //gg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //gg.FillRectangle(grad, gradRect);
            //gg.FillRectangle(shadow, shadowRect);
            //gg.DrawString("Добавить один ПК", myf, Brushes.Black, new PointF(55, 15));
            //gg.DrawLine(Pens.Black, 0, inY, this.Width, inY);
            gg.TextRenderingHint = TextRenderingHint.AntiAlias;
            gg.DrawString("netOpen "+Application.ProductVersion.ToString(), myf2, shadow, new PointF(Width/2-125, 255));
            gg.DrawString("netOpen "+Application.ProductVersion.ToString(), myf, Brushes.White, new PointF(Width/2-120, 255));

            //gg.DrawString("Ковальчуку Вячеславу", myf2, shadow, new PointF(Width / 2 - 125, 255));

            gg.DrawString("Разработчик:", this.Font, Brushes.Black, 25, 300);
            gg.DrawString("Контактная иформация:", this.Font, Brushes.Black, 25, 300+this.Font.Size+5);
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpacityT.Start();
        }

        private void GlassAb_FormClosing(object sender, FormClosingEventArgs e)
        {
            OptData.Default.MainForm.Enabled = true;
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
                if (this.Opacity - step < 0.01) { this.Opacity = 0; OpacityT.Stop(); this.Close(); }
                else this.Opacity -= step;
            }
            //this.Text = "Timer Op is Running, and opacity=" + this.Opacity.ToString();
        }

    }
}
