using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionEspav
{
    public partial class reservationMaterielimp : Form
    {
        public reservationMaterielimp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReservationMat blt = new ReservationMat();
            blt.SetParameterValue("name", textBox1.Text);
            blt.SetParameterValue("prenom", textBox2.Text);
            crystalReportViewer1.ReportSource = blt;
            crystalReportViewer1.Refresh();
        }
    }
}
