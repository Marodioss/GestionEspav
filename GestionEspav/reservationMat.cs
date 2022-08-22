using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionEspav
{
    public partial class reservationMat : Form
    {
        DBclass con = new DBclass();

        ResevationM resevationM = new ResevationM();
        public reservationMat()
        {
            InitializeComponent();
            showTable();
            LoadcomboClass();
        }
        private void LoadcomboClass()
        {

            MySqlDataAdapter da = new MySqlDataAdapter("SELECT  nomMateriel FROM materiels", con.getconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nomMateriel";
            comboBox1.ValueMember = "nomMateriel";
        }
        public void showTable()
        {
            dataGridView1.DataSource = resevationM.getReservationMatList(new MySqlCommand("SELECT * FROM `reservationmat`"));
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateL = dateTimePicker1.Value;
            DateTime dateR = dateTimePicker2.Value;
            string nom = textBox4.Text;
            string prenom = textBox1.Text;
            int idMateriel = int.Parse(resevationM.getMaterielNP(comboBox1.Text));
            int nbrItem = int.Parse(textBox3.Text);
            int a = int.Parse(textBox2.Text);
            string retourne = radioButton1.Checked ? "Oui" : "Non";
            if (nbrItem < a)
            {
                if (resevationM.insertReservationMat(nom, prenom, dateL, dateR, idMateriel, nbrItem, retourne))
                {
                    MessageBox.Show("Reservation Ajouter", " Reservation Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable();
                }

                else
                {
                    MessageBox.Show("Empty Field", "Reservation ajouter reservation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else 
                MessageBox.Show("Empty Field", "le nombre d'item reserve est supérieure a le nombre d'item dans le stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
           
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            
            textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            String r = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            if(r == "Oui")
            {
                radioButton1.Checked = true;
            }
            else 
                radioButton2.Checked = true;


        }

        private void reservationMat_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idMateriel = int.Parse(resevationM.getMaterielNP(comboBox1.Text));
           // int nbrItem = int.Parse(textBox3.Text);

            int nbrMS = int.Parse(resevationM.requpNbrMatRest(comboBox1.Text));
            int nbrMR = int.Parse(resevationM.requpNbrMatRes(idMateriel));
            int resNbrMatR = nbrMS - nbrMR;
            textBox2.Text = resNbrMatR.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dateL = dateTimePicker1.Value;
            DateTime dateR = dateTimePicker2.Value;
            string nom = textBox4.Text;
            string prenom = textBox1.Text;
            int idMateriel = int.Parse(comboBox1.Text);
            int nbrItem = int.Parse(textBox3.Text);
            int id = int.Parse(textBox5.Text);
            string retourne = radioButton1.Checked ? "Oui" : "Non";

            {
                if (resevationM.updateReservation(id, nom, prenom, dateL, dateR, idMateriel, nbrItem, retourne))
                {
                    showTable();
                    MessageBox.Show("Enseignant data update", "Update Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //button3.PerformClick();
                }
                //}
                /*   catch (Exception ex)

                   {
                       MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
               }*/
                else
                {
                    MessageBox.Show("Redimentionner la photo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
