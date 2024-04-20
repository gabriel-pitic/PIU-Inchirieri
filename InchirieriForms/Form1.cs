using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NivelStocareDate;
using Clase;
using System.Drawing.Text;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;

namespace InchirieriForms
{
    public partial class Form1 : Form
    {
        AdministrareMasiniText adminMasini;

        private Label lblMarca;
        private Label lblModel;
        private Label lblTransmisie;
        private Label lblClasa;
        private Label lblInmatriculare;
        private Label lblLocuri;
        private Label lblPretZi;
        private Label lblAlimentare;
        private Label lblCuloare;
        private Label lblOptiuni;
        private Label lblId;

        private Label[] lblsMarca;
        private Label[] lblsModel;
        private Label[] lblsTransmisie;
        private Label[] lblsClasa;
        private Label[] lblsInmatriculare;
        private Label[] lblsLocuri;
        private Label[] lblsPretZi;
        private Label[] lblsAlimentare;
        private Label[] lblsCuloare;
        private Label[] lblsOptiuni;
        private Label[] lblsId;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 50;
        private const int DIMENSIUNE_PAS_X = 120;


        public Form1()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie=Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminMasini = new AdministrareMasiniText(caleCompletaFisier);
            int nrMasini = 0;
            masina[] Masini = adminMasini.GetMasini(out nrMasini);

            //proprietati
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Consolas", 11, FontStyle.Bold);
            this.ForeColor = Color.LightGray;
            this.Text = "Informatii masini";

            //adaugare controale de tip Label:
            
            lblId = new Label();
            lblId.Width = LATIME_CONTROL;
            lblId.Text = "ID";
            lblId.Left = DIMENSIUNE_PAS_X;
            lblId.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblId);

