using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Clase;
using NivelStocareDate;

namespace PIU_Inchirieri_masini
{
    class Program
    {
        static void Main()
        {
            AdministrareMasini adminMasini = new AdministrareMasini();
            masina MasinaNoua = new masina();
            int NrMasini = 0;

            string optiune;
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
                        if (cars[i].alimentare==g)
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

        

    }
}
