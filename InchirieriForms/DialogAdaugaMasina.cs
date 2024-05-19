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
using System.Web;
using System.Windows.Forms;

namespace InchirieriForms
{
    public partial class DialogAdaugaMasina : Form
    { Color errorColor = Color.FromArgb(242, 61, 0);
        Color defaultColor = Color.FromArgb(224, 224, 224);
        Color focusColor = Color.FromArgb(255, 255, 255);
       
        public AdministrareMasiniText adminMasini;
        public AdministrareRent adminRent;
        public DialogAdaugaMasina()
        {
            InitializeComponent();

            btnOk.Click += BtnOk_Click;
            btnCancel.Click += BtnCancel_Click;
            cbxClasa.DropDownStyle=ComboBoxStyle.DropDownList;
            cbxCuloare.DropDownStyle=ComboBoxStyle.DropDownList;

           
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminMasini = new AdministrareMasiniText(caleCompletaFisier);

            string numeFisier1 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie1 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier1 = locatieFisierSolutie1 + "\\" + numeFisier1;

            adminMasini = new AdministrareMasiniText(caleCompletaFisier);

            txtInmat.GotFocus += TxtInmat_GotFocus;
            txtInmat.LostFocus += TxtInmat_LostFocus;

            txtLocuri.GotFocus += TxtLocuri_GotFocus;
            txtLocuri.LostFocus += TxtLocuri_LostFocus;

            txtMarca.GotFocus += TxtMarca_GotFocus;
            txtMarca.LostFocus += TxtMarca_LostFocus;

            txtModel.GotFocus += TxtModel_GotFocus;
            txtModel.LostFocus += TxtModel_LostFocus;

            txtPret.GotFocus += TxtPret_GotFocus;
            txtPret.LostFocus += TxtPret_LostFocus;

            btnCancel.Click += BtnCancel_Click1;
        }

        private void BtnCancel_Click1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtPret_LostFocus(object sender, EventArgs e)
        {
            txtPret.BackColor = defaultColor;  
        }

        private void TxtPret_GotFocus(object sender, EventArgs e)
        {
           txtPret.BackColor = Color.White;
        }

        private void TxtModel_LostFocus(object sender, EventArgs e)
        {
            txtModel.BackColor = defaultColor;
        }

        private void TxtModel_GotFocus(object sender, EventArgs e)
        {
            txtModel.BackColor = Color.White;
        }

        private void TxtMarca_LostFocus(object sender, EventArgs e)
        {
            txtMarca.BackColor = defaultColor;
        }

        private void TxtMarca_GotFocus(object sender, EventArgs e)
        {
           txtMarca.BackColor= Color.White;
        }

        private void TxtLocuri_LostFocus(object sender, EventArgs e)
        {
            txtLocuri.BackColor = defaultColor;
        }

        private void TxtLocuri_GotFocus(object sender, EventArgs e)
        {
           txtLocuri.BackColor= Color.White;
        }

        private void TxtInmat_LostFocus(object sender, EventArgs e)
        {
            txtInmat.BackColor = defaultColor;
        }

