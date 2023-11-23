using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_projet.model
{
    class Consultation
    {
        public Consultation(int numCons, int nss, DateTime dateCons)
        {
            NumCons = numCons;
            this.nss = nss;
            DateCons = dateCons;
        }

        public int NumCons { get; set; }
        public int nss{ get; set; }
        public DateTime DateCons { get; set; }
    }
}
