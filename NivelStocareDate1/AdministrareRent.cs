using Clase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NivelStocareDate1
{
    public class AdministrareRent
    {
        private string numeFisier;

        public AdministrareRent(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddInchiriere(Inchiriere inchiriere)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(inchiriere.ConversieLaSir_PentruFisier(inchiriere));
                inchiriere.active = true;
              

            }
         

        }

        public List<Inchiriere> GetInchirieri()
        {
            List<Inchiriere> rents = new List<Inchiriere>();
            Inchiriere nou= null;
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    nou = new Inchiriere(linieFisier);
                    rents.Add(nou);
                    
                }
            }

            return rents;
        }

        public void DeleteInchiriere(int id)
        {
            List<Inchiriere> rents = GetInchirieri();
            Inchiriere deleted = rents.FirstOrDefault(r => r.id == id);
            if(deleted != null)
            {
                rents.Remove(deleted);
                File.WriteAllText(numeFisier, string.Empty);
            }

            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                foreach (Inchiriere rent in rents)
                {
                    streamWriterFisierText.WriteLine(rent.ConversieLaSir_PentruFisier(rent));
                   
                }
            }

        }

        public void UpdateInchiriere(Inchiriere  rent)
        {
            List<Inchiriere> rents = GetInchirieri();
            Inchiriere updated = rents.FirstOrDefault(r => r.id == rent.id);
            if (updated != null)
            {
                File.WriteAllText(numeFisier, string.Empty);
                updated.pret = rent.pret;
                updated.DataInceput = rent.DataInceput;
                updated.DataSfarsit=rent.DataSfarsit;
                updated.Client.Nume=rent.Client.Nume;
                updated.Client.Prenume = rent.Client.Prenume;
                updated.Client.CNP = rent.Client.CNP;
                updated.CarID=rent.CarID;
                updated.active=rent.active;

            }
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                foreach (Inchiriere ren in rents)
                {
                    streamWriterFisierText.WriteLine(ren.ConversieLaSir_PentruFisier(ren));

                }
            }
        }


    }
}
