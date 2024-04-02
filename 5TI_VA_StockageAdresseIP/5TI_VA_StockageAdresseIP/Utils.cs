namespace _5TI_VA_StockageAdresseIP
{
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

        public String QuestionneUtilisateur(String question)
        {
            return QuestionneUtilisateur(question, (str) => true);
        }

        public int QuestionneUtilisateurInt(String question)
        {
            return Int32.Parse(QuestionneUtilisateur(question, (str) => Int32.TryParse(str, out int val)));
        }

        /// <summary>
        /// Implémentation de QuestionneUtilisateur qui demande à l'utilisateur pour des bytes (nombre entre 0 et 255 inclus)
        /// </summary>
        /// <param name="question">La question posée</param>
        /// <returns>un byte</returns>
        public byte QuestionneUtilisateurByte(String question)
        {
            return Byte.Parse(QuestionneUtilisateur(question, (str) => Byte.TryParse(str, out byte val)));
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
}
