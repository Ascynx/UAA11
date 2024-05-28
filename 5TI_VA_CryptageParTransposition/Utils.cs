using System.Text.RegularExpressions;

namespace _5TI_VA_CryptageParTransposition
{
    struct Utils
    {
        public String QuestionneUtilisateur(String question, Func<String, bool> condition)
        {
            Console.WriteLine(question);
            string res = Console.ReadLine();

            while (res == null || !condition.Invoke(res))
            {
                Console.WriteLine("Je n'ai pas compris ce que vous avez dis.");
                res = Console.ReadLine();
            }

            return res;
        }

        public String QuestionneUtilisateur(String question)
        {
            return QuestionneUtilisateur(question, (str) => true);
        }

        public int QuestionneUtilisateurInt(String question)
        {
            return Int32.Parse(QuestionneUtilisateur(question, (str) => Int32.TryParse(str, out int val)));
        }

        public int QuestionneUtilisateurIntBetween(String question, int min, int max)
        {
            if (min > max)
            {
                int inter = min;
                min = max;
                max = inter;
            }

            return Int32.Parse(QuestionneUtilisateur(question, (str) => Int32.TryParse(str, out int val) && (val <= max && val >= min)));
        }

        public bool QuestionneUtilisateurBool(String question)
        {
            return Boolean.Parse(QuestionneUtilisateur(question, (str) => Boolean.TryParse(str, out bool val)));
        }

        //https://stackoverflow.com/questions/323640/can-i-convert-a-c-sharp-string-value-to-an-escaped-string-literal
        private static string ToLiteral(string input)
        {
            return Regex.Escape(input);
        }

        public String ConcatMatrices<T>(T[,] matrice)
        {
            string concat = "";
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                string line = "";
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    T to = matrice[i, j];
                    if (to == null)
                    {
                        line += "NULL";
                    }
                    else
                    {
                        line += ToLiteral(to.ToString());
                    }
                    if (j != matrice.GetLength(1) - 1)
                    {
                        line += ", ";
                    }
                }
                if (i != 0)
                {
                    concat += "\n";
                }
                concat += line;
            }

            return concat;
        }
    }
}
