using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsTpFin.Fonction;

namespace WinFormsTpFin
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            interface2.init_list_produit(listBox5);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox5.SelectedIndex;
            interface2.affi_produit(index, listBox5, label5, listBox2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            Hide();
            f.ShowDialog();
            Close();
        }
    }
}
