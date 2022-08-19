using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace GestionEspav
{
    public partial class gestionMateriels : Form
    {
        DBclass con = new DBclass();
        Materiel materiel = new Materiel();
        public gestionMateriels()
        {
            InitializeComponent();
            showTable();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string nomMateriel = textBox7.Text;
            string codeMateriel = textBox4.Text;
            int nbrUnite = int.Parse(textBox1.Text);


            if (materiel.InsertMateriel(nomMateriel, codeMateriel, nbrUnite))
            {
                showTable();
                MessageBox.Show("Nouveau Materiel Ajouter", "Ajouter Materiel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Empty Field", "Ajouter Materiel", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox7.Text);
            string nomMateriel = textBox7.Text;
            string codeMateriel = textBox4.Text;
            int nbrUnite = int.Parse(textBox1.Text);


            if (materiel.updateMateriel(id, nomMateriel, codeMateriel, nbrUnite))
            {
                showTable();
                MessageBox.Show("Materiel data update", "Update Materiel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button3.PerformClick();
            }
            //}
            /*   catch (Exception ex)

               {
                   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }*/
            else
            {
                MessageBox.Show("Update Materiel Erreur ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void gestionMateriels_Load(object sender, EventArgs e)
        {
            showTable();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox7.Clear();
        }
        public void showTable()
        {
            dataGridView1.DataSource = materiel.getMaterielslist(new MySqlCommand("SELECT * FROM `materiels`"));

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }
    }
}
