﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionEspav
{
    public partial class CrudEtudiant : Form
    {
        DBclass con = new DBclass();
        Etudiant student = new Etudiant();
        public CrudEtudiant()
        {
            InitializeComponent();
            LoadcomboClass();
        }
        private void LoadcomboClass()
        {

            MySqlDataAdapter da = new MySqlDataAdapter("SELECT niveau FROM class", con.getconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "niveau";
            comboBox1.ValueMember = "niveau";
        }

        private void CrudEtudiant_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(opf.FileName);
        }
        bool verify()
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") ||
                (textBox3.Text == "") || (textBox4.Text == "") ||
                (textBox5.Text == "") || (textBox6.Text == "") ||
                (pictureBox1.Image == null))
            {
                return false;
            }
            else
                return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nom = textBox1.Text;
            string prenom = textBox2.Text;
            string cin = textBox3.Text;
            DateTime datei = dateTimePicker1.Value;
            string idclass = comboBox1.GetItemText(comboBox1.SelectedItem);
            string telephone = textBox4.Text;
            string whatsapp = textBox5.Text;
            string email = textBox6.Text;
          


            if (verify())
            {
               
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();


                    if (student.insertStudent(nom, prenom, cin, datei, idclass, telephone, whatsapp, email, img))
                    {
                        MessageBox.Show("Nouveau Etudiant Ajouter", "Ajouter Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Ajouter Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
            dateTimePicker1.Value = DateTime.Now;
            pictureBox1.Image = null;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
