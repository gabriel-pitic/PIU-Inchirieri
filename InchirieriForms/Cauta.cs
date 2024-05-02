using Clase;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InchirieriForms
{
    public partial class Cauta : Form
    {
        AdministrareMasiniText adminMasini;

        public Cauta()
        {
            InitializeComponent();
            btnCauta.Click += Cauta_Clicked1;

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminMasini = new AdministrareMasiniText(caleCompletaFisier);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Cauta_Clicked1(object sender, EventArgs e)
        {
            masina car=new masina();
            car = adminMasini.GetMasina(txtModel.Text, txtMarca.Text);
            if (car != null)
            {
                string info = car.ConversieLaSir_PentruFisier();
                List<string> listInfo = new List<string>();
                listInfo.Add(info);
                CautaGridView.DataSource = listInfo.Select(x => new { masina = x }).ToList();
            }
        }
    }

   
}
