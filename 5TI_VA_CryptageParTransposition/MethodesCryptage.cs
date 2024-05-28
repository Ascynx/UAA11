using System.Security.Cryptography;

namespace _5TI_VA_CryptageParTransposition
{
    struct MethodesCryptage
    {
        /// <summary>
        /// Fonction qui retire tout caractère dit "whitespace" et qui met toutes lettres en majuscules.
        /// </summary>
        /// <param name="str">La phrase à nettoyer</param>
        /// <returns>La phrase sans espace et tout en majuscule</returns>
        public String NettoyeString(String str)
        {
            string apres = "";
            int strLen = str.Length;
            for (int i = 0; i < strLen; i++)
            {
                char car = str[i];
                if (!Char.IsWhiteSpace(car))
                {
                    if (car >= 97 && car <= 122)
                    {
                        apres += (char)((car - 97) + 65);
                    } else
                    {
                        apres += car;
                    }
                }

            }

            return apres;
        }

        /// <summary>
        /// Cree une matrice de caractères usé dans la méthode de cryptage
        /// </summary>
        /// <param name="cle">La clé</param>
        /// <param name="phrase">La phrase</param>
        /// <param name="matrice">La matrice</param>
        public void CreeMatrice(string cle, string phrase, out char[,] matrice)
        {
            int dimension = (phrase.Length / cle.Length) + 2;
            if (phrase.Length % cle.Length > 0)
            {
                dimension++;
            }

            matrice = new char[dimension, cle.Length];
        }

        /// <summary>
        /// écrit la clé et la phrase dans la matrice
        /// </summary>
        /// <param name="cle">La clé de cryptage</param>
        /// <param name="phrase">La phrase à crypter</param>
        /// <param name="matrice">La matrice où l'on va insérer la clé et la phrase</param>
        public void EcritChainesDansMatrice(string cle, string phrase, ref char[,] matrice)
        {
            for (int i = 0; i < cle.Length; i++)
            {
                matrice[0, i] = cle[i];
            }

            int j = 0;
            for (int k = 2; k < matrice.GetLength(0); k++)
            {
                int l = 0;
                while (l < matrice.GetLength(1) && j < phrase.Length)
                {
                    matrice[k, l++] = phrase[j++];
                }
            }
        }

        /// <summary>
        /// Trie la 1ère ligne de la matrice donnée
        /// </summary>
        /// <param name="matrice">La matrice à trier</param>
        public void TrieLigne(ref char[,] matrice)
        {
            bool permut = false;
            do
            {
                permut = false;
                for (int i = 0; i < matrice.GetLength(1) - 1; i++)
                {
                    if (matrice[0, i] > matrice[0, i + 1])
                    {
                        char x = matrice[0, i];
                        matrice[0, i] = matrice[0, i + 1];
                        matrice[0, i + 1] = x;
                        permut = true;
                    }
                }
            } while (permut);
        }

        /// <summary>
        /// Crée la matrice qui va servir à crypter la matrice principale
        /// </summary>
        /// <param name="cle">La clé de cryptage</param>
        /// <param name="matriceTriee">La matrice de cryptage (outil)</param>
        public void CreeMatriceOutil(string cle, out char[,] matriceTriee)
        {
            matriceTriee = new char[3, cle.Length];
            for (int i = 0; i < matriceTriee.GetLength(1); i++)
            {
                matriceTriee[0, i] = cle[i];
                matriceTriee[2, i] = (char)0;
            }

            TrieLigne(ref matriceTriee);
            for (int i = 0; i < matriceTriee.GetLength(1); i++)
            {
                matriceTriee[1, i] = (char) (i + 1);
            }
        }

        /// <summary>
        /// Reporte l'ordre la matrice outil sur la matrice principale
        /// </summary>
        /// <param name="matrice">La matrice principale</param>
        /// <param name="matriceOutil">La matrice outil</param>
        public void ReporteOrdre(ref char[,] matrice, ref char[,] matriceOutil)
        {
            for (int i = 0; i < matrice.GetLength(1); i++)
            {
                bool trouve = false;
                int j = 0;
                while (trouve == false && j < matriceOutil.GetLength(1))
                {
                    if (matrice[0, i] == matriceOutil[0, j] && matriceOutil[2, j] != '1')
                    {
                        matrice[1, i] = matriceOutil[1, j];
                        matriceOutil[2, j] = '1';
                        trouve = true;  
                    }
                    j++;
                }
            }
        }

        /// <summary>
        /// convertit la matrice de cryptage en texte encrypté
        /// </summary>
        /// <param name="matrice">La matrice de cryptage</param>
        /// <returns>La matrice sous forme de texte encrypté</returns>
        public string ConstruitCryptage(char[,] matrice)
        {
            string chaine = "";
            int num = 0;
            while (num != matrice.GetLength(1))
            {
                for (int i = 0; i < matrice.GetLength(1); i++)
                {
                    if (matrice[1, i] == (char) (num + 1))
                    {
                        for (int j = 2; j < matrice.GetLength(0); j++)
                        {
                            chaine += matrice[j, i];
                        }
                        chaine += " ";
                        num++;
                    }
                    
                }
            }
            return chaine;
        }
    }
}
