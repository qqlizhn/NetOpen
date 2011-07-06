namespace netOpen.OneFuncWindows
{
    partial class ShareSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShareSearch));
            this.iml = new System.Windows.Forms.ImageList(this.components);
            this.drawT = new System.Windows.Forms.Timer(this.components);
            this.cmSearch = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.плиткаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.детальныйВидToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.крупныеЗначкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssl = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iml
            // 
            this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
            this.iml.TransparentColor = System.Drawing.Color.Transparent;
            this.iml.Images.SetKeyName(0, "Folder Closed.png");
            this.iml.Images.SetKeyName(1, "ico172.ico");
            this.iml.Images.SetKeyName(2, "ico174.ico");
            // 
            // drawT
            // 
            this.drawT.Interval = 20;
            this.drawT.Tick += new System.EventHandler(this.drawT_Tick);
            // 
            // cmSearch
            // 
            this.cmSearch.FormattingEnabled = true;
            this.cmSearch.Items.AddRange(new object[] {
            "Видео\\Клипы\\Фильмы\\Video\\Videos\\Films\\Clips",
            "Музыка\\Треки\\Муза\\Саундтреки\\Music\\Soundtrack",
            "Проги\\Программы\\Инстол\\Инстал\\Setup\\Install\\Programs\\Progs"});
            this.cmSearch.Location = new System.Drawing.Point(59, 58);
            this.cmSearch.Name = "cmSearch";
            this.cmSearch.Size = new System.Drawing.Size(330, 21);
            this.cmSearch.TabIndex = 4;
            this.cmSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmSearch_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(423, 54);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(35, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.плиткаToolStripMenuItem,
            this.детальныйВидToolStripMenuItem,
            this.крупныеЗначкиToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // плиткаToolStripMenuItem
            // 
            this.плиткаToolStripMenuItem.Name = "плиткаToolStripMenuItem";
            this.плиткаToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.плиткаToolStripMenuItem.Text = "Плитка";
            this.плиткаToolStripMenuItem.Click += new System.EventHandler(this.плиткаToolStripMenuItem_Click);
            // 
            // детальныйВидToolStripMenuItem
            // 
            this.детальныйВидToolStripMenuItem.Name = "детальныйВидToolStripMenuItem";
            this.детальныйВидToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.детальныйВидToolStripMenuItem.Text = "Детальный вид";
            this.детальныйВидToolStripMenuItem.Click += new System.EventHandler(this.детальныйВидToolStripMenuItem_Click);
            // 
            // крупныеЗначкиToolStripMenuItem
            // 
            this.крупныеЗначкиToolStripMenuItem.Name = "крупныеЗначкиToolStripMenuItem";
            this.крупныеЗначкиToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.крупныеЗначкиToolStripMenuItem.Text = "Крупные значки";
            this.крупныеЗначкиToolStripMenuItem.Click += new System.EventHandler(this.крупныеЗначкиToolStripMenuItem_Click);
            // 
            // ssl
            // 
            this.ssl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ssl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.ssl.ContextMenuStrip = this.contextMenuStrip1;
            this.ssl.GridLines = true;
            this.ssl.LargeImageList = this.iml;
            this.ssl.Location = new System.Drawing.Point(3, 82);
            this.ssl.MultiSelect = false;
            this.ssl.Name = "ssl";
            this.ssl.Size = new System.Drawing.Size(450, 257);
            this.ssl.SmallImageList = this.iml;
            this.ssl.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ssl.TabIndex = 6;
            this.ssl.UseCompatibleStateImageBehavior = false;
            this.ssl.View = System.Windows.Forms.View.Tile;
            this.ssl.DoubleClick += new System.EventHandler(this.Share_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Название папки";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Имя компютера";
            this.columnHeader2.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.копироватьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 26);
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            this.копироватьToolStripMenuItem.Click += new System.EventHandler(this.копироватьToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Что ищем?";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "оК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cmSearch_is);
            // 
            // ShareSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 342);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmSearch);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ssl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShareSearch";
            this.Text = "ShareSearch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShareSearch_FormClosing);
            this.Load += new System.EventHandler(this.ShareSearch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TopP_Paint);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList iml;
        private System.Windows.Forms.Timer drawT;
        private System.Windows.Forms.ComboBox cmSearch;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem плиткаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem детальныйВидToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem крупныеЗначкиToolStripMenuItem;
        private System.Windows.Forms.ListView ssl;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
    }
}