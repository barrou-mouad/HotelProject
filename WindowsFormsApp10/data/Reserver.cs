using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10.data
{
    public class Reserver
    {
        public int id { get; set; }

        public DateTime date_debut { get; set; }

        public DateTime date_fin { get; set; }

        public DateTime date_paye_arrhes { get; set; }

        public Chambre Chambre { get; set; }

        public ICollection<Consommation> ConsommationList { get; set; }
        public Client Client { get; set; }




    }
}
