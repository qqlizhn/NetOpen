using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Design;
using System.Runtime.InteropServices;
//using System.ServiceModel.Dispatcher;

namespace netOpen
{
    public partial class SinglePCAdd : Form
    {
        bool grew = false;
        int colorR = 94;
        Graphics gg;
        Bitmap drawing = null;

        public SinglePCAdd()
        {
            InitializeComponent();
        }

        private void SinglePCAdd_Load(object sender, EventArgs e)
        {
            rbIP.Checked = true;
            drawT.Start();
            DoubleBuffered = true;
            rbDom.UseCompatibleTextRendering = true;
            rbIP.UseCompatibleTextRendering = true;
           // TopP.;
            this.SetStyle( /*ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |*/ControlStyles.DoubleBuffer, true);
            //this.Update();
        }

      public void DrawFormBackgroud(Graphics g, Rectangle r)
{

    drawing = new Bitmap(this.Width, this.Height, g);
    gg = Graphics.FromImage(drawing);

	Rectangle shadowRect = new Rectangle(r.X, r.Y, r.Width, 10);
	Rectangle gradRect = new Rectangle(r.X, r.Y + 9, r.Width, 42);
	//LinearGradientBrush shadow = new LinearGradientBrush(shadowRect, Color.FromArgb(30, 41, 61), Color.FromArgb(47, 64, 94), LinearGradientMode.Vertical);
    LinearGradientBrush shadow = new LinearGradientBrush(shadowRect, Color.FromArgb(30, 61, 41), Color.FromArgb(47, colorR, 64), LinearGradientMode.Vertical);
	//LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.FromArgb(47, 64, 94), Color.FromArgb(49, 66, 95), LinearGradientMode.Vertical);
    LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.Green, Color.DarkGreen, LinearGradientMode.Vertical);
	ColorBlend blend = new ColorBlend();

	// Set multi-color gradient
	blend.Positions = new[] { 0.0f, 0.35f, 0.5f, 0.65f, 1.0f };
	//blend.Colors = new[] { Color.FromArgb(47, 64, 94), Color.FromArgb(64, 88, 126), Color.FromArgb(66, 90, 129), Color.FromArgb(64, 88, 126), Color.FromArgb(49, 66, 95) };
    blend.Colors = new[] { Color.FromArgb(47,colorR, 64), Color.FromArgb(64, colorR+32, 88), Color.FromArgb(66, colorR+35, 90), Color.FromArgb(64, colorR+32, 88), Color.FromArgb(49, colorR+1, 66) };
	grad.InterpolationColors = blend;
    Font myf=new System.Drawing.Font(this.Font.FontFamily,16);
	// Draw basic gradient and shadow
    //gg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
	gg.FillRectangle(grad, gradRect);
	gg.FillRectangle(shadow, shadowRect);
    gg.DrawString("Добавить один ПК", myf, Brushes.GhostWhite, new PointF(55, 15));
    gg.DrawImage(Properties.Resources.singleAdd1.ToBitmap(), 10, 10,32,32);


    g.DrawImageUnscaled(drawing, 0, 0);
    gg.Dispose();

	// Draw checkers
    //g.FillRectangle(checkers, r);
}

      private void TopP_Paint(object sender, PaintEventArgs e)
      {
          DrawFormBackgroud(e.Graphics, e.ClipRectangle);
      }

      private void rbIP_CheckedChanged(object sender, EventArgs e)
      {
          if (rbIP.Checked)
          {
              tName.Enabled = false;
              ipAd.Enabled = true;
              ipAd.Focus();
          }
          else
          {
              tName.Enabled = true;
              ipAd.Enabled = false;
              tName.Focus();
          }
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

      private void SinglePCAdd_FormClosing(object sender, FormClosingEventArgs e)
      {
          drawT.Stop();
          OptData.Default.MainForm.Enabled = true;
      }

      protected override void OnPaintBackground(
         System.Windows.Forms.PaintEventArgs pevent)
      {
          // Do nothing.
          pevent.Graphics.FillRectangle(SystemBrushes.Control, 0, 52, this.Width, this.Height - 51);
          
      }

      private void button2_Click(object sender, EventArgs e)
      {
          this.Close();
      }

      private void button1_Click(object sender, EventArgs e)
      {

          if (rbIP.Checked)
          {
              netOpen_MainWindow.tChangeBox.Text = ipAd.Text;
          }
          else
          {
              netOpen_MainWindow.tChangeBox.Text = tName.Text;
          }
          this.Close();
      }

      private void ipAd_KeyDown(object sender, KeyEventArgs e)
      {
          if (e.KeyData == Keys.Enter)
          {
              EventArgs ex = new EventArgs();
              button1_Click(sender, ex);
          }
      }

    }
}
