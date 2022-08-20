using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            if (resevationM.insertReservationMat(nom, prenom, dateL, dateR, idMateriel, nbrItem))
            {
                MessageBox.Show("Reservation Ajouter", "L'heure Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Empty Field", "Reservation ajouter reservation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
