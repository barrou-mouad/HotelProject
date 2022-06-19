using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10.data
{

    public class Hotel
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string addresse { get; set; }
        public string tel { get; set; }
        public Classe Classe { get; set; }
        public ICollection<Chambre> chambres { get; set; }
        //  public ICollection<Prestation> prestations { get; set; }


    }

}
