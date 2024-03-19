namespace _5TI_VA_ResolutionDEquations3Inconnue;
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
            concat += "\n" + line;
        }

        return concat;
    }

    public T[,] CloneMatrice<T>(T[,] matrice)
    {
        T[,] clone = new T[matrice.GetLength(0), matrice.GetLength(1)];
        for (int i = 0; i < matrice.GetLength(0); i++)
        {
            for (int j = 0; j < matrice.GetLength(1); j++)
            {
                clone[i, j] = matrice[i, j];
            }
        }
        return clone;
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

    public double[,] ResousEquationPivotDeGauss(double[,] equations)
    {
        double[,] resultat = new double[3, 4];
        if (equations.GetLength(0) != resultat.GetLength(0) || equations.GetLength(1) != resultat.GetLength(1)) {
            throw new ArgumentOutOfRangeException(nameof(equations) + "doit être de dimensions x= 3, y = 4");
        }
        double[,] inter = CloneMatrice(equations);


        //TODO apparement il y a un problème qqpart ici.
        for (int pivot = 0; pivot < resultat.GetLength(0); pivot++)
        {
            double coeff = inter[pivot, pivot];
            if (coeff != 1)
            {
                for (int j = 0; j < resultat.GetLength(0); j++)
                {
                    inter[pivot, j] /= coeff;
                }
            }

            for (int k = pivot; k  < resultat.GetLength(0); k++)
            {
                double val = inter[k, pivot];
                bool positif = val > 0;
                for (int l = 0; l < Math.Abs(val); l++)
                {
                    for (int m = 0; m < resultat.GetLength(1); m++) {
                        double valeurPivot = inter[pivot, m];
                        if (positif)
                        {
                            inter[k, m] -= valeurPivot;
                        } else
                        {
                            inter[k,m] += valeurPivot;
                        }
                    }
                }
            }
        }

        return resultat;
    }
}