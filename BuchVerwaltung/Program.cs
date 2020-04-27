using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchVerwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            bool fertig = false;

            while (!fertig)
            {
                Console.Clear();
                Console.WriteLine("Buch Verwaltungs Software v 0.666");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Was möchstest Du machen?");
                Console.WriteLine("1. Buch erfassen");
                Console.WriteLine("2. Liste alle bucher zeigen");
                Console.WriteLine("3. Buch suchen nach ISBN-Nummer");
                Console.WriteLine("4. Buch suchen nach Genre");
                Console.WriteLine("5. Exit");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Verwaltung.BuchWrite();
                        break;
                    case "2":
                        Verwaltung.ZeigAll();
                        break;
                    case "3":
                        Verwaltung.SuchISBN();
                        break;
                    case "4":
                        Verwaltung.SuchGenre();
                        break;
                    case "5":
                        fertig = true;
                        break;
                }
            }
        }


        
    }
}
