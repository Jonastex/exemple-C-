using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace WinFormsTpFin.Fonction
{
    class interface1
    {
        public static void init_list (ListBox list)
        {
            List<LigneCommande> ligneCommandes = RequestDB.SelectionCommande();

            foreach (LigneCommande x in ligneCommandes)
            {
                list.Items.Add(x.Id + " -> " + (x.Quantiter * x.PrixUnitaire));
            }
        }

        public static void init_combo (ComboBox box)
        {
            List<produit> produitList = RequestDB.select_produit();
            foreach (produit produit in produitList)
            {
                box.Items.Add( produit.Id + " -> " + produit.Libelle);
            }
        }


        public static void mod_prix (int index, string text, Label affi, ListBox list)
        {
            if (index != -1 && text != "")
            {

                // deja expliquer dans le form 1
                string a = list.Items[index].ToString();
                string indexx = a.Split(" -> ")[0];
                int id = int.Parse(indexx);


                int prix = RequestDB.select_prix_produit(id);
                try
                {
                    int quantiter = int.Parse(text);
                    affi.Text = quantiter * prix + " euros";
                }
                catch 
                {
                    MessageBox.Show("Je ne prend que les nombres ;) ");
                }
                
            }        
        }
    }
}
