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
