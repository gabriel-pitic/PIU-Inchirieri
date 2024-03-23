using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Clase;
using NivelStocareDate;
using System.IO;
using System.Runtime.CompilerServices;
using System.Data.OleDb;

namespace PIU_Inchirieri_masini
{
    class Program
    {
        static void Main()
        {
            AdministrareMasini adminMasini = new AdministrareMasini();
            masina MasinaNoua = new masina();
            int NrMasini = 0;
            AdministrareClienti adminClienti = new AdministrareClienti();
            client ClientNou = new client();
            int NrClienti = 0;

            string optiune;
            Console.WriteLine("Alege entitatea: ");         //alege clasa unde facem operatiile de citire etc
            Console.WriteLine("1.Masina");
            Console.WriteLine("2.Client");
            Console.WriteLine("3.Problema 2 Laboratorul 4");
            int opt = int.Parse(Console.ReadLine());
            if (opt == 1)
                do
                {
                    Console.WriteLine("C. Citire informatii masina de la tastatura");
                    Console.WriteLine("I. Afisare informatii ultima masina");
                    Console.WriteLine("A. Afisare masini");
                    Console.WriteLine("S. Salvare masina in vector de obiecte");
                    Console.WriteLine("F. Cautare masina");
                    Console.WriteLine("X. Inchidere program");

                    Console.WriteLine("Alegti o optiune: ");
                    optiune = Console.ReadLine().ToUpper();
                    switch (optiune)
                    {
                        case "C":
                            MasinaNoua = CitireMasinaTastatura();
                            break;
                        case "I":
                            AfisareMasina(MasinaNoua);
                            break;
                        case "S":

                            adminMasini.AddMasina(MasinaNoua);
                            Console.WriteLine("Salvat");
                            break;
                        case "A":
                            masina[] masini = adminMasini.GetMasini(out NrMasini);
                            AfisareMasini(masini, NrMasini);
                            break;
                        case "F":
                            masina[] cars = adminMasini.GetMasini(out NrMasini);
                            CautareMasina(cars, NrMasini);
                            break;
                    }
                } while (optiune.ToUpper() != "X");
            else if (opt == 2)
            {
                do
                {
                    Console.WriteLine("C. Citire informatii client de la tastatura");
                    Console.WriteLine("I. Afisare informatii ultimul client");
                    Console.WriteLine("A. Afisare clienti");
                    Console.WriteLine("S. Salvare client in vector de obiecte");
                    Console.WriteLine("F. Cautare client");
                    Console.WriteLine("X. Inchidere program");

                    Console.WriteLine("Alegti o optiune: ");
                    optiune = Console.ReadLine().ToUpper();
                    switch (optiune)
                    {
                        case "C":
                            ClientNou = CitireClientTastatura();
                            break;
                        case "I": AfisareClient(ClientNou); break;
                        case "S": adminClienti.AddClient(ClientNou); Console.WriteLine("Salvat"); break;
                        case "A":
                            client[] clienti = adminClienti.GetClienti(out NrClienti);
                            AfisareClienti(clienti, NrClienti);
                            break;
                        case "F":
                            client[] clients = adminClienti.GetClienti(out NrClienti);
                            CautareClient(clients, NrClienti);
                            break;
                    }
                } while (optiune.ToUpper() != "X");
            }
            else if (opt == 3) Problema2();
        }

        public static masina CitireMasinaTastatura()
        {
            Console.WriteLine("Introduceti marca: ");
            string marca = Console.ReadLine();
            Console.WriteLine("Introduceti modelul: ");
            string model = Console.ReadLine();
            Console.WriteLine("Introduceti tipul transmisiei: ");
            string transmisie = Console.ReadLine();
            Console.WriteLine("Introduceti clasa masinii:");
            string clasa = Console.ReadLine();
            Console.WriteLine("Introduceti numarul de inmatriculare: ");
            string nrmat = Console.ReadLine();
            Console.WriteLine("Introduceti numarul de locuri: ");
            int nrlocuri = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti pretul/zi: ");
            float pret_zi = float.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti tipul de combustibil: ");
            string alimentare = Console.ReadLine();

            masina Masina = new masina(marca, model, transmisie, clasa, nrmat, nrlocuri, pret_zi, alimentare);
            return Masina;

        }

        public static void AfisareMasina(masina Masina)
        {
            Console.WriteLine(Masina.Info());
        }

        public static void AfisareMasini(masina[] masini, int nrmasini)
        {
            Console.WriteLine("Masinile sunt: ");
            for (int i = 0; i < nrmasini; i++)
            {
                string infoMasina = masini[i].Info();
                Console.WriteLine(infoMasina);
                Console.WriteLine("\n");
            }
        }

