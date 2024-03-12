namespace _5TI_AlexandreVandervoort_ManipulationMatrices;
internal struct Matrices
{
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
                    line += to.ToString();
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

    public int[,] GenereRandMatrice(int x, int y)
    {
        int[,] matrice = new int[x, y];

        Random rand = new Random();
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                matrice[i, j] = rand.Next(0, 100);
            }
        }

        return matrice;
    }

    public bool AdditionneMatrices(int[,] matrice1, int[,] matrice2, out int[,] fusionne)
    {
        bool resultat = true;

        fusionne = new int[matrice1.GetLength(0), matrice1.GetLength(1)];
        if (matrice1.GetLength(0) != matrice2.GetLength(0) && matrice1.GetLength(1) != matrice2.GetLength(1))
        {
            return false;
        }
        for (int i = 0; i < fusionne.GetLength(0); i++)
        {
            for (int j = 0; j < fusionne.GetLength(1); j++)
            {
                if (((long)matrice1[i, j] + matrice2[i, j] >= 2_147_483_646) ||
                ((long)matrice1[i, j] + matrice2[i, j] <= -2_147_483_646))
                {
                    return false;
                }
                fusionne[i, j] = matrice1[i, j] + matrice2[i, j];
            }
        }

        return resultat;
    }


    public bool MultiplieMatrices(int[,] matrice1, int[,] matrice2, out int[,] fusionne)
    {
        bool resultat = true;

        fusionne = new int[matrice2.GetLength(0), matrice1.GetLength(1)];
        if (matrice1.GetLength(0) != matrice2.GetLength(1))
        {
            return false;
        }

        for (int i = 0; i < fusionne.GetLength(0); i++) {
            for (int j = 0; j < fusionne.GetLength(1); j++) {
                int total = 0;
                for (int k = 0; k < matrice1.GetLength(0); k++) {
                    if (((long) matrice1[i,k] + matrice2[i,k]) >= 2_147_483_646 || ((long) matrice1[i,k] + matrice2[i,k]) <= -2_147_483_646 ||
                    (long) matrice1[i,k] + matrice2[i,k] + total >= 2_147_483_646 || (long) matrice1[i,k] + matrice2[i,k] + total <= -2_147_483_646) {
                        return false;
                    }

                    total += matrice1[i, k] * matrice2[k,j];
                }

                fusionne[i,j] = total;
            }
        }

        return resultat;
    }
}