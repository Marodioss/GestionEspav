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
        public Form1()
        {
            InitializeComponent();
        }
        private void CostumeDesign()
        {
            panel4.Visible = false;
            panel6.Visible = false;

        }
        private void hidesubmenu()
        {
            if (panel4.Visible == true)
                panel4.Visible = false;
            if (panel6.Visible == true)
                panel6.Visible = false;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            showsubmenu(panel4);
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
    }
}
