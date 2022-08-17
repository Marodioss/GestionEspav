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
            dataGridView1.DataSource = matiere.getMatiereList(new MySqlCommand("select m.nom , c.coff ,cl.specialiter from matiere m inner join coefficient c on (m.id = c.idmatiere) inner join class cl on (c.idclass = cl.id);"));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Nom = textBox1.Text;
            int coff = int.Parse(textBox2.Text);
            int idc = int.Parse(comboBox1.GetItemText(comboBox1.SelectedValue));
            if (matiere.InsertMatiere(Nom, idc))
            {
                int idM = int.Parse(matiere.getMatiereId(Nom));

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
        }
    }
}
