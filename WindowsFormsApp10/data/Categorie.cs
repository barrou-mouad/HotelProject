using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10.data
{
    public class Categorie
    {
        public int id { get; set; }
        public string description { get; set; }

        public ICollection<Chambre> chambres { get; set; }
    }
}
