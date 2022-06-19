using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10.data
{
    public class Chambre
    {
        public int id { get; set; }
        public string tel { get; set; }
        public Hotel Hotel { get; set; }
        public Categorie Categorie { get; set; }

        public float prix { get; set; }
        public ICollection<Reserver> reservers { get; set; }
    }
}
