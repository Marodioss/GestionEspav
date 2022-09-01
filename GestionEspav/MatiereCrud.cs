﻿using MySql.Data.MySqlClient;
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
    public partial class MatiereCrud : Form
    {
        DBclass con = new DBclass();
        Matiere matiere = new Matiere();
        Coeffi coeffi = new Coeffi();
        public MatiereCrud()
        {
            InitializeComponent();
            LoadcomboClass();
            showTable();
        }

        private void MatiereCrud_Load(object sender, EventArgs e)
        {

        }
        private void LoadcomboClass()
        {

            MySqlDataAdapter da = new MySqlDataAdapter("SELECT id , specialiter FROM class", con.getconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "specialiter";
            comboBox1.ValueMember = "id";
        }
        public void showTable()
        {
            dataGridView1.DataSource = matiere.getMatiereList(new MySqlCommand("select m.id, m.nom , c.coff ,cl.specialiter from matiere m inner join coefficient c on (m.id = c.idmatiere) inner join class cl on (c.idclass = cl.id);"));

        }
        bool verify()
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                return false;
            }
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Nom = textBox1.Text;
            if (matiere.verifieidmat(Nom))
            {
                int idM = int.Parse(matiere.getMatiereId(Nom));
                int coff = int.Parse(textBox2.Text);
                int idc = int.Parse(comboBox1.GetItemText(comboBox1.SelectedValue));
                if (coeffi.InsertCoedd(coff, idM, idc))
                {
                    showTable();
                    MessageBox.Show("Nouvelle matiers Ajouter", "Ajouter Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Empty Field", "Ajouter Enseignant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            else
            {
                if (matiere.InsertMatiere(Nom))
                {
                    int coff = int.Parse(textBox2.Text);
                    int idc = int.Parse(comboBox1.GetItemText(comboBox1.SelectedValue));
                    int idM = int.Parse(matiere.getMatiereId(Nom));
                    if (coeffi.InsertCoedd(coff, idM, idc))
                    {
                        showTable();
                        MessageBox.Show("Nouvelle matiers Ajouter", "Ajouter Matière", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Empty Field", "Ajouter Matière", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox3.Text); 
            //Show a confirmation message before delete the student
            if (MessageBox.Show("Are you sure you want to remove this student", "Remove Matière", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (matiere.deleteMatiere(id))
                {
                    showTable();
                    MessageBox.Show("Matière Removed", "Remove Matière", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); 
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }
    }
}
