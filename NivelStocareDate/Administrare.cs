using Clase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AdministrareMasini
    {
        private const int NR_MAX_MASINI = 100;
        private List<masina> masini;
        private int nr_masini;

        public AdministrareMasini()
        {
            masini=new List<masina>();
                
        }

        public void AddMasina(masina Masina)
        {
            masini.Add(Masina);

        }
        public List<masina> GetMasini()
        {
           
            return masini;
        }
    }
    public class AdministrareClienti
    {
        private const int NR_MAX_CLIENTI = 100;
        private client[] clienti;
        private int nr_clienti;

        public AdministrareClienti()
        {
            clienti = new client[NR_MAX_CLIENTI];
            nr_clienti = 0;
        }

        public void AddClient(client Client)
        {
            clienti[nr_clienti] = Client;
            nr_clienti++;

        }
        public client[] GetClienti(out int nr_clienti)
        {
            nr_clienti = this.nr_clienti;
            return clienti;
        }
    }
}
