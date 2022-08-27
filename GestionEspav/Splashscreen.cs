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
    public partial class Splashscreen : Form
    {
        public Splashscreen()
        {
            InitializeComponent();
        }
        int startpoint = 0;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            

            startpoint += 1;
            guna2ProgressIndicator1.Start();
            Verification ver = new Verification();
            string fileName = @"C:\Windows32.txt";
            int dar = ver.verifyFile(fileName);
            if (dar < 15)
            {
                Login login = new Login();
                guna2ProgressIndicator1.Stop();
                timer1.Stop();
                this.Hide();
                login.Show();
            }
            else
            {
                ChofiyanCHofik CHOF =new ChofiyanCHofik();    
                CHOF.Show();
                this.Hide();
            }
                
        }

        private void Splashscreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
