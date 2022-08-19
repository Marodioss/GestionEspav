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
    public partial class ListeEnseignant : Form
    {
        DBclass con = new DBclass();
        Enseignant enseignant = new Enseignant();
        public ListeEnseignant()
        {
            InitializeComponent();
            showTable();
        }
        private void LoadcomboClass()
        {

            MySqlDataAdapter da = new MySqlDataAdapter("SELECT idMatiere , nomMatiere FROM matiere", con.getconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nomMatiere";
            comboBox1.ValueMember = "idMatiere";
        }
        private void ListEnseignant_Load_1(object sender, EventArgs e)
        {
            showTable();
            LoadcomboClass();
        }
        public void showTable()
        {
            dataGridView1.DataSource = enseignant.getEnseignantlist(new MySqlCommand("SELECT * FROM `enseignant`"));
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[8];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        bool verify()
        {
            if ((textBox1.Text == "") || (textBox3.Text == "") ||
                (textBox2.Text == "") || (textBox4.Text == "") ||
                (pictureBox2.Image == null) || (textBox5.Text == "") || (textBox6.Text == ""))
            {
                return false;
            }
            else
                return true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.ResetText();
            pictureBox2.Image = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox7.Text);
            string nom = textBox1.Text;
            string prenom = textBox2.Text;
            string cin = textBox3.Text;
            int idmE = Convert.ToInt32(comboBox1.SelectedValue);
            string telephone = textBox4.Text;
            string whatsapp = textBox5.Text;
            string email = textBox6.Text;
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            byte[] img = ms.ToArray();
            //if (verify())
            // {
            // try
            {
                if (enseignant.updateEnseignant(id, nom, prenom, cin, idmE, telephone, whatsapp, email, img))
                {
                    showTable();
                    MessageBox.Show("Enseignant data update", "Update Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Redimentionner la photo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox2.Image = Image.FromFile(opf.FileName);


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            byte[] img = (byte[])dataGridView1.CurrentRow.Cells[8].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox2.Image = Image.FromStream(ms);


        }
    }
}
