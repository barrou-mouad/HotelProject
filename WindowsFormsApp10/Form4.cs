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

namespace WindowsFormsApp10
{
    public partial class Form4 : Form
    {
        public Reserver reserver;
        public Classe classe;
        public Categorie categorie;
        public bool isReserved;
        public Form4(Reserver res,Classe cl,Categorie cat ,bool isReserved )
        {
            InitializeComponent();
            reserver = res;
            classe=cl; 
            categorie=cat;
            this.isReserved = isReserved;

        }

        private void Form4_Load(object sender, EventArgs e)
        {


        
            UC.Hotel hotel = new UC.Hotel(reserver, classe, categorie, isReserved);
            hotel.Location = new Point(3, 51);
            hotel.Width = 816;
            hotel.Height = 368;
            hotel.Visible = true;
            this.Controls.Add(hotel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(null, null, null, false);
            form4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }
    }
}
