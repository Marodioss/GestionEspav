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
    public partial class demandeAcces : Form
    {
        DBclass con = new DBclass();
        DemandeAcce demandeAcce = new DemandeAcce();
        public demandeAcces()
        {
            InitializeComponent();
            showTable();
            LoadcomboClass();
        }
        public void showTable()
        {
             dataGridView1.DataSource = demandeAcce.getDemandeAcceList(new MySqlCommand("SELECT * FROM `reservationsalle`"));

        }
        private void LoadcomboClass()
        {

            MySqlDataAdapter da = new MySqlDataAdapter("SELECT  nomMateriel FROM materiels", con.getconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nomMateriel";
            comboBox1.ValueMember = "nomMateriel";
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            String nom = textBox4.Text;
            String prenom = textBox1.Text;
            DateTime dateR = dateTimePicker1.Value;
            DateTime dateH = dateTimePicker2.Value;
            int idMateriel = int.Parse(demandeAcce.getMaterielNP(comboBox1.Text));
            int nbrItem = int.Parse(textBox3.Text);
            String nomParticip = textBox7.Text;
            String chefEquipe = textBox6.Text;
            float duree = float.Parse(textBox8.Text);
            String natureTrav = textBox9.Text;
            String salle = textBox10.Text;

            int a = 0;
            a = int.Parse(textBox2.Text);
            //string retourne = radioButton1.Checked ? "Oui" : "Non";
            if (nbrItem <= a)
            {
                if (demandeAcce.insertDemandeAcce(nom, prenom, dateR, dateH, idMateriel,
                                                     nbrItem, nomParticip, chefEquipe, duree, natureTrav, salle))
                {
                    MessageBox.Show("Demande d'acces Ajouter", " demande d'acces Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showTable();
                }

                else
                {
                    MessageBox.Show("Empty Field", "Demande d'acces ajouter ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
                MessageBox.Show("Empty Field", "le nombre d'item reserve est supérieure a le nombre d'item dans le stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idMateriel = int.Parse(demandeAcce.getMaterielNP(comboBox1.Text));
            // int nbrItem = int.Parse(textBox3.Text);

            int nbrMS = int.Parse(demandeAcce.requpNbrMatRest(comboBox1.Text));
            int nbrMR = int.Parse(demandeAcce.requpNbrMatRes(idMateriel));
            int resNbrMatR = nbrMS - nbrMR;
            textBox2.Text = resNbrMatR.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

         //comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
           
            int id = int.Parse(textBox5.Text);
            String nom = textBox4.Text;
            String prenom = textBox1.Text;
            DateTime dateR = dateTimePicker1.Value;
            DateTime dateH = dateTimePicker2.Value;
            int idMateriel = int.Parse(comboBox1.Text);
            int nbrItem = int.Parse(textBox3.Text);
            String nomParticip = textBox7.Text;
            String chefEquipe = textBox6.Text;
            float duree = float.Parse(textBox8.Text);
            String natureTrav = textBox9.Text;
            String salle = textBox10.Text;
            
                if (demandeAcce.updateReservationSalle(nom, prenom, dateR, dateH, idMateriel,
                                                     nbrItem, nomParticip, chefEquipe, duree, natureTrav, salle))
                {
                    showTable();
                    MessageBox.Show("Reservation data update", "Update Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //button3.PerformClick();
                }
              
                
            
        }
    }
}