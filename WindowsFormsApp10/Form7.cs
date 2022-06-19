using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp10.data;

namespace WindowsFormsApp10
{
    public partial class Form7 : Form
    {
        Reserver res;
        public Form7(Reserver reservation)
        {
            InitializeComponent();
            res= reservation;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            cl.Text = res.Client.nom + " " + res.Client.prenom;
            ch.Text = res.Chambre.id.ToString();
            dd.Text = res.date_debut.ToString();
            df.Text = res.date_fin.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(res);
            form5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8(res.id); 
            form8.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(null, null, null, false);
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MyDB database = new MyDB();
            database.Entry(res).State = EntityState.Deleted;
            database.SaveChanges();
            MessageBox.Show("La reservation est annulée");
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }
    }
}
