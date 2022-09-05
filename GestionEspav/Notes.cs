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
    public partial class Notes : Form
    {
        Etudiant student = new Etudiant();
        NotesClass notes = new NotesClass();
        DBclass con = new DBclass();
        Controle controle = new Controle(); 
        public Notes()
        {
            InitializeComponent();
            LoadcomboNote();
            showTableC();
            showTableE();
        }
        bool verify()
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") ||
                (textBox3.Text == "") 
               
                )
            {
                return false;
            }
            else
                return true;
        }
        private void LoadcomboNote()
        {

            MySqlDataAdapter da = new MySqlDataAdapter("SELECT nom , id  FROM matiere", con.getconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nom";
            comboBox1.ValueMember = "id";
        }
        public void showTableC()
        {
            dataGridView1.DataSource = notes.getNotesList(new MySqlCommand("SELECT m.nom , e.nom , e.prenom,c.note FROM controle c inner join etudiant e on (c.idEtudiant = e.id) inner join matiere m on (c.idMatiere = m.id); "));
        }
        public void showTableE()
        {
            dataGridView2.DataSource = notes.getNotesList(new MySqlCommand("SELECT m.nom , e.nom , e.prenom,c.note FROM notes c inner join etudiant e on (c.idEtudiant = e.id) inner join matiere m on (c.idMatiere = m.id); "));
        }

        private void Notes_Load(object sender, EventArgs e)
        {
            showTableC();
            showTableE();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idE = int.Parse(student.getEtudiantNP(textBox1.Text, textBox2.Text));
            int idM = int.Parse(comboBox1.GetItemText(comboBox1.SelectedValue));
            float note = float.Parse(textBox3.Text);
            if (verify())
            {
                if (notes.InsertNote(note, idM, idE))
                {
                    MessageBox.Show("Note Ajouter", "Note Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTableE();
                }
                else
                {
                    MessageBox.Show("Empty Field", "Note ajouter Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Remplir tous les champs ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idE = int.Parse(student.getEtudiantNP(textBox1.Text, textBox2.Text));
            int idM = int.Parse(comboBox1.GetItemText(comboBox1.SelectedValue));
            int Cid = int.Parse(comboBox2.GetItemText(comboBox2.SelectedValue));
            float note = float.Parse(textBox3.Text);
            if (verify())
            {
                if (controle.InsertControle(note, idM, idE,Cid))
                {
                    MessageBox.Show("Note Ajouter", "Note Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTableC();
                }
                else
                {
                    MessageBox.Show("Empty Field", "Note ajouter Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Remplir tous les champs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
