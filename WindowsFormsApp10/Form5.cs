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
    public partial class Form5 : Form
    {
        Reserver reserver = new Reserver();
        MyDB db = new MyDB();
        public Form5(Reserver res)
        {
            InitializeComponent();
            reserver = res;
     

        }

        private void Form5_Load(object sender, EventArgs e)
        {

            client.Text = reserver.Client.nom + " " + reserver.Client.prenom;
            comboBox1.DataSource = db.Prestations.ToArray();
            comboBox1.DisplayMember = "libelle" ;
            comboBox1.ValueMember = "id";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Prestation prestation = (Prestation)comboBox1.SelectedItem;
            if (prestation != null) prix.Text = prestation.prix.ToString() ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Prestation prestation = (Prestation)comboBox1.SelectedItem;
            Consommation consommation = new Consommation();
            consommation.date_consommation = DateTime.Now;
            consommation.Prestation= prestation;
            consommation.Reserver = reserver;
            String dt= DateTime.Now.ToString("HH:mm:ss");
            consommation.heure_consommation = dt;
            db.Consommations.Add(consommation);
            db.SaveChanges();
            MessageBox.Show("bien passé !");
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
    }
}
