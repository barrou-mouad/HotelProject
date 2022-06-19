using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp10.data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {   Form2 f2 = new Form2();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
               int nleft,
               int nTop,
               int nRight,
               int nBottom,
               int nWidthEllipse,
               int nHeightEllipse


               );
        public Form1()
        {
            InitializeComponent();
            button4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button4.Width, button4.Height, 30, 30));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          MyDB dB = new MyDB();
            //    MessageBox.Show(dB.Courses.First().Teacher.nom);
            /*          Course[] course = 
                          dB.Teachers
                          .Where(t => t.id == 1)
                          .Join( dB.Courses,us => us.id,
                            o => o.teacherId,
                           (o, us) => us
                          ).ToArray();*/
            //   dataGridView1.DataSource = dB.Courses.ToList();
           
        //        MessageBox.Show(         dB.Chambres.Include("reservers").Include("reservers.Client").First().reservers.First().Client.nom.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            f2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(null, null, null, false);
            form4.Show();
            this.Hide();
        }
    }
}
