using System;
using System.Data.SqlTypes;
using System.IO;
using System.Text;

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
        bool busy { get; set; }
        public CuloareMasina culoare { get; set; } 
        public OptiuniMasina optiuni {get; set; }

        public enum CuloareMasina       //enum #1
        {
            Rosu, Alb, Negru, Gri, Albastru, Verde, Maro
        }
        [Flags]
        public enum OptiuniMasina   //enum #2
        {    None=0b_0000_0000,
            AerConditionat= 0b_0000_0001<<1, //1
            Navigatie= 0b_0000_0010<<2,    //2
            SenzoriParcare=0b_0000_0100<<3,    //4
            CruiseControl= 0b_0000_1000<<4,    //8
            ScauneIncalzite=0b_0001_0000<<5 //16
        }
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
           //constructor tastatura
        }
        public masina(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(';');

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            this.id = Convert.ToInt32(dateFisier[0]);
            this.marca = dateFisier[1];
            this.model = dateFisier[2];
            this.transmisie= dateFisier[3];
            this.clasa= dateFisier[4];
            this.inmat = dateFisier[5];
            this.locuri = Convert.ToInt32(dateFisier[6]);
            this.pret_zi = float.Parse(dateFisier[7]);
            this.alimentare = dateFisier[8];
           this.culoare = (CuloareMasina)Enum.Parse(typeof(CuloareMasina), dateFisier[9]);
            //
            string[] optiuniArray = dateFisier[10].Split(',');
            foreach (string optiune in optiuniArray)
            {
                int optiuneInt = int.Parse(optiune);
                optiuni |= (OptiuniMasina)(1 << (optiuneInt - 1));
            }

        }
        //constructor text
        public static OptiuniMasina SelectOptions()
        {
            OptiuniMasina selectedOptions = OptiuniMasina.None;

            Console.WriteLine("Introduceti optiunile (separate de virgule)");
            Console.WriteLine("1. AerConditionat");
            Console.WriteLine("2. Navigatie");
            Console.WriteLine("3. SenzoriParcare");
            Console.WriteLine("4. CruiseControl");
            Console.WriteLine("5. ScauneIncalzite");

            string[] selectedOptionsStrings = Console.ReadLine().Split(',');

            foreach (string option in selectedOptionsStrings)
            {
                if (int.TryParse(option.Trim(), out int optionNumber))
                {
                    switch (optionNumber)
                    {
                        case 1:
                            selectedOptions |= OptiuniMasina.AerConditionat;

                            break;
                        case 2:
                            selectedOptions |= OptiuniMasina.Navigatie;
                            break;
                        case 3:
                            selectedOptions |= OptiuniMasina.SenzoriParcare;
                            break;
                        case 4:
                            selectedOptions |= OptiuniMasina.CruiseControl;
                            break;
                        case 5:
                            selectedOptions |= OptiuniMasina.ScauneIncalzite;
                            break;
                        default:
                            Console.WriteLine("Numar optiune invalid.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Optiune invalida.");
                }
            }


            return selectedOptions;
        }


        //
        public string ListOptiuni()
        {
            StringBuilder outputBuilder = new StringBuilder();
            short i = 1;

            foreach (OptiuniMasina option in Enum.GetValues(typeof(OptiuniMasina)))
            {
                if (optiuni.HasFlag(option))
                {
                    outputBuilder.AppendLine($"{i} {option}");
                    i++;
                }
            }

            return outputBuilder.ToString();
        }
        public void ListOptiuniText(StreamWriter stream)
        {
            short i = 1;
            Console.WriteLine("Optiunile sunt:");
            foreach (OptiuniMasina option in Enum.GetValues(typeof(OptiuniMasina)))
            {
                if (optiuni.HasFlag(option))
                {
                    stream.WriteLine(i + " " + option);
                    i++;
                }

            }
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