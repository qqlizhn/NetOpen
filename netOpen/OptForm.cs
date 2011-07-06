using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using netOpen;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Net;

namespace netOpen
{
    public partial class OptForm : Form
    {
        public static bool HaveAChange = false;
        bool grew = false;
        int colorR = 94, AnimSize = 52;
        Graphics gg;
        Bitmap drawing = null;

        public OptForm()
        {
            InitializeComponent();
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
            Rectangle gradRect = new Rectangle(r.X, r.Y + 9, r.Width, AnimSize - 10);
            LinearGradientBrush shadow = new LinearGradientBrush(shadowRect, Color.FromArgb(61, 30, 41), Color.FromArgb(colorR, 47, colorR), LinearGradientMode.Vertical);
            //LinearGradientBrush shadow = new LinearGradientBrush(shadowRect, Color.FromArgb(30, 61, 41), Color.FromArgb(47, colorR, 64), LinearGradientMode.Vertical);
            LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.FromArgb(47, 64, 94), Color.FromArgb(49, 66, 95), LinearGradientMode.Vertical);
            //LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.Green, Color.DarkGreen, LinearGradientMode.Vertical);
            ColorBlend blend = new ColorBlend();

            // Set multi-color gradient
            blend.Positions = new[] { 0.0f, 0.35f, 0.5f, 0.65f, 0.95f, 1f };
            blend.Colors = new[] { Color.FromArgb(colorR, 47, colorR), Color.FromArgb(colorR + 22, 64, colorR + 32), Color.FromArgb(colorR + 20, 66, colorR + 35), Color.FromArgb(colorR + 20, 64, colorR + 32), Color.FromArgb(colorR, 49, colorR + 1), SystemColors.Control };
            //blend.Colors = new[] { Color.FromArgb(47, colorR, 64), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(66, colorR + 35, 90), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(49, colorR + 1, 66),SystemColors.Control };
            grad.InterpolationColors = blend;
            Font myf = new System.Drawing.Font(this.Font.FontFamily, 16);
            // Draw basic gradient and shadow
            //gg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gg.FillRectangle(grad, gradRect);
            gg.FillRectangle(shadow, shadowRect);
            gg.TextRenderingHint = TextRenderingHint.AntiAlias;
            gg.DrawString("Настройки проложения", myf, Brushes.GhostWhite, new PointF(55, 15));
            gg.DrawImage(Properties.Resources.opt1.ToBitmap(), 10, 10,32,32);

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

        private void OptForm_Load(object sender, EventArgs e)
        {
            //this.Icon = Properties.Resources.opt;
            chkHiden.Checked = OptData.Default.ShowHidenRes;
            chkFragmP.Checked = OptData.Default.PingPacketFragment;
            chkListSave.Checked = OptData.Default.RememberPClist;
            trPingBuffer.Value = OptData.Default.PingBufferLen;
            trTimeOut.Value = OptData.Default.PingWaitTime;
            trThreadAmount.Value = OptData.Default.ScanThreadAmount;
            lTrAm.Text = trTimeOut.Value.ToString();
            lBufAm.Text = trPingBuffer.Value.ToString();
            lThAm.Text = trThreadAmount.Value.ToString();
            OptData.Default.OptForm = this;
            OptData.Default.diapListH = diapList;
            for (int i = 0; i < OptData.Default.DiapCount; i++)
            {
                ListViewItem nli = new ListViewItem();
                nli.Text = netOpen_MainWindow.ipdip[i].Name;
                nli.SubItems.Add(netOpen_MainWindow.ipdip[i].StartIPAdress);
                nli.SubItems.Add(netOpen_MainWindow.ipdip[i].EndIPAdress);
                nli.SubItems.Add(netOpen_MainWindow.ipdip[i].Status);
                nli.SubItems.Add(netOpen_MainWindow.ipdip[i].Descr);
                diapList.Items.Add(nli);
            }
            drawT.Start();
            FillZaklLists();
            //OptData.Default.Diapazon = diapList.Items[0];
        }

