using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace netOpen
{
    public partial class AddRedact : Form
    {
        public AddRedact()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tName.TextLength == 0)
            {
                MessageBox.Show("Невозможно создать диапазон без имени", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tName.Focus();
            }
            else
            {
                try
                {
                    IPAddress.Parse(tStIP.Text);
                    IPAddress.Parse(tEndIP.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Границы введены неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!IsEndIpBigger()) { MessageBox.Show("Нижняя граница должна быть меньше верхней", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); tStIP.Focus(); return; }
                    if (OptData.Default.Add)
                    {
                        ListViewItem ni = new ListViewItem();
                        ni.Text = tName.Text;
                        ni.SubItems.Add(tStIP.Text);
                        ni.SubItems.Add(tEndIP.Text);
                        ni.SubItems.Add(cbStatus.Text);
                        ni.SubItems.Add(tDescr.Text);
                        OptData.Default.DiapCount++;
                        OptData.Default.diapListH.Items.Add(ni);
                    }
                    else
                    {
                        ListViewItem ni = OptData.Default.diapListH.FocusedItem;
                        ni.SubItems.Clear();
                        ni.Text = tName.Text;
                        ni.SubItems.Add(tStIP.Text);
                        ni.SubItems.Add(tEndIP.Text);
                        ni.SubItems.Add(cbStatus.Text);
                        ni.SubItems.Add(tDescr.Text);
                    }
                    OptForm.HaveAChange = true;
                    this.Close();
                }
        }

        private void AddRedact_Load(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;
        }

        private void AddRedact_FormClosing(object sender, FormClosingEventArgs e)
        {
            OptData.Default.OptForm.Enabled = true;
        }

        public bool IsEndIpBigger()
        {
            byte[] stip = tStIP.GetAddressBytes();
            byte[] enip = tEndIP.GetAddressBytes();
            int fr = 0, sec = 0;
            for (int i = 0; i < 4; i++)
            {
                if (enip[i] < stip[i]) fr+=(int)Math.Pow(4-i,2);
                else if (enip[i] > stip[i]) sec += (int)Math.Pow(4 - i, 2);
            }
            //MessageBox.Show("Fr=" + fr.ToString() + ", Sec=" + sec.ToString());
            if (sec > fr) return true;
            else return false;
        }
    }
}
