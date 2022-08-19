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

            MySqlDataAdapter da = new MySqlDataAdapter("SELECT concat(nom,'','niveau','',idclass) as nommaate , id  FROM matiere", con.getconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nommaate";
            comboBox1.ValueMember = "id";
        }
        public void showTable()
        {
            dataGridView1.DataSource = notes.getNotesList(new MySqlCommand("select distinct(m.nom )as Matiere ,e.nom , e.prenom , c.specialiter ,  n.note as Examen ,co.note as Controle from matiere m inner join notes n on (m.id = n.idmatiere) inner join etudiant e on (n.idEtudiant = e.id) inner join class c on (e.idclass = c.id) inner join controle co on (m.id = co.idmatiere) group by m.nom;"));
        }

        private void Notes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idE = int.Parse(student.getEtudiantNP(textBox1.Text, textBox2.Text));
            int idM = int.Parse(comboBox1.GetItemText(comboBox1.SelectedValue));
            float note = float.Parse(textBox3.Text);
        
            if (notes.InsertNote(note, idM, idE))
            {
                MessageBox.Show("Payement Ajouter", "Payement Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
