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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(button4.Text))
            {
                MessageBox.Show("Le champs rechercher est vide !!!");
            }
            else
            {
                if (radioButton1.Checked) { 
                MyDB db = new MyDB();
                Reserver reserver = new Reserver();
                int id = Int16.Parse(textBox1.Text);
                
                reserver = db.Reservers.Include("Chambre").Include("Client").Where(x=>x.Chambre.id==id && (x.date_debut<=DateTime.Now) && (x.date_fin>=DateTime.Now )).FirstOrDefault();
                if (reserver != null) {
                    Form7 form = new Form7(reserver);
                    form.Show();
                }

                }
                else
                {
                    MyDB db = new MyDB();
                    Reserver reserver = new Reserver();
                    int id = Int16.Parse(textBox1.Text);
                    reserver = db.Reservers.Include("Chambre").Include("Client").
                    Where(x => x.Chambre.id == id && 
                    x.date_debut.CompareTo( date_debut.Value.Date)==0 &&
                    x.date_fin.CompareTo( date_fin.Value.Date)==0)
                    .FirstOrDefault();
                    if (reserver != null)
                    {
                        Form7 form = new Form7(reserver);
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Le chambre "+ textBox1.Text + " n'est pas resrvé ");
                    }

                }
            }
        }
        bool isTrue(DateTime t1,DateTime t2)
        {
            return (t1.CompareTo(t2) == 0);
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            panel2.Visible= false;
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
