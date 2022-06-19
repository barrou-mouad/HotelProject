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
    public partial class Form8 : Form
    {
        public int id { get; set; }
        public Form8(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Form8_Load(object sender, EventArgs e)
        {


            CrystalReport2 report1 = new CrystalReport2();
            DataSet ds1 = new DataSet();
            DataTable dt1 = new HotelDataSet.ReservationDataTable();
            DataTable dt2 = new HotelDataSet.ConsomDataTable();
            MyDB db = new MyDB();
            List<Reserver> students = db.Reservers.Include("Chambre").Include("Client").Include("ConsommationList").Include("ConsommationList.Prestation") .Where(x => x.id == id).ToList();
            foreach (Reserver dr in students)
            {
                foreach (Consommation n in dr.ConsommationList)
                {
                    DataRow dataRow1 = dt2.NewRow();
                    dataRow1[0] = n.Prestation.prix;
                    dataRow1[1] = n.Prestation.libelle;
                    dataRow1[2] = n.date_consommation;
                    dataRow1[3] = n.heure_consommation;

                    dt2.Rows.Add(dataRow1);
                }

                DataRow dataRow = dt1.NewRow();
                dataRow[0] = dr.Chambre.id;
                dataRow[1] = dr.date_debut;
                dataRow[2] = dr.date_fin;
                dataRow[3] = dr.Client.nom+" "+dr.Client.prenom;
                dataRow[4] = dr.Chambre.prix;
         
                dataRow[5] =(dr.date_fin-dr.date_debut).TotalDays;
         
                dt1.Rows.Add(dataRow);

            }
            ds1.Tables.Add(dt1);
            ds1.Tables.Add(dt2);
            report1.SetDataSource(ds1);
            crystalReportViewer1.ReportSource = report1;
        }
    }
}
