using System;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Configuration;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using netOpen.Networking;
using System.Drawing;

namespace netOpen
{
    public partial class Form1 : Form
    {
 /*       struct IpDataContainer
        {
            public string PcName,PcIp;

            public IpDataContainer(string x, string y)
            {
                PcName = x;
                PcIp = y;
            }
        }*/

       // IpDataContainer[] PCMas=new IpDataContainer[10000];
        public static string ip_adress;
        public static int numb = 0, acum = 0, iMachAm=254;
        public static object locker = new object();
        public bool mIs = false,mL=true;
        public TabPage ThrCr = new TabPage();

        public Form1()
        {
            InitializeComponent();
        }

        /*public void GetPcArray()
        {
            ListViewItem temp=new ListViewItem();
            string[] name=new string[numb];
            for (int i=0;i<numb;i++)
            {
                temp = pcList.Items[i];
                name[i]=temp.Text;
                temp.Text = temp.Name;
            }
            pcList.Sorting = SortOrder.Ascending;
            pcList.Sort();
            for (int i = 0; i < numb; i++)
            {
                temp = pcList.Items[i];
                temp.Text = name[i];
            }
            pcList.Refresh();
        }*/
        /// <summary>
        /// Func, that threading. For now - not perfect one ;)
        /// </summary>
        public void find_add(object ip_ad)
        {
                string spor = (string)ip_ad;
                int n = numb;
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                ListViewItem new_pc = new ListViewItem();
                IPHostEntry ipH = new IPHostEntry();

                // Use the default Ttl value which is 128,
                // but change the fragmentation behavior.
                options.DontFragment = true;

                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "a";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = OptData.Default.PingWaitTime;
                PingReply reply = pingSender.Send(spor, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    ipH = Dns.Resolve(spor);
                    new_pc.Name = spor;
                    new_pc.Text = ipH.HostName;
                    new_pc.ToolTipText = spor;
                    //new_pc.ImageList = LittleI;
                    new_pc.ImageIndex = 2;
                    if (numb == 0) new_pc.Selected = true;
                    pcList.Items.Add(new_pc);
                    lock (locker) numb++;
                    statusPCs.Text = numb.ToString();
                }
                lock (locker) acum++;
                pBar_stat.Value = acum;

            //Условие окончания сканирования, активация недоступных элементов
                if (acum == iMachAm) //вместо 254 должно быть число сканируемых машин
                {
                    tsRef.Enabled = true;
                    сканироватьToolStripMenuItem.Enabled = true;
                }
        }

        /// <summary>
        /// Geting a list of pc'c in the selected network
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void bRefresh_Click(object sender, EventArgs e)
        {
            string ip_adr = "192.168.0.";
            //string ip_adr=
           // string ip_adr =;
            tsRef.Enabled = false;
            сканироватьToolStripMenuItem.Enabled = false;
            открытьToolStripMenuItem.Enabled = true;
            обновитьToolStripMenuItem1.Enabled = true;
            пинговатьToolStripMenuItem.Enabled = true;
            int i = 0;
            numb = 0;
            pBar_stat.Maximum = iMachAm;
            pBar_stat.Minimum = 0;
            pBar_stat.Value = 0;
            acum = 0;
            pcList.Items.Clear();
            for (i = 1; i < 255; i++)
            {
                ip_adress = ip_adr + i.ToString();
                //Add_PC();
                Thread t = new Thread(new ParameterizedThreadStart(find_add));
                t.IsBackground = true;
                t.Start(ip_adress);
                pcList.Refresh();
            }
            pcList.Sort();
        }

