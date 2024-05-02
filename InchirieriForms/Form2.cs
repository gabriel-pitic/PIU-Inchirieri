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
using static Clase.masina;


namespace InchirieriForms
{
    public partial class Form2 : Form
    {
        AdministrareMasiniText adminMasini;

        private Label lblMarca;
        private TextBox txtMarca;

        private Label lblModel;
        private TextBox txtModel;

        private Label lblTransmisie;
        private TextBox txtTransmisie;

        private Label lblClasa;
        private TextBox txtClasa;

        private Label lblInmatriculare;
        private TextBox txtInmatriculare;

        private Label lblLocuri;
        private TextBox txtLocuri;

        private Label lblPretZi;
        private TextBox txtPretZi;

        private Label lblAlimentare;
        private TextBox txtAlimentare;

        private Label lblCuloare;
        private ComboBox cmbCuloare;

        private Label lblOptiuni;
        private CheckedListBox chkOptiuni;

        private Button btnAdauga;

        private Label lblId;

        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 170;

        //limite
        private const int MAXIM_TEXT = 20;
        private const int MAXIM_LOCURI = 7;
        private const int MAXIM_INMAT = 7;
     
        public Form2()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminMasini = new AdministrareMasiniText(caleCompletaFisier);
            
            List<masina> Masini = adminMasini.GetMasini();
            int nrMasini = Masini.Count;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Consolas", 12, FontStyle.Bold);
            this.ForeColor = Color.LightGray;
            this.Text = "Introducere date";


            lblMarca = new Label();
            lblMarca.Width = LATIME_CONTROL;
            lblMarca.Text = "Marca:";
            lblMarca.Left = DIMENSIUNE_PAS_X - 50;
            lblMarca.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblMarca);

