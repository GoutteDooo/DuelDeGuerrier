using DuelDeGuerrier.Classes;

namespace DuelDeGuerrier
{
    internal class Program
    {
        static List<Guerrier> fourmisGuerrieres = new List<Guerrier>(); // Liste contenant les fourmis guerrières instanciées
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
                        FourmiNoire fourmiNoire = CreerFourmiNoire(); // On crée une nouvelle instance de FourmiNoire (nommée fourmiTest)
                        Console.WriteLine("Une fourmi noire a été créée !");
                        fourmiNoire.AfficherInfos(); // On utilise la méthode AfficherInfos de la classe FourmiNoire
                        fourmisGuerrieres.Add(fourmiNoire); // Ajouter l'instance de fourmiNoire à la liste des fourmis guerrières
                        break;

                    case "2": // Si utilisateur veut créer une fourmi rousse
                        FourmiRousse fourmiRousse = CreerFourmiRousse();
                        Console.WriteLine("Une fourmi rousse a été créée !");
                        fourmiRousse.AfficherInfos();
                        fourmisGuerrieres.Add(fourmiRousse);
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

        /**
         * Affiche la liste des fourmis guerrières qui ont été instanciées par le joueur.
         */
        public static void AfficherListeGuerriers()
        {
            Console.WriteLine("Les fourmis guerrières sont : ???");
        }
    }
}
