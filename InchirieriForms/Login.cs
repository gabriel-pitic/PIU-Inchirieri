using Clase;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InchirieriForms
{
    public partial class Login : Form
    {   public List<angajat> users = new List<angajat>();
        public Login()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier1"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = Path.Combine(locatieFisierSolutie, numeFisier);
            
            
            try
            {
                string[] linii = File.ReadAllLines(caleCompletaFisier);
                foreach (string line in linii)
                {
                    try
                    {
                        string[] credentials = line.Split(',');
                        string username = credentials[0].Trim();
                        string password = credentials[1].Trim();

                        angajat user=new angajat(username, password);
                        users.Add(user);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtPassword.UseSystemPasswordChar = true;

            btnLogin.Click += BtnLogin_Click;

           
          this.AcceptButton = btnLogin;
            
         
        }



        private void Login_Load(object sender, EventArgs e)
        {
        
        }
        private bool ValidString(string str)
        {
            if (str == null || string.IsNullOrEmpty(str))
                return false;
            return true;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            bool ok=false;
            foreach(angajat user in users)
            {
                if (user != null && txtPassword.Text.Trim() == user.password && txtUsername.Text.Trim() == user.username)
                {
                    ok = true;
                
                }    
                    
            }
            if (ok)
            {
          Menu meniu=new Menu();
                this.Hide();
                meniu.Show();
               
                
            }
            else
            {
                MessageBox.Show("Invalid");
                ResetLabels();
            }
           
        }

        private void ResetLabels()
        {
            txtUsername.Text = String.Empty; 
            txtPassword.Text = String.Empty;
        }
    }
}
