using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UserControl1 : UserControl
    {

        private static bool grew = true;
        public static int PerV = 60,dif=0,step=5;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            myt.Start();
            
        }

        private void myt_Tick(object sender, EventArgs e)
        {
            if (!grew)
            {
                if (label1.Height + step > PerV) { label1.Height = PerV; }
                else { label1.Height += step; }
                if (label1.Height == PerV) { grew = true; myt.Stop(); button1.Enabled = true; }
            }
            if (grew)
            {
                if (label1.Height - step < 0) label1.Height = 0;
                else label1.Height -= step;
                if (label1.Height == 0) { grew = false; myt.Stop(); button1.Enabled = true; }
            }
            button1.Location = new Point(button1.Location.X, label1.Location.Y - dif);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            dif = button1.Height/2;
            label1.Height = PerV;
            button1.Location = new Point(this.Width / 2 - button1.Width / 2, label1.Location.Y - dif);
            //initc();
        }

        private void initc()
        {
            label1.Height = 0;
            
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            button1.Location = new Point(this.Width/2-button1.Width/2,label1.Location.Y-dif);
        }

        /// <summary>
        /// Указывает шаг анимации. По умолчанию равен 5 пикселей
        /// </summary>
        /// <param name="x"></param>
        public void ChangeSpeed(int Speed)
        {
            object sender=new object();
            EventArgs e=new EventArgs();
            step = Speed;
            UserControl1_Resize(sender, e);
        }

        /// <summary>
        /// Указывает размер выдвижного окна
        /// </summary>
        /// <param name="x"></param>
        public void ChangeSize(int Size)
        {
            PerV = Size;
            object sender = new object();
            EventArgs e = new EventArgs();
            UserControl1_Resize(sender, e);
            
        }


        /// <summary>
        /// Эмулирует нажатие на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Slide()
        {
            object sender = new object();
            EventArgs e = new EventArgs();
            UserControl1_Resize(sender, e);
            button1_Click(sender, e);
        }

        /// <summary>
        /// Настраивает ширину кнопки
        /// </summary>
        /// <param name="x"></param>
        public void ChangeButtonWidth(int Width)
        {
            button1.Width = Width;
            object sender = new object();
            EventArgs e = new EventArgs();
            UserControl1_Resize(sender, e);
        }

        public void ChangeButtonText(string Name)
        {
            button1.Text = Name;
            object sender = new object();
            EventArgs e = new EventArgs();
            UserControl1_Resize(sender, e);
        }

        /// <summary>
        /// Возвращает указатель на панель инструментов внутри всплывающего окна
        /// </summary>
        /// <returns></returns>
        public ToolStrip ToolStripHandler()
        {
            return toolStrip1;
        }

    }
}
