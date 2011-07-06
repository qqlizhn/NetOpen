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
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using netOpen.Networking;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace netOpen
{
    public partial class netOpen_MainWindow : Form
    {
        public struct DiapasonIP
        {
            public string StartIPAdress;
            public string EndIPAdress;
            public string Name;
            public string Status;
            public string Descr;
        }

        /// <summary>
        /// Структура, хранящая информацию об общедоступных ресурах элемента сети
        /// </summary>
        public struct ShareData
        {
            public List<string> ShareAdress;
            public List<string> ShareName;
            public System.IO.FileSystemInfo[] NearFilesFolders;
        }

        public static string ip_adress;
        public static int numb = 0, acum = 0, iMachAm=254,selInd=65535,iReadStep=0,ThrShAc=0;
        public static object locker = new object();
        public static bool mIs = false,mL=true,menum=false,bInProgrs=false;
        public TabPage ThrCr = new TabPage();
        public ToolStrip slidets;
        public static DiapasonIP[] ipdip=new DiapasonIP[100];
        public static string OptionFileName = "opt.bin";
        public static TextBox tChangeBox = new TextBox();
        public ListViewItem drg;
        Graphics gg1;
        Bitmap drawing1 = null;

        List<Thread> ThrLst=new List<Thread>();
        List<Thread> ShareThrLst = new List<Thread>();
        public static List<ShareData> ShareList = new List<ShareData>();
        //private EventHandler mit_Click;
        //public static Temp TempW=new Temp();

        public netOpen_MainWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException +
                    "\n" + ex.TargetSite + "\n" + ex.Source + "\n"+
                    ex.StackTrace + "\n" + ex.InnerException + "\n"+ex.HelpLink);
            }
        }

        //Обработчик загрузки главной формы
        private void Form1_Load(object sender, EventArgs e)
        {
            GetShStat.Text = "";
            msStatusStrip.Checked = OptData.Default.StatusBarVisible;
            //открытьToolStripMenuItem.Enabled = false;
            //обновитьToolStripMenuItem1.Enabled = false;
            //пинговатьToolStripMenuItem.Enabled = false;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            OptData.Default.MainForm = this;
            OptData.Default.NotifyMe = notifyIcon1;
            ReadFile();
            tChangeBox.TextChanged+=new EventHandler(tChangeBox_TextChanged);
            DrawFormBackgroud();
            AddButtonsToStrip();
            OptData.Default.ZaklData = ZaklMenu;
            ActPC.Items[1].Enabled=false;
            ActPC.Items[2].Enabled=false;
            ActPC.Items[3].Enabled=false;
            ActPC.Items[5].Enabled = false;
            LoadZakl();
        }

        public void AddButtonsToStrip()
        {
            slidets = sbShareInfo.ToolStripHandler();
            //slidets.Items[0].Enabled = false;

            ToolStripButton tempA = new ToolStripButton("Добавить в закладки", Properties.Resources.Earth200);
            tempA.Click += new EventHandler(добавитьВЗакладки_Click);
            tempA.ImageAlign = ContentAlignment.MiddleCenter;
            tempA.TextImageRelation = TextImageRelation.ImageAboveText;
            tempA.TextAlign = ContentAlignment.BottomCenter;
            slidets.Items.Add(tempA);

            ToolStripButton tempB = new ToolStripButton("Temp window", Properties.Resources.Earth200);
            tempB.Click += new EventHandler(tempB_Click);
            tempB.ImageAlign = ContentAlignment.MiddleCenter;
            tempB.TextImageRelation = TextImageRelation.ImageAboveText;
            tempB.TextAlign = ContentAlignment.BottomCenter;

            slidets.Items.Add(tempB);
            sbShareInfo.Slide();
        }

        void tempB_Click(object sender, EventArgs e)
        {
            //TempWindow();
            CopyF cp = new CopyF();
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == DialogResult.OK)
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    cp.SourceFile = of.FileName;
                    cp.DestenationFile = fb.SelectedPath+@"\"+of.SafeFileName;
                    cp.CopyIt();
                }
            }
        }

        private void TempWindow()
        {
            /*Temp wnd = new Temp();
            wnd.Show();
            wnd.rtb.Text = "Ниже приведен список всех сканируемых IP\n";
            string ip_adr = "";
            int i = 0;
            for (int j = 0; j < OptData.Default.DiapCount; j++)
            {
                if (ipdip[j].Status == "Включено")
                {
                    ip_adr = ipdip[j].StartIPAdress;
                    while (ip_adr != ipdip[j].EndIPAdress)
                    {
                        i++;
                        wnd.rtb.Text += i.ToString() + ": " + ip_adr + "\n";
                            ip_adr = GetNextIP(ip_adr);
                    }
                }
            }*/
            //if (pcList.Items.Count > 0 && pcList.SelectedItems[0].Focused)
            {
                this.Enabled = false;
                ZaklAdd nzak = new ZaklAdd("lifisgod","192.168.0.135",LittleI.Images[2]);
                nzak.Show();
                nzak.folderL.SelectedIndex = 1;
                nzak.tName.Focus();
            }
            
            
        }

        /// <summary>
        /// Reading ip diapasons from saved file
        /// </summary>
        public void ReadFile()
        {
            FileInfo fi = new FileInfo(OptionFileName);
            if (fi.Exists)
            {
            try
            {
                FileStream fs = new FileStream(OptionFileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                OptData.Default.DiapCount = Convert.ToInt32(br.ReadString());
                for (int i = 0; i < OptData.Default.DiapCount; i++)
                {
                    ipdip[i].Name = br.ReadString();
                    ipdip[i].StartIPAdress = br.ReadString();
                    ipdip[i].EndIPAdress = br.ReadString();
                    ipdip[i].Status = br.ReadString();
                    ipdip[i].Descr = br.ReadString();
                }
            }
                catch (Exception)
                {
                    ipdip = null;
                    ipdip = new DiapasonIP[1000];
                    OptData.Default.DiapCount = 0;
                    FileStream fs = new FileStream(OptionFileName, FileMode.Create, FileAccess.Write);
                    fs.WriteByte(31);
                    MessageBox.Show("Ошибка в файле настроек, он был обнулён", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else OptData.Default.DiapCount = 0;
        }

        /// <summary>
        /// Func, that threading. For now - not perfect one ;)
        /// </summary>
       public void ThreadPingSend(object ip_ad)
        {
            int n=0;
            bool ok = false;
            lock (locker) n = numb;
                string spor = (string)ip_ad;
                byte[] ar = new byte[] { 0, 0, 0, 0 };
                try
                {
                    IPAddress sim = new IPAddress(ar);
                    IPAddress.TryParse(spor, out sim);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    lock (locker) { acum++; pBar_stat.Value = acum; }
                    return;
                }
                //TempW.Show();
                //TempW.rtb.Text += spor + "\n";
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                ListViewItem new_pc = new ListViewItem();
                IPHostEntry ipH = new IPHostEntry();

                // Use the default Ttl value which is 128,
                // but change the fragmentation behavior.
                options.DontFragment = OptData.Default.PingPacketFragment;

                // Create a buffer of "PingBufferLen" bytes of data to be transmitted.
                string data = "a";
                for (int i = 0; i < OptData.Default.PingBufferLen-1; i++)
                {
                    data += "a";
                }
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = OptData.Default.PingWaitTime;
                string nameOfpc = "";
                try
                {
                    PingReply reply = pingSender.Send(spor, timeout, buffer, options);
                    if (reply.Status == IPStatus.Success)
                    {
                        //this.Text = spor;
                        //ipH = Dns.GetHostEntry(spor);
                        ipH = Dns.Resolve(spor);
                        //ipH.HostName;
                        new_pc.Name = spor;
                        nameOfpc = ipH.HostName;
                        if (ipH.HostName.Length < 15)
                            for (int i = 0; i < 15 - ipH.HostName.Length; i++)
                                nameOfpc += " ";
                        new_pc.Text = nameOfpc;
                        new_pc.ToolTipText = spor;
                        new_pc.SubItems.Add(spor);
                        //new_pc.ImageList = LittleI;
                        new_pc.ImageIndex=2;
                        if (ipH.HostName != spor)
                            new_pc.Group = pcList.Groups[0];
                        else new_pc.Group = pcList.Groups[1];
                        if (numb == 0) new_pc.Selected = true;
                        if (!pcList.Items.ContainsKey(new_pc.ToolTipText))
                        {
                            //OptData.Default.MainForm.Text = spor;
                            //pcList.Refresh();
                            lock (locker)
                            {
                                pcList.Items.Add(new_pc);
                                numb++;
                                statusPCs.Text = numb.ToString();
                            }
                        }
                        ok = true;
                    }
                    else
                    {
                        KonUsl();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ok = false;
                }
               
                if (ok==true)
                {
                    bool started = false;
                    while (started==false)
                    {
                        if (ShareThrLst.Count < OptData.Default.ScanThreadAmount)
                        {
                            Thread tr = new Thread(new ParameterizedThreadStart(CollectShares));
                            ShareThrLst.Add(tr);
                            try
                            {
                                tr.Start(ip_ad);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("error starting thread!");
                            }
                            started = true;
                        }
                        else Thread.CurrentThread.Join(50);
                    }
                }
                KonUsl();
        }

       public void KonUsl()
       {
           lock (locker)
           {
               ThrLst.Remove(Thread.CurrentThread);
               acum++; pBar_stat.Value = acum;
               pBar_prc.Text = Convert.ToString(Math.Round((double)pBar_stat.Value / pBar_stat.Maximum * 100))
                   + "% " + acum.ToString() + "->" + iMachAm.ToString() + " ";
           }
           //Условие окончания сканирования, активация недоступных элементов
           if (acum == iMachAm)
           {
               //timer1.Stop();
               //tsRef.Enabled = true;
               //pcList.Sorting = SortOrder.Ascending;
               //pcList.Sort();
               сканироватьToolStripMenuItem.Enabled = true;
               tsRef.Image = Properties.Resources.scan ;
               bInProgrs = false;
           }
       }
        

        /// <summary>
        /// Geting a list of pc'c in the selected network
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanNet()
        {
           // bool Running = true;
            string ip_adr = "";

                for (int j = 0; j < OptData.Default.DiapCount; j++)
                {
                    //MessageBox.Show(j.ToString());
                    if (ipdip[j].Status == "Включено")
                    {
                            ip_adr = ipdip[j].StartIPAdress;
                            //MessageBox.Show(ip_adr);


                            //MessageBox.Show(j + ":" + ip_adr);

                            while (ip_adr != ipdip[j].EndIPAdress)
                                //for (i = 1; i < 255; i++)
                                {
                                    
                                    //ip_adress = ip_adr + i.ToString();
                                    //Add_PC();
                                    if (!bInProgrs) break;
                                    Thread t = new Thread(new ParameterizedThreadStart(ThreadPingSend));
                                    t.IsBackground = true;
                                    ThrLst.Add(t);
                                    if (ThrLst.Count < OptData.Default.ScanThreadAmount)
                                    {
                                        try
                                        {
                                            t.Start(ip_adr);
                                            //TempW.rtb.Text += ip_adr + "\n";
                                        }
                                        catch(Exception)
                                        {
                                            Console.WriteLine("error!");
                                        }
                                        ip_adr = GetNextIP(ip_adr);
                                        //pcList.Refresh();
                                    }
                                    else { Thread.CurrentThread.Join(100); /*Application.DoEvents();*/ }
                                }
                        }
                    }
            //Running=false;
            //TempW.rtb.Text += "Running toped!\n";
                
            //pcList.Sort();
        }

        /// <summary>
        /// Получает список открытых ресурсов указанного IP, и сохраняет их в структуре
        /// </summary>
        /// <param name="CurIP"></param>
        public void CollectShares(object CurIP)
        {
            string server = (string)CurIP;
            bool accesible = true;
            int count=0;
            ShareData se = new ShareData();
            bool HasRes = false;
            se.ShareAdress = new List<string>();
            se.ShareName = new List<string>();

            if (server != null)
            {
                ShareCollection shi = ShareCollection.GetShares(server);
                System.IO.FileSystemInfo[] AllD=new FileSystemInfo[1];
                if (shi != null)
                {
                    foreach (Share si in shi)
                    {
                        accesible = true;
                        if (si.ShareType.ToString() == "Disk")
                        {
                            HasRes = true;
                            //Определяем доступны ли росшары
                            if (si.IsFileSystem)
                            {
                                count++;
                                try
                                {
                                    System.IO.DirectoryInfo d = si.Root;
                                    //System.IO.DirectoryInfo[] Flds = d.GetDirectories();
                                    AllD = null;
                                    AllD = d.GetFileSystemInfos();
                                    //d.Attributes=FileAttributes.
                                }
                                catch (Exception)
                                {
                                    accesible = false;
                                    count--;
                                }
                                if (accesible)
                                {
                                    se.ShareName.Add(si.NetName);
                                    se.ShareAdress.Add(si.ToString());
                                    se.NearFilesFolders = AllD;
                                    //MessageBox.Show(si.NetName + " " + si.ToString());
                                }
                            }
                        }  
                    }
                    if (count > 0)
                    {
                        lock (locker) ShareList.Add(se);
                        ListViewItem[] fi=pcList.Items.Find(server, true);
                        foreach (ListViewItem it in fi)
                        {
                            it.ImageIndex = 13;
                        }
                    }
                }
            }
            if ((ThrShAc + 1) <numb) GetShStat.Text = "Полный список всех ресурсов в процессе создания..";
            else GetShStat.Text = "Полный список всех ресурсов создан.";
            thrsh.Text = Convert.ToString(ShareThrLst.Count-1);
            lock (locker) { ShareThrLst.Remove(Thread.CurrentThread); ThrShAc++;}
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
            if (e.Button == MouseButtons.Left&&pcList.Items.Count>0)
            {
                /*Thread t = new Thread(BuildShareList);
                t.Start();*/
                BuildShareList();
            }
            if (pcList.Items.Count > 0)
            {
                foreach (ToolStripMenuItem item in ActPC.Items)
                {
                    item.Enabled = true;
                }
            }
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
                        if (si.ShareType.ToString() == "Disk") tmp.rtb.Text += si.ShareType + " " + si + " " + si.Root.Exists.ToString() +"\n";

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

        /// <summary>
        /// Creating a new tab at tabwindow, and placing there a pcShareList
        /// </summary>
        public void BuildShareList()
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
            bool HasRes = false;
            Val.ImageIndex = 11;
            ListView share_list = new ListView();
            share_list.Dock = DockStyle.Fill;
            share_list.LargeImageList = LargeI;
            share_list.Location = new Point(3, 3);
            share_list.Name = "_"+pcList.FocusedItem.ToolTipText;
            share_list.SmallImageList = LittleI;
            share_list.StateImageList = LittleI;
            share_list.HideSelection = false;
            share_list.ShowItemToolTips = true;
            share_list.DoubleClick += new EventHandler(Share_MouseClick);
            share_list.SelectedIndexChanged += new EventHandler(share_list_SelectedIndexChanged);
            share_list.Leave += new EventHandler(share_list_Leave);
            share_list.ContextMenuStrip = Refresh;
            share_list.ItemDrag += new ItemDragEventHandler(share_list_ItemDrag);
            //share_list.drag

            // <Geting_Shares>
            string server = pcList.FocusedItem.ToolTipText;
            Application.DoEvents();
            ShareCollection shi = ShareCollection.GetShares(server);
            if (shi != null)
            {
                foreach (Share si in shi)
                {
                    Application.DoEvents();
                    ListViewItem sli = new ListViewItem();
                    if (!OptData.Default.ShowHidenRes)
                    {
                        if (si.ShareType.ToString() == "Disk")
                        {
                            sli.Text = si.NetName;
                            sli.ToolTipText = si.ToString();
                            sli.ImageIndex = 6;
                            HasRes = true;

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
                    else
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
            Val.Text = pcList.FocusedItem.Text.Trim();
            Val.Name = pcList.FocusedItem.ToolTipText;
            Val.ToolTipText = pcList.FocusedItem.Text.Trim() + " : " + pcList.FocusedItem.ToolTipText;


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

        void share_list_ItemDrag(object sender, ItemDragEventArgs e)
        {
            drg = (ListViewItem)e.Item;
        }

        /// <summary>
        /// Creating a new tab at tabwindow, and placing there a pcShareList
        /// </summary>
        /// <param name="adress">Ip adress dest</param>
        /// /// <param name="name">Dns name</param>
        public void BuildShareList(string adress,string name)
        {
            //TabPage error = new TabPage("?");
            for (int z = 0; z < TabP.TabPages.Count; z++)
            {
                if (TabP.TabPages[z].Text == adress)
                {
                    //ThrCr = error;
                    return;
                }
            }

            TabPage Val = new TabPage();
            Val.ImageIndex = 11;
            ListView share_list = new ListView();
            share_list.Dock = DockStyle.Fill;
            share_list.LargeImageList = LargeI;
            share_list.Location = new Point(3, 3);
            share_list.Name = "PcShares";
            share_list.SmallImageList = LittleI;
            share_list.StateImageList = LittleI;
            share_list.HideSelection = false;
            share_list.ShowItemToolTips = true;
            share_list.DoubleClick += new EventHandler(Share_MouseClick);
            share_list.SelectedIndexChanged += new EventHandler(share_list_SelectedIndexChanged);
            share_list.Leave += new EventHandler(share_list_Leave);
            share_list.MouseDown += new MouseEventHandler(share_list_MouseDown);
            share_list.ContextMenuStrip = Refresh;

            // <Geting_Shares>
            string server = adress;
            Application.DoEvents();
            ShareCollection shi = ShareCollection.GetShares(server);
            if (shi != null)
            {
                foreach (Share si in shi)
                {
                    Application.DoEvents();
                    ListViewItem sli = new ListViewItem();
                    if (!OptData.Default.ShowHidenRes)
                    {
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
                    else
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
            Val.Text = name;
            Val.ToolTipText = name + " : " + adress;


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

        void share_list_MouseDown(object sender, MouseEventArgs e)
        {
            ListView sh = (ListView)sender;
            //sh.FocusedItem;
            sh.SelectedItems.Clear();
            sh.SelectedIndices.Clear();
            //selInd = 40000;
            slidets.Items[0].Enabled = false;
            //label6.Text = selInd.ToString();
        }


        void share_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label6.Text = selInd.ToString();
            ListView ShareList = (ListView)sender;
            if (ShareList.SelectedIndices.Count > 0)
            {
                if (selInd == 40000 || ShareList.SelectedIndices[0] != selInd)
                {
                    slidets.Items[0].Enabled = true;
                    OptData.Default.CurActiveItem = ShareList.SelectedItems[0];
                }
                /*else if (ShareList.SelectedIndices[0] == selInd)
                {
                    //MessageBox.Show(sbShareInfo.IsUp().ToString());
                    slidets.Items[0].Enabled = false;

                }*/
                selInd = ShareList.SelectedIndices[0];
                FolderToZakl.Enabled = true;
            }
            else
            {
                slidets.Items[0].Enabled = false;
                FolderToZakl.Enabled = false;
                selInd = 40000;
            }
            //if (!slidets.Items[0].Enabled&&sbShareInfo.IsUp()) sbShareInfo.Slide();
            //slidets.Items[0].Enabled = false;
            if (slidets.Items[0].Enabled && !sbShareInfo.IsUp()) sbShareInfo.Slide();
        }


        void share_list_Leave(object sender, EventArgs e)
        {
            ListView sh = (ListView)sender;
            sh.FocusedItem = null;
            sh.SelectedItems.Clear();
            sh.SelectedIndices.Clear();
            selInd = 40000;
            slidets.Items[0].Enabled = false;
            //if (sbShareInfo.IsUp()) sbShareInfo.Slide();
        }

        public void Share_MouseClick(object sender, EventArgs e)
        {
            ListView temp = (ListView)sender;
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

        /// <summary>
        /// Compares to strings, and if its IP's equal - returns true
        /// </summary>
        /// <param name="StartIP"></param>
        /// <param name="EndIP"></param>
        /// <returns></returns>
        public bool CompareIP(string StartIP, string EndIP)
        {
            string a=new string(StartIP.ToCharArray());
            string b = new string(EndIP.ToCharArray());
            a.Replace('.','0');
            b.Replace('.', '0');
            decimal A, B;
            A = Convert.ToDecimal(a);
            B = Convert.ToDecimal(b);
            if (A == B) return true;
            else return false;
        }

        /// <summary>
        /// Подчсёт кол-ва адресов, входящих в диапазон IP
        /// </summary>
        /// <param name="StartIP"></param>
        /// <param name="EndIP"></param>
        /// <returns></returns>
        public decimal IpAdressCount(string StartIP, string EndIP)
        {
            byte[] ips = new byte[] {0,0,0,0};
            try
            {
                IPAddress sim = new IPAddress(ips);
                IPAddress.TryParse(StartIP,out sim);
                IPAddress.TryParse(EndIP, out sim);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            decimal count = 0,sip=0,eip=0;
            char[] sep=new char[]{'.',','};
            string[] SIPparts=StartIP.Split(sep);
            string[] EIPparts = EndIP.Split(sep);
            for (int i = 0; i <4; i++)
            {
                sip += Convert.ToByte(SIPparts[i])*Convert.ToDecimal(Math.Pow(255,3-i));
                eip += Convert.ToByte(EIPparts[i])*Convert.ToDecimal(Math.Pow(255, 3-i));
                if (sip == eip) sip = eip = 0;
            }
            count = eip - sip;
            return count;
        }

        /// <summary>
        /// Вычисляет следующий (по порядку) адрес, в зависимости от переданного
        /// </summary>
        /// <param name="lastIP"></param>
        /// <returns></returns>
        public string GetNextIP(string lastIP)
        {
            char[] sep = new char[] { '.', ',' };
            string[] parts = lastIP.Split(sep);
            string result = "";
            byte[] Pmas = new byte[] { 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                Pmas[i] = Convert.ToByte(parts[i]);
            }
            if (Pmas[3] < 255) Pmas[3]++;
            else if (Pmas[2] < 255) { Pmas[2]++; Pmas[3] = 0; }
            else if (Pmas[1] < 255) { Pmas[1]++; Pmas[2] = 0; }
            else if (Pmas[0] < 255) { Pmas[0]++; Pmas[1] = 0; }
            result = Pmas[0] + "." + Pmas[1] + "." + Pmas[2] + "." + Pmas[3];
            return result;
        }

        private void sbShareInfo_Resize(object sender, EventArgs e)
        {
            if (!sbShareInfo.IsUp() && sbShareInfo.InMoove() && sbShareInfo.Height - 5 == sbShareInfo.GetSize())
                TabP.Height = sbShareInfo.Location.Y - TabP.Location.Y - 15;
            else if (sbShareInfo.IsUp() && sbShareInfo.InMoove() && sbShareInfo.Height - 5 == 20) TabP.Height = sbShareInfo.Location.Y - TabP.Location.Y + 10;
        }


        #region Обработчики событий(небольшие по коду)

        private void показатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        private void поискПоРесурсамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchAmogShares(sender, e);
        }

        private void pctBox_Resize(object sender, EventArgs e)
        {
            DrawFormBackgroud();
        }

        private void menu_Leave(object sender, EventArgs e)
        {
            menu.Visible = false;
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

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void TabP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) mL = true;
        }

        private void TabP_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) mL = false;
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
            SaveZakl();
            StopScan();
            notifyIcon1.Dispose();
        }

        private void tsbOpt_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            OptForm opt = new OptForm();
            opt.Show();
        }

        private void tChangeBox_TextChanged(object sender, EventArgs e)
        {
            ThreadPingSend(tChangeBox.Text);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                GlassAb glass = new GlassAb();
                glass.Show();
                glass.Location = new Point(this.Location.X + this.Width / 2 - glass.Width / 2, this.Location.Y + this.Height / 2 - glass.Height / 2);
            }
            else
            {
                NonGlassAb nonglass = new NonGlassAb();
                nonglass.Show();
                nonglass.Location = new Point(this.Location.X + this.Width / 2 - nonglass.Width / 2, this.Location.Y + this.Height / 2 - nonglass.Height / 2);
                //nonglass.Size = new Size(350, 376);
            }
        }

        private void Add_One_PC_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            SinglePCAdd tempF = new SinglePCAdd();
            tempF.Show();
            tempF.Location = new Point(this.Location.X + this.Width / 2 - tempF.Width / 2, this.Location.Y + this.Height / 2 - tempF.Height / 2);
            //tempF.Size = new Size(350, 376);
        }


        private void плиткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pcList.View = View.Tile;
        }

        #endregion

        /// <summary>
        /// Обработчик нажатия на кнопку сканирования сети
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Scan_Button_Click(object sender, EventArgs e)
        {
            if (!bInProgrs)
            {
                //tsRef.Enabled = false;
                //сканироватьToolStripMenuItem.Enabled = false;
                открытьToolStripMenuItem.Enabled = true;
                //обновитьToolStripMenuItem1.Enabled = true;
                //пинговатьToolStripMenuItem.Enabled = true;
                statusPCs.Text = "0";
                iMachAm = 0;
                pcList.Items.Clear();
                numb = 0;
                pBar_stat.Minimum = 0;
                pBar_stat.Value = 0;
                acum = 0;
                ThrLst.Clear();
                ShareThrLst.Clear();
                ShareList.Clear();
                //TempW.Show();

                for (int j = 0; j < OptData.Default.DiapCount; j++)
                {
                    if (ipdip[j].Status == "Включено")
                    {
                        //MessageBox.Show(IpAdressCount(ipdip[j].StartIPAdress, ipdip[j].EndIPAdress).ToString());
                        iMachAm += (int)IpAdressCount(ipdip[j].StartIPAdress, ipdip[j].EndIPAdress);
                    }
                }

                pBar_stat.Maximum = iMachAm+1;
                bInProgrs = true;
                tsRef.Image = Properties.Resources.stop;
                Thread t=new Thread(new ThreadStart(ScanNet));
                t.Start();
                //bRefresh_Click(sender, e);
            }
            else
            {
                StopScan();
                tsRef.Image = Properties.Resources.scan;
                bInProgrs = false;
            }
        }

        /// <summary>
        /// Stoping scan
        /// </summary>
        private void StopScan()
        {
            bInProgrs = false;
            foreach (Thread t in ShareThrLst)
            {
                t.Interrupt();
            }
            foreach (Thread t in ThrLst)
            {
                t.Interrupt();
            }
        }

        private void msStatusStrip_Click(object sender, EventArgs e)
        {
            if (msStatusStrip.Checked)
            {
                status.Visible = true;
                OptData.Default.StatusBarVisible = true;
            }
            else
            {
                status.Visible = false;
                OptData.Default.StatusBarVisible = false;
            }
        }

        private void сохранитьНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptData.Default.Save();
            SaveZakl();
        }

        /// <summary>
        /// Создаёт окно поиска ресурсов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchAmogShares(object sender, EventArgs e)
        {
            OneFuncWindows.ShareSearch nw = new OneFuncWindows.ShareSearch();
            nw.Show();
            nw.Location = new Point(this.Location.X + this.Width / 2 - nw.Width / 2, this.Location.Y + this.Height / 2 - nw.Height / 2);
        }

        public void DrawFormBackgroud()
        {
            //int colorR = 90;
            Rectangle r = pctBox.Bounds;
            drawing1 = new Bitmap(r.Width,r.Height);
            gg1 = Graphics.FromImage(drawing1);
            LinearGradientBrush grad_1;
            Rectangle gradRect;

            try
            {
                 gradRect = new Rectangle(r.X, r.Y, r.Width, r.Height);
                //LinearGradientBrush grad = new LinearGradientBrush(gradRect, Color.FromArgb(47, 64, 94), Color.FromArgb(49, 66, 95), LinearGradientMode.Vertical);
                 grad_1 = new LinearGradientBrush(gradRect, SystemColors.GradientActiveCaption, Color.White, LinearGradientMode.Horizontal);
                //LinearGradientBrush CirclGrad = new LinearGradientBrush(gradRect, Color.FromArgb(0, 67, 125, 98), Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical);
                //ColorBlend blend = new ColorBlend();
                //ColorBlend ShBlend = new ColorBlend();
                 gg1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                 gg1.FillRectangle(grad_1, gradRect);
                 gg1.DrawImage(Properties.Resources.Earth200, 3, 3, 67, 67);
                 pctBox.BackgroundImage = drawing1;
                 //g.DrawImageUnscaled(drawing1, 0, 0);
                 gg1.Dispose();
            }
            catch (Exception)
            {
                Console.WriteLine("sss");
            }
            // Set multi-color gradient
            //blend.Positions = new[] { 0.0f, 0.35f, 0.5f, 0.65f, 1.0f };
            //ShBlend.Positions = new[] { 0.0f, 0.75f, 1.0f };
            //blend.Colors = new[] { Color.FromArgb(47, 64, 94), Color.FromArgb(64, 88, 126), Color.FromArgb(66, 90, 129), Color.FromArgb(64, 88, 126), Color.FromArgb(49, 66, 95) };
            //ShBlend.Colors = new[] { Color.FromArgb(49, colorR + 1, 66), Color.FromArgb(66, colorR + 90, 90), Color.WhiteSmoke };
           // shadowDown.InterpolationColors = ShBlend;
            //blend.Colors = new[] { Color.FromArgb(47, colorR, 64), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(66, colorR + 35, 90), Color.FromArgb(64, colorR + 32, 88), Color.FromArgb(49, colorR + 1, 66) };
           // grad.InterpolationColors = blend;
            //Font myf = new System.Drawing.Font(this.Font.FontFamily, 21);
            //Font myf2 = new System.Drawing.Font(this.Font.FontFamily, 22);
            // Draw basic gradient and shadow


            // Draw checkers
            //g.FillRectangle(checkers, r);
        }



        private void добавитьВЗакладкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pcList.Items.Count > 0&&pcList.SelectedItems[0].Focused)
            {
                this.Enabled = false;
                ZaklAdd nzak=new ZaklAdd(pcList.SelectedItems[0].Text,
                    pcList.SelectedItems[0].ToolTipText, 
                    LittleI.Images[pcList.SelectedItems[0].ImageIndex]);
                //nzak.folderL.SelectedIndex = 1;
                nzak.Show();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            OptForm frm = new OptForm();
            frm.tabOpt.SelectedIndex = 1;
            frm.Show();
        }

        private void закрытьВсеКромеТекущейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTabControl tab=TabP;
            int cur = tab.SelectedIndex;
            for (int i = 0; i < tab.TabPages.Count; i++)
            {
                if (i != cur) tab.TabPages.Remove(tab.TabPages[i]);
            }
        }

        private void SaveZakl()
        {
            //FileStream fs = new FileStream("zakl.ini", FileMode.Create);
            //StringBuilder str = new StringBuilder();
            string sd = "";
            try
            {
                using (StreamWriter str = new StreamWriter("zakl.ini"))
                {
                    if (ZaklMenu.DropDownItems.Count > 0)
                    {
                        foreach (ToolStripMenuItem mainItem in ZaklMenu.DropDownItems)
                        {
                            if (mainItem.Checked)
                            {
                                str.WriteLine("Folder = " + mainItem.Text);
                                ToolStripMenuItem submenu = (ToolStripMenuItem)mainItem;
                                if (submenu.DropDownItems.Count > 0)
                                {
                                    foreach (ToolStripMenuItem subitem in submenu.DropDownItems)
                                    {
                                        byte[] ar = new byte[] { 0, 0, 0, 0 };
                                        IPAddress sim = new IPAddress(ar);

                                        if (!IPAddress.TryParse(subitem.Name, out sim))
                                            sd = "folder";
                                        else sd = "pc";
                                        str.WriteLine("  SubItemName = " + subitem.Name);
                                        str.WriteLine("  SubItemText = " + subitem.Text);
                                        str.WriteLine("  SubItemImage = " + sd);
                                        str.WriteLine();
                                    }
                                }
                            }
                            else
                            {
                                byte[] ar = new byte[] { 0, 0, 0, 0 };
                                IPAddress sim = new IPAddress(ar);
                                if (!IPAddress.TryParse(mainItem.Name, out sim))
                                    sd = "folder";
                                else sd = "pc";
                                str.WriteLine("  ItemName = " + mainItem.Name);
                                str.WriteLine("  ItemText = " + mainItem.Text);
                                str.WriteLine("  ItemImage = " + sd);
                                str.WriteLine();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удаётся сохранить закладки.\n" + ex.Message, 
                    "Ошибка сохранения закладок", MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
            }
        
        }

        void LoadZakl()
        {
            string line = "",type="";
            char[] spl = new char[] {'='};
            string[] parts = new string[3];
            int curf = 0;
            ToolStripMenuItem mit = new ToolStripMenuItem();
            try
            {
                using (StreamReader sr = new StreamReader("zakl.ini"))
                {
                    ZaklMenu.DropDownItems.Clear();
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        parts = line.Split(spl);
                        //MessageBox.Show("|"+parts[0].Trim()+"|"+"\n"+"|"+parts[1].Trim()+"|");
                       // MessageBox.Show("|" + parts[0] + "|" + "\n" + "|" + parts[1] + "|");
                        if (parts[0].Trim() == "Folder")
                        {
                            mit = new ToolStripMenuItem();
                            mit.Text = parts[1].Trim();
                            mit.Image = Properties.Resources.Folder_Open1;
                            mit.Checked = true;
                            //if (!ZaklMenu.DropDownItems.Contains(mit))
                            {
                                ZaklMenu.DropDownItems.Add(mit);
                                curf++;
                                //MessageBox.Show("Folder Added:" + mit.Text);
                            }
                        }
                        else if (parts[0].Trim() == "ItemName" || parts[0].Trim() == "SubItemName")
                        {
                            type = parts[0].Trim();
                            mit = new ToolStripMenuItem();
                            mit.Name = parts[1].Trim();
                            mit.ToolTipText = parts[1].Trim();
                            //MessageBox.Show("|" + parts[0].Trim() + "|" + "\n" + "|" + parts[1].Trim() + "|");
                            for (int i = 0; i < 2; i++)
                            {
                                line = sr.ReadLine();
                                parts = line.Split(spl);
                                //MessageBox.Show("|" + parts[0].Trim() + "|" + "\n" + "|" + parts[1].Trim() + "|");
                                if (i == 0) mit.Text = parts[1].Trim();
                                if (i == 1)
                                {
                                    if (parts[1].Trim() == "folder")
                                    {
                                        mit.Image = Properties.Resources.netfolder.ToBitmap();
                                        mit.Click += new EventHandler(mi_Click);
                                    }
                                    else
                                    {
                                        mit.Image = Properties.Resources.pc;
                                        mit.Click += new EventHandler(mitt_Click);
                                    }
                                }
                            }
                            if (type == "SubItemName")
                            {
                                ToolStripMenuItem men = (ToolStripMenuItem)ZaklMenu.DropDownItems[curf-1];
                                men.DropDownItems.Add(mit);
                                //MessageBox.Show("Share added Subitem:" + mit.Text);
                            }
                            if (type == "ItemName")
                            {
                                ZaklMenu.DropDownItems.Add(mit);
                               // MessageBox.Show("Share added item:" + mit.Text);
                            }
                            //MessageBox.Show("|" + type + "|");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Cold n't open file\n");
                // MessageBox.Show(ex.Message);
            }
        }
        void mitt_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem nmi = (ToolStripMenuItem)sender;
            BuildShareList(nmi.Name,nmi.Text);
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = TabP.SelectedTab.Text.Trim();
            string ip = TabP.SelectedTab.Name;
            TabP.TabPages.Remove(TabP.SelectedTab);
            BuildShareList(ip, name);
        }

        /// <summary>
        /// Создаёт окно создания закладки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void добавитьВЗакладки_Click(object sender, EventArgs e)
        {
            if (OptData.Default.CurActiveItem!=null)
            {
                ListViewItem item = OptData.Default.CurActiveItem;
                this.Enabled = false;
                ZaklAdd nzak = new ZaklAdd(item.Text,
                    item.ToolTipText,
                    Properties.Resources.netfolder.ToBitmap());
                //nzak.folderL.SelectedIndex = 1;
                nzak.Show();
            }
        }

        private void TabP_TabPageClosedNow()
        {
            TabP.SelectedIndex=TabP.TabCount-1;
        }
    }
}
