namespace netOpen
{
    partial class SinglePCAdd
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
            this.drawT = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tName = new System.Windows.Forms.TextBox();
            this.rbDom = new System.Windows.Forms.RadioButton();
            this.rbIP = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ipAd = new IPAddressControlLib.IPAddressControl();
            this.SuspendLayout();
            // 
            // drawT
            // 
            this.drawT.Interval = 20;
            this.drawT.Tick += new System.EventHandler(this.drawT_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(185, 98);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(87, 20);
            this.tName.TabIndex = 10;
            this.tName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ipAd_KeyDown);
            // 
            // rbDom
            // 
            this.rbDom.AutoSize = true;
            this.rbDom.Location = new System.Drawing.Point(19, 98);
            this.rbDom.Name = "rbDom";
            this.rbDom.Size = new System.Drawing.Size(144, 17);
            this.rbDom.TabIndex = 9;
            this.rbDom.TabStop = true;
            this.rbDom.Text = "Сканировать по имени:";
            this.rbDom.UseVisualStyleBackColor = true;
            // 
            // rbIP
            // 
            this.rbIP.AutoSize = true;
            this.rbIP.BackColor = System.Drawing.SystemColors.Control;
            this.rbIP.Location = new System.Drawing.Point(19, 75);
            this.rbIP.Name = "rbIP";
            this.rbIP.Size = new System.Drawing.Size(160, 17);
            this.rbIP.TabIndex = 8;
            this.rbIP.TabStop = true;
            this.rbIP.Text = "Сканировать по IP адресу:";
            this.rbIP.UseVisualStyleBackColor = false;
            this.rbIP.CheckedChanged += new System.EventHandler(this.rbIP_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Введите адрес добавляемого компьютера:";
            // 
            // ipAd
            // 
            this.ipAd.AllowInternalTab = false;
            this.ipAd.AutoHeight = true;
            this.ipAd.BackColor = System.Drawing.SystemColors.Window;
            this.ipAd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAd.Location = new System.Drawing.Point(185, 72);
            this.ipAd.MinimumSize = new System.Drawing.Size(87, 20);
            this.ipAd.Name = "ipAd";
            this.ipAd.ReadOnly = false;
            this.ipAd.Size = new System.Drawing.Size(87, 20);
            this.ipAd.TabIndex = 6;
            this.ipAd.Text = "...";
            this.ipAd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ipAd_KeyDown);
            // 
            // SinglePCAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 155);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbIP);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tName);
            this.Controls.Add(this.rbDom);
            this.Controls.Add(this.ipAd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SinglePCAdd";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SinglePCAdd_FormClosing);
            this.Load += new System.EventHandler(this.SinglePCAdd_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TopP_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer drawT;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.RadioButton rbDom;
        private System.Windows.Forms.RadioButton rbIP;
        private System.Windows.Forms.Label label1;
        private IPAddressControlLib.IPAddressControl ipAd;
    }
}