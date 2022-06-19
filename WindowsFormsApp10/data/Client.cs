using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10.data
{
    public class Client
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }

        public string adresse { get; set; }
        public string cin { get; set; }
        public string code_postal { get; set; }
        public string pays { get; set; }
        public string tel { get; set; }
        public string email { get; set; }

        public ICollection<Reserver> reservers { get; set; }

        /*
                 id serial primary key,
        nom varchar(255),
        prenom varchar(255),
        code_postal varchar(255),
        pays varchar(255),
        tel varchar(255),
        email varchar(255)
         */

    }
}