            lblMarca = new Label();
            lblMarca.Width = LATIME_CONTROL;
            lblMarca.Text = "Marca";
            lblMarca.Left = DIMENSIUNE_PAS_X*2;
            lblMarca.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblMarca);

            lblModel = new Label();
            lblModel.Width = LATIME_CONTROL;
            lblModel.Text = "Model";
            lblModel.Left = DIMENSIUNE_PAS_X * 3;
            lblModel.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblModel);

            lblTransmisie = new Label();
            lblTransmisie.Width = LATIME_CONTROL;
            lblTransmisie.Text = "Transmisie";
            lblTransmisie.Left = DIMENSIUNE_PAS_X * 4;
            lblTransmisie.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblTransmisie);

            lblClasa = new Label();
            lblClasa.Width = LATIME_CONTROL;
            lblClasa.Text = "Clasa";
            lblClasa.Left = DIMENSIUNE_PAS_X * 5;
            lblClasa.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblClasa);

            lblInmatriculare = new Label();
            lblInmatriculare.Width = LATIME_CONTROL;
            lblInmatriculare.Text = "Nr. inmat";
            lblInmatriculare.Left = DIMENSIUNE_PAS_X * 6;
            lblInmatriculare.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblInmatriculare);

            lblLocuri = new Label();
            lblLocuri.Width = LATIME_CONTROL;
            lblLocuri.Text = "Nr. locuri";
            lblLocuri.Left = DIMENSIUNE_PAS_X * 7;
            lblLocuri.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblLocuri);

            lblLocuri = new Label();
            lblLocuri.Width = LATIME_CONTROL;
            lblLocuri.Text = "Nr. locuri";
            lblLocuri.Left = DIMENSIUNE_PAS_X * 7;
            lblLocuri.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblLocuri);

            lblPretZi=new Label();
            lblPretZi.Width = LATIME_CONTROL;
            lblPretZi.Text = "Pret/Zi";
            lblPretZi.Left = DIMENSIUNE_PAS_X * 8;
            lblPretZi.ForeColor = Color.DarkGreen;
            this.Controls.Add (lblPretZi);

            lblPretZi = new Label();
            lblPretZi.Width = LATIME_CONTROL;
            lblPretZi.Text = "Pret/Zi";
            lblPretZi.Left = DIMENSIUNE_PAS_X * 8;
            lblPretZi.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblPretZi);

            lblAlimentare = new Label();
            lblAlimentare.Width = LATIME_CONTROL;
            lblAlimentare.Text = "Alimentare";
            lblAlimentare.Left = DIMENSIUNE_PAS_X * 9;
            lblAlimentare.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblAlimentare);

            lblCuloare = new Label();
            lblCuloare.Width = LATIME_CONTROL;
            lblCuloare.Text = "Culoare";
            lblCuloare.Left = DIMENSIUNE_PAS_X * 10;
            lblCuloare.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblCuloare);

            lblOptiuni = new Label();
            lblOptiuni.Width = LATIME_CONTROL;
            lblOptiuni.Text = "Optiuni";
            lblOptiuni.Left = DIMENSIUNE_PAS_X * 11;
            lblOptiuni.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblOptiuni);


            //


            
            lblsMarca = new Label[nrMasini];
            lblsModel = new Label[nrMasini];
            lblsTransmisie = new Label[nrMasini];
            lblsClasa = new Label[nrMasini];
            lblsInmatriculare = new Label[nrMasini];
            lblsLocuri = new Label[nrMasini];
            lblsPretZi = new Label[nrMasini];
            lblsAlimentare = new Label[nrMasini];
            lblsCuloare = new Label[nrMasini];
            lblsOptiuni = new Label[nrMasini];
            lblsId = new Label[nrMasini];



            for (int i = 0; i < nrMasini; i++)
            {
                lblsId[i] = CreateLabel(Convert.ToString(Masini[i].id), DIMENSIUNE_PAS_X, (1 + i) * DIMENSIUNE_PAS_Y);
                lblsMarca[i] = CreateLabel(Masini[i].marca, 2 * DIMENSIUNE_PAS_X, (i + 1) * DIMENSIUNE_PAS_Y);
                lblsModel[i] = CreateLabel(Masini[i].model, 3 * DIMENSIUNE_PAS_X, (i + 1) * DIMENSIUNE_PAS_Y);
                lblsTransmisie[i] = CreateLabel(Masini[i].transmisie, 4 * DIMENSIUNE_PAS_X, (i + 1) * DIMENSIUNE_PAS_Y);
                lblsClasa[i] = CreateLabel(Masini[i].clasa, 5 * DIMENSIUNE_PAS_X, (i + 1) * DIMENSIUNE_PAS_Y);
                lblsInmatriculare[i] = CreateLabel(Masini[i].inmat, 6 * DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y * (i + 1));
                lblsLocuri[i] = CreateLabel(Convert.ToString(Masini[i].locuri), 7 * DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y * (i + 1));
                lblsPretZi[i] = CreateLabel(Convert.ToString(Masini[i].pret_zi), 8 * DIMENSIUNE_PAS_X, (i + 1) * DIMENSIUNE_PAS_Y);
                lblsAlimentare[i] = CreateLabel(Masini[i].alimentare, 9 * DIMENSIUNE_PAS_X, (i + 1) * DIMENSIUNE_PAS_Y);
                lblsCuloare[i] = CreateLabel(Convert.ToString(Masini[i].culoare), DIMENSIUNE_PAS_X * 10, DIMENSIUNE_PAS_Y * (i + 1));
                lblsOptiuni[i] = CreateLabel(Convert.ToString(Masini[i].ListOptiuni()), DIMENSIUNE_PAS_X * 11, DIMENSIUNE_PAS_Y * (i + 1));

            }


        }

        private Label CreateLabel(string labelText, int left, int top)
        {
            Label label = new Label();
            label.Width = LATIME_CONTROL;
            label.Text = labelText;
            label.TextAlign = ContentAlignment.BottomLeft;
            label.Left = left;
           label.ForeColor = Color.DarkBlue;
            label.BackColor = Color.WhiteSmoke;
            label.Top = top;
            label.Location = new Point(left, top);
            this.Controls.Add(label);
            label.Visible = true;
            return label;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaMasini();
        }

        private void AfiseazaMasini()
        {
            


        }
    }
}
