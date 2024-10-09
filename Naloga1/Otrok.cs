using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga1
{
    class Otrok : Oseba
    {
        private string sola;
        private string najljubsiPredmet;
        private int starost;

        public string Sola
        {
            get { return sola; }
            set { sola = value; }
        }

        public string NajljubsiPredmet
        {
            get { return najljubsiPredmet; }
            set { najljubsiPredmet = value; }
        }

        public int Starost
        {
            get { return starost; }
            set { starost = value; }
        }
        public Otrok() { }
        public Otrok(string ime, string priimek, DateTime datumRojstva, string sola, string najljubsiPredmet, int starost)
            : base(ime, priimek, datumRojstva)
        {
            this.sola = sola;
            this.najljubsiPredmet = najljubsiPredmet;
            this.starost = starost;
        }

        public override void Izpis()
        {
            Console.WriteLine($"Otrok: {Ime} {Priimek}, Sola: {Sola}, Najljubši predmet: {NajljubsiPredmet}, Starost: {Starost}, Datum rojstva: {DatumRojstva.ToShortDateString()}");
        }
    }
}
