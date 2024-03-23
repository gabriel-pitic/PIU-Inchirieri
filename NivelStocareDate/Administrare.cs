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
        private masina[] masini;
        private int nr_masini;

        public AdministrareMasini()
        {
            masini=new masina[NR_MAX_MASINI];
            nr_masini=0;
        }

        public void AddMasina(masina Masina)
        {
            masini[nr_masini] = Masina;
            nr_masini++;

        }
        public masina[] GetMasini(out int nr_masini)
        {
            nr_masini = this.nr_masini;
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
