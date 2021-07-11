using System;

namespace Koleksiyonlar_Soru_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] sayılar = new double[20];
            Veri_Girisi kontrol = new Veri_Girisi();

            for (int i = 0; i < 20; i++)
            {
                if (kontrol.DoubleGirisi((i+1).ToString(), out double sayi) == false){return;}
                sayılar[i] = sayi;
            }
            BubbleSort(ref sayılar);

            Console.WriteLine("En Büyük Sayılar: " + sayılar[19].ToString() + " , " + sayılar[18].ToString() + ", " + sayılar[17].ToString());
            Console.WriteLine("En Küçük Sayılar: " + sayılar[0].ToString() + ", " + sayılar[1].ToString() + ", " + sayılar[2].ToString());
            double buyukort = (sayılar[19]+  sayılar[18]+ sayılar[17])/3;
            double kucukort = (sayılar[0]+  sayılar[1]+ sayılar[2])/3;
            Console.WriteLine("En Büyük Sayıların Ortalaması: " + buyukort);
            Console.WriteLine("En Küçük Sayıların Ortalaması: " + kucukort);
            Console.WriteLine("Büyük ve Küçük Sayıların Ortalamalarının Toplamı: " + (kucukort+buyukort).ToString());
        }

        public static void BubbleSort(ref double[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n; i++) 
            {
                int degisim = 0;
                for (int j = 0; j < n - 1; j++) 
                {
                    if (a[j] > a[j + 1]) 
                    {
                        double degistir = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = degistir;
                        degisim++;
                    }
                }
                if (degisim == 0) {break;} //yer değişimi olmadıysa sıralama tamamlanmıştır
            }
        }
    }

    class Veri_Girisi
    {
        public bool DoubleGirisi(string no, out double sayi)
        {
            bool DoubleDegil = true;
            double n = 0;

            Console.WriteLine("Lütfen {0} nolu sayıyı girin: (Çıkış='exit')",no);

            while (DoubleDegil)
            {
                string girilenDeger = Console.ReadLine();
                if (girilenDeger.ToLower() == "exit"){
                    sayi = 0;
                    return false;
                }

                if (double.TryParse(girilenDeger, out n) == false){
                    DoubleDegil = true; // girilen deger numerik degil
                    Console.WriteLine("Girdiğiniz değer uygun degil, lütfen tekrar deneyin.(Çıkış='exit')");
                }
                else{
                    DoubleDegil = false; // girilen deger Double
                }
            }
            sayi = n;
            return true;
        }
    }  
}
