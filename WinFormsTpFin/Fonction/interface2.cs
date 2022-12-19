using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormsTpFin.Fonction
{
    internal class interface2
    {
        public static void init_list_produit (ListBox list)
        {
            List<produit> ListProuduit = RequestDB.select_produit();
            foreach (produit x in ListProuduit)
            {
                list.Items.Add(x.Id + " -> " + x.Libelle);
            }
        }

        public static void affi_produit (int index, ListBox list, Label affi, ListBox list2)
        {
            if (index != 1)
            {
                // deja expliquer dans le form 1
                string a = list.Items[index].ToString();
                string indexx = a.Split(" -> ")[0];
                int id = int.Parse(indexx);
                produit prod = RequestDB.select_produit_id(id);
                affi.Text = ("ID -> " + prod.Id +
                    "\n Libelle -> " + prod.Libelle +
                    "\n Prix unitaire -> " + prod.PrixUnitaire +
                    "\n Date de modification -> " + prod.ModifiedDate);

                list2.Items.Clear();
                List<LigneCommande> ListCommande = RequestDB.select_ligne_comande(id);
                foreach (LigneCommande x in ListCommande)
                {
                    list2.Items.Add("ID : " + x.Id + " -> " + "Quantiter : " + x.Quantiter);
                }

            }
        }
    }
}
