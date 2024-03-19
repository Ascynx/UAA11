namespace _5TI_VA_ResolutionDEquations3Inconnue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utils utils = new Utils();
            Matrices matrices = new Matrices();

            Console.WriteLine("Bienvenue dans mon programme de résolution d'équations à 3 inconnues");
            double[] equ1 = utils.QuestionneUtilisateurEquation3("Quelle est votre première equation (format #.##x #.##y #.##z = #.##)");
            double[] equ2 = utils.QuestionneUtilisateurEquation3("Quelle est votre seconde equation (format #.##x #.##y #.##z = #.##)");
            double[] equ3 = utils.QuestionneUtilisateurEquation3("Quelle est votre troisième equation (format #.##x #.##y#.##z = #.##)");

            double[,] equations = new double[3, 4];
            for (int i = 0; i < 3; i++)
            {
                double[] list = null;
                if (i == 0)
                {
                    list = equ1;
                } else if (i == 1)
                {
                    list = equ2;
                } else if (i == 2)
                {
                    list = equ3;
                }
                for (int j = 0; j < 4; j++)
                {
                    double v = list[j];
                    equations[i, j] = v;
                   
                }
            }

            Console.WriteLine("Matrice d'équations orginelle = " + matrices.ConcatMatrices(equations));
            Console.WriteLine("Résultat = " + matrices.ConcatMatrices(matrices.ResousEquationPivotDeGauss(equations)));

            ConsoleKey continuer = ConsoleKey.Escape;
            while (continuer != ConsoleKey.N)
            {
                Console.WriteLine("Pour commencez je vais vous demander de me donner vos 3 equations aux inconnues.");


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