using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace GestionEspav
{
    public partial class presenceEnsg : Form
    {
        DBclass con = new DBclass();
        Enseignant enseignant = new Enseignant();
        PresenceEns presenceEns = new PresenceEns();

        public presenceEnsg()
        {
            InitializeComponent();
            showTable();
        }
        bool verify()
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") ||
                (textBox4.Text == ""))
            {
                return false;
            }
            else
                return true;
        }
        public void showTable()
        {
            dataGridView1.DataSource = presenceEns.getPresenceList(new MySqlCommand("SELECT * FROM `presenceens`"));
            //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            //imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[9];
            // imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                DateTime dateP = dateTimePicker1.Value;
                int idenseignant = int.Parse(enseignant.getEnseignantNP(textBox4.Text, textBox1.Text));
                float heureT = float.Parse(textBox2.Text);

                if (presenceEns.insertPresence(dateP, idenseignant, heureT))
                {
                    MessageBox.Show("L'heure Ajouter", "L'heure Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("Empty Field", "L'heure ajouter Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Remplir tous les champs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
