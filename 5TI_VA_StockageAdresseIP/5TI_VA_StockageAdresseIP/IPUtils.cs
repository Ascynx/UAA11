namespace _5TI_VA_StockageAdresseIP
{
    internal struct IPUtils
    {
        public struct AdresseIP
        {
            public string nom;
            public byte[] adresse;
            public AdresseIP()
            {
                nom = "";
                adresse = new byte[4];
            }

            public override string ToString()
            {
                return (nom == null ? "INCONNU" : nom) + ": " + (adresse == null ? "0.0.0.0" : ConcateneAdresse(adresse));
            }
        }

        /// <summary>
        /// Fonction booléenne qui modifie le tableau reprenant toutes les adresses encodé
        /// pour lui en ajouter une si le tableau n'est pas déja plein.
        /// Elle met aussi à jour le nombre d'adresses déja présentes dans le tableau.
        /// Si l'ajout a pu se faire, elle renvoie true, sinon elle renvoie false
        /// </summary>
        /// <param name="adresses">Liste d'adresses IP/Noms (taille max = 20)</param>
        /// <param name="adresseIP">l'adresse IP que l'on veut enregistrer</param>
        /// <returns>Si l'ajout pu se faire</returns>
        public bool AjouteAdresseIP(ref AdresseIP[] adresses, byte[] adresseIP)
        {
            bool resultat = false;
            for (int i = 0; i < adresses.Length; i++)
            {
                if (AdresseEstVide(adresses[i].adresse))
                {
                    adresses[i].adresse = adresseIP;
                    resultat = true;
                    break;
                }
            }
            return resultat;
        }

        /// <summary>
        /// Fonction booléenne aqui modifie le tableau reprenant toutes les adresses encodée en lui,
        /// dans le but, si possible, d'ajouter un nom au tableau.
        /// Si l'ajout pu se faire, elle renvoie true, sinon, elle renvoie false
        /// </summary>
        /// <param name="adresses">Liste d'adresses IP/Noms (taille max = 20)</param>
        /// <param name="nom">le nom que l'on veut enregistrer</param>
        /// <returns>Si l'ajout pu se faire</returns>
        public bool AjouteNom(ref AdresseIP[] adresses, string nom)
        {
            bool resultat = false;
            for (int i = 0; i < adresses.Length; ++i)
            {
                if (adresses[i].nom == null)
                {
                    adresses[i].nom = nom;
                    resultat = true;
                    break;
                }
            }
            return resultat;
        }

        /// <summary>
        /// Fonction qui renvoie une chaîne de caractère contenant les valeurs se trouvant
        /// dans une ligne donnée du tableau d'adresses IP.
        /// L'adresse est structurée avec des points ( par exemple 192.168.1.1 )
        /// </summary>
        /// <param name="adresseIP">Une adresse IP</param>
        /// <returns>L'adresse IP donnée sous forme d'un string</returns>
        /// <exception cref="ArgumentException">Si la taille d'adresse IP est inférieur ou supérieur à 4</exception>
        public static string ConcateneAdresse(byte[] adresseIP)
        {
            if (adresseIP.Length != 4) {
                throw new ArgumentException("Une Adresse IP est d'une taille de 4, pas plus, pas moins");
            }

            string adresseStr = "";

            for (int i = 0; i < adresseIP.Length; i++)
            {
                adresseStr += adresseIP[i];
                if (i != adresseIP.Length - 1)
                {
                    adresseStr += ".";
                }
            }

            return adresseStr;
        }

        /// <summary>
        /// Fonction qui crée une chaîne de caractères contenant les adresses et noms en les associant
        /// </summary>
        /// <param name="adresses">Tableau contenant les noms et adresses</param>
        /// <returns>Une chaîne de caractère contenant les noms et adresses associées.</returns>
        /// <exception cref="ArgumentException">Si la taille de adresses n'est pas 20</exception>
        public string ConcateneTout(AdresseIP[] adresses)
        {
            if (adresses.Length != 20)
            {
                throw new ArgumentException("Taille d'adresse doit être de 20.");
            }

            string concatene = "";
            for (int i = 0; i < adresses.Length; i++)
            {
                AdresseIP ip = adresses[i];
                concatene += ip.ToString();
                if (i != (adresses.Length - 1))
                {
                    concatene += "\n";
                }
            }

            return concatene;
        }

        /// <summary>
        /// Procédure qui permet de remplir un tableau de 4 places pour contenir une Adresse IP complète
        /// </summary>
        /// <param name="adresse">tableau pour contenir l'adresse IP</param>
        /// <exception cref="ArgumentException">Si le tableau donné n'as pas une taille de 4.</exception>
        public void LireAdresseIP(ref byte[] adresse)
        {
            Utils utils = new Utils();
            if (adresse.Length != 4)
            {
                throw new ArgumentException("Une Adresse IP est d'une taille de 4, pas plus, pas moins");
            }

            for (int i = 0; i < 4; i++)
            {
                adresse[i] = utils.QuestionneUtilisateurByte("Quel est l'ID en " + (i + 1) + (i == 0 ? "ere" : "eme") + " position");
            }
        }

        /// <summary>
        /// Fonction permettant de voir si l'adresse dans la fonction est considérée vide ou pas
        /// </summary>
        /// <param name="adresse">L'adresse</param>
        /// <returns>Si toutes les ID de l'adresse IP sont égaux à 0.</returns>
        public bool AdresseEstVide(byte[] adresse)
        {
            bool res = false;
            for (int i = 0; i < 4; i++)
            {
                if (adresse[i] != 0)
                {
                    res = true;
                    break;
                }
            }

            return res;
        }
    }
}
