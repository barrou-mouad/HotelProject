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
    public partial class Form2 : Form
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
        public Form2()
        {
            InitializeComponent();
          


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {   if(string.IsNullOrEmpty(nom.Text)|| string.IsNullOrEmpty(prenom.Text)|| string.IsNullOrEmpty(cin.Text) || string.IsNullOrEmpty(pays.Text) || string.IsNullOrEmpty(tel.Text) ||string.IsNullOrEmpty(email.Text))
            {
                MessageBox.Show("Merci de remplir tout les champs " ,"Attention");
            }
            else
            {
                Client cl = new Client();
                cl.nom = nom.Text;
                cl.prenom = prenom.Text;
                cl.tel = tel.Text;
                cl.code_postal=code_postale.Text;
                cl.pays=pays.Text;
                cl.adresse=adresse.Text;
                cl.cin=cin.Text;
                cl.email=email.Text;

                Form3 form3 = new Form3(cl);
                form3.Show();
                this.Hide();
            }
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(null ,null,null,false);
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
