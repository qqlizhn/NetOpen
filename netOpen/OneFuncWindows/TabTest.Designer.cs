namespace netOpen
{
    partial class TabTest
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
            this.myTabControl1 = new netOpen.MyTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.myTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myTabControl1
            // 
            this.myTabControl1.Controls.Add(this.tabPage1);
            this.myTabControl1.Controls.Add(this.tabPage2);
            this.myTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.myTabControl1.Location = new System.Drawing.Point(12, 12);
            this.myTabControl1.Name = "myTabControl1";
            this.myTabControl1.SelectedIndex = 0;
            this.myTabControl1.Size = new System.Drawing.Size(260, 238);
            this.myTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(252, 212);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1 ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(252, 212);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2 ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TabTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.myTabControl1);
            this.Name = "TabTest";
            this.ShowInTaskbar = false;
            this.Text = "TabTest";
            this.myTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyTabControl myTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}