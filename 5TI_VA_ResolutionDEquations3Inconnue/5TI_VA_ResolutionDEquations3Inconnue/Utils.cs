using System.Text.RegularExpressions;

namespace _5TI_VA_ResolutionDEquations3Inconnue;

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

    private static Regex regex = new Regex("(?:[\\-+]?[0-9,.]+x)?(?:[\\-+]?[0-9,.]+y)?(?:[\\-+]?[0-9,.]+z)?=(?:[\\-]?[0-9,.]+)", RegexOptions.IgnoreCase); 
    public double[] QuestionneUtilisateurEquation3(String question)
    {
        string unparsedEq = QuestionneUtilisateur(question, (str) => regex.IsMatch(str.Replace(" ", "")));
        unparsedEq.Replace(" ", "");
        
        double[] equation = new double[4];
        string num = "";
        for (int i = 0; i <  unparsedEq.Length; i++)
        {
            char c = unparsedEq[i];
            if (Char.IsDigit(c) || c == '+' || c == '-')
            {
                num += c;
            } else
            {
                if (Char.IsLetter(c))
                {
                    Double.TryParse(num, out double val1);
                    if (c == 'x')
                    {
                        if (val1 == 0)
                        {
                            equation[0] = num == "-" ? -1 : 1;
                        } else
                        {
                            equation[0] = val1;
                        }
                        
                    } else if (c == 'y')
                    {
                        if (val1 == 0)
                        {
                            equation[1] = num == "-" ? -1 : 1;
                        }
                        else
                        {
                            equation[1] = val1;
                        }
                    } else if (c == 'z')
                    {
                        if (val1 == 0)
                        {
                            equation[2] = num == "-" ? -1 : 1;
                        }
                        else
                        {
                            equation[2] = val1;
                        }
                    }

                    num = "";
                }
            }
        }

        if (Double.TryParse(num, out double val2))
        {
            equation[3] = val2;
        }

        return equation;
    }
}