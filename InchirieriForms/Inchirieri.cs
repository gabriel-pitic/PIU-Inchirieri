using Clase;
using NivelStocareDate;
using NivelStocareDate1;
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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InchirieriForms
{
    public partial class Inchirieri : Form
    {
        Font roboto = new Font("Roboto", 10);
        AdministrareRent adminRent;
        AdministrareMasiniText adminMasini;
        public Inchirieri()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            dataGridInchirieri.Font= roboto;

            adminRent = new AdministrareRent(caleCompletaFisier);
            List<Inchiriere> rents = adminRent.GetInchirieri();

            string numeFisier1 = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie1 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier1 = locatieFisierSolutie1 + "\\" + numeFisier1;
            adminMasini=new AdministrareMasiniText(caleCompletaFisier1);

            btnAdd.Click += BtnAdd_Click;
            btnExit.Click += BtnExit_Clicked;
            btnRefresh.Click += BtnRefresh_Click;
            Refresh_Inchirieri(rents);
            btnDelete.Click += BtnDelete_Click;
            txtCauta.TextChanged += TxtCauta_TextChanged;
            cbxSearch.DropDownStyle= ComboBoxStyle.DropDownList;
            cbxSearch.SelectedIndex = 0;

            btnModify.Click += btnModify_Click;

            Init_GridView();
            Refresh_Inchirieri(rents);

        }

        private bool TryParseDateRange(string input, out DateTime startDate, out DateTime endDate)
        {
            startDate = DateTime.MinValue;
            endDate = DateTime.MinValue;

            string[] dates = input.Split(':');
            if (dates.Length != 2)
            {
                return false;
            }

            bool startParsed = DateTime.TryParseExact(dates[0], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out startDate);
            bool endParsed = DateTime.TryParseExact(dates[1], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out endDate);

            return startParsed && endParsed;
        }

        private void TxtCauta_TextChanged(object sender, EventArgs e)
        {
            List<Inchiriere> rents = adminRent.GetInchirieri();
            string criteria = cbxSearch.SelectedItem.ToString();

            string searchValue = txtCauta.Text.ToLower();
            List<Inchiriere> filteredRents=null;
            switch (criteria)
            {
                case "Niciun criteriu":
                    filteredRents = rents.Where(rent =>
                     rent.ConversieLaSir_PentruFisier(rent).ToLower().Contains(searchValue)
                     ).ToList();
                    
                    break;
                case "Nume":
                    filteredRents = rents.Where(rent => rent.Client.Nume.ToLower().Contains(searchValue)).ToList();
                    break;
                case "Prenume":
                    filteredRents = rents.Where(rent => rent.Client.Prenume.ToLower().Contains(searchValue)).ToList();
                    break;
                case "ID Masina":
                    filteredRents = rents.Where(rent => rent.CarID.ToString().Contains(searchValue)).ToList();
                    break;
                case "DataInceput:DataSfarsit":
                    if (TryParseDateRange(searchValue, out DateTime startDate, out DateTime endDate))
                    {
                        filteredRents = rents.Where(rent =>
                            rent.DataInceput >= startDate && rent.DataInceput <= endDate ||
                            rent.DataSfarsit >= startDate && rent.DataSfarsit <= endDate
                        ).ToList();
                    }
                    break;
                case "Interval pret":
                    if (TryParsePriceRange(searchValue, out double minPrice, out double maxPrice))
                    {
                        filteredRents = rents.Where(rent => rent.pret >= minPrice && rent.pret <= maxPrice).ToList();
                    }

                    break;
                case "CNP":
                    filteredRents = rents.Where(rent => rent.Client.CNP.ToLower().Contains(searchValue)).ToList();
                    break;

            }

            Refresh_Inchirieri(filteredRents);


        }

        private bool TryParsePriceRange(string input, out double minPrice, out double maxPrice)
        {
            minPrice = double.MinValue;
            maxPrice = double.MaxValue;

            string[] prices = input.Split(':');
            if (prices.Length != 2)
            {
                return false;
            }

            bool minParsed = double.TryParse(prices[0], out minPrice);
            bool maxParsed = double.TryParse(prices[1], out maxPrice);

            return minParsed && maxParsed;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridInchirieri.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridInchirieri.SelectedRows[0];
                    Inchiriere selectedInchiriere = (Inchiriere)selectedRow.DataBoundItem;
                    //Pas2 : se apeleaza noul constructor al formei FormaDestinatie
                    if (selectedInchiriere != null)
                    {
                        using (DialogModificaInchiriere frmDest = new DialogModificaInchiriere(selectedInchiriere))
                        {
                            var dr = frmDest.ShowDialog(this);
                            frmDest.Close();
                        }
                    }
                }
            }
            catch
            {
                Exception ex = new Exception();
            }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridInchirieri.SelectedRows.Count>0)
            {   
                try
                {
                    DataGridViewRow selectedRow = dataGridInchirieri.SelectedRows[0];
                    Inchiriere selectedInchiriere = (Inchiriere)selectedRow.DataBoundItem;

                    if(selectedInchiriere != null)
                    {

                        DialogResult result = MessageBox.Show("Esti sigur ca vrei sa  stergi aceasta inchiriere ", "Are you sure" , MessageBoxButtons.YesNoCancel) ;
                        if (result == DialogResult.Yes)
                        {

                            int selectedId = selectedInchiriere.id;
                            adminRent.DeleteInchiriere(selectedId);
                            adminMasini.UpdateMasina(selectedInchiriere.CarID, true);
                            dataGridInchirieri.DataSource = adminRent.GetInchirieri();
                        }
                        if(result== DialogResult.No || result==DialogResult.Cancel) {
                            return;
                        }
                        
                    }
                }
                catch(Exception ed)
                {
                    MessageBox.Show(ed.Message);
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
          
            foreach(Inchiriere rent in adminRent.GetInchirieri())
            {
                if(rent.active==false)
                {
                    adminMasini.UpdateMasina(rent.CarID, true);
                }
                if(rent.active==true)
                {
                    adminMasini.UpdateMasina(rent.CarID, false);
                }
            }
            Refresh_Inchirieri(adminRent.GetInchirieri());

        }

        private void Refresh_Inchirieri(List<Inchiriere> rents)
        {
            dataGridInchirieri.DataSource = null; // Clear previous data
            dataGridInchirieri.Columns.Clear();
            Init_GridView();
            dataGridInchirieri.DataSource = rents;// Set new data source with BindingList
            
        }


        private void Init_GridView()
        {
            // Clear existing rows and columns in the DataGridView
   
          

            // Manually add columns to the DataGridView
            dataGridInchirieri.AutoGenerateColumns = false;

            // Add columns with proper data bindings
            dataGridInchirieri.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID"
            });
            dataGridInchirieri.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ClientNume",
                HeaderText = "Nume"
            });
            dataGridInchirieri.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ClientPrenume",
                HeaderText = "Prenume"
            });
            dataGridInchirieri.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CNP",
                HeaderText = "CNP"
            });
            dataGridInchirieri.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CarID",
                HeaderText = "ID Masina"
            });
            dataGridInchirieri.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataInceput",
                HeaderText = "Start Date"
            });
            dataGridInchirieri.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataSfarsit",
                HeaderText = "End Date"
            });
            dataGridInchirieri.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Pret",
                HeaderText = "Price"
            });
            dataGridInchirieri.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "active",
                HeaderText = "Active"
            });

            // Set the DataSource of the DataGridView
            
        }

        private void Inchirieri_LoadForm(object sender, EventArgs e)
        {
          
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DialogAdaugaInchiriere dial=new DialogAdaugaInchiriere();
            dial.Show();
        }

        private void btnRefresh_Clicked(object sender, EventArgs e)
        {
            
        }
        private void dgvMasini_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
            
        }

        
      

        private void BtnExit_Clicked(object sender, EventArgs e)
        {
            this.Hide();
            Menu me= new Menu();
            me.Show();
        }

        
    }
}
