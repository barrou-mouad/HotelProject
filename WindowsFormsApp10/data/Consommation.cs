using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10.data
{
    public class Consommation
    {
        public int id { get; set; }
        public DateTime date_consommation { get; set; }

        public string heure_consommation { get; set; }

        public Reserver Reserver { get; set; }

        public Prestation Prestation { get; set; }

    }
}
