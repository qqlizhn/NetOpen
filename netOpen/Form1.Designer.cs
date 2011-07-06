namespace netOpen
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pBar_stat = new System.Windows.Forms.ToolStripProgressBar();
            this.pcList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ActPC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.пинговатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeI = new System.Windows.Forms.ImageList(this.components);
            this.LittleI = new System.Windows.Forms.ImageList(this.components);
            this.Refresh = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.главнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инструментыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.сканироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsRef = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.status = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPCs = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.мелкиеЗначкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.крупныеЗначкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.деталеыйВидToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.поАлфавитуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.протиАлфавитаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поIPАдресамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.TabMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.закрытьВкладкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьВсеКромеТекущейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВИзбранноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartPage = new System.Windows.Forms.TabPage();
            this.TabP = new System.Windows.Forms.TabControl();
            this.ActPC.SuspendLayout();
            this.Refresh.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.status.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.TabMenu.SuspendLayout();
            this.TabP.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBar_stat
            // 
            this.pBar_stat.AccessibleRole = System.Windows.Forms.AccessibleRole.ProgressBar;
            this.pBar_stat.Name = "pBar_stat";
            this.pBar_stat.Size = new System.Drawing.Size(100, 16);
            // 
            // pcList
            // 
            this.pcList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pcList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.pcList.ContextMenuStrip = this.ActPC;
            this.pcList.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pcList.FullRowSelect = true;
            this.pcList.GridLines = true;
            this.pcList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.pcList.LargeImageList = this.LargeI;
            this.pcList.Location = new System.Drawing.Point(2, 66);
            this.pcList.MultiSelect = false;
            this.pcList.Name = "pcList";
            this.pcList.Size = new System.Drawing.Size(145, 362);
            this.pcList.SmallImageList = this.LittleI;
            this.pcList.StateImageList = this.LittleI;
            this.pcList.TabIndex = 0;
            this.pcList.UseCompatibleStateImageBehavior = false;
            this.pcList.View = System.Windows.Forms.View.SmallIcon;
            this.pcList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pcList_MouseClick);
            this.pcList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pcList_MouseUp);
            this.pcList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcList_MouseMove);
            this.pcList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcList_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Active PCs";
            this.columnHeader1.Width = 129;
            // 
            // ActPC
            // 
            this.ActPC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.обновитьToolStripMenuItem1,
            this.пинговатьToolStripMenuItem});
            this.ActPC.Name = "contextMenuStrip1";
            this.ActPC.Size = new System.Drawing.Size(133, 70);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // обновитьToolStripMenuItem1
            // 
            this.обновитьToolStripMenuItem1.Name = "обновитьToolStripMenuItem1";
            this.обновитьToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.обновитьToolStripMenuItem1.Text = "Обновить";
            this.обновитьToolStripMenuItem1.Click += new System.EventHandler(this.обновитьToolStripMenuItem1_Click);
            // 
            // пинговатьToolStripMenuItem
            // 
            this.пинговатьToolStripMenuItem.Name = "пинговатьToolStripMenuItem";
            this.пинговатьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.пинговатьToolStripMenuItem.Text = "Пинговать";
            this.пинговатьToolStripMenuItem.Click += new System.EventHandler(this.пинговатьToolStripMenuItem_Click);
            // 
            // LargeI
            // 
            this.LargeI.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LargeI.ImageStream")));
            this.LargeI.TransparentColor = System.Drawing.Color.Transparent;
            this.LargeI.Images.SetKeyName(0, "ico11.ico");
            this.LargeI.Images.SetKeyName(1, "ico14.ico");
            this.LargeI.Images.SetKeyName(2, "ico16.ico");
            this.LargeI.Images.SetKeyName(3, "ico134.ico");
            this.LargeI.Images.SetKeyName(4, "ico135.ico");
            this.LargeI.Images.SetKeyName(5, "ico146.ico");
            this.LargeI.Images.SetKeyName(6, "ico172.ico");
            this.LargeI.Images.SetKeyName(7, "ico174.ico");
            this.LargeI.Images.SetKeyName(8, "ico176.ico");
            this.LargeI.Images.SetKeyName(9, "ico16721.ico");
            // 
            // LittleI
            // 
            this.LittleI.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LittleI.ImageStream")));
            this.LittleI.TransparentColor = System.Drawing.Color.Transparent;
            this.LittleI.Images.SetKeyName(0, "ico11.ico");
            this.LittleI.Images.SetKeyName(1, "ico172.ico");
            this.LittleI.Images.SetKeyName(2, "ico16.ico");
            this.LittleI.Images.SetKeyName(3, "ico176.ico");
            this.LittleI.Images.SetKeyName(4, "ico174.ico");
            this.LittleI.Images.SetKeyName(5, "ico134.ico");
            this.LittleI.Images.SetKeyName(6, "ico135.ico");
            this.LittleI.Images.SetKeyName(7, "ico146.ico");
            this.LittleI.Images.SetKeyName(8, "ico14.ico");
            this.LittleI.Images.SetKeyName(9, "ico16721.ico");
            // 
            // Refresh
            // 
            this.Refresh.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьToolStripMenuItem});
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(129, 26);
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.обновитьToolStripMenuItem.Text = "Обновить";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.главнаяToolStripMenuItem,
            this.инструментыToolStripMenuItem,
            this.сToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(542, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // главнаяToolStripMenuItem
            // 
            this.главнаяToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.главнаяToolStripMenuItem.Name = "главнаяToolStripMenuItem";
            this.главнаяToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.главнаяToolStripMenuItem.Text = "Главная";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // инструментыToolStripMenuItem
            // 
            this.инструментыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.toolStripSeparator1,
            this.сканироватьToolStripMenuItem});
            this.инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
            this.инструментыToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.инструментыToolStripMenuItem.Text = "Инструменты";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // сканироватьToolStripMenuItem
            // 
            this.сканироватьToolStripMenuItem.Name = "сканироватьToolStripMenuItem";
            this.сканироватьToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.сканироватьToolStripMenuItem.Text = "Сканировать";
            this.сканироватьToolStripMenuItem.Click += new System.EventHandler(this.сканироватьToolStripMenuItem_Click);
            // 
            // сToolStripMenuItem
            // 
            this.сToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.сToolStripMenuItem.Name = "сToolStripMenuItem";
            this.сToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.сToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRef,
            this.toolStripButton2});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(542, 22);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsRef
            // 
            this.tsRef.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRef.Image = ((System.Drawing.Image)(resources.GetObject("tsRef.Image")));
            this.tsRef.ImageTransparentColor = System.Drawing.Color.White;
            this.tsRef.Name = "tsRef";
            this.tsRef.Size = new System.Drawing.Size(23, 20);
            this.tsRef.Text = "Сканировать сеть";
            this.tsRef.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton2.Text = "GetShares";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pBar_stat,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.statusPCs});
            this.status.Location = new System.Drawing.Point(0, 431);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(542, 22);
            this.status.TabIndex = 8;
            this.status.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(77, 17);
            this.toolStripStatusLabel2.Text = "Найдено ПК:";
            // 
            // statusPCs
            // 
            this.statusPCs.Name = "statusPCs";
            this.statusPCs.Size = new System.Drawing.Size(13, 17);
            this.statusPCs.Text = "0";
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripSplitButton2,
            this.toolStripButton1});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip2.Location = new System.Drawing.Point(2, 46);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(145, 22);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.мелкиеЗначкиToolStripMenuItem,
            this.крупныеЗначкиToolStripMenuItem,
            this.деталеыйВидToolStripMenuItem,
            this.списокToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton1.Text = "Вид значков";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.мелкиеЗначкиToolStripMenuItem_Click);
            // 
            // мелкиеЗначкиToolStripMenuItem
            // 
            this.мелкиеЗначкиToolStripMenuItem.Name = "мелкиеЗначкиToolStripMenuItem";
            this.мелкиеЗначкиToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.мелкиеЗначкиToolStripMenuItem.Text = "Мелкие значки";
            this.мелкиеЗначкиToolStripMenuItem.Click += new System.EventHandler(this.мелкиеЗначкиToolStripMenuItem_Click);
            // 
            // крупныеЗначкиToolStripMenuItem
            // 
            this.крупныеЗначкиToolStripMenuItem.Name = "крупныеЗначкиToolStripMenuItem";
            this.крупныеЗначкиToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.крупныеЗначкиToolStripMenuItem.Text = "Крупные значки";
            this.крупныеЗначкиToolStripMenuItem.Click += new System.EventHandler(this.крупныеЗначкиToolStripMenuItem_Click);
            // 
            // деталеыйВидToolStripMenuItem
            // 
            this.деталеыйВидToolStripMenuItem.Name = "деталеыйВидToolStripMenuItem";
            this.деталеыйВидToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.деталеыйВидToolStripMenuItem.Text = "Деталеый вид";
            this.деталеыйВидToolStripMenuItem.Click += new System.EventHandler(this.деталеыйВидToolStripMenuItem_Click);
            // 
            // списокToolStripMenuItem
            // 
            this.списокToolStripMenuItem.Name = "списокToolStripMenuItem";
            this.списокToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.списокToolStripMenuItem.Text = "Список";
            this.списокToolStripMenuItem.Click += new System.EventHandler(this.списокToolStripMenuItem_Click);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поАлфавитуToolStripMenuItem,
            this.протиАлфавитаToolStripMenuItem,
            this.поIPАдресамToolStripMenuItem});
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton2.Text = "Сортировка";
            this.toolStripSplitButton2.ButtonClick += new System.EventHandler(this.поАлфавитуToolStripMenuItem_Click);
            // 
            // поАлфавитуToolStripMenuItem
            // 
            this.поАлфавитуToolStripMenuItem.Name = "поАлфавитуToolStripMenuItem";
            this.поАлфавитуToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.поАлфавитуToolStripMenuItem.Text = "По алфавиту";
            this.поАлфавитуToolStripMenuItem.Click += new System.EventHandler(this.поАлфавитуToolStripMenuItem_Click);
            // 
            // протиАлфавитаToolStripMenuItem
            // 
            this.протиАлфавитаToolStripMenuItem.Name = "протиАлфавитаToolStripMenuItem";
            this.протиАлфавитаToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.протиАлфавитаToolStripMenuItem.Text = "Против алфавита";
            this.протиАлфавитаToolStripMenuItem.Click += new System.EventHandler(this.протиАлфавитаToolStripMenuItem_Click);
            // 
            // поIPАдресамToolStripMenuItem
            // 
            this.поIPАдресамToolStripMenuItem.Name = "поIPАдресамToolStripMenuItem";
            this.поIPАдресамToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.поIPАдресамToolStripMenuItem.Text = "По IP адресам";
            this.поIPАдресамToolStripMenuItem.Click += new System.EventHandler(this.поIPАдресамToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // TabMenu
            // 
            this.TabMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьВкладкуToolStripMenuItem,
            this.закрытьВсеКромеТекущейToolStripMenuItem,
            this.добавитьВИзбранноеToolStripMenuItem});
            this.TabMenu.Name = "TabMenu";
            this.TabMenu.Size = new System.Drawing.Size(237, 70);
            // 
            // закрытьВкладкуToolStripMenuItem
            // 
            this.закрытьВкладкуToolStripMenuItem.Name = "закрытьВкладкуToolStripMenuItem";
            this.закрытьВкладкуToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.закрытьВкладкуToolStripMenuItem.Text = "Закрыть активную вкладку";
            this.закрытьВкладкуToolStripMenuItem.Click += new System.EventHandler(this.закрытьВкладкуToolStripMenuItem_Click);
            // 
            // закрытьВсеКромеТекущейToolStripMenuItem
            // 
            this.закрытьВсеКромеТекущейToolStripMenuItem.Name = "закрытьВсеКромеТекущейToolStripMenuItem";
            this.закрытьВсеКромеТекущейToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.закрытьВсеКромеТекущейToolStripMenuItem.Text = "Закрыть все, кроме активной";
            // 
            // добавитьВИзбранноеToolStripMenuItem
            // 
            this.добавитьВИзбранноеToolStripMenuItem.Name = "добавитьВИзбранноеToolStripMenuItem";
            this.добавитьВИзбранноеToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.добавитьВИзбранноеToolStripMenuItem.Text = "Добавить в избранное";
            // 
            // StartPage
            // 
            this.StartPage.ImageIndex = 8;
            this.StartPage.Location = new System.Drawing.Point(4, 23);
            this.StartPage.Name = "StartPage";
            this.StartPage.Size = new System.Drawing.Size(378, 352);
            this.StartPage.TabIndex = 1;
            this.StartPage.Text = "Стартовая";
            this.StartPage.UseVisualStyleBackColor = true;
            // 
            // TabP
            // 
            this.TabP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabP.ContextMenuStrip = this.TabMenu;
            this.TabP.Controls.Add(this.StartPage);
            this.TabP.HotTrack = true;
            this.TabP.ImageList = this.LittleI;
            this.TabP.Location = new System.Drawing.Point(153, 49);
            this.TabP.Name = "TabP";
            this.TabP.SelectedIndex = 0;
            this.TabP.ShowToolTips = true;
            this.TabP.Size = new System.Drawing.Size(386, 379);
            this.TabP.TabIndex = 10;
            this.TabP.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TabP_MouseClick);
            this.TabP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabP_MouseDown);
            this.TabP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TabP_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 453);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.status);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pcList);
            this.Controls.Add(this.TabP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "netOpen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ActPC.ResumeLayout(false);
            this.Refresh.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.TabMenu.ResumeLayout(false);
            this.TabP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListView pcList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip Refresh;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ActPC;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem пинговатьToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem главнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инструментыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сканироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsRef;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        public System.Windows.Forms.ImageList LittleI;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        public System.Windows.Forms.ToolStripProgressBar pBar_stat;
        public System.Windows.Forms.ToolStripStatusLabel statusPCs;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem мелкиеЗначкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem крупныеЗначкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem деталеыйВидToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem поАлфавитуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem протиАлфавитаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поIPАдресамToolStripMenuItem;
        public System.Windows.Forms.ImageList LargeI;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ContextMenuStrip TabMenu;
        private System.Windows.Forms.ToolStripMenuItem закрытьВкладкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьВсеКромеТекущейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьВИзбранноеToolStripMenuItem;
        private System.Windows.Forms.TabPage StartPage;
        public System.Windows.Forms.TabControl TabP;

    }
}

