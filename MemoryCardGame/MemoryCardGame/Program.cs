using System;
using System.Diagnostics;

class HafizaKartOyunu
{
    static void Main()
    {
        char[] gizliDizi = { 'A', 'A', 'B', 'B', 'C', 'C', 'D', 'D', 'E', 'E', 'F', 'F', 'G', 'G', 'H', 'H' };
        bool[] acikKartlar = new bool[16];
        int hamleSayisi = 0;
        

        Random random = new Random();
        Stopwatch zamanSayaci = new Stopwatch();
        zamanSayaci.Start();

        // Kartları karıştır
        for (int i = 0; i < gizliDizi.Length; i++)
        {
            int r = random.Next(gizliDizi.Length);
            char temp = gizliDizi[i];
            gizliDizi[i] = gizliDizi[r];
            gizliDizi[r] = temp;
        }
       

        while (Array.Exists(acikKartlar, x => x == false))
        {
            Console.Clear();
            KartlariYazdir(gizliDizi, acikKartlar);
            int ilkSecim = KartSec("Lütfen 1. Kartı seçiniz >> ", acikKartlar);
            acikKartlar[ilkSecim - 1] = true;
            Console.Clear();
            KartlariYazdir(gizliDizi, acikKartlar);
            int ikinciSecim = KartSec("Lütfen 2. Kartı seçiniz >> ", acikKartlar);
            acikKartlar[ikinciSecim - 1] = true;
            Console.Clear();
            KartlariYazdir(gizliDizi, acikKartlar);

            if (gizliDizi[ilkSecim - 1] != gizliDizi[ikinciSecim - 1])
            {
                Console.WriteLine("Kartlar aynı değil, tekrar deneyin.");
                acikKartlar[ilkSecim - 1] = false;
                acikKartlar[ikinciSecim - 1] = false;
            }

            hamleSayisi++;
            Thread.Sleep(3000);
           
        }

        zamanSayaci.Stop();
        double sure = zamanSayaci.Elapsed.TotalMinutes;

        Console.Clear();
        KartlariYazdir(gizliDizi, acikKartlar);
        Console.WriteLine("\nOYUN BİTTİ!");
        Console.WriteLine("TOPLAM ADIM SAYISI = " + hamleSayisi);
        Console.WriteLine("TOPLAM SÜRE = " + sure.ToString("0.00") + " dk");
    }

    static int KartSec(string mesaj, bool[] acikKartlar)
    {
        int secim = 0;
        bool gecerliSecim = false;

        while (!gecerliSecim)
        {
            Console.Write(mesaj);
            string girdi = Console.ReadLine();

            if (int.TryParse(girdi, out secim) && secim >= 1 && secim <= 16)
            {
                if (!acikKartlar[secim - 1])
                {
                    gecerliSecim = true;
                }
                else
                {
                    Console.WriteLine("Açık olan bir kart seçtiniz! Lütfen geçerli bir kart seçiniz.");
                }
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir kart seçiniz (1-16 arası bir sayı girin).");
            }
        }

        return secim;
    }

    static void KartlariYazdir(char[] kartlar, bool[] acikKartlar)
    {
        for (int i = 0; i < kartlar.Length; i++)
        {
            if (acikKartlar[i])
            {
                Console.Write("| " + kartlar[i] + " ");
            }
            else
            {
                Console.Write("| " + (i + 1) + " ");
            }

            if ((i + 1) % 4 == 0)
            {
                Console.WriteLine("|");
            }
        }
        Console.WriteLine("--------------------------");
    }
}