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
    public partial class PaimentImprimer : Form
    {
        public PaimentImprimer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FichePayement blt = new FichePayement();
            blt.SetParameterValue("name", textBox1.Text);
            blt.SetParameterValue("prenom", textBox2.Text);
            blt.SetParameterValue("dateM", dateTimePicker1.Value);
            crystalReportViewer1.ReportSource = blt;
            crystalReportViewer1.Refresh();
        }
    }
}
