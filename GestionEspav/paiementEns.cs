using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace GestionEspav
{
    public partial class paiementEns : Form
    {
        DBclass connect = new DBclass();
        Enseignant enseignant = new Enseignant();
        PaiementEnsg paiementEnsg = new PaiementEnsg();

        public paiementEns()
        {
            InitializeComponent();
            showTable();
        }
        public void showTable()
        {
            //select p.* , e.nom , e.photo from payement p inner join etudiant e on (p.Etudiantid = e.id ) ORDER BY p.date"
            dataGridView1.DataSource = paiementEnsg.getPayementListE(new MySqlCommand("select p.* , e.nom , e.photo from payementens p inner join enseignant e on (p.idenseignant = e.id )"));
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[10];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateD = dateTimePicker1.Value;
            DateTime dateF = dateTimePicker2.Value;
            int idenseignant = int.Parse(enseignant.getEnseignantNP(textBox4.Text, textBox1.Text));
            float TotalHeure = float.Parse(paiementEnsg.requpTotalHeure(idenseignant, dateD, dateF));
            string type = radioButton1.Checked ? "oui" : "non";
            float prixHeure = float.Parse(textBox2.Text);
            float montant = int.Parse(textBox3.Text);
            float v = int.Parse(paiementEnsg.verify(idenseignant, dateD));

            if (v == 0)
            {
                if (paiementEnsg.insertPayementE(type, prixHeure, TotalHeure, montant, idenseignant, dateD, dateF))
                {
                    showTable();
                    MessageBox.Show("Paiement Ajouter", "Paiement Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else
                {
                    MessageBox.Show("Empty Field", "Paiement ajouter à L'Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
                MessageBox.Show("Mois deja payé", "Mois deja payé", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DateTime datePaiement = dateTimePicker3.Value;
            DateTime dateD = dateTimePicker1.Value;
            DateTime dateF = dateTimePicker2.Value;
            int idenseignant = int.Parse(enseignant.getEnseignantNP(textBox4.Text, textBox1.Text));
            float TotalHeure = float.Parse(paiementEnsg.requpTotalHeure(idenseignant, dateD, dateF));
            string type = radioButton1.Checked ? "Heure" : "forfait";
            float prixHeure = float.Parse(textBox2.Text);
            float montant;
            if (type == "Heure")
            {
                montant = prixHeure * TotalHeure;
                textBox3.Text = montant.ToString();
            }
            else
            {
                montant = prixHeure;
                textBox3.Text = montant.ToString();
            }

        }
    }
}
