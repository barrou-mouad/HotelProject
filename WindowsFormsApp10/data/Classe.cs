using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10.data
{
    public class Classe
    {
        public int id { get; set; }

        public int nb_etoiles { get; set; }
        public ICollection<Hotel> hotels { get; set; }
    }
}
