using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_projet.model
{
    class patient
    {
        public patient(int nss, string nom, string prenom, string sexe, string adresse, int tel, DateTime dateNaiss)
        {
            Nss = nss;
            Nom = nom;
            Prenom = prenom;
            Sexe = sexe;
            Adresse = adresse;
            Tel = tel;
            DateNaiss = dateNaiss;
        }

        public int Nss { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public string Adresse { get; set; }
        public int Tel { get; set; }
        public DateTime DateNaiss { get; set; }

    }
}