        public static void CautareMasina(masina[] cars, int nrmasini)
        {
            Console.WriteLine("Alegeti un criteriu:");
            Console.WriteLine("1. Model");
            Console.WriteLine("2. Marca");
            Console.WriteLine("3. Clasa");
            Console.WriteLine("4. Locuri");
            Console.WriteLine("5. Pret mai mare");
            Console.WriteLine("6. Pret mai mic");
            Console.WriteLine("7. Alimentare");
            Console.WriteLine("8. Transmisie");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("Introdu modelul: ");
                    string a = Console.ReadLine();
                    for (int i = 0; i < nrmasini; i++)
                    {
                        string infoMasina = cars[i].Info();
                        if (cars[i].model == a)
                            Console.WriteLine(infoMasina + "\n");
                    }
                    break;
                case 2:
                    Console.WriteLine("Introdu marca: ");
                    string b = Console.ReadLine();
                    for (int i = 0; i < nrmasini; i++)
                    {
                        string infoMasina = cars[i].Info();
                        if (cars[i].marca == b)
                            Console.WriteLine(infoMasina + "\n");
                    }
                    break;
                case 3:
                    Console.WriteLine("Introdu clasa: ");
                    string c = Console.ReadLine();
                    for (int i = 0; i < nrmasini; i++)
                    {
                        string infoMasina = cars[i].Info();
                        if (cars[i].clasa == c)
                            Console.WriteLine(infoMasina + "\n");
                    }
                    break;
                case 4:
                    Console.WriteLine("Introdu numarul de locuri: ");
                    int d = int.Parse(Console.ReadLine());
                    for (int i = 0; i < nrmasini; i++)
                    {
                        string infoMasina = cars[i].Info();
                        if (cars[i].locuri == d)
                            Console.WriteLine(infoMasina + "\n");
                    }
                    break;
                case 5:
                    Console.WriteLine("Introdu pretul: ");
                    int e = int.Parse(Console.ReadLine());
                    for (int i = 0; i < nrmasini; i++)
                    {
                        string infoMasina = cars[i].Info();
                        if (cars[i].pret_zi >= e)
                            Console.WriteLine(infoMasina + "\n");
                    }
                    break;
                case 6:
                    Console.WriteLine("Introdu pretul: ");
                    int f = int.Parse(Console.ReadLine());
                    for (int i = 0; i < nrmasini; i++)
                    {
                        string infoMasina = cars[i].Info();
                        if (cars[i].pret_zi <= f)
                            Console.WriteLine(infoMasina + "\n");
                    }
                    break;
                case 7:
                    Console.WriteLine("Introdu tipul de alimentare: ");
                    string g = Console.ReadLine();
                    for (int i = 0; i < nrmasini; i++)
                    {
                        string infoMasina = cars[i].Info();
                        if (cars[i].alimentare == g)
                            Console.WriteLine(infoMasina + "\n");
                    }
                    break;
                case 8:
                    Console.WriteLine("Introdu tipul de transmisie: ");
                    string h = Console.ReadLine();
                    for (int i = 0; i < nrmasini; i++)
                    {
                        string infoMasina = cars[i].Info();
                        if (cars[i].transmisie == h)
                            Console.WriteLine(infoMasina + "\n");
                    }
                    break;


            }
        }

        public static client CitireClientTastatura()
        {
            Console.WriteLine("Introdu numele si prenumele clientului: ");
            string name = Console.ReadLine();
            string[] nume = name.Split(' ');
            Console.WriteLine("Introdu CNP-ul clientului: ");
            string cnp = Console.ReadLine();

            client Client = new client(nume[0], nume[1], cnp);
            return Client;



        }

        public static void AfisareClient(client Client)
        {
            Console.WriteLine(Client.info());
        }

        public static void AfisareClienti(client[] Client, int nrclienti)
        {
            Console.WriteLine("Clientii sunt: ");
            for (int i = 0; i < nrclienti; i++)
            {
                string infoClient = Client[i].info();
                Console.WriteLine(infoClient);
                Console.WriteLine("\n");
            }
        }

        public static void CautareClient(client[] clienti, int nrclienti)
        {
            Console.WriteLine("Alegeti criteriul de cautare: ");
            Console.WriteLine("1.Prenume");
            Console.WriteLine("2.Nume");
            Console.WriteLine("3.CNP");
            int crt = int.Parse(Console.ReadLine());
            switch (crt)
            {
                case 2:
                    Console.WriteLine("Cauta dupa numele: ");
                    string cauta = Console.ReadLine();
                    for (int i = 0; i < nrclienti; i++)
                    {
                        string infoClient = clienti[i].info();
                        if (clienti[i].Nume == cauta)
                        {
                            Console.WriteLine(infoClient);
                            Console.WriteLine("\n");
                        }
                    }
                    break;
                case 1:
                    Console.WriteLine("Cauta dupa prenumele: ");
                    string cauta1 = Console.ReadLine();
                    for (int i = 0; i < nrclienti; i++)
                    {
                        string infoClient = clienti[i].info();
                        if (clienti[i].Prenume == cauta1)
                        {
                            Console.WriteLine(infoClient);
                            Console.WriteLine("\n");
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Cauta dupa CNP: ");
                    string cauta2 = Console.ReadLine();
                    for (int i = 0; i < nrclienti; i++)
                    {
                        string infoClient = clienti[i].info();
                        if (clienti[i].CNP == cauta2)
                        {
                            Console.WriteLine(infoClient);
                            break;
                        }
                    }
                    break;
            }
        }

        public static void Problema2()
        {
            string fisier = "file.txt";
            string[][] cuvinte = new string[26][];

            using (StreamReader streamReader = new StreamReader(fisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(linieFisier))
                    {
                        char litera = char.ToLower(linieFisier[0]);
                        if (char.IsLetter(litera))
                        {
                            int index = litera - 'a';
                            if (cuvinte[index] == null)
                            {
                                cuvinte[index] = new string[1] { linieFisier };
                            }
                            else
                            {
                                string[] tempArray = new string[cuvinte[index].Length + 1];
                                Array.Copy(cuvinte[index], tempArray, cuvinte[index].Length);
                                tempArray[cuvinte[index].Length] = linieFisier;
                                cuvinte[index] = tempArray;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 26; i++)
            {
                char litera = (char)('a' + i);
                Console.Write($"'{litera}': ");
                if (cuvinte[i] != null)
                {
                    foreach (string cuvant in cuvinte[i])
                    {
                        Console.Write($"{cuvant} ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();

        }
    }
}
