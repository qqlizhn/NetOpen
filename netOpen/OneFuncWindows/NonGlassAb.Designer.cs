namespace netOpen
{
    partial class NonGlassAb
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
            this.Close = new System.Windows.Forms.Button();
            this.drawT = new System.Windows.Forms.Timer(this.components);
            this.OpacityT = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.BackColor = System.Drawing.Color.Transparent;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Location = new System.Drawing.Point(139, 329);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(67, 23);
            this.Close.TabIndex = 0;
            this.Close.Text = "Закрыть";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            this.Close.Paint += new System.Windows.Forms.PaintEventHandler(this.Close_Paint);
            // 
            // drawT
            // 
            this.drawT.Interval = 20;
            this.drawT.Tick += new System.EventHandler(this.drawT_Tick);
            // 
            // OpacityT
            // 
            this.OpacityT.Interval = 15;
            this.OpacityT.Tick += new System.EventHandler(this.OpacityT_Tick);
            // 
            // NonGlassAb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 352);
            this.ControlBox = false;
            this.Controls.Add(this.Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NonGlassAb";
            this.Opacity = 0D;
            this.Text = "О программе";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NonGlassAb_FormClosing);
            this.Load += new System.EventHandler(this.NonGlassAb_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NonGlassAb_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Timer drawT;
        private System.Windows.Forms.Timer OpacityT;
    }
}