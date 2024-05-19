using Clase;
using NivelStocareDate1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AdministrareMasiniText
    {   
        private const int NR_MAX_MASINI = 50;
        private string numeFisier;
        public event EventHandler MasinaAdded;

        public AdministrareMasiniText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddMasina(masina Masina)
        {
            using (StreamWriter streamWriterFisierText=new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(Masina.ConversieLaSir_PentruFisier());
 
            }
            MasinaAdded?.Invoke(this, EventArgs.Empty);

        }



        public List<masina> GetMasini()
        {
            List <masina> Masini=new List<masina>();
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                  
                    Masini.Add(new masina(linieFisier));
                

                }
            }
           
            return Masini;
        }
         
 
        public masina GetMasina(string model, string marca)
        {
            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;

                // citeste cate o linie si creaza un obiect de tip Masina
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    masina Masina = new masina(linieFisier);
                    if (Masina.model.Equals(model) || Masina.marca.Equals(marca))
                        return Masina;
                }
            }

            return null;
        }

        public void DeleteMasina(int id)
        {
            List<masina> cars = GetMasini();
            masina deleted = cars.FirstOrDefault(r => r.id == id);
            if (deleted != null)
            {
                cars.Remove(deleted);
                File.WriteAllText(numeFisier, string.Empty);
            }

            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                foreach (masina car  in cars)
                {
                    streamWriterFisierText.WriteLine(car.ConversieLaSir_PentruFisier());

                }
            }

        }

        public void UpdateMasina(int id, bool option)
        {
            List<masina> cars = GetMasini();
            masina updated = cars.FirstOrDefault(r => r.id == id);
            if (updated != null)
            {
                updated.available = option;
                File.WriteAllText(numeFisier, string.Empty);
                

            }
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                foreach (masina car in cars)
                {
                    streamWriterFisierText.WriteLine(car.ConversieLaSir_PentruFisier());
                    Console.WriteLine(car.available);

                }
            }
        }

        public void ModifyMasina(masina car)
        {
            List<masina> cars = GetMasini();
            masina updated = cars.FirstOrDefault(r => r.id == car.id);
            if (updated != null)
            {
                updated.marca = car.marca;
                updated.model=car.model;
                updated.clasa = car.clasa;
                updated.alimentare = car.alimentare;
                updated.transmisie=car.transmisie;
                updated.optiuni = car.optiuni;
                updated.culoare= car.culoare;
                updated.pret_zi=car.pret_zi;
                updated.locuri=car.locuri;
                



                File.WriteAllText(numeFisier, string.Empty);


            }
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                foreach (masina ca in cars)
                {
                    streamWriterFisierText.WriteLine(ca.ConversieLaSir_PentruFisier());
                    Console.WriteLine(ca.available);

                }
            }
        }


    }
}
