namespace _5TI_AlexandreVandervoort_ManipulationMatrices;
class Program
{
    static void Main(string[] args)
    {
        Utils utils = new Utils();
        Matrices matrices = new Matrices();

        Console.WriteLine("Bienvenue dans le programme de traitement de matrices");
        ConsoleKey continuer = ConsoleKey.Escape;
        while (continuer != ConsoleKey.N) {
            int x = utils.QuestionneUtilisateurIntBetween("Quelle taille voulez vous en X pour les matrices?", 1, 10000);
            int y = utils.QuestionneUtilisateurIntBetween("Quelle taille voulez vous en Y pour les matrices?", 1, 10000);
            int manipulation = utils.QuestionneUtilisateurIntBetween("Quelle manipulation voulez vous faire?\n0: Addition\n1: Multiplication", 0, 1);
            int[,] matriceOriginelle1 = matrices.GenereRandMatrice(x, y);
            int[,] matriceOriginelle2 = matrices.GenereRandMatrice(x, y);

            Console.WriteLine("Matrice 1:");
            Console.WriteLine(matrices.ConcatMatrices(matriceOriginelle1));
            Console.WriteLine("Matrice 2:");
            Console.WriteLine(matrices.ConcatMatrices(matriceOriginelle2));

            int[,] fusionne;
            switch(manipulation) {
                case 0:
                    
                    bool resultatAdd = matrices.AdditionneMatrices(matriceOriginelle1, matriceOriginelle2, out fusionne);

                    if  (resultatAdd) {
                        Console.WriteLine("Résultat de l'addition de matrices:");
                        Console.WriteLine(matrices.ConcatMatrices(fusionne));
                    } else {
                        Console.WriteLine("Erreur: la manipulation n'as pas pu s'exécuter.");
                    }
                    break;
                case 1:
                    bool resultatMult = matrices.MultiplieMatrices(matriceOriginelle1, matriceOriginelle2, out fusionne);

                    if  (resultatMult) {
                        Console.WriteLine("Résultat de la multiplication de matrices:");
                        Console.WriteLine(matrices.ConcatMatrices(fusionne));
                    } else {
                        Console.WriteLine("Erreur: la manipulation n'as pas pu s'exécuter.");
                        Console.WriteLine(matrices.ConcatMatrices(fusionne));
                    }
                    break;
                default:
                    Console.WriteLine("Erreur: " + manipulation + " n'est pas une manipulation valide");
                    break;
            }

            Console.WriteLine("Voulez vous continuer? y: oui, n: non");
            continuer = Console.ReadKey(true).Key;
            while (continuer != ConsoleKey.N && continuer != ConsoleKey.Y) {
                continuer = Console.ReadKey(true).Key;
                Console.WriteLine("Voulez vous continuer? y: oui, n: non");
            }
        }
    }
}
