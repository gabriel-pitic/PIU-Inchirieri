using Clase;
using NivelStocareDate;
using NivelStocareDate1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InchirieriForms
{
    public partial class DialogAdaugaInchiriere : Form
    {
        public AdministrareMasiniText adminMasini;
        public Color headerColor = Color.FromArgb(254, 185, 65);
        public AdministrareRent adminRent;
        public masina CheckedMasina;
        public ErrorProvider Eroare = new ErrorProvider();
        public Color defaultColor = Color.FromArgb(224, 224, 224);
        
        

        public DialogAdaugaInchiriere()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminMasini = new AdministrareMasiniText(caleCompletaFisier);
            List<masina> masini = new List<masina>();
            masini = adminMasini.GetMasini();
            //
            string numeFisier1 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie1 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier1 = locatieFisierSolutie1 + "\\" + numeFisier1;
            adminRent = new AdministrareRent(caleCompletaFisier1);
            List<Inchiriere> rents = adminRent.GetInchirieri();
            Eroare.BlinkStyle = ErrorBlinkStyle.NeverBlink;

           
         

            InitializeComponent();

            Refresh_ListView();

            btnRefresh.Click += btnRefresh_Clicked;
            btnOk.Click += BtnOk_Click;
            listViewMasini.ItemChecked += listViewMasini_ItemChecked;
            txtCauta.TextChanged += txtCauta_TextChanged;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            //
            txtCNP.GotFocus += TxtCNP_GotFocus;
            txtCNP.LostFocus += TxtCNP_LostFocus;
            //
            txtNume.GotFocus += TxtNume_GotFocus;
            txtNume.LostFocus += TxtNume_LostFocus;
            //
            txtPrenume.GotFocus += TxtPrenume_GotFocus;
            txtPrenume.LostFocus += TxtPrenume_LostFocus;

            btnCancel.Click += BtnCancel_Click;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtPrenume_LostFocus(object sender, EventArgs e)
        {
            txtPrenume.BackColor = Color.FromArgb(224, 224, 224);

        }

        private void TxtPrenume_GotFocus(object sender, EventArgs e)
        {
            txtPrenume.BackColor = Color.White;
        }

        private void TxtNume_LostFocus(object sender, EventArgs e)
        {
            txtNume.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void TxtNume_GotFocus(object sender, EventArgs e)
        {
            txtNume.BackColor = Color.White;
        }

        private void TxtCNP_LostFocus(object sender, EventArgs e)
        {
            txtCNP.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void TxtCNP_GotFocus(object sender, EventArgs e)
        {
           txtCNP.BackColor= Color.White;
        }


        private void Change_Pret()
        {
            double pret=0;
            if (CheckedMasina != null) 
             pret = CheckedMasina.pret_zi * (dateTimePicker2.Value - dateTimePicker1.Value).TotalDays;
            if (pret > 0)
            {
                string pretText = pret.ToString("0.##");
                pretText = pretText + " lei";
                label5.Text = pretText;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            bool ok = true;
            //validare Nume

            string nume = "";
            if (string.IsNullOrEmpty(txtNume.Text))
            {
                ok = false;
                txtNume.BackColor = Color.OrangeRed;
                lblEroare.Text = "Eroare, introdu un nume";
                lblEroare.Visible = true;
                return;
            }
            else
            {
                lblEroare.Visible = false;
                nume = txtNume.Text;
                txtNume.BackColor = defaultColor;
                
            }
            //

            if (int.TryParse(txtNume.Text, out _))
            {
                ok = false;
                txtNume.BackColor = Color.OrangeRed;
                lblEroare.Text = "Eroare, introdu un nume valid";
                lblEroare.Visible = true;
                return;
            }
            else
            {
                lblEroare.Visible = false;
                nume = txtNume.Text;
                txtNume.BackColor = defaultColor;

            }
            //Validare Prenume

            string prenume = "";
            if (string.IsNullOrEmpty(txtPrenume.Text))
            {
                ok = false;
                txtPrenume.BackColor = Color.OrangeRed;
                lblEroare.Text = "Eroare, introdu un nume";
                lblEroare.Visible = true;
                return;

            }
            else
            {
                lblEroare.Visible = false;
                prenume = txtPrenume.Text;
                txtPrenume.BackColor = defaultColor;
            }
            //
            if (int.TryParse(txtPrenume.Text, out _))
            {
                ok = false;
                txtPrenume.BackColor = Color.OrangeRed;
                lblEroare.Text = "Eroare, introdu un nume valid";
                lblEroare.Visible = true;
                return;
            }
            else
            {
                lblEroare.Visible = false;
                prenume = txtPrenume.Text;
                txtPrenume.BackColor = defaultColor;

            }

            //Validare CNP
            string CNP = "";
            if (string.IsNullOrEmpty(txtCNP.Text) || txtCNP.Text.Length != 13)
            {
                ok = false; ;
                txtCNP.BackColor = Color.OrangeRed;
                lblEroare.Text="Eroare, dimensiune neadecvata";
                lblEroare.Visible= true;
                return;
            }
            else
            {
                lblEroare.Visible = false;
                CNP = txtCNP.Text;
                txtCNP.BackColor = defaultColor;

            }
            //
            if (!long.TryParse(txtCNP.Text, out long result) || result<0 )
            {
                ok = false; ;
                txtCNP.BackColor = Color.OrangeRed;
                lblEroare.Text = "Eroare, CNP invalid";
                lblEroare.Visible = true;
                return;
            }
            else
            {
                lblEroare.Visible = false;
                CNP = txtCNP.Text;
                txtCNP.BackColor = defaultColor;

            }

            //Validare date

            DateTime data_inceput = dateTimePicker1.Value;
            DateTime data_sfarsit = dateTimePicker2.Value;
            DateTime dataAzi = DateTime.Today;

            if(data_inceput<dataAzi)
            { MessageBox.Show("Data de inceput nu poate fi mai mica decat data curenta");
                ok = false;
                return;
            }

            if(data_inceput>data_sfarsit)
            {
                MessageBox.Show("Data de inceput nu poate fi mai mare decat data de sfarsit");
                ok = false;
                return;
            }
            if ((data_sfarsit - data_inceput).Days > 50)
            {
                MessageBox.Show("Nu se poate inchiria pe o perioada mai mare de 50 de zile");
                ok = false;
                return;
            }
            // Validare Pret

            double pret;
            string[] price;
            price = label5.Text.Split(' ');
            if (double.TryParse(price[0], out pret) == false ||  pret<0)
            {
                ok = false;
                return;
            }
            
           

            if(CheckedMasina==null)
            {
                ok = false;
                lblEroare.Text = "Alegeti o masina";
                lblEroare.Visible = true;
                pret = 0;
                return;
            }
            else
            {
                lblEroare.Visible = false;
                pret = (data_sfarsit - data_inceput).Days * CheckedMasina.pret_zi;
                if (pret < 0)
                {
                    ok = false;
                    return;
                }
            }
                        if (ok)
            {
                MessageBox.Show("Inchiriere Adaugata");
                Reset_Controls();
                client Client = new client(nume, prenume, CNP);
                Inchiriere rental = new Inchiriere(Client, CheckedMasina, data_inceput, data_sfarsit, pret);
                adminRent.AddInchiriere(rental);   
                adminMasini.UpdateMasina(CheckedMasina.id, false);
                CheckedMasina = null;
            }
            else
            { MessageBox.Show("Date invalide"); }    

        }

        private void Reset_Controls()
        {
            txtCNP.Text = "";
            txtNume.Text = "";
            txtPrenume.Text = "";
            dateTimePicker1.Value= DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;
            listViewSelected.Clear();

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
            {
            Change_Pret();
            }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Change_Pret(); 
        }


        private void btnRefresh_Clicked(object sender, EventArgs e)
        {
            Refresh_ListView();
        }



        private void Refresh_ListView()
        {
            listViewMasini.Clear();

            listViewMasini.View = View.Details;
            listViewMasini.FullRowSelect = true;
            listViewMasini.CheckBoxes = true;
            listViewMasini.Columns.Add("Marca", 100);
            listViewMasini.Columns.Add("Model", 100);
            listViewMasini.Columns.Add("Transmisie", 100);
            listViewMasini.Columns.Add("Alimentare", 100);
            listViewMasini.Columns.Add("Nr. locuri", 100);
            listViewMasini.Columns.Add("Pret pe zi [lei]", 100);
            listViewMasini.Columns.Add("Numar inmatriculare", 150);
            listViewMasini.Columns.Add("Culoare", 100);
            listViewMasini.Columns.Add("Optiuni", 200);
            List<masina> cars = new List<masina>();
            cars = adminMasini.GetMasini();
            foreach (masina car in cars)
            { if (car.available == true)
                    try
                    {
                        ListViewItem item = new ListViewItem(car.marca);
                        item.SubItems.Add(car.model);
                        item.SubItems.Add(car.transmisie);
                        item.SubItems.Add(car.alimentare);
                        item.SubItems.Add(car.locuri.ToString());
                        item.SubItems.Add(car.pret_zi.ToString());
                        item.SubItems.Add(car.inmat);
                        item.SubItems.Add(car.culoare.ToString());
                        item.SubItems.Add(GetSetOptionsString(car.optiuni));
                        Console.WriteLine(car.GetSelectedOptions(car.optiuni));


                        listViewMasini.Items.Add(item);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
        }

        private void txtCauta_TextChanged(object sender, EventArgs e)
        {
            listViewMasini.Clear();

            string text = txtCauta.Text.ToLower();
            List<masina> cars = new List<masina>();
            cars = adminMasini.GetMasini();

            var filteredCars = cars.Where(car => car.marca.ToLower().Contains(text) ||
                                          car.model.ToLower().Contains(text) ||
                                          car.transmisie.ToLower().Contains(text) ||
                                          car.alimentare.ToLower().Contains(text) ||
                                          car.locuri.ToString().Contains(text) ||
                                          car.pret_zi.ToString().Contains(text) ||
                                          car.inmat.ToLower().Contains(text) ||
                                          car.culoare.ToString().ToLower().Contains(text)||
                                          car.GetSelectedOptions(car.optiuni).Contains(text)).ToList();


            listViewMasini.View = View.Details;
            listViewMasini.FullRowSelect = true;
            listViewMasini.CheckBoxes = true;
            listViewMasini.Columns.Add("Marca", 100);
            listViewMasini.Columns.Add("Model", 100);
            listViewMasini.Columns.Add("Transmisie", 100);
            listViewMasini.Columns.Add("Alimentare", 100);
            listViewMasini.Columns.Add("Nr. locuri", 100);
            listViewMasini.Columns.Add("Pret pe zi [lei]", 100);
            listViewMasini.Columns.Add("Numar inmatriculare", 150);
            listViewMasini.Columns.Add("Culoare", 100);
            listViewMasini.Columns.Add("Optiuni", 200);
           
            foreach (masina car in filteredCars)
            {
                if (car.available == true)
                    try
                    {
                        ListViewItem item = new ListViewItem(car.marca);
                        item.SubItems.Add(car.model);
                        item.SubItems.Add(car.transmisie);
                        item.SubItems.Add(car.alimentare);
                        item.SubItems.Add(car.locuri.ToString());
                        item.SubItems.Add(car.pret_zi.ToString());
                        item.SubItems.Add(car.inmat);
                        item.SubItems.Add(car.culoare.ToString());
                        item.SubItems.Add(GetSetOptionsString(car.optiuni));
                        Console.WriteLine(car.GetSelectedOptions(car.optiuni));


                        listViewMasini.Items.Add(item);


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                
            }
        }

        private void listViewMasini_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked == true)
            {
                string inmat = e.Item.SubItems[6].Text;
                CheckedMasina = new masina();
                foreach(masina car in adminMasini.GetMasini())
                {
                    if (car.inmat==inmat)
                    {
                        CheckedMasina = car;

                        listViewSelected.View = View.Details;
                        ListViewItem item=new ListViewItem();
                        item.Text = CheckedMasina.Info();
                      

                        listViewSelected.Items.Clear();
                       listViewSelected.Columns.Clear();
                        
                        listViewSelected.Columns.Add("Informatii mașină", 500);
                        listViewSelected.Items.Add(item);

                        listViewSelected.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        listViewSelected.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                       
                         double pret = CheckedMasina.pret_zi * (dateTimePicker2.Value - dateTimePicker1.Value).TotalDays;

                        string pretText = pret.ToString("0.##");
                        pretText = pretText + " lei";
                        label5.Text= pretText;

                        

                        break;
                    }
                }
            }
            if (e.Item.Checked == true)
            {
                for (int i = 0; i < listViewMasini.Items.Count; i++)
                {
                    if (listViewMasini.Items[i].Checked && i != e.Item.Index)
                    {
                        listViewMasini.Items[i].Checked = false;
                    }
                    
                }
            }
        }

        private string SelectedCar()
        {
            return "";
        }

        public static string GetSetOptionsString(OptiuniMasina optiuni)
        {
            StringBuilder selectedOptionsBuilder = new StringBuilder();

            if (optiuni ==OptiuniMasina.None)
            {
                return "None";
            }

            if ((optiuni & OptiuniMasina.AerConditionat) != 0)
            {
                selectedOptionsBuilder.Append("AerConditionat,");
            }

            if ((optiuni & OptiuniMasina.Navigatie) != 0)
            {
                selectedOptionsBuilder.Append("Navigatie,");
            }

            if ((optiuni & OptiuniMasina.SenzoriParcare) != 0)
            {
                selectedOptionsBuilder.Append("SenzoriParcare,");
            }

            if ((optiuni & OptiuniMasina.CruiseControl) != 0)
            {
                selectedOptionsBuilder.Append("CruiseControl,");
            }

            if ((optiuni & OptiuniMasina.ScauneIncalzite) != 0)
            {
                selectedOptionsBuilder.Append("ScauneIncalzite,");
            }

            if (selectedOptionsBuilder.Length > 0)
            {
                // Remove the trailing comma
                selectedOptionsBuilder.Length--; // Remove the last character
            }

            return selectedOptionsBuilder.ToString();
        }
    }
}
