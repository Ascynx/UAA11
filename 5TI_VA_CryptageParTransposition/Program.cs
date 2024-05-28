namespace _5TI_VA_CryptageParTransposition
{
    internal class Program
    {
        public static readonly Utils UTILS = new();
        public static readonly MethodesCryptage CRYPTAGE = new();

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le programme pour crypter par transposition.");

            ConsoleKey continuer = ConsoleKey.Escape;
            while (continuer != ConsoleKey.N)
            {
                string phrase = UTILS.QuestionneUtilisateur("Quelle est la phrase que vous voulez crypter?", (str => str.Length > 0));
                string cle = UTILS.QuestionneUtilisateur("En utilisant quelle clé (taille inférieure à 10 caractères)?", (str => str.Length > 0));
                phrase = CRYPTAGE.NettoyeString(phrase);
                cle = CRYPTAGE.NettoyeString(cle);

                CRYPTAGE.CreeMatrice(cle, phrase, out char[,] matriceP);
                CRYPTAGE.EcritChainesDansMatrice(cle, phrase, ref  matriceP);
                CRYPTAGE.CreeMatriceOutil(cle, out char[,] matriceO);
                CRYPTAGE.ReporteOrdre(ref matriceP, ref matriceO);
                string crypte = CRYPTAGE.ConstruitCryptage(matriceP);

                Console.WriteLine("matrice principale:\n" + UTILS.ConcatMatrices(matriceP));
                Console.WriteLine("matrice outil:\n" + UTILS.ConcatMatrices(matriceO));
                Console.WriteLine($"Avec phrase: {phrase} et clé: {cle}, reçu: {crypte}");

                Console.WriteLine("Voulez vous continuer? y: oui, n: non");
                continuer = Console.ReadKey(true).Key;
                while (continuer != ConsoleKey.N && continuer != ConsoleKey.Y)
                {
                    Console.WriteLine("Voulez vous continuer? y: oui, n: non");
                    continuer = Console.ReadKey(true).Key;
                }
            }
        }
    }
}