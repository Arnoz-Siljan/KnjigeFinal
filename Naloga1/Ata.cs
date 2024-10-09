using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga1
{
    class Ata : Oseba
    {
        private string poklic;
        private string izobrazba;
        private int delovnaDoba;

        public string Poklic
        {
            get { return poklic; }
            set { poklic = value; }
        }

        public string Izobrazba
        {
            get { return izobrazba; }
            set { izobrazba = value; }
        }

        public int DelovnaDoba
        {
            get { return delovnaDoba; }
            set { delovnaDoba = value; }
        }
        public Ata() { }
        public Ata(string ime, string priimek, DateTime datumRojstva, string poklic, string izobrazba, int delovnaDoba)
            : base(ime, priimek, datumRojstva)
        {
            this.poklic = poklic;
            this.izobrazba = izobrazba;
            this.delovnaDoba = delovnaDoba;
        }

        public override void Izpis()
        {
            Console.WriteLine($"Ata: {Ime} {Priimek}, Poklic: {Poklic}, Izobrazba: {Izobrazba}, Delovna doba: {DelovnaDoba} let, Datum rojstva: {DatumRojstva.ToShortDateString()}");
        }
    }
}