        private void TxtInmat_GotFocus(object sender, EventArgs e)
        {
            txtInmat.BackColor = Color.White;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                bool ok = true;
                //validare marca
                string marca="";
                if (string.IsNullOrEmpty(txtMarca.Text))
                {
                    ok = false;
                    txtMarca.BackColor = Color.OrangeRed;
                    lblEroare.Text = "Introdu o marca";
                    lblEroare.Visible = true;
                    return;
                }
                else
                {
                    marca = txtMarca.Text;
                    txtMarca.BackColor = defaultColor;
                    lblEroare.Visible = false;
                }
                //validare model
                string model = "";
                if (string.IsNullOrEmpty(txtModel.Text))
                {
                    ok = false;
                    txtModel.BackColor = Color.OrangeRed;
                    lblEroare.Text = "Introdu un model";
                    lblEroare.Visible = true;
                    return;
                }
                else
                {
                    model = txtModel.Text;
                    txtModel.BackColor = defaultColor;
                    lblEroare.Visible = false;
                }
                //validare clasa
                string clasa= "";
                if (string.IsNullOrEmpty(cbxClasa.Text))
                {
                    ok = false;
                    cbxClasa.BackColor = Color.OrangeRed;
                    lblEroare.Text = "Alege o clasa";
                    lblEroare.Visible = true;
                    return;

                }
                else
                {
                    clasa = cbxClasa.Text;
                    cbxClasa.BackColor = defaultColor;
                    lblEroare.Visible = false;
                }
                //validare culoare
                CuloareMasina culoare = CuloareMasina.Alb;
                if (string.IsNullOrEmpty(cbxCuloare.Text))
                {
                    ok = false;
                    cbxCuloare.BackColor = Color.OrangeRed;
                    lblEroare.Text = "Alege o culoare";
                    lblEroare.Visible = true;
                    return;
                }
                else
                {
                    culoare = (CuloareMasina)cbxCuloare.SelectedIndex;
                    cbxCuloare.BackColor = defaultColor;
                    lblEroare.Visible = false;
                }
                //validare inmatriculare
                string inmatriculare = "";
                if (txtInmat.Text.Length != 7 || string.IsNullOrEmpty(txtInmat.Text))
                {
                    ok = false;
                    txtInmat.BackColor = Color.OrangeRed;
                    lblEroare.Text = "Numar inmatriculare invalid";
                    lblEroare.Visible= true;
                    return;

                }
                else
                {
                    inmatriculare = txtInmat.Text;
                    txtInmat.BackColor = defaultColor;
                    lblEroare.Visible = false;
                }
                //validare locuri
                int nrlocuri = 0;
                if(!int.TryParse(txtLocuri.Text, out nrlocuri) || nrlocuri<2 || nrlocuri>8)
                {
                    ok = false;
                    txtLocuri.BackColor = Color.OrangeRed;
                    lblEroare.Text = "Introdu un numar valid";
                    lblEroare.Visible = true;
                    return;
                }
                else
                {
                    lblEroare.Visible = false;
                    txtLocuri.BackColor= defaultColor;
                }
                //validare pret
                float pret = 0;
                if(!float.TryParse(txtPret.Text, out pret)|| pret<=0)
                {
                    ok = false;
                    txtLocuri.BackColor = errorColor;
                    lblEroare.Text = "Introdu un pret valid";
                    lblEroare.Visible = true;
                    return;
                }
                else
                {   
                    txtPret.BackColor= defaultColor;
                    lblEroare.Visible = false;
                }
                //validare transmisie
                string transmisie = "";
                if (!rdbAutomata.Checked && !rdbManuala.Checked)
                {
                    ok = false;
                    lblEroare.Text = "Alegeti o optiune";
                    lblEroare.Visible = true;
                    return;

                }
                else
                {
                    if(rdbAutomata.Checked) {
                        transmisie = rdbAutomata.Text;
                    }
                    if(rdbManuala.Checked)
                    {
                        transmisie=rdbManuala.Text;
                    }
                    lblEroare.Visible = false;
                }
                //validare alimentare
                string alimentare = "";
                if (!rdbBenzina.Checked && !rdbElectrica.Checked && !rdbMotorina.Checked)
                {
                    ok = false;
                    lblEroare.Text = "Alegeti o optiune";
                    lblEroare.Visible = true;
                    return;
                }
                else
                {
                    if (rdbElectrica.Checked)
                    {
                        alimentare = rdbElectrica.Text;
                    }
                    if (rdbMotorina.Checked)
                    {
                        alimentare = rdbMotorina.Text;
                    }
                    if (rdbBenzina.Checked)
                    {
                        alimentare = rdbBenzina.Text;
                    }
                    lblEroare.Visible=false;
                }
                //validare optiuni
                OptiuniMasina optiuni=new OptiuniMasina();
                if (cListBoxOptiuni.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Alegeti optiuni(minim 1)");
                    ok = false;
                    return;
                }
                else
                {
                    foreach (var item in cListBoxOptiuni.CheckedItems)
                    {
                        if (item.ToString().Trim() == "None") optiuni |= OptiuniMasina.None;
                        if (item.ToString().Trim() == "AerConditionat") optiuni |= OptiuniMasina.AerConditionat;
                        if (item.ToString().Trim() == "Navigatie") optiuni |= OptiuniMasina.Navigatie;
                        if (item.ToString().Trim() == "SenzoriParcare") optiuni |= OptiuniMasina.SenzoriParcare;
                        if (item.ToString().Trim() == "CruiseControl") optiuni |= OptiuniMasina.CruiseControl;
                        if (item.ToString().Trim() == "ScauneIncalzite") optiuni |= OptiuniMasina.ScauneIncalzite;
                       
                    }
                }
                //

                if(ok)
                {
                    masina newMasina = new masina(marca, model, transmisie, clasa, inmatriculare, nrlocuri, pret, alimentare, (int)culoare, optiuni);
                    adminMasini.AddMasina(newMasina);
                    newMasina.available = true;
                    MessageBox.Show("Masina adaugata");
                    Reset_Controls();
                }
                else
                {
                    MessageBox.Show("Date invalide");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
      
        private void Reset_Controls()
        {
            txtInmat.Text = "";
            txtLocuri.Text = "";
            txtMarca.Text = "";
            txtModel.Text = "";
            txtPret.Text = "";
            cbxClasa.SelectedIndex = 0;
            cbxCuloare.SelectedIndex = 0;
            rdbAutomata.Checked = false;
            rdbManuala.Checked = false;
            rdbMotorina.Checked = false;
            rdbBenzina.Checked = false;
            rdbElectrica.Checked = false;
        }
    }
}
