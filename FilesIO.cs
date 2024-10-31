using System;
using System.IO;
using System.Security.Cryptography; //Laat ons toe om alles van schrijven en lezen van data toe te laten. Belangrijk: zet dit als je met files werkt.

namespace _05FilesIO //BELANGRIJK, ZIE "SOLUTION EXPLORER". Ga naar tab "view" => "solution explorer". Zo kan je uw files zien.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FILES AANMAKEN.
            StreamWriter stream = File.CreateText("file.txt");
            // Streamwriter is eeen klasse, hetgene dat het aanduid is een object. Dingen zoals "int" is een datatype, hetgene dat het aanduid een variabele.
            stream.WriteLine("Dit is een tekstfile"); //Scrhrijft tekst, opent nieuwe lijn.
            stream.Write("Hallo"); // schrijft tekst, geen nieuwe lijn.
            stream.Write(" Mijn naam is James");
            stream.Close(); // Schrijf maar 1 close; meerdere zorgen ervoor dat er overschrijven ontstaan.

            //Files op andere locaties.
            stream = File.CreateText(@"C:\test\file.txt"); //Als je pad naar file niet kent; kopieer adress.
            stream.WriteLine("Tekst in andere file");
            stream.Close();

            /*  Computers hebben "special folders"
             *  BV: Bureaublad, downloads, documenten, muziek, videos, ...*/
            //FILE OP DESKTOP
            string desktopfolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //Console.WriteLine(desktopfolder) = Toont pad naar desktop.
            // desktopfolder is een string van pad naar desktop.
            string path = Path.Combine(desktopfolder, "File.txt");
            stream = File.CreateText(path);
            stream.WriteLine("TEST OP HET BUREAUBLAD");
            stream.Close();

            if (File.Exists(path)) //Checked of file bestaat op bureaublad.
            {
                stream = File.AppendText(path); // AppendText = Tekst toevoegen aan bestaande tekst in file.
                stream.WriteLine("Nog meer testen");
                stream.WriteLine("Nog meer meer");
                stream.Close();
            }

            if (File.Exists(@"C:\test\file.txt"))
            {
                stream = File.AppendText(@"C:\test\file.txt");
                stream.WriteLine("H A L L O");
                stream.Close();
            }

            //DELETEN VAN FILES
            //Stap 1, file aanmaken.
            string muziekfolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic); // = C:\Users\jamey\Music
            string padvanmuziek = Path.Combine(muziekfolder, "file.txt");
            stream = File.CreateText(padvanmuziek);
            stream.WriteLine("TEST");
            stream.Close();
            //Stap 2: checken of het bestaat.
            if (File.Exists(padvanmuziek))
            {
                File.Delete(padvanmuziek);
            }


            string input = Console.ReadLine();
            char[] chars = input.ToCharArray();
            Console.Write(chars + " ");

        }
    }
}
