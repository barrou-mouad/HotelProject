using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10.data
{
    public class Prestation
    {
        public int id { get; set; }
        public string libelle { get; set; }

        public float prix { get; set; }

        /* public Concerne Concerne { get; set; }*/

        public ICollection<Consommation> consommations { get; set; }

        // public Hotel Hotel { get; set; }
    }
}
