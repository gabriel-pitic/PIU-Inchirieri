using System;

namespace Clase
{
    public class masina
    {

        public string marca { get; set; }
        public string model { get; set; }   //modelul din marca
        private static int nextID = 0;
        public int id { get; }
        public string transmisie { get; set; }
        public string alimentare { get; set; } //benzina, motorina, electrica
        public int locuri { get; set; }
        public float pret_zi { get; set; }
        public string clasa { get; set; }
        public string inmat { get; set; } //numar inmatriculare

        bool busy { get; set; }
        public masina(string _marca, string _model, string _transmisie, string _clasa, string _inmat, int _locuri, float _pret_zi, string _alimentare)
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

        }

        public masina()
        {
            marca = model = transmisie = clasa = inmat = alimentare = string.Empty;

        }

        public string Info()
        {
            string info = string.Format("ID: {0}, Model: {1} {2}, Clasa {3}\n Numar de inmatriculare: {4}, Locuri: {5}, Alimentare: {6}, Transmisie: {7}\n Pret pe zi: {8}", id, marca, model, clasa, inmat, locuri, alimentare, transmisie, pret_zi);

            return info;
        }

    }

    public class client
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }

        public client(string nume, string prenume, string cNP)
        {
            Nume = nume;
            Prenume = prenume;
            CNP = cNP;
        }
    }

    public class angajat
    {
        public int id { get; }
        private static int nextID = 0;
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public angajat(string _Nume, string _Prenume, string _CNP, string _username, string _password)
        {
            Nume = _Nume;
            Prenume = _Prenume;
            CNP = _CNP;
            username = _username;
            password = _password;
            id = nextID++;
        }
    }

    public class Inchiriere
    {
        public int id { get; }
        private static int nextID = 0;
        public client Client { get; set; }
        public masina Masina { get; set; }
        public DateTime DataInceput { get; set; }
        public DateTime DataSfarsit { get; set; }

        public Inchiriere(client client, masina masina, DateTime dataInceput, DateTime dataSfarsit)
        {
            this.id = nextID++;
            this.Client = client;
            this.Masina = masina;
            this.DataInceput = dataInceput;
            this.DataSfarsit = dataSfarsit;
        }
    }
}