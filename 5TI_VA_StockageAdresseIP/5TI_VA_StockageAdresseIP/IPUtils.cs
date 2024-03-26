namespace _5TI_VA_StockageAdresseIP
{
    internal struct IPUtils
    {
        public struct IP
        {
            public string nom;
            public byte[] adresse;
            public IP()
            {
                nom = "";
                adresse = new byte[4];
            }
        }

        public bool AjouteAdresseIP(ref byte[][] adresses, byte[] adresseIP)
        {
            bool resultat = false;
            for (int i = 0; i < adresses.Length; i++)
            {
                if (adresses[i] == null)
                {
                    adresses[i] = adresseIP;
                    resultat = true;
                    break;
                }
            }
            return resultat;
        }

        public bool AjouteNom(ref string[] noms, string nom)
        {
            bool resultat = false;
            for (int i = 0; i < noms.Length; i++)
            {
                if (noms[i] == null)
                {
                    noms[i] = nom;
                    resultat = true;
                    break;
                }
            }
            return resultat;
        }


        public string ConcateneAdresse(byte[] adresseIP)
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

        public string ConcateneTout(byte[][] adresses, string[] noms)
        {
            if (adresses.Length != 20 || noms.Length != 20)
            {
                throw new ArgumentException("La taille est requise d'être de 20.");
            }

            string concatene = "";

            for (int i = 0; i < 20; i++)
            {
                string ligne = "";
                byte[] adresse = adresses[i];
                string nom = noms[i];

                if (nom == null || nom == "")
                {
                    ligne += "INCONNU: ";
                } else
                {
                    ligne += nom + ": ";
                }

                if (adresse == null)
                {
                    ligne += "0.0.0.0";
                } else
                {
                    ligne += ConcateneAdresse(adresse);
                }

                concatene += ligne;
                if (i != (20 - 1))
                {
                    concatene += "\n";
                }
            }

            return concatene;
        }

        public void LireAdresseIP(ref byte[] adresse)
        {
            Utils utils = new Utils();
            if (adresse.Length != 4)
            {
                throw new ArgumentException("Une Adresse IP est d'une taille de 4, pas plus, pas moins");
            }

            for (int i = 0; i < 4; i++)
            {
                adresse[i] = utils.QuestionneUtilisateurByte("Quel est le nombre en " + (i + 1) + (i == 0 ? "ere" : "eme") + " position");
            }
        }
    }
}
