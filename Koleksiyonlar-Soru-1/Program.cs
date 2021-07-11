using System;
using System.Collections;

namespace Koleksiyonlar_Soru_1
{
    class Program
    {
        // Soru - 1: Klavyeden girilen 20 adet pozitif sayının asal ve asal olmayan olarak 2 ayrı listeye atın.
        // (ArrayList sınıfını kullanarak yazınız.)
        // Negatif ve numeric olmayan girişleri engelleyin.
        // Her bir dizinin elemanlarını büyükten küçüğe olacak şekilde ekrana yazdırın.
        // Her iki dizinin eleman sayısını ve ortalamasını ekrana yazdırın.
        static void Main(string[] args)
        {
            Veri_Girisi kontrol = new Veri_Girisi();
            ArrayList AsalOlmayanlar = new ArrayList();
            ArrayList AsalOlanlar = new ArrayList();

            Console.WriteLine("Çıkmak için 'exit' yazabilirsiniz.");
            for (int i = 0; i < 20; i++)
            {
                if (kontrol.PozitifTamsayiGirisi((i+1).ToString(), out int sayi) == false){return;}
                
                bool AsalMi = true;
                for (int j = 2; j < sayi; j++)
                {
                    if (sayi%j==0){
                        AsalOlmayanlar.Add(sayi);
                        AsalMi = false;
                        break;
                    }
                }
                if(AsalMi){AsalOlanlar.Add(sayi);}
            }
            AsalOlanlar.Sort();
            AsalOlmayanlar.Sort();

            YazdirveTopla("Asal Sayılar",AsalOlanlar);
            YazdirveTopla("Asal Olmayan Sayılar",AsalOlmayanlar);
        }

        static void YazdirveTopla(string str, ArrayList intarrlist){
            int Toplam = 0;
            Console.WriteLine(str + " Listesi:");
            for (int j = intarrlist.Count-1; j >= 0; j--)
            {
                String asal=intarrlist[j].ToString();
                Console.WriteLine(asal);
                Toplam += int.Parse(asal);
            }
            
            Console.WriteLine(str + " Toplamı:");
            Console.WriteLine(Toplam);

            Console.WriteLine(str + " Ortalaması:");
            Console.WriteLine(Toplam / 20);
        }
    }

    class Veri_Girisi
    {
        public bool PozitifTamsayiGirisi(string no, out int sayi)
        {
            bool pozitifDegil = true;
            int n = 0;

            Console.WriteLine("Lütfen {0} nolu tamsayıyı girin: (Çıkış='exit')",no);

            while (pozitifDegil)
            {
                string girilenDeger = Console.ReadLine();
                if (girilenDeger.ToLower() == "exit"){
                    sayi = 0;
                    return false;
                }
                if (int.TryParse(girilenDeger, out n) == false){
                    pozitifDegil = true; // girilen deger numerik degil
                    Console.WriteLine("Girdiğiniz değer bir tamsayı degil, lütfen tekrar deneyin.(Çıkış='exit')");
                }
                else if(n < 0) {
                    pozitifDegil = true; // girilen deger pozitif degil
                    Console.WriteLine("Girdiğiniz sayı pozitif degil, lütfen tekrar deneyin.(Çıkış='exit')");
                }
                else if(n == 0) {
                    pozitifDegil = true; // sıfır pozitif degil
                    Console.WriteLine("Sıfır uygun değil, lütfen tekrar deneyin.(Çıkış='exit')");
                } 
                else {
                    pozitifDegil = false; // girilen deger pozitif tamsayı
                }
            }
            sayi = n;
            return true;
        }
    }
}
