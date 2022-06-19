using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp10.data;

namespace WindowsFormsApp10
{
    public partial class Form3 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
     
        private static extern IntPtr CreateRoundRectRgn(
     int nleft,
     int nTop,
     int nRight,
     int nBottom,
     int nWidthEllipse,
     int nHeightEllipse


     );
        MyDB myDb;
        public Client client;
        public Form3(Client cl)
        {
            InitializeComponent();
            myDb = new MyDB();
            client = cl;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1  = new Form1();
            form1.Show();
            this.Hide();    
        }

        private void Form3_Load(object sender, EventArgs e)
        {
   
            // ---------------------------------------------------

                carBox1.DataSource    = myDb.Categories.ToArray();
                carBox1.DisplayMember = "description";
                carBox1.ValueMember   = "id";

            // ---------------------------------------------------

                classeBox2.DataSource    = myDb.Classes.ToArray();
                classeBox2.DisplayMember = "nb_etoiles";
                classeBox2.ValueMember   = "id";

            // ---------------------------------------------------



            //   MessageBox.Show(chambres2.First().id.ToString());


        }

        private void button4_Click(object sender, EventArgs e)
        {

            int id_cat = Int16.Parse(carBox1.SelectedValue.ToString());
            int id_classe = Int16.Parse(classeBox2.SelectedValue.ToString());
            Categorie categorie = myDb.Categories.Where(x => x.id == id_cat).First();
            Classe classe = myDb.Classes.Where(x => x.id == id_classe).First();
            Reserver rs = new Reserver();
            rs.Client = client;
            rs.date_debut = DateTime.Parse(date_debut.Text);
            myDb = null;
            rs.date_fin = DateTime.Parse(date_fin.Text);

            Form4 form4 = new Form4(rs,classe,categorie,true);
            form4.Show();
            this.Hide();
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
