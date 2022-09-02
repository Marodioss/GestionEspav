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
    public partial class imprimerPayementENs : Form
    {
        public imprimerPayementENs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            payementEns blt = new payementEns();
            blt.SetParameterValue("name", textBox1.Text);
            blt.SetParameterValue("prenom", textBox2.Text);
            blt.SetParameterValue("dateM", dateTimePicker1.Value);
            // blt.SetParameterValue("dateM", dateTimePicker1.Value);
            crystalReportViewer1.ReportSource = blt;
            crystalReportViewer1.Refresh();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
