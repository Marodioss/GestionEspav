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
    public partial class Form1 : Form
    {
        Etudiant student = new Etudiant();
        public Form1()
        {
            InitializeComponent();
            CostumeDesign();
            studentCount();
        }
        private void CostumeDesign()
        {
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel12.Visible = false;

        }
        private void hidesubmenu()
        {
            if (panel4.Visible == true)
                panel4.Visible = false;
            if (panel6.Visible == true)
                panel6.Visible = false;
            if (panel7.Visible == true)
                panel7.Visible = false;
            if (panel8.Visible == true)
                panel8.Visible = false;
            if (panel12.Visible == true)
                panel12.Visible = false;

        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void showsubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hidesubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }
        private void studentCount()
        {
            //Display the values
            label_totalStd.Text = "Total Etudiant : " + student.totalStudent();
        label2.Text = "Payement: " + student.totalPayement();
           label1.Text = "Total Professeur: " + student.totalProfesseur();
            label3.Text = "Payement: " + student.totalPayementP();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            studentCount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new CrudEtudiant());
            hidesubmenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showsubmenu(panel4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new ListEtudiant());
            hidesubmenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new Notes());
            hidesubmenu();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new PayementEtudiant());
            hidesubmenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showsubmenu(panel6);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openChildForm(new CrudEnseignant());
            hidesubmenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openChildForm(new ListeEnseignant());
            hidesubmenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new paiementEns());
            hidesubmenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new presenceEnsg());
            hidesubmenu();
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            openChildForm(new MatiereCrud());
            hidesubmenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            showsubmenu(panel7);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panel3.Controls.Add(panel5);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            openChildForm(new reservationMat());
            hidesubmenu();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            openChildForm(new demandeAcces());
            hidesubmenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            showsubmenu(panel8);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openChildForm(new gestionMateriels());
            hidesubmenu();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            showsubmenu(panel12);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            openChildForm(new PaimentImprimer());
            hidesubmenu();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            openChildForm(new imprimerPayementENs());
            hidesubmenu();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            openChildForm(new imprimersalle());
            hidesubmenu();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            openChildForm(new reservationMaterielimp());
            hidesubmenu();
        }
    }
}
