using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InchirieriForms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            btnAdmin.Click += BtnAdmin_Clicked;
            btnInchirieri.Click += BtnInchirieri_Clicked;
        }
        private void Menu_Load(object sender, EventArgs e)
        {
        
        }

        private void BtnInchirieri_Clicked(object sender, EventArgs e)
        {
            this.Hide();
            Inchirieri rent = new Inchirieri();
            rent.Show();
        }
        private void BtnAdmin_Clicked(object sender, EventArgs e)
        {
            this.Hide();
            Masini masini = new Masini();
            masini.Show(); 
        }
    }

   
}
