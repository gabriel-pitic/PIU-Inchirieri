using System;
//

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
        marca = _marca;
        model = _model;
        transmisie = _transmisie;
        clasa = _clasa;
        inmat = _inmat;
        locuri = _locuri;
        pret_zi = _pret_zi;
        alimentare = _alimentare;
        id = nextID++;

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
        id = nextID++;
        Client = client;
        Masina = masina;
        DataInceput = dataInceput;
        DataSfarsit = dataSfarsit;
    }
}
