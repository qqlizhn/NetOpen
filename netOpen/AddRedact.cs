using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            if (OptData.Default.Add)
            {
                ListViewItem ni = new ListViewItem();
                ni.Text = tName.Text;
                ni.SubItems.Add(tStIP.Text);
                ni.SubItems.Add(tEndIP.Text);
                ni.SubItems.Add(cbStatus.Text);
                ni.SubItems.Add(tDescr.Text);
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
            this.Close();
        }

        private void AddRedact_Load(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;
        }

        private void AddRedact_FormClosing(object sender, FormClosingEventArgs e)
        {
            OptData.Default.OptForm.Enabled = true;
        }
    }
}
