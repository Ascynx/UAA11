﻿namespace _5TI_VA_StockageAdresseIP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utils utils = new Utils();
            IPUtils ipUtils = new IPUtils();

            byte[][] adresses = new byte[20][];
            string[] noms = new string[20];

            Console.WriteLine("Hello, World!");
            ConsoleKey continuer = ConsoleKey.Escape;
            while (continuer != ConsoleKey.N)
            {
                byte[] adresse = new byte[4];
                Console.WriteLine("Veuillez entrer une adresse IP.");
                ipUtils.LireAdresseIP(ref adresse);
                string nom = utils.QuestionneUtilisateur("à qui appartient cette adresse?");

                ipUtils.AjouteNom(ref noms, nom);
                ipUtils.AjouteAdresseIP(ref adresses, adresse);

                Console.WriteLine(ipUtils.ConcateneTout(adresses, noms));
                Console.WriteLine("Voulez vous continuer? y: oui, n: non");
                continuer = Console.ReadKey(true).Key;
                while (continuer != ConsoleKey.N && continuer != ConsoleKey.Y)
                {
                    continuer = Console.ReadKey(true).Key;
                    Console.WriteLine("Voulez vous continuer? y: oui, n: non");
                }
            }
        }
    }
}