        /// <summary>
        /// Opening adress in MS Explorer
        /// </summary>
        public void Open_Sg(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    Process pProc = new Process();
                    string adr = @"\\" + pcList.FocusedItem.ToolTipText;
                    pProc.StartInfo.FileName = "explorer.exe";
                    pProc.StartInfo.Arguments = adr;
                    pProc.Start();
                }
                catch (Exception)
                {
                    Console.WriteLine("No any selected items!");
                }
            }

        }

        /// <summary>
        /// Looking for clicks over pcList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcList_MouseClick(object sender, MouseEventArgs e)
        {
            TabPage newTabPage = new TabPage();
            if (e.Button == MouseButtons.Left)
            {
                /*Thread t = new Thread(GetShares_Click);
                t.Start();*/
                GetShares_Click();
            }
        }

        private void обновитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rem_share();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseEventArgs newEventArg = new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0);
            Open_Sg(sender, newEventArg);
        }

        /// <summary>
        /// Menu's thing, that starts pinging other PC 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void пинговатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process pProc = new Process();
            string adr = "-t "+pcList.FocusedItem.ToolTipText;
            pProc.StartInfo.FileName = "ping.exe";
            pProc.StartInfo.Arguments = adr;
            pProc.Start();
        }

        /// <summary>
        /// Geting shares, and looking at them :::))))
        /// </summary>
        public void Rem_share()
        {
            string server = pcList.FocusedItem.ToolTipText;

            if (server != null && server.Trim().Length > 0)
            {
                Temp tmp = new Temp();
                tmp.Show();
                tmp.rtb.Text += "\nShares on "+server+"\n";
                ShareCollection shi = ShareCollection.GetShares(server);
                if (shi != null)
                {
                    foreach (Share si in shi)
                    {
                        if (si.ShareType.ToString()=="Disk")tmp.rtb.Text += si.ShareType + " " + si + " " + si.Path + "\n";

                        // If this is a file-system share, try to
                        // list the first five subfolders.
                        // NB: If the share is on a removable device,
                        // you could get "Not ready" or "Access denied"
                        // exceptions.
                        // If you don't have permissions to the share,
                        // you will get security exceptions.

                        //Определяем доступны ли росшары
                        /*if (si.IsFileSystem)
                        {
                            try
                            {
                                System.IO.DirectoryInfo d = si.Root;
                                System.IO.DirectoryInfo[] Flds = d.GetDirectories();
                            }
                            catch (Exception ex)
                            {
                                tmp.rtb.Text += "\tError listing:" + si.ToString() + "\n\t" + ex.Message + "\n";
                            }
                        }*/
                    }
                }
                else
                    tmp.rtb.Text += "Unable to enumerate the shares on" + server + ".\n"
                        + "Make sure the machine exists, and that you have permission to access it.\n\n";
            }
        }

        private void сканироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bRefresh_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bRefresh_Click(sender, e);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            открытьToolStripMenuItem.Enabled = false;
            обновитьToolStripMenuItem1.Enabled = false;
            пинговатьToolStripMenuItem.Enabled = false;
            OptData.Default.MainForm = this;
            //pcList = OptData.Default.PC_list_saved;
        }

        private void мелкиеЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pcList.View = View.SmallIcon;
        }

        private void крупныеЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pcList.View = View.LargeIcon;
        }

        private void деталеыйВидToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pcList.View = View.Details;
        }

        private void списокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pcList.View = View.List;
        }

        private void протиАлфавитаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pcList.Sorting = SortOrder.Descending;
        }

        private void поАлфавитуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pcList.Sorting = SortOrder.Ascending;
        }

        private void поIPАдресамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pcList.Sorting = SortOrder.None;
        }

        private void pcList_MouseDown(object sender, MouseEventArgs e)
        {
            mIs = true;
        }

        private void pcList_MouseUp(object sender, MouseEventArgs e)
        {
            mIs = false;
        }

        private void pcList_MouseMove(object sender, MouseEventArgs e)
        {
            if (mIs)
            {
                mIs = false;
            }
        }


        /// <summary>
        /// Creating a new tab at tabwindow, and placing there a pcShareList
        /// </summary>
        public void GetShares_Click()
        {
            TabPage error = new TabPage("?");
            for (int z = 0; z < TabP.TabPages.Count; z++)
            {
                if (TabP.TabPages[z].Text == pcList.FocusedItem.Text)
                {
                    ThrCr = error;
                    return;
                }
            }

            TabPage Val = new TabPage();
            ListView share_list = new ListView();
            share_list.Dock = DockStyle.Fill;
            share_list.LargeImageList = LargeI;
            share_list.Location = new Point(3, 3);
            share_list.Name = "PcShares";
            share_list.SmallImageList = LittleI;
            share_list.StateImageList = LittleI;
            share_list.DoubleClick += new EventHandler(Share_MouseClick);
            share_list.ContextMenuStrip = Refresh;

            // <Geting_Shares>
            string server = pcList.FocusedItem.ToolTipText;
            ShareCollection shi = ShareCollection.GetShares(server);
             if (shi != null)
             {
                 foreach (Share si in shi)
                 {
                     ListViewItem sli = new ListViewItem();
                     if (si.ShareType.ToString() == "Disk")
                     { 
                         sli.Text = si.NetName;
                         sli.ToolTipText = si.ToString();
                         sli.ImageIndex = 6;
                         
                         
                         if (si.IsFileSystem)
                         {
                             try
                             {
                                 System.IO.DirectoryInfo d = si.Root;
                                 System.IO.DirectoryInfo[] Flds = d.GetDirectories();
                             }
                             catch (Exception)
                             {
                                 sli.ImageIndex = 0;
                             }
                         }
                         share_list.Items.Add(sli);
                     }

                }
             }

            // </Geting_Shares>

            Val.Controls.Clear();
            Val.Controls.Add(share_list);
            Val.Padding = new Padding(3);
            Val.Text = pcList.FocusedItem.Text;
            Val.ToolTipText = pcList.FocusedItem.Text+" : "+pcList.FocusedItem.ToolTipText;
            

            try
            {
                TabP.TabPages.Add(Val);
                TabP.SelectTab(TabP.TabCount - 1);
            }
            catch (Exception ez)
            {
                MessageBox.Show(ez.Message, "Error");
            }

        }

        public void Share_MouseClick(object sender, EventArgs e)
        {
            ListView temp = new ListView();
            temp = (ListView)sender;
            //MessageBox.Show(temp.FocusedItem.ToolTipText, "fuck");
            try
            {
                Process pProc = new Process();
                pProc.StartInfo.FileName = "explorer.exe";
                pProc.StartInfo.Arguments = temp.FocusedItem.ToolTipText;
                pProc.Start();
            }
            catch (Exception)
            {
                Console.WriteLine("No any selected items!");
            }
        }

        public void Open_Sel_Share()
        {
            
        }

        /// <summary>
        /// This func enables to close a tabs by double_click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabP_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (TabP.TabCount > 1)
                {
                    int i = 0;
                    if (TabP.SelectedIndex > 0) i = TabP.SelectedIndex - 1;
                    else i = TabP.SelectedIndex;
                    TabP.TabPages[TabP.SelectedIndex].Dispose();
                    TabP.SelectTab(i);
                }
            }
        }

        private void TabP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) mL = true;
        }

        private void TabP_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) mL = false;
        }

        /// <summary>
        /// Closing active tab, if it's not the last one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void закрытьВкладкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TabP.TabCount > 1)
            {
                int i = 0;
                if (TabP.SelectedIndex > 0) i = TabP.SelectedIndex - 1;
                else i = TabP.SelectedIndex;
                TabP.TabPages[TabP.SelectedIndex].Dispose();
                TabP.SelectTab(i);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OptForm opt = new OptForm();
            opt.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //OptData.Default.PC_list_saved = pcList;
            OptData.Default.Save();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            OptForm opt = new OptForm();
            opt.Show();
        }

    }
}
