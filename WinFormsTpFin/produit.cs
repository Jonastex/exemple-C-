using System;
using System.Collections.Generic;
using System.Text;


namespace WinFormsTpFin
{
    class produit
    {
        private int _id;
        private string _Libelle;
        private string _Reference;
        private int _PrixUnitaire;
        private DateTime _ModifiedDate;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Libelle
        {
            get { return _Libelle; }
            set { _Libelle = value; }
        }

        public string Reference {
            get { return _Reference; }
            set { _Reference = value; }
        }

        public int PrixUnitaire
        {
            get { return _PrixUnitaire; }
            set { _PrixUnitaire = value; }
        }

        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }


        public produit(int id, string libelle, string reference, int prixunitaire, DateTime Date)
        {
            this.Id = id;
            this.Libelle = libelle;
            this.Reference = reference;
            this.PrixUnitaire = prixunitaire;
            this.ModifiedDate = Date;
        }
       
       
        public produit() { }
    }
}
