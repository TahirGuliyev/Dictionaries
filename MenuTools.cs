using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dictionaries
{
    static class MenuTools
    {
        static int menuNumb;
        public static void Menu() {
            Console.WriteLine("\tMENYU\n");
            Console.WriteLine("1. Yeni luget yarat");
            Console.WriteLine("2. Lugeti redakte et");
            Console.WriteLine("3. Lugetde axtar");
            Console.WriteLine("4. Lugeti sil");
            Console.WriteLine("5. Cixis");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Secim ucun bir eded daxil edin...");
            menuNumb = Convert.ToInt32(Console.ReadLine());
            switch (menuNumb) {
                case 1:
                    createDictionary();
                    break;
                case 2:
                    editDictionary();
                    break;
                case 3:
                    searchDictionary();
                    break;
                case 4:
                    deleteDictionary();
                    break;
                case 5:
                    exit();
                    break;
            }
        }
        private static void createDictionary() {
            Console.Clear();
            string birinciSoz;
            string ikinciSoz;
            Console.WriteLine("Sozu daxil edin...");
            birinciSoz = Console.ReadLine();
            Console.WriteLine("Tercumesini daxil edin...");
            ikinciSoz = Console.ReadLine();
            Dictionaries.Instance.Luget.Add(birinciSoz, ikinciSoz);
            using (StreamWriter writer = new StreamWriter(Dictionaries.Instance.FilePath))
            {
                foreach (var read in Dictionaries.Instance.Luget)
                {
                    writer.WriteLine(read);
                    writer.Close();
                }
            }
        }
        private static void editDictionary()
        {
            int secim = 0;
            string birinciSoz;
            string ikinciSoz;
            string readText = File.ReadAllText(Dictionaries.Instance.FilePath);
            string[] arr = readText.Split(",");
            birinciSoz = arr[0].Remove(0,1);
            ikinciSoz = arr[1].Remove(arr[1].Length-1, 1).Trim();
            Console.WriteLine("Deyismek istediyiniz sozun nomresini daxil edin...");
            Console.WriteLine($"1. {birinciSoz}");
            Console.WriteLine($"2. {ikinciSoz}");
            secim = Convert.ToInt32(Console.ReadLine());
            if (secim == 1)
            {
                Console.Write("Yeni versiya sozu daxil edin: ");
                birinciSoz = Console.ReadLine();
            }
            else if (secim == 2)
            {
                Console.Write("Yeni versiya sozu daxil edin: ");
                ikinciSoz = Console.ReadLine();
            }
            else {
                Console.WriteLine("Sozun nomresini duzgun daxil edin!");
            }
            Dictionaries.Instance.Luget.Remove(birinciSoz);
            Dictionaries.Instance.Luget.Add(birinciSoz, ikinciSoz);
            using (StreamWriter writer = new StreamWriter(Dictionaries.Instance.FilePath))
            {
                foreach (var read in Dictionaries.Instance.Luget)
                {
                    writer.WriteLine(read);
                    writer.Close();
                }
            }
        }
        private static void searchDictionary()
        {
            Console.WriteLine("Axtarmaq istediyiniz sozu daxil edin:");
            string soz = Console.ReadLine();
            foreach (var item in Dictionaries.Instance.Luget) {
                if (item.Key == soz || item.Value == soz)
                {
                    Console.WriteLine("Axtardiginiz soz lugetde var!");
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
                else {
                    Console.WriteLine("Axtardiginiz soz lugetde yoxdur!");
                }
            }
        }
        private static void deleteDictionary()
        {
            Console.WriteLine("Silmek istediyiniz sozu daxil edin.");
            string soz = Console.ReadLine();
            Dictionaries.Instance.Luget.Remove(soz);
        }
        private static void exit()
        {
            Environment.Exit(0);
        }

    }
}
