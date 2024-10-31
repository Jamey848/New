using System;
using System.IO;
using System.Text.RegularExpressions;
namespace Week05_HarryPotter03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in File.ReadLines("Characters.csv"))
            {
                if (item.Contains("Gryffindor"))
                {
                    int eerste = item.IndexOf(";"); //Dit gaat de eerste index zoeken van eerste ;
                    string substring = item.Substring(eerste + 1);
                    int tweede = substring.IndexOf(";");
                    Console.WriteLine(substring.Substring(0, tweede));


                }
            }
        }
    }
}
