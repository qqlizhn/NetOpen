namespace netOpen
{
    partial class ZaklAdd
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
            this.folderL = new System.Windows.Forms.ComboBox();
            this.drawT = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // folderL
            // 
            this.folderL.FormattingEnabled = true;
            this.folderL.Items.AddRange(new object[] {
            "Вне папок"});
            this.folderL.Location = new System.Drawing.Point(158, 54);
            this.folderL.Name = "folderL";
            this.folderL.Size = new System.Drawing.Size(122, 21);
            this.folderL.TabIndex = 0;
            // 
            // drawT
            // 
            this.drawT.Interval = 20;
            this.drawT.Tick += new System.EventHandler(this.drawT_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя списка закладок:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::netOpen.Properties.Resources.Folder_Open1;
            this.pictureBox1.Location = new System.Drawing.Point(136, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Имя новой закладки:";
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(136, 98);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(144, 20);
            this.tName.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.добавитьВЗакладкиToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(205, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ZaklAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 156);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.folderL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZaklAdd";
            this.ShowIcon = false;
            this.Text = "Закладка";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZaklAdd_FormClosing);
            this.Load += new System.EventHandler(this.ZaklAdd_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TopP_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer drawT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox folderL;
        public System.Windows.Forms.TextBox tName;
    }
}