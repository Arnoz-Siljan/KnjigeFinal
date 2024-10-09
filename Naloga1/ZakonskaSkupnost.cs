using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga1
{
    internal class ZakonskaSkupnost
    {
        private Ata ata;
        private Mama mama;
        private List<Otrok> otroci;

        public Ata Ata
        {
            get { return ata; }
            set { ata = value; }
        }

        public Mama Mama
        {
            get { return mama; }
            set { mama = value; }
        }

        public List<Otrok> Otroci
        {
            get { return otroci; }
            private set { otroci = value; }
        }
        public ZakonskaSkupnost() { }
        public ZakonskaSkupnost(Ata ata, Mama mama)
        {
            Ata = ata;
            Mama = mama;
            Otroci = new List<Otrok>();
        }
        public bool MamaJeStaraVsaj15(Otrok otrok)
        {
            int starostMame = DateTime.Now.Year - mama.DatumRojstva.Year;
            int starostOtroka = DateTime.Now.Year - otrok.DatumRojstva.Year;
            return starostMame - starostOtroka >= 15;
        }

        public void DodajOtroka(Otrok otrok)
        {
            if (!MamaJeStaraVsaj15(otrok))
            {
                throw new IzjemaZaMamo("Mama ni stara vsaj 15 let");
            }
            else  
                otroci.Add(otrok);   
        }

        public static List<ZakonskaSkupnost> UvoziIzCSV(string pot)
        {
            List<ZakonskaSkupnost> skupnosti = new List<ZakonskaSkupnost>();
            var vrstice = File.ReadAllLines(pot);

            foreach (var vrstica in vrstice)
            {
                var podatki = vrstica.Split(',');

                
                string imeAta = podatki[0];
                string priimekAta = podatki[1];
                DateTime datumRojstvaAta = DateTime.ParseExact(podatki[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string poklicAta = podatki[3];
                string izobrazbaAta = podatki[4];
                int delovnaDobaAta = int.Parse(podatki[5]);
                Ata ata = new Ata(imeAta, priimekAta, datumRojstvaAta, poklicAta, izobrazbaAta, delovnaDobaAta);

           
                string imeMama = podatki[6];
                string priimekMama = podatki[7];
                DateTime datumRojstvaMama = DateTime.ParseExact(podatki[8], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string hobiMama = podatki[9];
                string najljubsaHranaMama = podatki[10];
                int steviloOtrokMama = int.Parse(podatki[11]);
                Mama mama = new Mama(imeMama, priimekMama, datumRojstvaMama, hobiMama, najljubsaHranaMama, steviloOtrokMama);
                ZakonskaSkupnost skupnost = new ZakonskaSkupnost(ata, mama);

                
                int otrokStartIndex = 12;
                while (otrokStartIndex < podatki.Length)
                {
                    string imeOtrok = podatki[otrokStartIndex];
                    string priimekOtrok = podatki[otrokStartIndex + 1];
                    DateTime datumRojstvaOtrok = DateTime.ParseExact(podatki[otrokStartIndex + 2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    string otrokovaSola = podatki[otrokStartIndex + 3];
                    string najljubsiPredmetOtrok = podatki[otrokStartIndex + 4];
                    int starostOtrok = int.Parse(podatki[otrokStartIndex + 5]);

                    Otrok otrok = new Otrok(imeOtrok, priimekOtrok, datumRojstvaOtrok, otrokovaSola, najljubsiPredmetOtrok, starostOtrok);
                    skupnost.DodajOtroka(otrok);

                    otrokStartIndex += 6; 
                }

                
                skupnosti.Add(skupnost);
            }

            return skupnosti;
        }

        public double IzracunajPovprecnoStarostOtrok()
        {
            if (otroci.Count == 0) return 0;
            double skupnaStarost = 0;
            foreach (var otrok in otroci)
            {
                skupnaStarost += DateTime.Now.Year - otrok.DatumRojstva.Year;
            }
            return skupnaStarost / otroci.Count;
        }
        public Otrok NajmlajsiOtrok()
        {
            if (otroci.Count == 0) return null;
            Otrok najmlajsi = otroci[0];
            foreach (var otrok in otroci)
            {
                if (otrok.DatumRojstva > najmlajsi.DatumRojstva)
                {
                    najmlajsi = otrok;
                }
            }
            return najmlajsi;
        }
        public Otrok NajdiOtrokaZNajljubsimPredmetom(string najljubsiPredmet)
        {
            foreach (var otrok in otroci)
            {
                if (otrok.NajljubsiPredmet == najljubsiPredmet)
                {
                    return otrok;
                }
            }
            return null;
        }


    }
}
