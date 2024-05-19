
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

namespace InchirieriForms
{
    public partial class Masini : Form
    {
        public AdministrareMasiniText adminMasini;
        public AdministrareRent adminRent;
        public Masini()
        { 
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminMasini = new AdministrareMasiniText(caleCompletaFisier);
            List<masina> Masini = new List<masina>();
            Masini = adminMasini.GetMasini();
            int nrMasini = Masini.Count;

            string numeFisier1 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie1 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier1 = locatieFisierSolutie1 + "\\" + numeFisier1;

            adminRent=new AdministrareRent(caleCompletaFisier1);
            cbxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSearch.SelectedIndex = 0;

            btnAdd.Click += BtnAdd_Click;
            btnRefresh.Click += BtnRefresh_Click;
            btnExit.Click += BtnExit_Click;
            txtCauta.TextChanged += TxtCauta_TextChanged;
            btnModify.Click += btnModify_Click;

            Init_GridView();
            Refresh_GridView(Masini);
            
        }

        private void TxtCauta_TextChanged(object sender, EventArgs e)
        {
            List<masina> cars = adminMasini.GetMasini();
            string criteria = cbxSearch.SelectedItem.ToString();

            string searchValue = txtCauta.Text.ToLower();
            List<masina> filteredCars = null;
            switch (criteria)
            {
                case "Niciun criteriu":
                    filteredCars = cars.Where(car =>
        car.model.ToLower().Contains(searchValue) ||
        car.marca.ToLower().Contains(searchValue) ||
        car.transmisie.ToLower().Contains(searchValue) ||
        car.clasa.ToLower().Contains(searchValue) ||
        car.inmat.ToLower().Contains(searchValue) ||
        car.locuri.ToString().Contains(searchValue) ||
        car.pret_zi.ToString().Contains(searchValue) ||
        car.alimentare.ToLower().Contains(searchValue) ||
        car.stringCuloare.ToLower().Contains(searchValue)
    ).ToList();
                    break;
                case "Model":
                    filteredCars = cars.Where(car => car.model.ToLower().Contains(searchValue)).ToList();
                    break;
                case "Marca":
                    filteredCars = cars.Where(car => car.marca.ToLower().Contains(searchValue)).ToList();
                    break;
                case "Transmisie":
                    filteredCars = cars.Where(car => car.transmisie.ToLower().Contains(searchValue)).ToList();
                    break;
                case "Clasa":
                    filteredCars = cars.Where(car => car.clasa.ToLower().Contains(searchValue)).ToList();
                    break;
                case "Nr. inmatriculare":
                    filteredCars = cars.Where(car => car.inmat.ToLower().Contains(searchValue)).ToList();
                    break;
                case "Locuri":
                    filteredCars = cars.Where(car => car.locuri.ToString().Contains(searchValue)).ToList();
                    break;
                case "Interval  pret":
                    if (TryParsePriceRange(searchValue, out double minPrice, out double maxPrice))
                    {
                        filteredCars = cars.Where(car => car.pret_zi >= minPrice && car.pret_zi <= maxPrice).ToList();
                    }
                    break;
                case "Alimentare":
                    filteredCars = cars.Where(car => car.alimentare.ToLower().Contains(searchValue)).ToList();
                    break;
                case "Culoare":
                    // Assuming 'culoare' is an enum property
                    filteredCars = cars.Where(car => car.stringCuloare.ToLower().Contains(searchValue)).ToList();
                    break;
                case "Disponibilitate":
                    filteredCars=cars.Where(car=>car.available==true).ToList();
                    break;
            }

            Refresh_GridView(filteredCars);


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

        private void Refresh_GridView(List<masina> masini)
        {
            dataGridMasini.DataSource = null; // Clear previous data
            dataGridMasini.Columns.Clear();
            Init_GridView();
            dataGridMasini.DataSource = masini;// Set new data source with BindingList

          

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridMasini.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridMasini.SelectedRows[0];
                    masina selectedMasina = (masina)selectedRow.DataBoundItem;
                    //Pas2 : se apeleaza noul constructor al formei FormaDestinatie
                    if (selectedMasina != null)
                    {
                        using (DialogModificaMasina frmDest = new DialogModificaMasina(selectedMasina))
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
                MessageBox.Show(ex.Message);
            }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridMasini.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow =dataGridMasini.SelectedRows[0];
                    masina selectedMasina = (masina)selectedRow.DataBoundItem;

                    if (selectedMasina != null)
                    {

                        DialogResult result = MessageBox.Show("Esti sigur ca vrei sa  stergi aceasta masina ", "Are you sure", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            List <masina> cars = adminMasini.GetMasini();
                            int selectedId = selectedMasina.id;
                            masina car=cars.FirstOrDefault(r => r.id == selectedId);
                            if (car.available == true)
                            {
                                adminMasini.DeleteMasina(selectedId);
                            }
                            else
                            {
                                MessageBox.Show("Masina este angajata  intr-o inchiriere");
                            }
                            Refresh_GridView(adminMasini.GetMasini());
                        }
                        if (result == DialogResult.No || result == DialogResult.Cancel)
                        {
                            return;
                        }

                    }
                }
                catch (Exception ed)
                {
                    MessageBox.Show(ed.Message);
                }
            }
        }



        private void Init_GridView()
        {
            // Clear existing rows and columns in the DataGridView



            // Manually add columns to the DataGridView
            dataGridMasini.AutoGenerateColumns = false;

            // Add columns with proper data bindings
            dataGridMasini.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID"
            });
            dataGridMasini.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "marca",
                HeaderText = "Marca"
            });
            dataGridMasini.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "model",
                HeaderText = "Model"
            });
            dataGridMasini.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "transmisie",
                HeaderText = "Transmisie"
            });
            dataGridMasini.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "clasa",
                HeaderText = "Clasa"
            });
            dataGridMasini.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "inmat",
                HeaderText = "Numar inmatriculare", 
                Width=200
                 
            });
            dataGridMasini.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "locuri",
                HeaderText = "Nr. locuri"
            });
            dataGridMasini.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "pret_zi",
                HeaderText = "Pret pe zi[lei]"
            });
            dataGridMasini.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "alimentare",
                HeaderText = "Alimentare"
            });
            dataGridMasini.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "stringCuloare",
                HeaderText = "Culoare"
            });
            dataGridMasini.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "available",
                HeaderText = "Available"
            });


            // Set the DataSource of the DataGridView

        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu meniu=new Menu();
            meniu.Show();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DialogAdaugaMasina dial=new DialogAdaugaMasina();
            dial.ShowDialog();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            Refresh_GridView(adminMasini.GetMasini());

        }
    }
}
