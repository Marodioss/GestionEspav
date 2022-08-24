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
            showTable();
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
        public void showTable()
        {
            dataGridView1.DataSource = notes.getNotesList(new MySqlCommand("SELECT m.nom,c.coff , cl.specialiter , ex.note as examen , co.note ,e.nom , e.prenom as controle from matiere m INNER JOIN coefficient c on (m.id = c.idmatiere) INNER JOIN class cl ON(c.idclass = cl.id) inner join etudiant e on (cl.id = e.idclass) inner JOIN notes ex on (ex.idmatiere = m.id and ex.idEtudiant = e.id)inner JOIN controle co on (co.idmatiere = m.id and co.idEtudiant = e.id);"));
        }

        private void Notes_Load(object sender, EventArgs e)
        {
            showTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idE = int.Parse(student.getEtudiantNP(textBox1.Text, textBox2.Text));
            int idM = int.Parse(comboBox1.GetItemText(comboBox1.SelectedValue));
            float note = float.Parse(textBox3.Text);
        
            if (notes.InsertNote(note, idM, idE))
            {
                MessageBox.Show("Note Ajouter", "Payement Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showTable();
            }
            else
            {
                MessageBox.Show("Empty Field", "Payement ajouter Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idE = int.Parse(student.getEtudiantNP(textBox1.Text, textBox2.Text));
            int idM = int.Parse(comboBox1.GetItemText(comboBox1.SelectedValue));
            float note = float.Parse(textBox3.Text);

            if (controle.InsertControle(note, idM, idE))
            {
                MessageBox.Show("Payement Ajouter", "Payement Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showTable();
            }
            else
            {
                MessageBox.Show("Empty Field", "Payement ajouter Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
