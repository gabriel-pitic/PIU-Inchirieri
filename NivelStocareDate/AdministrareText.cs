using Clase;
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
                streamWriterFisierText.WriteLine(Masina.Info());
                Masina.ListOptiuniText(streamWriterFisierText);
            }
        }

        public masina[] GetMasini(out int nrStudenti)
        {
            masina[] Masini=new masina[NR_MAX_MASINI];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                
                nrStudenti = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                
                    Masini[nrStudenti] = new masina(linieFisier);
                    nrStudenti++;
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

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    masina Masina = new masina(linieFisier);
                    if (Masina.model.Equals(model) && Masina.marca.Equals(marca))
                        return Masina;
                }
            }

            return null;
        }

    }
}
