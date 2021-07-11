using System;
using System.Collections.Generic;

namespace Koleksiyonlar_Soru_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var chrlist = new List<char>();
            string checkstr = "aeıiuüoö";
            Console.WriteLine("Cümleyi giriniz:");
            string STR = Console.ReadLine();

            foreach (char chr in STR)
                if (checkstr.Contains(chr)){chrlist.Add(chr);}

            Console.WriteLine("Sesli harfler sıralanmadan:");
            yazdir(chrlist);

            chrlist.Sort();
            Console.WriteLine("Sesli harfler sıralanmış şekilde:");
            yazdir(chrlist);
        }

        private static void yazdir(List<char> chrlist){
            string cikti = "";
            foreach (char chr in chrlist)
                cikti += chr;
            Console.WriteLine(cikti);
        }
    }
}
