using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga1
{
    class Mama : Oseba
    {
        private string hobi;
        private string najljubsaHrana;
        private int steviloOtrok;

        public string Hobi
        {
            get { return hobi; }
            set { hobi = value; }
        }

        public string NajljubsaHrana
        {
            get { return najljubsaHrana; }
            set { najljubsaHrana = value; }
        }

        public int SteviloOtrok
        {
            get { return steviloOtrok; }
            set { steviloOtrok = value; }
        }
        public Mama () { }
        public Mama(string ime, string priimek, DateTime datumRojstva, string hobi, string najljubsaHrana, int številoOtrok)
            : base(ime, priimek, datumRojstva)
        {
            this.hobi = hobi;
            this.najljubsaHrana = najljubsaHrana;
            this.steviloOtrok = številoOtrok;
        }

        public override void Izpis()
        {
            Console.WriteLine($"Mama: {Ime} {Priimek}, Hobi: {Hobi}, Najljubša hrana: {NajljubsaHrana}, Število otrok: {steviloOtrok}, Datum rojstva: {DatumRojstva.ToShortDateString()}");
        }
    }
}