            txtMarca = new TextBox();
            txtMarca.Width = LATIME_CONTROL;
            txtMarca.Left = DIMENSIUNE_PAS_X * 2 - 50;
            this.Controls.Add(txtMarca);
            //Marca
            lblModel = new Label();
            lblModel.Width = LATIME_CONTROL;
            lblModel.Text = "Model:";
            lblModel.Left = DIMENSIUNE_PAS_X - 50;
            lblModel.Top = DIMENSIUNE_PAS_Y;
            lblModel.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblModel);

            txtModel = new TextBox();
            txtModel.Width = LATIME_CONTROL;
            txtModel.Left = DIMENSIUNE_PAS_X * 2 - 50;
            txtModel.Top = DIMENSIUNE_PAS_Y;
            this.Controls.Add(txtModel);
            //Model
            lblTransmisie = new Label();
            lblTransmisie.Width = LATIME_CONTROL;
            lblTransmisie.Text = "Transmisia:";
            lblTransmisie.Left = DIMENSIUNE_PAS_X - 50;
            lblTransmisie.Top = DIMENSIUNE_PAS_Y * 2;
            lblTransmisie.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblTransmisie);

            txtTransmisie = new TextBox();
            txtTransmisie.Width = LATIME_CONTROL;
            txtTransmisie.Left = DIMENSIUNE_PAS_X * 2 - 50;
            txtTransmisie.Top = DIMENSIUNE_PAS_Y * 2;
            this.Controls.Add(txtTransmisie);
            //transmisie
            lblClasa = new Label();
            lblClasa.Width = LATIME_CONTROL;
            lblClasa.Text = "Clasa:";
            lblClasa.Left = DIMENSIUNE_PAS_X - 50;
            lblClasa.Top = DIMENSIUNE_PAS_Y * 3; 
            lblClasa.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblClasa);

            txtClasa = new TextBox();
            txtClasa.Width = LATIME_CONTROL;
            txtClasa.Left = DIMENSIUNE_PAS_X * 2 - 50;
            txtClasa.Top = DIMENSIUNE_PAS_Y * 3;
            this.Controls.Add(txtClasa);
            //clasa
            lblInmatriculare = new Label();
            lblInmatriculare.Width = LATIME_CONTROL;
            lblInmatriculare.Text = "Inmatriculare:";
            lblInmatriculare.Left = DIMENSIUNE_PAS_X - 50;
            lblInmatriculare.Top = DIMENSIUNE_PAS_Y * 4; 
            lblInmatriculare.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblInmatriculare);

            txtInmatriculare = new TextBox();
            txtInmatriculare.Width = LATIME_CONTROL;
            txtInmatriculare.Left = DIMENSIUNE_PAS_X * 2 - 50;
            txtInmatriculare.Top = DIMENSIUNE_PAS_Y * 4;
            this.Controls.Add(txtInmatriculare);
            //inmaatriculare

            lblLocuri = new Label();
            lblLocuri.Width = LATIME_CONTROL;
            lblLocuri.Text = "Locuri:";
            lblLocuri.Left = DIMENSIUNE_PAS_X - 50;
            lblLocuri.Top = DIMENSIUNE_PAS_Y * 5; 
            lblLocuri.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblLocuri);

            txtLocuri = new TextBox();
            txtLocuri.Width = LATIME_CONTROL;
            txtLocuri.Left = DIMENSIUNE_PAS_X * 2 - 50;
            txtLocuri.Top = DIMENSIUNE_PAS_Y * 5;
            this.Controls.Add(txtLocuri);
            //locuri
            lblPretZi = new Label();
            lblPretZi.Width = LATIME_CONTROL;
            lblPretZi.Text = "Pret pe zi [lei]:";
            lblPretZi.Left = DIMENSIUNE_PAS_X - 50;
            lblPretZi.Top = DIMENSIUNE_PAS_Y * 6;
            lblPretZi.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblPretZi);

            txtPretZi = new TextBox();
            txtPretZi.Width = LATIME_CONTROL;
            txtPretZi.Left = DIMENSIUNE_PAS_X * 2 - 50;
            txtPretZi.Top = DIMENSIUNE_PAS_Y * 6;
            this.Controls.Add(txtPretZi);
            //pret/zi

            lblAlimentare = new Label();
            lblAlimentare.Width = LATIME_CONTROL;
            lblAlimentare.Text = "Alimentare:";
            lblAlimentare.Left = DIMENSIUNE_PAS_X - 50;
            lblAlimentare.Top = DIMENSIUNE_PAS_Y * 7;
            lblAlimentare.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblAlimentare);

            txtAlimentare = new TextBox();
            txtAlimentare.Width = LATIME_CONTROL;
            txtAlimentare.Left = DIMENSIUNE_PAS_X * 2 - 50;
            txtAlimentare.Top = DIMENSIUNE_PAS_Y * 7;
            this.Controls.Add(txtAlimentare);
            //alimentare

            lblCuloare = new Label();
            lblCuloare.Width = LATIME_CONTROL;
            lblCuloare.Text = "Culoare:";
            lblCuloare.Left = DIMENSIUNE_PAS_X - 50;
            lblCuloare.Top = DIMENSIUNE_PAS_Y * 8; //
            lblCuloare.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblCuloare);

            cmbCuloare = new ComboBox();
            cmbCuloare.Width = LATIME_CONTROL;
            cmbCuloare.Left = DIMENSIUNE_PAS_X * 2 - 50;
            cmbCuloare.Top = DIMENSIUNE_PAS_Y * 8; // 
            this.Controls.Add(cmbCuloare);

            foreach (CuloareMasina culoare in Enum.GetValues(typeof(CuloareMasina)))
            {
                cmbCuloare.Items.Add(culoare);
            }
            //culori
            lblOptiuni = new Label();
            lblOptiuni.Width = LATIME_CONTROL;
            lblOptiuni.Text = "Optiuni:";
            lblOptiuni.Left = DIMENSIUNE_PAS_X - 50;
            lblOptiuni.Top = DIMENSIUNE_PAS_Y * 9; //
            lblOptiuni.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblOptiuni);

            chkOptiuni = new CheckedListBox();
            chkOptiuni.Width = LATIME_CONTROL;
            chkOptiuni.Left = DIMENSIUNE_PAS_X * 2 - 50;
            chkOptiuni.Top = DIMENSIUNE_PAS_Y * 9;
            chkOptiuni.Height = 150;
            this.Controls.Add(chkOptiuni);

            foreach (OptiuniMasina option in Enum.GetValues(typeof(OptiuniMasina)))
            {
                chkOptiuni.Items.Add(option);
            }
            //optiuni

            btnAdauga = new Button();
            btnAdauga.Width = LATIME_CONTROL;
            btnAdauga.Top = DIMENSIUNE_PAS_Y * 14;
            btnAdauga.Left = DIMENSIUNE_PAS_X * 2 - 50;
            btnAdauga.Text = "Adauga masina";
            btnAdauga.Height = 30;
            btnAdauga.Click += new EventHandler(Adauga_Clicked);

            btnAdauga.ForeColor = Color.DarkSeaGreen;

            this.Controls.Add(btnAdauga);

            this.FormClosed += OnFormClosed;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Adauga_Clicked(object sender, EventArgs e)
        {
            bool ok = true;
     
            string marca = txtMarca.Text;

            if (marca.Length > MAXIM_TEXT || string.IsNullOrWhiteSpace(marca))
            {
               
                txtMarca.BackColor = Color.Red;
                ok = false;
            
                
            }
            else
            {
                txtMarca.BackColor = Color.White;
            }


            string model = txtModel.Text;

            if (model.Length > MAXIM_TEXT || string.IsNullOrWhiteSpace(model))
            {
                
                txtModel.BackColor = Color.Red;
                ok = false;
         
            }
            else
            {
                txtModel.BackColor = Color.White;
            }

            string transmisie = txtTransmisie.Text;

            if (transmisie.Length > MAXIM_TEXT || string.IsNullOrWhiteSpace(transmisie))
            {
                txtTransmisie.BackColor = Color.Red;
                ok= false;
      
            }
            else
            {
                txtTransmisie.BackColor = Color.White;
            }


            string clasa = txtClasa.Text;


            if (clasa.Length > MAXIM_TEXT || string.IsNullOrWhiteSpace(model))
            {
                txtClasa.BackColor = Color.Red;
                ok = false;
              
            }
            else
            {
                txtClasa.BackColor = Color.White;
            }


            string inmatriculare = txtInmatriculare.Text;

            if (inmatriculare.Length != MAXIM_INMAT || string.IsNullOrWhiteSpace(inmatriculare))
            {
                txtInmatriculare.BackColor = Color.Red;
                ok = false;
             
            }
            else
            {
                txtInmatriculare.BackColor = Color.White;
            }

            int locuri;

            if (!int.TryParse(txtLocuri.Text, out locuri) || (locuri <= 0||locuri>MAXIM_LOCURI))
            {
                txtLocuri.BackColor = Color.Red;
                ok = false;
        
            }
            else
            {
                txtLocuri.BackColor = Color.White;
            }

            float pretZi;

            if (!float.TryParse(txtLocuri.Text, out pretZi) || (pretZi <= 0||pretZi>500))
            {
                txtPretZi.BackColor = Color.Red;
                ok = false;
           
            }
            else
            {
                txtPretZi.BackColor = Color.White;
            }

            string alimentare = txtAlimentare.Text;

            if (alimentare.Length > MAXIM_TEXT || string.IsNullOrWhiteSpace(transmisie))
            {
                txtAlimentare.BackColor = Color.Red;
                ok = false;
       
            }
            else
            {
                txtAlimentare.BackColor = Color.White;
            }
            CuloareMasina culoare = (CuloareMasina)cmbCuloare.SelectedItem;
            //
            OptiuniMasina optiuni = new OptiuniMasina();
            foreach (var item in chkOptiuni.CheckedItems)
            {
                optiuni |= (OptiuniMasina)item;
            }

            //de reimplementat sa functioneze optiunile
            if (ok)
            {
                masina newMasina = new masina(marca, model, transmisie, clasa, inmatriculare, locuri, pretZi, alimentare, (int)culoare, optiuni);
                adminMasini.AddMasina(newMasina);

                MessageBox.Show("Masina adaugata cu succes!");
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Date invalide");
            }
        }

        private void ClearInputFields()
        {
            txtMarca.Text = "";
            txtModel.Text = "";
            txtTransmisie.Text = "";
            txtClasa.Text = "";
            txtInmatriculare.Text = "";
            txtLocuri.Text = "";
            txtPretZi.Text = "";
            txtAlimentare.Text = "";
            cmbCuloare.SelectedIndex = -1; // Reseteaza combobox
            for (int i = 0; i < chkOptiuni.Items.Count; i++)
            {
                chkOptiuni.SetItemChecked(i, false); //debifeaza toate optiunile
            }
        }

        private void OnFormClosed(object sender, EventArgs e)
        {
            

        }
    }
}
