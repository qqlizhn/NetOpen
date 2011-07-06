namespace netOpen
{
    partial class Temp
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
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb
            // 
            this.rtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb.BackColor = System.Drawing.Color.White;
            this.rtb.ForeColor = System.Drawing.Color.Black;
            this.rtb.Location = new System.Drawing.Point(2, 2);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(397, 467);
            this.rtb.TabIndex = 0;
            this.rtb.Text = "";
            this.rtb.Click += new System.EventHandler(this.rtb_Click);
            // 
            // Temp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 471);
            this.Controls.Add(this.rtb);
            this.Name = "Temp";
            this.Text = "Temp";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox rtb;
    }
}