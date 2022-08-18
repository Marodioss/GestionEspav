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

namespace GestionEspav
{
    public partial class CrudEnseignant : Form
    {
        DBclass con = new DBclass();
        Enseignant enseignant = new Enseignant();
        public CrudEnseignant()
        {
            InitializeComponent();
            LoadcomboClass();
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox2.Image = Image.FromFile(opf.FileName);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            // add new enseignant
            //string nom, string prenom, string cin, int idmE, string telephone, string whatsapp, string email, byte[] img
            string nom = textBox1.Text;
            string prenom = textBox2.Text;
            string cin = textBox3.Text;
            int idmE = int.Parse(comboBox1.GetItemText(comboBox1.SelectedValue));
            string telephone = textBox4.Text;
            string whatsapp = textBox5.Text;
            string email = textBox6.Text;
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            byte[] img = ms.ToArray();

            if (enseignant.InsertEnseignant(nom, prenom, cin, idmE, telephone, whatsapp, email, img))
            {
                MessageBox.Show("Nouveau Enseignant Ajouter", "Ajouter Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Empty Field", "Ajouter Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.ResetText();
            pictureBox2.Image = null;

        }

        private void CrudEnseignant_Load(object sender, EventArgs e)
        {

        }
    }
}
