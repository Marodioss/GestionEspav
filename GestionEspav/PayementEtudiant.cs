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
        bool verify()
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") ||
                (textBox3.Text == ""))
            {
                return false;
            }
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            DateTime moisD = dateTimePicker1.Value;
            string modep = radioButton1.Checked ? "Check" : "Cash";
            DateTime moisF = dateTimePicker2.Value;

            if (verify())
            {
                float montant = float.Parse(textBox3.Text);
                int idE = int.Parse(student.getEtudiantNP(textBox1.Text, textBox2.Text));
                int v = int.Parse(payment.verifyM(idE, moisD));
                if (v == 0)
                {
                    try
                    {

                        if (payment.insertPayement(montant, modep, moisD, moisF, idE))
                        {
                            MessageBox.Show("Payement Ajouter", "Payement Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showTable();
                        }
                    }
                    catch (Exception ex)

                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                    MessageBox.Show("Mois deja payé", "Mois deja payé", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Remplissez les champs", "Champ vide", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
