using DuelDeGuerrier.Classes;

namespace DuelDeGuerrier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AfficherMenuPrincipal();
        }

        public static void AfficherMenuPrincipal()
        {
            Console.WriteLine("--- Menu principal ---");
            Console.WriteLine("1. Créer un guerrier");
            Console.WriteLine("2. Afficher un guerrier");
            Console.WriteLine("3. Lancer un tournoi\n");
            Console.WriteLine("0. Quitter\n");
            Console.WriteLine("Veuillez entrer un nombre");
            string saisie = Console.ReadLine();

            if (saisie == "1") // Si le joueur veut créer un guerrier
            {
                AjouterGuerrier();
            }
        }

        /**
         * Permet de créer une fourmi guerrière (Guerrier) personnalisé
         */
        public static void AjouterGuerrier()
        {
            Console.Clear(); // Enlever tout le texte du menu principal
            bool estActif = true; // Tant qu'il est sur true, le sous-menu est actif
            while (estActif == true)
            {
                Console.WriteLine(
                    $"---- Créer un Guerrier ----\n" +
                    $"\n" +
                    $"\n" +
                    $"Quel type de fourmi souhaitez-vous créer ?\n" +
                    $"\n" +
                    $"1. Fourmi Noire (Défense élevée)\n" +
                    $"2. Fourmi Rousse (Attaque élevée)\n" +
                    $"\n" +
                    $"0. Quitter le sous-menu\n");
                Console.Write("> ");
                string saisie = Console.ReadLine();

                Console.Clear(); // Afficher le texte en lien avec la saisie et réafficher le sous-menu
                Console.ForegroundColor = ConsoleColor.Green;

                switch (saisie)
                {
                    case "1": // Si utilisateur veut créer une fourmi noire
                        FourmiNoire fourmiTest = CreerFourmiNoire(); // On crée une nouvelle instance de FourmiNoire (nommée fourmiTest)
                        Console.WriteLine("Une fourmi noire a été créée !");
                        fourmiTest.AfficherInfos(); // On utilise la méthode AfficherInfos de la classe FourmiNoire
                        break;

                    case "2": // Si utilisateur veut créer une fourmi rousse
                        FourmiRousse fourmiRousse = CreerFourmiRousse();
                        Console.WriteLine("Une fourmi rousse a été créée !");
                        fourmiRousse.AfficherInfos();
                        break;

                    case "0": // Si utilisateur veut quitter le sous-menu
                        estActif = false;
                        break;

                    default:
                        break;
                }
                Console.ResetColor();
            }
            // Retourner au menu principal
            AfficherMenuPrincipal();
        }
        /**
         * Retourne une instance de FourmiNoire
         */
        public static FourmiNoire CreerFourmiNoire()
        {
            return new FourmiNoire("pikachu",30,3,true);
        }

        /**
         * Retourne une instance de FourmiRousse
         */
        public static FourmiRousse CreerFourmiRousse()
        {
            return new FourmiRousse("dracofeu", 50, 5);
        }


    }
}
