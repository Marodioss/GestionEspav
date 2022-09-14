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
    public partial class demandeAcces : Form
    {
        DBclass con = new DBclass();
        DemandeAcce demandeAcce = new DemandeAcce();
        public demandeAcces()
        {
            InitializeComponent();
            showTable();
           
        }
        public void showTable()
        {
             dataGridView1.DataSource = demandeAcce.getDemandeAcceList(new MySqlCommand("SELECT * FROM `reservationsalle`"));

        }
        bool verify()
        {
            if ((textBox1.Text == "") || 
                (textBox9.Text == "") || (textBox4.Text == "") || (textBox6.Text == "") ||
                (textBox7.Text == "") || textBox8.Text == "" || textBox2.Text == "")
            {
                return false;
            }
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nom = textBox4.Text;
            String prenom = textBox1.Text;
            DateTime dateR = dateTimePicker1.Value;
            String dateH = textBox2.Text;
          //  int idMateriel = int.Parse(demandeAcce.getMaterielNP(comboBox1.Text));
          //  int nbrItem = int.Parse(textBox3.Text);
            String nomParticip = textBox7.Text;
            String chefEquipe = textBox6.Text;
            float duree = float.Parse(textBox8.Text);
            String natureTrav = textBox9.Text;
            String salle = textBox10.Text;

            //  int a = 0;
            //    a = int.Parse(textBox2.Text);
            //string retourne = radioButton1.Checked ? "Oui" : "Non";

            if (verify())
            {
                if (demandeAcce.insertDemandeAcce(nom, prenom, dateR, dateH,
                                                         nomParticip, chefEquipe, duree, natureTrav, salle))
                {
                    MessageBox.Show("Demande d'acces Ajouter", " demande d'acces Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable();
                }

                else
                {
                    MessageBox.Show("Empty Field", "Demande d'acces ajouter ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Remplir tous les champs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
           
            int id = int.Parse(textBox5.Text);
            String nom = textBox4.Text;
            String prenom = textBox1.Text;
            DateTime dateR = dateTimePicker1.Value;
            String dateH = textBox2.Text;
         //   int idMateriel = int.Parse(comboBox1.Text);
            //int id = int.Parse(textBox5.Text);
            String nomParticip = textBox7.Text;
            String chefEquipe = textBox6.Text;
            float duree = float.Parse(textBox8.Text);
            String natureTrav = textBox9.Text;
            String salle = textBox10.Text;

            
                if (demandeAcce.updateReservationSalle(id, nom, prenom, dateR, dateH,
                                                      nomParticip, chefEquipe, duree, natureTrav, salle))
                {
                    showTable();
                    MessageBox.Show("Reservation data update", "Update Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //button3.PerformClick();
                }
              
                
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
       
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            //comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            //   textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }
    }
}
