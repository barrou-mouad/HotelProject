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
    public partial class Room : UserControl
    {
        public Reserver reserver;
        public Room()
        {
            InitializeComponent();
        }
        public Color EstReserver(Chambre ch)
        {
            foreach (Reserver rs in ch.reservers)
            {
                if (rs.date_debut <= DateTime.Now && rs.date_fin >= DateTime.Now)
                {
                    return Color.Red;
                }
               
            }
            return Color.Green;
        }
        public Room(Reserver rsv) : this()
        {

            reserver = rsv;
    
            if(reserver.Client != null)
            {
                num.Text = reserver.Chambre.id.ToString();
                categorie.Text = reserver.Chambre.Categorie.description;
                hotel.Text = reserver.Chambre.Hotel.nom;
                prix.Text = reserver.Chambre.prix.ToString() + " DH";
                button1.BackColor = Color.Green;
                button1.Text =  "Reserver" ;
                button1.Visible = true;
                panel2.Visible = false;
            }
            else
            {
                num.Text = reserver.Chambre.id.ToString();
                categorie.Text = reserver.Chambre.Categorie.description;
                hotel.Text = reserver.Chambre.Hotel.nom;
                prix.Text = reserver.Chambre.prix.ToString();
                button1.Visible = false;
                panel2.BackColor = EstReserver(reserver.Chambre);
                panel2.Visible = true;
               


            }

        }

        private void Room_Load(object sender, EventArgs e)
        {
            int l = reserver.Chambre.Hotel.Classe.id;
            Stars[] stars = new Stars[l];
            for (int i = 0; i < l; i++)
            {

                stars[i] = new Stars();
                flowLayoutPanel1.Controls.Add(stars[i]);

            }
        }


        private void panel1_Click(object sender, PaintEventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
          if(  MessageBox.Show("Confirmer la reservation ?","Message de confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes && reserver.Client!=null) {
    
            Reserver rs = new Reserver();
            MyDB db = new MyDB();
           
            rs.date_debut = reserver.date_debut;
            rs.date_fin = reserver.date_fin;
            rs.date_paye_arrhes = DateTime.Now;
            Chambre c = db.Chambres.Where(x=>x.id== reserver.Chambre.id).First();

            // -------------------------------------------------------------
            rs.Chambre = c;
            db.Clients.Add(reserver.Client);
            db.SaveChanges();
            rs.Client = db.Clients.OrderByDescending(x => x.id).First(); 
            db.Reservers.Add(rs);
  
            db.SaveChanges();
            MessageBox.Show("La reservation est bien passé ");
                this.Hide();
            }

        }

    }

}