        private void bVkl_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem it in diapList.SelectedItems)
            {
                it.SubItems[3].Text = "Включено";
            }
            HaveAChange = true;
        }

        private void bOtkl_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem it in diapList.SelectedItems)
            {
                it.SubItems[3].Text = "Отключено";
            }
            HaveAChange = true;
            /*int i = diapList.FocusedItem.Index;
            diapList.Items[i].SubItems[3].Text = "Отключено";*/
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lTrAm.Text = trTimeOut.Value.ToString();
        }

        private void trPingBuffer_Scroll(object sender, EventArgs e)
        {
            lBufAm.Text = trPingBuffer.Value.ToString();
        }

        private void trThreadAmount_Scroll(object sender, EventArgs e)
        {
            lThAm.Text = trThreadAmount.Value.ToString();   
        }

        private void bOptSave_Click(object sender, EventArgs e)
        {
            LetMeIn();
            this.Close();
        }

        void LetMeIn()
        {
            OptData.Default.PingPacketFragment = chkFragmP.Checked;
            OptData.Default.RememberPClist = chkListSave.Checked;
            OptData.Default.ShowHidenRes = chkHiden.Checked;
            OptData.Default.ScanThreadAmount = Convert.ToByte(trThreadAmount.Value);
            OptData.Default.PingBufferLen = Convert.ToInt32(trPingBuffer.Value);
            OptData.Default.PingWaitTime = trTimeOut.Value;
            OptData.Default.Save();
        }

        private void bOptOtmena_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chkFragmP.Checked=false;
            chkListSave.Checked=true;
            chkHiden.Checked=false;
            trThreadAmount.Value=254;
            trPingBuffer.Value=8;
            trTimeOut.Value=2000;
            trThreadAmount_Scroll(sender, e);
            trPingBuffer_Scroll(sender, e);
            trackBar1_Scroll(sender, e);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            OptData.Default.Add = true;
            this.Enabled = false;
            AddRedact nf = new AddRedact();
            nf.Show();
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Действительно удалить?", "Удаление диапазона", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)==DialogResult.Yes)
            {
                try
                {
                    diapList.FocusedItem.Remove();
                    OptData.Default.DiapCount--;
                    HaveAChange = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Невозможно удалить");
                }
            }
        }


        private void diapList_Leave(object sender, EventArgs e)
        {
            //bDel.Enabled = false;
        }

        private void diapList_MouseDown(object sender, MouseEventArgs e)
        {
            bDel.Enabled = false;
            bCh.Enabled = false;
        }

        private void diapList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bDel.Enabled = true;
        }

        private void diapList_ItemActivate(object sender, EventArgs e)
        {
            bDel.Enabled = true;
            bCh.Enabled = true;
        }

        private void OptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventArgs ec=new EventArgs();
            //
            if (HaveAChange)
            {
                try
                {
                    WriteFile(diapList.Items);
                    netOpen_MainWindow.ipdip = new netOpen_MainWindow.DiapasonIP[1000];
                    for (int i = 0; i < OptData.Default.DiapCount; i++)
                    {
                        netOpen_MainWindow.ipdip[i].Name = diapList.Items[i].SubItems[0].Text;
                        netOpen_MainWindow.ipdip[i].StartIPAdress = diapList.Items[i].SubItems[1].Text;
                        netOpen_MainWindow.ipdip[i].EndIPAdress = diapList.Items[i].SubItems[2].Text;
                        netOpen_MainWindow.ipdip[i].Status = diapList.Items[i].SubItems[3].Text;
                        netOpen_MainWindow.ipdip[i].Descr = diapList.Items[i].SubItems[4].Text;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно сохранить файл настроек.\n" + 
                        ex.Message, "Ошибка сохранения настроек.", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                LetMeIn();
            }
            drawT.Stop();
            //bOptSave_Click(sender, ec);
                OptData.Default.MainForm.Enabled = true;
        }

        public void WriteFile(ListView.ListViewItemCollection lvi)
        {
            FileStream fs = new FileStream(netOpen_MainWindow.OptionFileName, FileMode.Create,FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(OptData.Default.DiapCount.ToString());
            for (int i = 0; i < OptData.Default.DiapCount; i++)
            {
                bw.Write(lvi[i].Text);
                bw.Write(lvi[i].SubItems[1].Text);
                bw.Write(lvi[i].SubItems[2].Text);
                bw.Write(lvi[i].SubItems[3].Text);
                bw.Write(lvi[i].SubItems[4].Text);
            }
            bw.Close();
        }

        private void bCh_Click(object sender, EventArgs e)
        {
            OptData.Default.Add = false;
            this.Enabled = false;
            AddRedact nf = new AddRedact();
            ListViewItem nli = new ListViewItem();
            nli = diapList.FocusedItem;
            nf.Text = "Редактировать диапазон";
            nf.tName.Text = nli.Text;
            nf.tStIP.Text = nli.SubItems[1].Text;
            nf.tEndIP.Text = nli.SubItems[2].Text;
            nf.tDescr.Text = nli.SubItems[4].Text;
            nf.Show();
        }

        void FillZaklLists()
        {
            int oofz = 0,folders=0;
            ListViewItem itemn = new ListViewItem("Вне папок");
            itemn.ImageIndex=1;
            lFold.Items.Add(itemn);
            if (OptData.Default.ZaklData.DropDownItems.Count>0)
            foreach (ToolStripMenuItem item in OptData.Default.ZaklData.DropDownItems)
            {
                if (item.Checked)
                {
                    ListViewItem newItem = new ListViewItem(item.Text);
                    newItem.ImageIndex=1;
                    lFold.Items.Add(newItem);
                    folders++;
                }
                else
                {
                    byte[] adr=new byte[]{192,168,12,1};
                    IPAddress ip=new IPAddress(adr);
                    ListViewItem newItem = new ListViewItem(item.Text);
                    newItem.ToolTipText = item.Name;
                    newItem.Name = item.Name;
                    if (IPAddress.TryParse(item.Name,out ip)) newItem.ImageIndex = 2;
                    else newItem.ImageIndex = 3;
                    lZakl.Items.Add(newItem);
                    oofz++;
                }
            }
        }

        private void lFold_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lst=lFold;
            if (lst.FocusedItem.Text == "Вне папок")
            {
                if (OptData.Default.ZaklData.DropDownItems.Count > 0)
                {
                    lZakl.Items.Clear();
                    foreach (ToolStripMenuItem item in OptData.Default.ZaklData.DropDownItems)
                    {
                        if (!item.Checked)
                        {
                            byte[] adr = new byte[] { 192, 168, 12, 1 };
                            IPAddress ip = new IPAddress(adr);
                            ListViewItem newItem = new ListViewItem(item.Text);
                            newItem.ToolTipText = item.Name;
                            newItem.Name = item.Name;
                            if (IPAddress.TryParse(item.Name, out ip)) newItem.ImageIndex = 2;
                            else newItem.ImageIndex = 3;
                            lZakl.Items.Add(newItem);
                        }
                    }
                }
            }
            else
            {
                if (OptData.Default.ZaklData.DropDownItems.Count > 0)
                {
                    lZakl.Items.Clear();
                    foreach (ToolStripMenuItem item in OptData.Default.ZaklData.DropDownItems)
                    {
                        if (item.Checked && item.Text == lst.FocusedItem.Text)
                        {
                            ToolStripMenuItem menu = (ToolStripMenuItem)item;
                            if (menu.DropDownItems.Count > 0)
                                foreach (ToolStripMenuItem subit in menu.DropDownItems)
                                {
                                    byte[] adr = new byte[] { 192, 168, 12, 1 };
                                    IPAddress ip = new IPAddress(adr);
                                    ListViewItem newItem = new ListViewItem(subit.Text);
                                    newItem.ToolTipText = subit.Name;
                                    newItem.Name = subit.Name;
                                    if (IPAddress.TryParse(subit.Name, out ip)) newItem.ImageIndex = 2;
                                    else newItem.ImageIndex = 3;
                                    lZakl.Items.Add(newItem);
                                }
                        }
                    }
                }
            }

        }

        private void delZakl_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lZakl.SelectedItems.Count; i++)
            {
                foreach (ToolStripMenuItem it in OptData.Default.ZaklData.DropDownItems)
                {
                    //ToolStripItem[] delit = OptData.Default.ZaklData.DropDownItems.Find(lZakl.SelectedItems[i].ToolTipText, true);
                    //OptData.Default.ZaklData.DropDownItems.RemoveByKey(lZakl.SelectedItems[i].ToolTipText);
                    if (it.DropDownItems.Count > 0)
                    {
                        //MessageBox.Show("Found drop down");
                        foreach (ToolStripMenuItem sit in it.DropDownItems)
                        {
                            //MessageBox.Show(/*sit.Name + "\n" + */lZakl.SelectedItems[i].Text);
                            if (sit.Name == lZakl.SelectedItems[i].ToolTipText)
                            {
                                it.DropDownItems.Remove(sit);
                                lZakl.Items.Remove(lZakl.SelectedItems[i]);
                                //MessageBox.Show(sit.Name + "\n" + lZakl.SelectedItems[i].ToolTipText);
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (it.Name == lZakl.SelectedItems[i].ToolTipText)
                        {
                            OptData.Default.ZaklData.DropDownItems.Remove(it);
                            lZakl.Items.Remove(lZakl.SelectedItems[i]);
                            //MessageBox.Show(it.Name + "\n" + lZakl.SelectedItems[i].ToolTipText);

                            return;
                        }
                    }
                }
            }
            //lFold_SelectedIndexChanged(sender, e);
        }

    }
}
