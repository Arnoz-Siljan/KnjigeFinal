using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga1
{
    abstract class Oseba
    {
        private string ime;
        private string priimek;
        private DateTime datumRojstva;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public string Priimek
        {
            get { return priimek; }
            set { priimek = value; }
        }

        public DateTime DatumRojstva
        {
            get { return datumRojstva; }
            set { datumRojstva = value; }
        }
        public Oseba()
        { }

        public Oseba(string ime, string priimek, DateTime datumRojstva)
        {
            this.ime = ime;
            this.priimek = priimek;
            this.datumRojstva = datumRojstva;
        }

        public abstract void Izpis();
    }
}
