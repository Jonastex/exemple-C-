using System;
using System.Collections.Generic;
using System.Text;


namespace WinFormsTpFin
{
    class LigneCommande
    {
        private int _id;
        private int _quantier;
        private int _prixunitaire;
        private int _identetecommande;
        private int _idproduit;
        private DateTime _ModifiedDate;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Quantiter
        {
            get { return _quantier; }
            set { _quantier = value; }
        }

        public int PrixUnitaire {
            get { return _prixunitaire;}
            set { _prixunitaire = value; }
        }

        public int Identetecommande
        {
            get { return _identetecommande;}
            set { _identetecommande = value; }
        }

        public int IdProduit
        {
            get { return _idproduit;}
            set { _idproduit = value; }
        }

        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }


        public LigneCommande (int id, int quantier, int prixunitaire, int Identetecommande, int IdProduit, DateTime Date)
        {
            this.Id = id;
            this.Quantiter = quantier;
            this.PrixUnitaire = prixunitaire;
            this.Identetecommande = Identetecommande;
            this.IdProduit = IdProduit;
            this.ModifiedDate = Date;
        }
        
        public LigneCommande (int id, int quantier)
        {
            this.Id = id;
            this.Quantiter = quantier;
        }
       
        public LigneCommande () { }
    }
}
