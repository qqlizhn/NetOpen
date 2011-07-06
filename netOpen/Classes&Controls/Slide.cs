using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace netOpen
{
    public partial class SlideBar : UserControl
    {

        public static bool grew = true;
        public static int PerV = 60,dif=0,step=5;

        public SlideBar()
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
                /*if (label1.Height + step > PerV) { label1.Height = PerV; }
                else { label1.Height += step; }
                if (label1.Height == PerV) { grew = true; myt.Stop(); button1.Enabled = true; }*/
                if (label1.Height + step >= PerV) { label1.Height = PerV; grew = true; myt.Stop(); button1.Enabled = true; }
                else label1.Height += step;
                //this.Location = new Point(this.Location.X, this.Location.Y-step);
            }
            if (grew)
            {
                /*if (label1.Height - step < 0) label1.Height = 0;
                else label1.Height -= step;
                if (label1.Height == 0) { grew = false; myt.Stop(); button1.Enabled = true; }*/
                if (label1.Height - step <= 0) { label1.Height = 0; grew = false; myt.Stop(); button1.Enabled = true; }
                else label1.Height -= step;
                //this.Location = new Point(this.Location.X, this.Location.Y + step);
            }
            button1.Location = new Point(button1.Location.X, label1.Location.Y - dif);
            this.Height = label1.Height + dif;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            dif = button1.Height/2;
            this.Height = label1.Height + dif;
            label1.Height = PerV;
            button1.Location = new Point(this.Width / 2 - button1.Width / 2, label1.Location.Y - dif);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.Location = new Point(this.Location.X, this.Location.Y + label1.Height);
            //initc();
        }

        private void initc()
        {
            label1.Height = 0;
            
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            button1.Location = new Point(this.Width/2-button1.Width/2,label1.Location.Y-dif);

            /*context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
            if (grafx != null)
            {
                grafx.Dispose();
                grafx = null;
            }
            grafx = context.Allocate(this.CreateGraphics(),
                new Rectangle(0, 0, this.Width, this.Height));

            // Cause the background to be cleared and redraw.
            //count = 6;
            //DrawToBuffer(grafx.Graphics);
            this.Refresh();*/

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
        /// Возвращает размер выдвижного окна
        /// </summary>
        /// <param name="x"></param>
        public int GetSize()
        {
            return PerV;


        }

        /// <summary>
        /// Получает или устанавливает размер изменяемой области
        /// </summary>
        public int GrowSize
        {
            get { return PerV; }
            set { PerV = value; }
        }

        /// <summary>
        /// Получает или устанавливает шаг изменения размера окна на каждый тик таймера
        /// </summary>
        public int StepSize
        {
            get { return step; }
            set { step = value; }
        }

        /// <summary>
        /// Получает или устанавливает время задержки таймера движения
        /// </summary>
        public int WorkTimerInterval
        {
            get { return myt.Interval; }
            set { myt.Interval = value; }
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

        /// <summary>
        /// Изменить текст кнопки
        /// </summary>
        /// <param name="Name"></param>
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

        /// <summary>
        /// Возвращает значение текущего положения панели
        /// </summary>
        /// <returns></returns>
        public bool IsUp()
        {
            return grew;
        }

        /// <summary>
        /// Возвращает значение наличия движения
        /// </summary>
        /// <returns></returns>
        public bool InMoove()
        {
            return myt.Enabled;
        }

        /*EventHandler Slide
        {
            
        }*/

    }
}
