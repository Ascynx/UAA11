namespace _5TI_AlexandreVandervoort_ManipulationMatrices;

internal struct Utils
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
}