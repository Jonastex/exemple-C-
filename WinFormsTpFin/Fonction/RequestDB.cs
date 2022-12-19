using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsTpFin
{
    class RequestDB
    {
        public static string info_db ()
        {
            return "Server=localhost;Database=Commande;Uid=root;Pwd=root";
        }

        public static List<LigneCommande> SelectionCommande ()
        {
            String connString = info_db();

            MySqlConnection conn = new MySqlConnection(connString);

            conn.Open ();

            string sql = @"SELECT * FROM lignecommande ORDER BY Identifiant";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            

            List<LigneCommande> Commande = new List<LigneCommande>();
            while (reader.Read())
            {
                LigneCommande c = new LigneCommande(reader.GetInt32("Identifiant"), 
                    reader.GetInt32("Quantite"),
                    reader.GetInt32("PrixUnitaire"),
                    reader.GetInt32("IdentifiantEnteteCommande"),
                    reader.GetInt32("IdentifiantProduit"),
                    reader.GetDateTime("ModifiedDate")
                    );
                Commande.Add(c);
            }

            conn.Close();
            return Commande;
        }

        public static void delete_commande (int id)
        {
            MySqlConnection connection = new MySqlConnection(info_db());

            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            connection.Open();
            command.CommandText = @"DELETE FROM lignecommande
                     WHERE identifiant = @identifier";
            command.Parameters.AddWithValue("@identifier", id);

            int result = command.ExecuteNonQuery();

            connection.Close();
 
        }

        public static List<produit> select_produit ()
        {
            String connString = info_db();

            MySqlConnection conn = new MySqlConnection(connString);

            conn.Open();

            string sql = @"SELECT * FROM produit ORDER BY Identifiant";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader reader = cmd.ExecuteReader();



            List<produit> Commande = new List<produit>();
            while (reader.Read())
            {
                produit c = new produit(reader.GetInt32("Identifiant"),
                    reader.GetString("Libelle"),
                    reader.GetString("Reference"),
                    reader.GetInt32("PrixUnitaire"),
                    reader.GetDateTime("ModifiedDate")
                    );
                Commande.Add(c);
            }

            conn.Close();
            return Commande;
        }

        public static int select_prix_produit (int id)
        {
            MySqlConnection connection = new MySqlConnection(info_db());

            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            connection.Open();
            command.CommandText = @"SELECT PrixUnitaire FROM produit WHERE Identifiant = @identif ORDER BY Identifiant";
            command.Parameters.AddWithValue("@identif", id);

            MySqlDataReader reader = command.ExecuteReader();

            int retour = 0;
            while (reader.Read())
            {
                retour = reader.GetInt32("PrixUnitaire");
            }

            
            connection.Close();
            return retour;
        }

        public static LigneCommande insert_lignecommande (int id_produit, int quantiter)
        {
            int prix = select_prix_produit(id_produit);
            MySqlConnection connection = new MySqlConnection(info_db());

            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            connection.Open();


            command.CommandText = @"INSERT INTO lignecommande (
                Quantite, 
                PrixUnitaire, 
                IdentifiantEnteteCommande,
                IdentifiantProduit,
                ModifiedDate)
            VALUES(
                @quantiter, 
                @prix,
                1,
                @produit,
                @date)";

            command.Parameters.AddWithValue("@quantiter", quantiter);
            command.Parameters.AddWithValue("@prix", prix);
            command.Parameters.AddWithValue("@produit", id_produit);
            command.Parameters.AddWithValue("@date", new DateTime());

            int result = command.ExecuteNonQuery();

            string sql = @"SELECT * FROM lignecommande ORDER BY Identifiant";
            MySqlCommand cmd = new MySqlCommand(sql, connection);

            MySqlDataReader reader = cmd.ExecuteReader();


            // c' est pas du tout opti et moche mais je ne sais pas comment retourner les valeurs inserer

            LigneCommande retour = new LigneCommande();
            while (reader.Read())
            {
                retour = new LigneCommande(reader.GetInt32("Identifiant"),
                   reader.GetInt32("Quantite"),
                   reader.GetInt32("PrixUnitaire"),
                   reader.GetInt32("IdentifiantEnteteCommande"),
                   reader.GetInt32("IdentifiantProduit"),
                   reader.GetDateTime("ModifiedDate")
                   );
            }

            connection.Close();

            return retour;
        }

        public static produit select_produit_id (int id) {
            MySqlConnection connection = new MySqlConnection(info_db());

            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            connection.Open();

            command.CommandText = @"SELECT * FROM produit WHERE Identifiant = @id ORDER BY Identifiant";

            command.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = command.ExecuteReader();



            produit retour = new produit();
            while (reader.Read())
            {
                retour = new produit(reader.GetInt32("Identifiant"),
                    reader.GetString("Libelle"),
                    reader.GetString("Reference"),
                    reader.GetInt32("PrixUnitaire"),
                    reader.GetDateTime("ModifiedDate")
                    );

            }

            connection.Close();
            return retour;
        }

        public static List<LigneCommande> select_ligne_comande(int id)
        {
            MySqlConnection connection = new MySqlConnection(info_db());

            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            connection.Open();

            command.CommandText = @"SELECT Identifiant, Quantite FROM lignecommande WHERE IdentifiantProduit = @id ORDER BY Identifiant";

            command.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = command.ExecuteReader();

            List<LigneCommande> retour = new List<LigneCommande>();
            while (reader.Read())
            {
                LigneCommande c = new LigneCommande(reader.GetInt32("Identifiant"),
                        reader.GetInt32("Quantite"));
                retour.Add(c);
            }

            connection.Close();
            return retour;
        }
    }
}
