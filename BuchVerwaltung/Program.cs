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
                        BuchWrite();
                        break;
                    case "2":
                        ZeigAll();
                        break;
                    case "3":
                        SuchISBN();
                        break;
                    case "4":
                        SuchGenre();
                        break;
                    case "5":
                        fertig = true;
                        break;
                }
            }
        }


        static void BuchWrite()
        {
            Console.Clear();
            try
            {
                Buch newBuch = new Buch();
            
                Console.WriteLine("\t Wir erfassen neu Buch");
                Console.WriteLine("---------------------------------------");
                Console.Write("Name des Buches.....: ");
                newBuch.StrName = Console.ReadLine();
                Console.Write("Genre...............: ");
                newBuch.StrGenre = Console.ReadLine();
                Console.Write("Autor...............: ");
                newBuch.StrAutor = Console.ReadLine();
                Console.Write("ISBN................: ");
                newBuch.StrISBN = Console.ReadLine();
                Console.Write("Einkaufspreis.......: ");
                newBuch.DEinkaufspreis = Double.Parse(Console.ReadLine());
                Console.Write("Verkaufspreis.......: ");
                newBuch.DVerkaufspreis = Double.Parse(Console.ReadLine());

                string strSql = "INSERT INTO tblBuch (BuchName, Genre, Autor, ISBNummer, Einkaufspreis, Verkaufspreis)" +
                                " VALUES(@name, @genre, @autor, @isbn, @ekpreis, @vkpreis)";


                SqlCommand cmd = new SqlCommand(strSql, DBconn.cn);

                cmd.Parameters.AddWithValue("@name", newBuch.StrName);
                cmd.Parameters.AddWithValue("@genre", newBuch.StrGenre);
                cmd.Parameters.AddWithValue("@autor", newBuch.StrAutor);
                cmd.Parameters.AddWithValue("@isbn", newBuch.StrISBN);
                cmd.Parameters.AddWithValue("@ekpreis", newBuch.DEinkaufspreis);
                cmd.Parameters.AddWithValue("@vkpreis", newBuch.DVerkaufspreis);

                DBconn.cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                string msg = "";
                for (int i = 0; i < e.Errors.Count; i++)
                {
                    msg += "Error #" + i + " Message: " + e.Errors[i].Message + "\n";
                }
                Console.WriteLine(msg);
                Console.ReadKey();
            }
            finally
            {
                if (DBconn.cn.State != ConnectionState.Closed)
                {
                    DBconn.cn.Close();
                }
            }
        }

        static void ZeigAll()
        {
            Console.Clear();
            try
            {
                string strSql = "SELECT * FROM tblBuch";

                DBconn.cn.Open();

                SqlDataAdapter da = new SqlDataAdapter(strSql, DBconn.cn);
                DataTable dt = new DataTable();

                int recordAffected = da.Fill(dt);

                if (recordAffected > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Console.WriteLine("{0}. {1, -15}{2, -15}{3, -15}{4, -25}{5, -15}{6, -15}", item[0], item[1], item[2], item[3], item[4], item[5], item[6]);
                    }
                }
                Console.ReadKey();
            }
            catch (SqlException e)
            {
                string msg = "";
                for (int i = 0; i < e.Errors.Count; i++)
                {
                    msg += "Error # " + i + "Message: " + e.Errors[i].Message + "\n";
                }
                Console.WriteLine(msg);
                Console.ReadKey();
            }
            finally
            {
                if (DBconn.cn.State != ConnectionState.Closed)
                {
                    DBconn.cn.Close();
                }
            }

        }

        static void SuchISBN()
        {
            Console.Clear();
            string strIsbn = "";
            string strSql = "SELECT BuchID, BuchName, Genre, Autor, ISBNummer, Einkaufspreis, Verkaufspreis " +
                "FROM tblBuch WHERE ISBNummer=@isbn";

            try
            {
                Console.Write("Bitte um exacte ISBN Nummer: ");
                strIsbn = Console.ReadLine();

                SqlCommand cmd = new SqlCommand(strSql, DBconn.cn);
                cmd.Parameters.AddWithValue("@isbn", strIsbn);

                DBconn.cn.Open();
                SqlDataReader drBuch = cmd.ExecuteReader();
                Console.Clear();

                if (drBuch.HasRows)
                {
                    foreach (Object item in drBuch)
                    {
                        Console.WriteLine("{0}. {1, -15}{2, -15}{3, -15}{4, -25}{5, -15}{6, -15}", 
                                            drBuch[0], drBuch[1], drBuch[2], drBuch[3], drBuch[4], drBuch[5], drBuch[6]);
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Keine Einträge gefunden!");
                    Console.ReadKey();
                }
            }
            catch (SqlException e)
            {
                string msg = "";
                for (int i = 0; i < e.Errors.Count; i++)
                {
                    msg += "Error #" + i + " Message: " + e.Errors[i].Message + "\n";
                }
                Console.WriteLine(msg);
                Console.ReadKey();
            }
            finally
            {
                if (DBconn.cn.State != ConnectionState.Closed)
                {
                    DBconn.cn.Close();
                }
            }

        }

        static void SuchGenre()
        {
            Console.Clear();
            string strGenre = "";
            string strSql = "SELECT BuchID, BuchName, Genre, Autor, ISBNummer, Einkaufspreis, Verkaufspreis " +
                "FROM tblBuch WHERE Genre=@genre";

            try
            {
                Console.Write("Bitte um exacte Genre: ");
                strGenre = Console.ReadLine();

                SqlCommand cmd = new SqlCommand(strSql, DBconn.cn);
                cmd.Parameters.AddWithValue("@genre", strGenre);

                DBconn.cn.Open();
                SqlDataReader drBuch = cmd.ExecuteReader();
                Console.Clear();

                if (drBuch.HasRows)
                {
                    foreach (Object item in drBuch)
                    {
                        Console.WriteLine("{0}. {1, -15}{2, -15}{3, -15}{4, -25}{5, -15}{6, -15}",
                                            drBuch[0], drBuch[1], drBuch[2], drBuch[3], drBuch[4], drBuch[5], drBuch[6]);
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Keine Einträge gefunden!");
                    Console.ReadKey();
                }
            }
            catch (SqlException e)
            {
                string msg = "";
                for (int i = 0; i < e.Errors.Count; i++)
                {
                    msg += "Error #" + i + " Message: " + e.Errors[i].Message + "\n";
                }
                Console.WriteLine(msg);
                Console.ReadKey();
            }
            finally
            {
                if (DBconn.cn.State != ConnectionState.Closed)
                {
                    DBconn.cn.Close();
                }
            }

        }
    }
}
