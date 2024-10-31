using System;
using System.IO;
using System.Text.RegularExpressions; //LAAT ONS TOE OM REGEX KLASSEN TE GEBRUIKEN

namespace Week05_Rapunzel01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //File openen en de content lezen en er iets mee doen.
            //verise 1
            /*StreamReader sr = File.OpenText("Rapunzel.txt");
            string tekstcheck = sr.ReadToEnd();
            sr.Close(); */

            //Versie 2
            string tekst = File.ReadAllText("Rapunzel.txt"); //ReadAllText: leest charackter per charackter. NIET lijn per lijn.
            Console.WriteLine($"Het aantal charakters is {tekst.Length}");

            // Lijnen tellen.
            //Versie 1.
            StreamReader sr = File.OpenText("Rapunzel.txt");
            int lijnen = 0;
            while (!sr.EndOfStream) 
            {
                sr.ReadLine();
                lijnen++;
            }
            sr.Close();
            Console.WriteLine($"Aantal lijnen: {lijnen}");

            //Versie 2.
            Console.WriteLine($"Het aantal lijnen: {File.ReadAllLines("Rapunzel.txt").Length}");

            // Specifiek charackter tellen.
            // Tellen van l'en en L'en.
            //Versie while.
            int countl = 0;
            int countL = 0;
            sr = File.OpenText("Rapunzel.txt");
            while (!sr.EndOfStream)
            {
                char c = (char)sr.Read();
                if (c == 'l')
                {
                    countl++;
                }
                else if (c == 'L')
                {
                    countL++;
                }
            }
            sr.Close();
            Console.WriteLine($"Hoeveelheid L'en: {countL} en de hoeveelheid l'en: {countl}");

            // Betere versie: if("Ll".Contains(c)) /*
            //                {
            //                    ...
            //                }*/

            //Tel de L'en en l'en.
            //Versie: foreach
            countl = 0;
            foreach (char item in tekst.ToLower())
            {
                if (item == 'l')
                {
                    countl++;
                }
            }
            Console.WriteLine($"Aantal l'en: {countl}");

            //Tel de L'en en l'en.
            //Versie for.
            countl = 0;
            for (int i = 0; i < tekst.Length; i++)
            {
                if (tekst[i] == 76||  tekst[i] == 108)
                {
                    countl++;
                }
            }
            Console.WriteLine($"Aantal l'en: {countl}");

            //WOORDEN TELLEN
            int telwoorden = 0;
            foreach (char c in tekst)
            {
                if (c == ' ')
                {
                    telwoorden++;
                }
            }
            Console.WriteLine($"Het aantal woorden: {telwoorden}");
            Console.WriteLine();

            // Aantal "rapunzel" in de tekst
            // Zonder regex
            string woord = "";
            int count = 0;

            foreach(char c in tekst.ToLower()) //String tekst = File.ReadAllText("Rapunezel.txt");
            {
                if ("abcdefghijklmnopqrstuvwxyz".Contains(c))
                {
                    woord += c;
                }
                else
                {
                    if (woord == "rapunzel")
                    {
                        count++;
                    }
                    woord = "";
                }
            }
            Console.WriteLine($"Het aantal Rapunzels: {count}");

            //Met regex, VOEG SYSTEM.TEXT.REGULAREXPRESSION TOE AAN, ZIE BOVENAAN!
            Regex regex = new Regex("rapunzel", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(tekst); /* Wat is een maxcollection? Een array die, in dit geval, rapunzel opslaat */
            Console.WriteLine($"Rapunzels: {matches.Count}");

            //Woorden tellen met REGEX
            regex = new Regex(@"\b\w+\b", RegexOptions.IgnoreCase);
            matches = regex.Matches(tekst);
            Console.WriteLine($"Aantal woorden: {matches.Count}");
            //LET OP; OPPASSEN VOOR WOORDEN MET ' 

            //Rapunzel vervangen.
            regex = new Regex(@"rapunzel", RegexOptions.IgnoreCase);
            string s = regex.Replace(tekst, "Anthony");
            Console.WriteLine(s);
            
        }
    }
}
