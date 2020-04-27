using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchVerwaltung
{
    class Buch
    {
        string strName;
        string strGenre;
        string strAutor;
        string strISBN;
        double dEinkaufspreis;
        double dVerkaufspreis;

        public string StrName { get => strName; set => strName = value; }
        public string StrGenre { get => strGenre; set => strGenre = value; }
        public string StrAutor { get => strAutor; set => strAutor = value; }
        public string StrISBN { get => strISBN; set => strISBN = value; }
        public double DEinkaufspreis { get => dEinkaufspreis; set => dEinkaufspreis = value; }
        public double DVerkaufspreis { get => dVerkaufspreis; set => dVerkaufspreis = value; }
    }
}
