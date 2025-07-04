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
            Console.WriteLine("1. Créer une fourmi guerrière");
            Console.WriteLine("2. Supprimer une fourmi guerrière");
            Console.WriteLine("3. Afficher la liste des fourmis guerrières");
            Console.WriteLine("4. Lancer un tournoi");
            Console.WriteLine("5. Afficher l'historique");
            Console.WriteLine("0. Quitter\n");
            Console.Write("Veuillez entrer un nombre: ");

            ConsoleKeyInfo saisie = Console.ReadKey();

            // Une fois que l'utilisateur a fait une saisie, on nettoie la console
            Console.Clear();
            string options = "123450";
            // Si le joueur saisie une autre option que celles disponibles
            if (!options.Contains(saisie.KeyChar))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Veuillez saisir une des options disponibles SVP.");
                Console.ResetColor();
                AfficherMenuPrincipal();
            }
            if (saisie.KeyChar == '1') // Si le joueur veut créer un guerrier
            {
                AjouterGuerrier();
            }
            if (saisie.KeyChar == '2') // Si le joueur veut supprimer une guerrière
            {
                SupprimerGuerrier();
            }

            if (saisie.KeyChar == '3') // Si l'utilisateur veut voir la liste des fourmis guerrières
            {
                AfficherFourmisGuerrieres();
            }
            if (saisie.KeyChar == '4') // Si le joueur veut lancer le tournoi
            {
                LancerTournoi();
            }

            if (saisie.KeyChar == '5') // Si le joueur affiche l'historique
            {
                AfficherHistorique();

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
                char saisie = Console.ReadKey().KeyChar;

                Console.Clear(); // Afficher le texte en lien avec la saisie et réafficher le sous-menu
                Console.ForegroundColor = ConsoleColor.Green;

                switch (saisie)
                {
                    case '1': // Si utilisateur veut créer une fourmi noire
                        FourmiNoire fourmiNoire = CreerFourmiNoire(); // On crée une nouvelle instance de FourmiNoire (nommée fourmiTest)
                        Console.WriteLine("Une fourmi noire a été créée !");
                        fourmiNoire.AfficherInfos(); // On utilise la méthode AfficherInfos de la classe FourmiNoire
                        fourmisGuerrieres.Add(fourmiNoire); // Ajouter l'instance de fourmiNoire à la liste des fourmis guerrières
                        break;

                    case '2': // Si utilisateur veut créer une fourmi rousse
                        FourmiRousse fourmiRousse = CreerFourmiRousse();
                        Console.WriteLine("Une fourmi rousse a été créée !");
                        fourmiRousse.AfficherInfos();
                        fourmisGuerrieres.Add(fourmiRousse);
                        break;

                    case '0': // Si utilisateur veut quitter le sous-menu
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
            return new FourmiNoire("pikachu", 30, 3, true);
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
        public static void AfficherFourmisGuerrieres()
        {
            Console.WriteLine("Les fourmis guerrières sont :");
            // Pour chaque fourmiGuerriere dans la liste fourmisGuerrieres
            foreach (Guerrier fourmiGuerriere in fourmisGuerrieres)
            {
                // On affiche les infos de la fourmiGuerriere actuelle
                fourmiGuerriere.AfficherInfos();
            }
        }

        /**
         * Fait se combattre toutes les fourmis de la liste fourmisGuerrieres jusqu'à ce qu'il n'en reste plus qu'une victorieuse
         * Lorsqu'il n'en reste plus qu'une, affiche la fourmi victorieuse
         */
        public static void LancerTournoi()
        {
            int round = 1;

            while (fourmisGuerrieres.Count > 1)
            {
                Console.WriteLine($"--- ROUND n°{round} ---");
                Combattre(); // Fait se combattre les deux premières fourmis de la liste
                // S'il ne reste plus qu'une seule fourmi guerrière dans la liste
                if (fourmisGuerrieres.Count == 1)
                {
                    Console.WriteLine($"La fourmi {fourmisGuerrieres[0].GetNom()} a remporté le tournoi!");
                    break;
                }
                round++;
            }
        }

        /**
         * Fait se combattre les deux premières fourmis de la liste fourmisGuerrieres
         * Jusqu'à ce qu'une des deux gagne.
         * Lorsqu'une fourmi remporte son duel, elle récupère tout ses PVs par défaut
         */
        public static void Combattre()
        {
            var fourmi1 = fourmisGuerrieres[0];
            var fourmi2 = fourmisGuerrieres[1];

            while (true)
            {
                Console.WriteLine($"Combat entre {fourmi1.GetNom()} et {fourmi2.GetNom()}");
                int degats = fourmi1.Attaquer();
                Console.WriteLine($"{fourmi1.GetNom()} attaque {fourmi2.GetNom()} avec des dégâts de {degats}");
                fourmi2.SubirDegats(degats);
                fourmi2.AfficherInfos();

                if (fourmi2.GetPointsDeVie() <= 0)
                {
                    fourmi2.SetPointsDeVie(0);
                    Console.WriteLine($"fourmi2 PV <= 0: {fourmi2.GetPointsDeVie()}");
                    fourmisGuerrieres.Remove(fourmi2);
                    break;
                }
                else
                {
                    Console.WriteLine($"fourmi2 PV > 0: {fourmi2.GetPointsDeVie()}");
                }


                //Console.WriteLine("Le tournoi interrompu par le joueur.");
            }
        }

        public static void SuppprimerGuerrier()
        {
            Console.WriteLine("Entrez le nom du guerrier a supprimer:");
            string nom = Console.ReadLine();

            //Si le nom entrée par le joueur existe dans la liste des fourmis 
            //Alors, supprimer la fourmi dont le nom correspond 
            //Sinon, redemandez joueur une entrée 



            foreach (Guerrier fourmiGuerriere in fourmisGuerrieres)
            {
                if (nom == fourmiGuerriere.GetNom())
                {
                    fourmisGuerrieres.Remove(fourmiGuerriere);
                    break;
                }
            }

        }

    }
}
