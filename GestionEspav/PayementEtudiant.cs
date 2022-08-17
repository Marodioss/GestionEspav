using MySql.Data.MySqlClient;
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
    public partial class PayementEtudiant : Form
    {
        DBclass con = new DBclass();
        Etudiant student = new Etudiant();
        PayementETUClass payment = new PayementETUClass();
        public PayementEtudiant()
        {
            InitializeComponent();
            showTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idE = int.Parse(student.getEtudiantNP(textBox1.Text, textBox2.Text));
            DateTime moisD = dateTimePicker1.Value;
            float montant = float.Parse(textBox3.Text);
            string modep = radioButton1.Checked ? "Check" : "Cash";
            DateTime moisF = dateTimePicker2.Value;

            int v = int.Parse(payment.verify(idE, moisD));

            if (v == 0)
            {


                if (payment.insertPayement(montant, modep, moisD, moisF, idE))
                {
                    MessageBox.Show("Payement Ajouter", "Payement Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable();
                }
                else
                {
                    MessageBox.Show("Empty Field", "Payement ajouter Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
                MessageBox.Show("Mois deja payé", "Mois deja payé", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void showTable()
        {
            dataGridView1.DataSource = payment.getPayementList(new MySqlCommand("select p.* , e.nom , e.photo from payement p inner join etudiant e on (p.Etudiantid = e.id ) ORDER BY p.date"));
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[9];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
    }
}
