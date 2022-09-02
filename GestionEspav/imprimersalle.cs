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
    public partial class imprimersalle : Form
    {
        public imprimersalle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReservationSalle blt = new ReservationSalle();
            blt.SetParameterValue("name", textBox1.Text);
            blt.SetParameterValue("prenom", textBox2.Text);
            crystalReportViewer1.ReportSource = blt;
            crystalReportViewer1.Refresh();
        }
    }
}
