using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp10.data;

namespace WindowsFormsApp10.UC
{

    public partial class Hotel : UserControl
    {
        public List<Reserver> chambres = new List<Reserver>();
        public List<UC.Room> rooms = new List<UC.Room>();
        public MyDB myDB = new MyDB();
        public Hotel()
        {
            InitializeComponent();


        }
        public Hotel(Reserver rsv,Classe classe,Categorie cat,bool isReserved):this(){

            if (isReserved) { 


            List<Reserver> reserves = myDB.Reservers.Include("Chambre")
            .Include("Chambre.Categorie").Include("Chambre.Hotel")
            .Include("Chambre.Hotel.Classe").
                Where(t => 
                (((
                t.date_debut >= rsv.date_debut) && (t.date_fin <= rsv.date_fin)  ||
           (t.date_debut >= rsv.date_debut && t.date_fin >= rsv.date_fin && t.date_debut <= rsv.date_fin) ||
            (t.date_debut <= rsv.date_debut && t.date_fin <= rsv.date_fin && t.date_fin >= rsv.date_debut) ||
            (t.date_debut <= rsv.date_debut && t.date_fin >= rsv.date_fin)) &&
            (t.Chambre.Categorie.id==cat.id) && (t.Chambre.Hotel.Classe.id==classe.id)
             )).ToList();

            List<Chambre> chambres2 = myDB.Chambres.Include("Hotel").Include("reservers").Include("Hotel.Classe").Include("Categorie").Where(t => t.Hotel.Classe.id == classe.id && t.Categorie.id== cat.id).ToList();

            foreach (Reserver r in reserves)
            {
                chambres2.Remove(r.Chambre);
            }

                myDB = null;
          foreach(Chambre ch in chambres2){
                Reserver r2 = new Reserver();
                r2.Chambre= ch;
                r2.date_debut = rsv.date_debut;
                r2.date_fin = rsv.date_fin;
                r2.Client = rsv.Client;
                rooms.Add(new UC.Room(r2));
          }
            }
            else
            {
                List< Chambre>   chs = myDB.Chambres.Include("Hotel").Include("Hotel.Classe").Include("Categorie").Include("reservers"). ToList();
                myDB=null;
                foreach (Chambre r in chs)
                {
                    Reserver r2 = new Reserver();
                    r2.Chambre = r;
                    rooms.Add(new UC.Room(r2));

                }
            }
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Hotel_Load(object sender, EventArgs e)
        {
            for(int i=0;i< rooms.Count;i++) {
                flowLayoutPanel1.Controls.Add(rooms[i]);
            }
            

        }
    }
}
