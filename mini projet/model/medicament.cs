using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_projet.model
{
    class medicament
    {
        public medicament(string codeMed, string nom, double prix, string lab)
        {
            CodeMed = codeMed;
            Nom = nom;
            Prix = prix;
            Lab = lab;
        }

        public String CodeMed { get; set; }
        public string Nom { get; set; }
        public double Prix{ get; set; }
        public String Lab{ get; set; }
    }
}
