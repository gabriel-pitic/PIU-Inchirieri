using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace Clase
{
    public class masina
    {   


        public string marca { get; set; }
        public string model { get; set; }   //modelul din marca
        private static int nextID = 0;
        public int id { get; }
        public string transmisie { get; set; }
        public string alimentare { get; set; } //benzina, motorina, electrica, hibrid
        public int locuri { get; set; }
        public float pret_zi { get; set; }
        public string clasa { get; set; }
        public string inmat { get; set; } //numar inmatriculare
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        public bool available { get; set; }
        public CuloareMasina culoare { get; set; } 
        public OptiuniMasina optiuni {get; set; }

        public string stringCuloare { get; set; }

      
        public masina(string _marca, string _model, string _transmisie, string _clasa, string _inmat, int _locuri, float _pret_zi, string _alimentare, int cul, OptiuniMasina options)
        {
            this.marca = _marca;
            this.model = _model;
            this.transmisie = _transmisie;
            this.clasa = _clasa;
            this.inmat = _inmat;
            this.locuri = _locuri;
            this.pret_zi = _pret_zi;
            this.alimentare = _alimentare;
            this.id = nextID++;
            this.culoare = (CuloareMasina)cul;
            this.optiuni = options;
            stringCuloare = culoare.ToString();

            this.available = true;
           
           //constructor tastatura
        }
        public masina(string linieFisier)
        {
            try
            {
                string[] dateFisier = linieFisier.Split(';');

                //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
                this.id = Convert.ToInt32(dateFisier[0]);
                this.marca = dateFisier[1];
                this.model = dateFisier[2];
                this.transmisie = dateFisier[3];
                this.clasa = dateFisier[4];
                this.inmat = dateFisier[5];
                this.locuri = Convert.ToInt32(dateFisier[6]);
                this.pret_zi = float.Parse(dateFisier[7]);
                this.alimentare = dateFisier[8];
                this.culoare = (CuloareMasina)Enum.Parse(typeof(CuloareMasina), dateFisier[9]);

                this.available = bool.Parse(dateFisier[11]);
                stringCuloare = this.culoare.ToString();
                //
                string[] optiuniArray = dateFisier[10].Split(',');
                optiuni = 0;
                foreach (string optiune in optiuniArray)
                {
                    int optiuneInt = int.Parse(optiune);
                    if (optiuneInt == 0) this.optiuni |= OptiuniMasina.None;
                    if (optiuneInt == 1) this.optiuni |= OptiuniMasina.AerConditionat;
                    if (optiuneInt == 2) this.optiuni |= OptiuniMasina.Navigatie;
                    if (optiuneInt == 3) this.optiuni |= OptiuniMasina.SenzoriParcare;
                    if (optiuneInt == 4) this.optiuni |= OptiuniMasina.CruiseControl;
                    if (optiuneInt == 5) this.optiuni |= OptiuniMasina.ScauneIncalzite;
                }
                if (id >= nextID)
                {
                    nextID = id + 1;

                }
               
                
            }
            catch (Exception e)
            {
                
            }

        
        }
        public string ConversieLaSir_PentruFisier()
        {
            string optionsString = GetSelectedOptions(this.optiuni);

            string masinaString = string.Format("{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12}",
                ';',
                id.ToString(),
                (marca ?? " NECUNOSCUT "),
                (model ?? " NECUNOSCUT "),
                (transmisie ?? " NECUNOSCUT "),
                (clasa ?? " NECUNOSCUT "),
                (inmat ?? " NECUNOSCUT "),
                locuri.ToString(),
                pret_zi.ToString(),
                (alimentare ?? " NECUNOSCUT "),
                (culoare.ToString() ?? " NECUNOSCUT"),
                optionsString,
                available.ToString()
                );

            return masinaString;
        }

        public string GetSelectedOptions(OptiuniMasina optiuni)
        {
            StringBuilder selectedOptionsBuilder = new StringBuilder();
            string none= "0";
            if (optiuni == OptiuniMasina.None)
            {
                return none;
            }
            else
            {

                if ((optiuni & OptiuniMasina.AerConditionat) != 0)
                {
                    selectedOptionsBuilder.Append("1,");
                }

                if ((optiuni & OptiuniMasina.Navigatie) != 0)
                {
                    selectedOptionsBuilder.Append("2,");
                }

                if ((optiuni & OptiuniMasina.SenzoriParcare) != 0)
                {
                    selectedOptionsBuilder.Append("3,");
                }

                if ((optiuni & OptiuniMasina.CruiseControl) != 0)
                {
                    selectedOptionsBuilder.Append("4,");
                }

                if ((optiuni & OptiuniMasina.ScauneIncalzite) != 0)
                {
                    selectedOptionsBuilder.Append("5,");
                }

                if (selectedOptionsBuilder.Length > 0)
                {
                    // Remove the trailing comma
                    selectedOptionsBuilder.Length--; // Remove the last character
                }
            }
            return selectedOptionsBuilder.ToString();
        }

  
  
        public masina()
        {
            marca = model = transmisie = clasa = inmat = alimentare = string.Empty;

        }

        public string Info()
        {
            string info = string.Format("ID: {0}, Model: {1} {2}, Clasa {3}\n Numar de inmatriculare: {4}, Locuri: {5}, Alimentare: {6}, Transmisie: {7}\n Pret pe zi: {8}\n{9}", id, marca, model, clasa, inmat, locuri, alimentare, transmisie, pret_zi, culoare.ToString());

            return info;
        }

    }

    public class client
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }

        public client()
        {
            Nume = Prenume = CNP = string.Empty;
       
        }

        public client(string nume, string prenume, string cNP)
        {
            this.Nume = nume;
            this.Prenume = prenume;
            this.CNP = cNP;
        }

        public string info()
        {
            string info = string.Format("Clientul cu CNP-ul: {0} are numele: {1} {2}", CNP, Nume, Prenume);
            return info;
        }
    }

    public class angajat
    {
        public string username { get; set; }
        public string password { get; set; }

        public angajat(string _username, string _password)
        {
            username = _username;
            password = _password;
        }

        
    }

    public class Inchiriere
    {
        public int id { get; }
        private static int nextID = 0;
        public client Client { get; set; }
        public masina Masina { get; set; }
        public int CarID { get; set; }
        public DateTime DataInceput { get; set; }
        public DateTime DataSfarsit { get; set; }

        public bool active { get; set; }

        public string ClientNume => Client?.Nume ?? "NECUNOSCUT";
        public string ClientPrenume => Client?.Prenume ?? "NECUNOSCUT";

        public string CNP => Client?.CNP ?? "NECUNOSCUT";
   

        public double pret {  get; set; }
        public Inchiriere(client client, masina masina, DateTime dataInceput, DateTime dataSfarsit, double pret)
        {
            this.id = nextID++;
            this.Client = client;
            this.Masina = masina;
            this.CarID = masina.id;
            this.DataInceput = dataInceput;
            this.DataSfarsit = dataSfarsit;
            this.pret = pret;
           
           
        }

        public string ConversieLaSir_PentruFisier(Inchiriere rent)
        {
       

            string rentString = string.Format("{1};{2};{3};{4};{5};{6};{7};{8}",
            ';',
                id.ToString(),
                (this.Client.Nume ?? " NECUNOSCUT "),
            (this.Client.Prenume ?? " NECUNOSCUT "),
                (this.Client.CNP ?? " NECUNOSCUT "),
                (CarID.ToString() ?? " NECUNOSCUT "),
                (DataInceput.ToString() ?? " NECUNOSCUT "),
                DataSfarsit.ToString(),
                pret.ToString()
                );

            return rentString;
        }

        private int SetId(int id)
        {
            if (id >= nextID)
            {
                nextID = id + 1;
            }
            return id;
        }

        public Inchiriere(string linieFisier)
        {
            try
            {
                this.Client = new client();
                string[] dateFisier = linieFisier.Split(';');
                this.id = SetId(Convert.ToInt32(dateFisier[0]));
                this.Client.Nume = dateFisier[1];
                this.Client.Prenume = dateFisier[2];
                this.Client.CNP = dateFisier[3];
                this.CarID = int.Parse(dateFisier[4]);
                this.DataInceput = Convert.ToDateTime(dateFisier[5]);
                this.DataSfarsit = Convert.ToDateTime(dateFisier[6]);
                this.pret = Convert.ToDouble(dateFisier[7]);
                if (DateTime.Now > DataSfarsit)
                {
                    this.active = false;
                }
                else
                {
                    this.active = true;
                    
                }

            }
            catch(Exception e)
            {
              
            }
        }
    }
}