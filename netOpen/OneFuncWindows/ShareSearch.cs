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
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace netOpen.OneFuncWindows
{
    public partial class ShareSearch : Form
    {
        private string curnamen,selp;
        bool grew = false;
        int colorR = 94,AnimSize=52;
        Graphics gg;
        Bitmap drawing = null;

        public ShareSearch()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {       //base.OnPaintBackground(e);    
            // Do nothing.
            //pevent.Graphics.FillRectangle(SystemBrushes.Control, 0, tableLayoutPanel1.RowStyles[0].Height, this.Width, this.Height - tableLayoutPanel1.RowStyles[0].Height);
            e.Graphics.FillRectangle(SystemBrushes.Control,0,e.ClipRectangle.Y+AnimSize,e.ClipRectangle.Width,e.ClipRectangle.Height-AnimSize);

        }

        private void cmSearch_is(object sender, EventArgs e)
        {
            ssl.Items.Clear();
            char[] seps=new char[]{'/','\\','|'};
            string[] mas = cmSearch.Text.Split(seps);
            foreach(netOpen_MainWindow.ShareData ShareE in netOpen_MainWindow.ShareList)
            {
                for (int i = 0; i < ShareE.ShareName.Count; i++)
                {
                    foreach (string ShN in mas)
                    {
                        if (ShN.Length > 0)
                        {
                            if ((ShareE.ShareName[i].ToLower().Contains(ShN.ToLower()) || ShareE.ShareName[i].ToLower() == ShN.ToLower())&&!IsItIs(ShareE.ShareAdress[i]))
                            {
                                ListViewItem lst = new ListViewItem(ShareE.ShareName[i]);
                                lst.SubItems.Add(ShareE.ShareAdress[i]);
                                lst.SubItems.Add(ShareE.ShareAdress[i]);
                                //lst.StateImageIndex = 1;
                                lst.ImageIndex = 1;
                                ssl.Items.Add(lst);
                            }
                            foreach (FileSystemInfo fsi in ShareE.NearFilesFolders)
                            {
                                if ((fsi.Name.ToLower().Contains(ShN.ToLower()) || fsi.Name.ToLower() == ShN.ToLower()) && !IsItIs(fsi.FullName))
                                {
                                        ListViewItem lst = new ListViewItem(fsi.Name);
                                        //MessageBox.Show(fsi.Extension.Length.ToString());
                                        if (fsi.Extension.Length > 0)
                                        {
                                            try
                                            {
                                                FileInfo ofof = new FileInfo(fsi.FullName);
                                               
                                            if (!iml.Images.ContainsKey(fsi.Name))
                                                    iml.Images.Add(fsi.Name, System.Drawing.Icon.ExtractAssociatedIcon(fsi.FullName));
                                            lst.ImageKey = fsi.Name;
                                                }
                                                catch (Exception ex)
                                                {
                                                    //MessageBox.Show("Icon is not getted!!\n"+ex.Message);
                                                    lst.ImageIndex = 2;
                                                }
                                            
                                            lst.SubItems.Add(fsi.Extension);
                                        }
                                        else
                                        {
                                            lst.ImageIndex = 1;
                                            lst.SubItems.Add(fsi.FullName);
                                        }
                                        lst.SubItems.Add(fsi.FullName);
                                        ssl.Items.Add(lst);
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool IsItIs(string path)
        {
            bool AllReady = false;
            foreach (ListViewItem lwi in ssl.Items)
            {
                if (path.ToUpper() == lwi.SubItems[2].Text.ToUpper())
                    AllReady = true;
            }
            return AllReady;
        }

        private void ShareSearch_Load(object sender, EventArgs e)
        {
            ssl.SmallImageList=iml;
            ssl.DoubleClick+=new EventHandler(Share_MouseClick);
            drawT.Start();
            DoubleBuffered = true;
            this.SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            /*try{
            Icon newi = Icon.ExtractAssociatedIcon(@"\\192.168.0.158\1кусок\One Piece Ep.215-216.srt");}
            catch (Exception ex) { MessageBox.Show(ex.Message); }*/
        }

        public void Share_MouseClick(object sender, EventArgs e)
        {
            ListView temp = (ListView)sender;
            //MessageBox.Show(temp.FocusedItem.ToolTipText, "fuck");
            try
            {
                Process pProc = new Process();
                pProc.StartInfo.FileName = "explorer.exe";
                pProc.StartInfo.Arguments = temp.FocusedItem.SubItems[2].Text;
                pProc.Start();
            }
            catch (Exception)
            {
                Console.WriteLine("No any selected items!");
            }
        }

        private void детальныйВидToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ssl.View = View.Details;
        }

        private void крупныеЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ssl.View = View.LargeIcon;
        }

        private void мелкиеЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ssl.View = View.SmallIcon;
        }

        private void плиткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ssl.View = View.Tile;
        }

        public void DrawFormBackgroud(Graphics g, Rectangle r)
        {

            drawing = new Bitmap(this.Width, AnimSize, g);
            gg = Graphics.FromImage(drawing);

            Rectangle shadowRect = new Rectangle(r.X, r.Y, r.Width, 10);
            Rectangle gradRect = new Rectangle(r.X, r.Y + 9, r.Width, AnimSize-9);
            LinearGradientBrush shadow = new LinearGradientBrush(shadowRect, Color.FromArgb(30, 61, 61), Color.FromArgb(47, colorR, colorR), LinearGradientMode.Vertical);
            //LinearGradientBrush shadow = new LinearGradientBrush(shadowRect, Color.FromArgb(30, 61, 41), Color.FromArgb(47, colorR, 64), LinearGradientMode.Vertical);
            LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.FromArgb(47, 64, 94), Color.FromArgb(49, 66, 95), LinearGradientMode.Vertical);
            //LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.Green, Color.DarkGreen, LinearGradientMode.Vertical);
            ColorBlend blend = new ColorBlend();

            // Set multi-color gradient
            blend.Positions = new[] { 0.0f, 0.35f, 0.5f, 0.65f, 0.95f,1f };
            blend.Colors = new[] { Color.FromArgb(47, colorR, colorR), Color.FromArgb(64, colorR + 22, colorR + 32), Color.FromArgb(66, colorR + 20, colorR + 35), Color.FromArgb(64, colorR + 20, colorR + 32), Color.FromArgb(49, colorR, colorR + 1), SystemColors.Control };
            //blend.Colors = new[] { Color.FromArgb(47, colorR, 64), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(66, colorR + 35, 90), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(49, colorR + 1, 66),SystemColors.Control };
            grad.InterpolationColors = blend;
            Font myf = new System.Drawing.Font(this.Font.FontFamily, 16);
            // Draw basic gradient and shadow
            //gg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gg.FillRectangle(grad, gradRect);
            gg.FillRectangle(shadow, shadowRect);
            gg.TextRenderingHint = TextRenderingHint.AntiAlias;
            gg.DrawString("Поиск по ресурсам сети", myf, Brushes.GhostWhite, new PointF(55, 15));
            gg.DrawImage(Properties.Resources.search1.ToBitmap(), 10, 10,32,32);

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

        private void ShareSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            drawT.Stop();
            OptData.Default.MainForm.Enabled = true;
        }

        private void cmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                EventArgs ex = new EventArgs();
                cmSearch_is(sender, ex);
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = true;
            fb.Description = "Выберите папку, для сохранения файла";
            //fb.RootFolder = Environment.SpecialFolder.MyDocuments;
            if (fb.ShowDialog() == DialogResult.OK)
            {
                Thread tr = new Thread(new ThreadStart(TrCopy));
                tr.IsBackground = true;
                selp = fb.SelectedPath;
                tr.Start();
            }
                //CopyFile(ssl.SelectedItems[0].ToolTipText, fb.SelectedPath);
            
        }

        void TrCopy()
        {
            Copyer letscopy = new Copyer(ssl.FocusedItem.SubItems[2].Text,
                    selp + @"\" + ssl.FocusedItem.Text);
                curnamen = ssl.SelectedItems[0].Text;
                //letscopy.CopyComplete += new Action<bool>(letscopy_CopyComplete);
                letscopy.CopyIt();

        }

        bool letscopy_CopyComplete()
        {
            OptData.Default.NotifyMe.BalloonTipTitle = "Копирование завершено";
            OptData.Default.NotifyMe.BalloonTipText = curnamen;
            OptData.Default.NotifyMe.BalloonTipIcon = ToolTipIcon.Info;
            OptData.Default.NotifyMe.ShowBalloonTip(1500);
            return true;
        }
    }
}
