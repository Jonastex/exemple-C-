using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTpFin;
using WinFormsTpFin.Fonction;

namespace WinFormsTpFin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            interface1.init_list(listBox1);
            interface1.init_combo(comboBox1);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            List<LigneCommande> ligneCommandes = RequestDB.SelectionCommande();
            if (index != -1)
            {
                LigneCommande selection = ligneCommandes[index];
                label1.Text = (" ID -> " + selection.Id +
                    "\n Quantiter -> " + selection.Quantiter +
                    "\n Prix unitaire -> " + selection.PrixUnitaire +
                    "\n ID entete produit -> " + selection.Identetecommande +
                    "\n ID produit -> " + selection.IdProduit +
                    "\n Date -> " + selection.ModifiedDate);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;


            // C' est pas possible de faire un set set data sur un index dans une list box
            string text = listBox1.Items[index].ToString();
            string indexx = text.Split(" -> ")[0];
            int id = int.Parse(indexx);

            RequestDB.delete_commande(id);

            listBox1.Items.RemoveAt(index);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            string text = textBox1.Text;
            
            interface1.mod_prix(index, text, label2, listBox1);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            string text = textBox1.Text;

            interface1.mod_prix(index, text, label2, listBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;

            // meme methode décris au dessus
            string textt = comboBox1.Items[index].ToString();
            string indexx = textt.Split(" -> ")[0];
            int id = int.Parse(indexx);


            string text = textBox1.Text;

            try
            {
                int quantiter = int.Parse(text);
                LigneCommande commande = RequestDB.insert_lignecommande(id, quantiter);

                listBox1.Items.Add(commande.Id + " -> " + (commande.Quantiter * commande.PrixUnitaire));
            }
            catch 
            {
                MessageBox.Show("Je ne prend que les nombres ;) ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            Hide();
            f.ShowDialog();
            Close();
        }
    }
}
