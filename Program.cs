using DuelDeGuerrier.Classes;
using System.Security.Cryptography.X509Certificates;

namespace DuelDeGuerrier
{
    internal class Program
    {
        static List<Guerrier> fourmisGuerrieres = new List<Guerrier>(); // Liste contenant les fourmis guerrières instanciées
        static List<Tournoi> historique = new List<Tournoi>(); // Liste contenant les tournois lancés et terminés
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
            // Si le joueur saisie une autre option que celles disponibles
            if (!LireChoixUtilisateur(0, 5, saisie))
            {
                AfficherErreur("Veuillez saisir une des options disponibles SVP.");
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
            if (saisie.KeyChar == '0') // Si le joueur veut quitter le programme
            {
                QuitterProgramme();
            }
        }

        /**
         * Permet de créer une fourmi guerrière (Guerrier) personnalisé
         */
        public static void AjouterGuerrier()
        {
            Console.Clear(); // Enlever tout le texte du menu principal
            bool estActif = true; // Tant qu'il est sur true, le sous-menu est actif
            while (estActif)
            {
                AfficherMenuAjouterGuerrier();
                Console.Write("> ");
                char saisie = Console.ReadKey().KeyChar;

                Console.Clear(); // Afficher le texte en lien avec la saisie et réafficher le sous-menu
                Console.ForegroundColor = ConsoleColor.Green;

                switch (saisie)
                {
                    case '1': // Si joueur veut créer une fourmi guerrière basique
                        InsererGuerriere("Guerrier");
                        break;

                    case '2': // Si utilisateur veut créer une fourmi noire
                        InsererGuerriere("FourmiNoire");
                        break;

                    case '3': // Si utilisateur veut créer une fourmi rousse
                        InsererGuerriere("FourmiRousse");
                        break;

                    case '4': // Si utilisateur veut créer une fourmi balle de fusil
                        InsererGuerriere("BalleDeFusil");
                        break;

                    case '0': // Si utilisateur veut quitter le sous-menu
                        estActif = false;
                        break;

                    default:
                        break;
                }
                Console.ResetColor();
            }
            // Retourner au menu principal lorsque joueur a appuyé sur '0'
            AfficherMenuPrincipal();
        }

        /**
         * Affiche le sous-menu pour ajouter un guerrier à la liste fourmisGuerrieres
         */
        public static void AfficherMenuAjouterGuerrier()
        {
            Console.WriteLine(
                $"---- Créer un Guerrier ----\n" +
                $"\n" +
                $"\n" +
                $"Quel type de fourmi souhaitez-vous créer ?\n" +
                $"\n" +
                $"1. Fourmi Guerrière (Stats équilibrées)\n" +
                $"2. Fourmi Noire (Défense élevée)\n" +
                $"3. Fourmi Rousse (Attaque élevée)\n" +
                $"4. Fourmi Balle De Fusil (Peut one shot mais PV faible)\n" +
                $"\n" +
                $"0. Quitter le sous-menu\n");
        }

        /**
         * Crée une nouvelle instance de la classe passée en paramètre (si elle existe)
         * Ensuite, insère celle-ci dans la liste fourmisGuerrieres
         */
        public static void InsererGuerriere(string classe)
        {
            // TODO: Générer un nom aléatoire dans le futur
            /* -- Statistiques de la future instance -- */
            /* ---------------------------------------- */
            Console.Write("Quel nom souhaitez-vous lui donner ? (non vide, alphanumérique) ");
            string nom = LireNomValide();
            Console.Write("\nCombien de PVs souhaitez-vous lui distribuer ? (entre 10 et 100) ");
            int pvs = LireEntierValide(10,100);
            Console.Write("\nCombien de dés d'attaque souhaitez-vous lui donner ? (entre 1 et 10) ");
            int desAttaque = LireEntierValide(1, 10);

            if (classe.Equals("Guerrier"))
            {
                Guerrier fourmiGuerriere = CreerFourmiGuerriere(nom, pvs, desAttaque);
                Console.WriteLine("Une fourmi guerrière a été créée!");
                fourmiGuerriere.AfficherInfos();
                fourmisGuerrieres.Add(fourmiGuerriere);
            }
            else if (classe.Equals("FourmiNoire"))
            {
                Console.WriteLine("Portera-t-elle une armure lourde ? (O/n)");
                bool armureLourde = LireBoolValide();
                FourmiNoire fourmiNoire = CreerFourmiNoire(nom, pvs, desAttaque, armureLourde); // On crée une nouvelle instance de FourmiNoire (nommée fourmiTest)
                Console.WriteLine("Une fourmi noire a été créée !");
                fourmiNoire.AfficherInfos(); // On utilise la méthode AfficherInfos de la classe FourmiNoire
                fourmisGuerrieres.Add(fourmiNoire); // Ajouter l'instance de fourmiNoire à la liste des fourmis guerrières
            }
            else if (classe.Equals("FourmiRousse"))
            {
                FourmiRousse fourmiRousse = CreerFourmiRousse(nom, pvs, desAttaque);
                Console.WriteLine("Une fourmi rousse a été créée !");
                fourmiRousse.AfficherInfos();
                fourmisGuerrieres.Add(fourmiRousse);
            }
            else if (classe.Equals("BalleDeFusil"))
            {
                Console.WriteLine("Combien de mana aura-t-elle ? ");
                int mana = LireEntierValide(10, 100);
                BalleDeFusil balleDeFusil = CreerFourmiBalleDeFusil(nom, pvs, desAttaque, mana);
                Console.WriteLine("Une fourmi Balle De Fusil a été créée!");
                balleDeFusil.AfficherInfos();
                fourmisGuerrieres.Add(balleDeFusil);
            }
        }

        /**
         * Retourne une instance de FourmiNoire
         */
        public static FourmiNoire CreerFourmiNoire(string nom, int pvs, int desAttaque, bool armureLourde)
        {
            return new FourmiNoire(nom, pvs, desAttaque, armureLourde);
        }

        /**
         * Retourne une instance de FourmiRousse
         */
        public static FourmiRousse CreerFourmiRousse(string nom, int pvs, int desAttaque)
        {
            return new FourmiRousse(nom, pvs, desAttaque);
        }

        /**
         * Retourne une instance Guerrier avec stats aléatoires
        */
        public static Guerrier CreerFourmiGuerriere(string nom, int pvs, int desAttaque)
        {
            return new Guerrier(nom, pvs, desAttaque);
        }

        public static BalleDeFusil CreerFourmiBalleDeFusil(string nom, int pvs, int desAttaque, int mana)
        {
            return new BalleDeFusil(nom, pvs, desAttaque, mana);
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
            RetourMenuPrincipal();
        }

        /**
         * Fait se combattre toutes les fourmis de la liste fourmisGuerrieres jusqu'à ce qu'il n'en reste plus qu'une victorieuse
         * Lorsqu'il n'en reste plus qu'une, affiche la fourmi victorieuse
         */
        public static void LancerTournoi()
        {
            /* -- Déclarations des données du tournoi -- */
            /* ----------------------------------------- */
            int numeroDeTournoi = historique.Count + 1;
            int nbParticipants = fourmisGuerrieres.Count;
            DateTime dateDuTournoi = DateTime.Now;

            // Gestion d'erreurs
            // S'il n'y a aucune fourmi dans la liste
            if (fourmisGuerrieres.Count == 0)
            {
                AfficherErreur("Aucune fourmi n'est présente dans l'arène !");
                RetourMenuPrincipal();
            }
            int round = 1; // Affichage sympa pour les rounds pendant le tournoi
            while (fourmisGuerrieres.Count > 1)
            {
                Console.WriteLine($"--- ROUND n°{round} ---");
                Combattre(); // Fait se combattre les deux premières fourmis de la liste
                round++;
            }
            // S'il ne reste plus qu'une seule fourmi guerrière dans la liste
            if (fourmisGuerrieres.Count == 1)
            {
                Console.WriteLine($"La fourmi {fourmisGuerrieres[0].GetNom()} a remporté le tournoi!");

                /* Crée une nouvelle instance de Tournoi et l'insérer dans l'historique */
                Guerrier vainqueur = fourmisGuerrieres[0];
                historique.Insert(0, new Tournoi(numeroDeTournoi, vainqueur, nbParticipants, dateDuTournoi));
                //TEST
                Console.WriteLine("Un tournoi a été ajouté dans l'historique.");

                //Entrée utilisateur pour revenir au menu principal
                RetourMenuPrincipal();
            }
            else
            {
                throw new Exception($"Erreur lors de la fin du tournoi. Il reste {fourmisGuerrieres.Count} dans la liste.");
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

        /**
         * Demande au joueur le nom de la fourmi à supprimer et la supprime si elle existe dans la liste
         */
        public static void SupprimerGuerrier()
        {
            bool suppressionFaite = false; // Vérifie que la suppression a bien été faite

            // Tant que le joueur entre un nom inexistant dans la liste (que la suppression n'a pas été effectuée)
            while (!suppressionFaite)
            {
                Console.WriteLine($"Liste des fourmis guerrières: {String.Join(" ,", fourmisGuerrieres.Select(f => f.GetNom()))}");
                // Entrée utilisateur
                Console.WriteLine("Entrez le nom de la fourmi guerrière à supprimer ('exit' pour quitter):");
                string nom = Console.ReadLine();
                if (nom == "exit")
                    break;

                // Pour chaque fourmi guerrière de la liste fourmisGuerrieres
                foreach (Guerrier fourmiGuerriere in fourmisGuerrieres)
                {
                    //Si le nom entrée par le joueur est le même que celui de la fourmiGuerriere
                    if (nom == fourmiGuerriere.GetNom())
                    {
                        //Alors, supprimer la fourmi dont le nom correspond
                        Console.WriteLine($"La fourmi dont le nom est {fourmiGuerriere.GetNom()} a été supprimée de la liste.");
                        fourmisGuerrieres.Remove(fourmiGuerriere);
                        suppressionFaite = true;
                        break;
                    }
                }
                // Si le nom de la fourmi guerrière est inexistant dans la liste, renvoyer une erreur
                Console.Clear();
                // Si la suppression n'a pas été faite
                if (!suppressionFaite)
                {
                    // On affiche une erreur
                    AfficherErreur("Erreur! Le nom de la fourmi guerrière que vous avez entré est inexistant.");
                }
                else
                {
                    // On affiche la confirmation de suppression
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"La fourmi du nom de {nom} a bien été supprimée de la liste.");
                    Console.ResetColor();
                    // Et on remet suppression sur false si le joueur veut supprimer une autre fourmi guerrière
                    suppressionFaite = false;
                }
            }
            // Clear le sous-menu avant de reprendre le menu principal
            Console.Clear();
            AfficherMenuPrincipal();
        }

        /**
         * Affiche l'historique des tournois de la liste historique
         * Par exemple :
         *          --- HISTORIQUE DES TOURNOIS ---
         *          
         *      Tournoi n°2 :
         *          Vainqueur : Pikachu - Fourmi Noire
         *          Participants : 12
         *          Date de lancement : 04/07/2025 14:24
         *
         *      Tournoi n°1 :
         *          Vainqueur : Dracofeu - Fourmi Rousse
         *          Participants : 8
         *          Date de lancement : 03/07/2025 17:12
        */
        public static void AfficherHistorique()
        {
            Console.WriteLine("\t\t--- HISTORIQUE DES TOURNOIS ---\n" +
                "\n");
            foreach (Tournoi tournoi in historique)
            {
                tournoi.AfficherDonnees();
                /*
                Console.WriteLine("\n" +
                    $"\tTournoi n°{tournoi.Numero} :\n" +
                    $"\t\tVainqueur : {tournoi.Vainqueur.GetNom()} - {tournoi.Vainqueur.GetType()}\n" +
                    $"\t\tParticipants : {tournoi.NombreParticipants}\n" +
                    $"\t\tDate de lancement : {tournoi.Date}\n");*/
            }

            // Entrée utilisateur pour revenir au menu principal
            RetourMenuPrincipal();
        }

        /**
         * Affiche un message d'au revoir et quitte le programme avec un code 0
         */
        public static void QuitterProgramme()
        {
            Console.WriteLine("Merci d'avoir joué à L'Arène Des Fourmis !\n\n" +
                "A bientôt!!");
            Environment.Exit(0);
        }

        /* ------------------------- */
        /* -- LECTURE DES ENTREES -- */
        /* ------------------------- */

        /**
         * Demande une entrée utilisateur pour un nom de fourmi
         * Retourne :
         *      Une string contenant un nom valide (non vide, alphanumérique)
         */
        public static string LireNomValide()
        {
            string input = Console.ReadLine();
            // Contrôles de saisie
            while ( input == null || input.Equals("") || !input.All(char.IsLetterOrDigit))
            {
                AfficherErreur("Erreur, veuillez recommencer SVP");
                Console.ForegroundColor= ConsoleColor.Green;
                input = Console.ReadLine();
            }
            return input;
        }

        /**
         * Lit une entrée utilisateur et vérifie si elle est conforme (entre min et max)
         * Retourne l'entier entré le cas échéant
         * Sinon, une exception est levée
         */
        public static int LireEntierValide(int min, int max)
        {
            int input = Convert.ToInt32(Console.ReadLine());
            while (input < min || input > max)
            {
                AfficherErreur($"Erreur, veuillez entrer un nombre compris entre {min} et {max} svp.");
                Console.ForegroundColor = ConsoleColor.Green;
                input = Convert.ToInt32(Console.ReadLine());
            }
            return input;
        }

        /**
         * Lit une entrée utilisateur entre "o" ou "n", et redemande si une autre entrée est donnée
         * Retourne:
         *      true si l'entrée est "o"
         *      false si l'entrée est "n"
         */
        public static bool LireBoolValide()
        {
            ConsoleKeyInfo input = Console.ReadKey();
            if (char.ToLower(input.KeyChar) == 'o' || input.Key == ConsoleKey.Enter)
                return true;
            else
                return false;
        }

        /**
         * Demande une entrée utilisateur pour revenir au menu principal
         */
        static void RetourMenuPrincipal()
        {
            Console.WriteLine("Appuyez sur une touche pour revenir au menu principal");
            ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            AfficherMenuPrincipal();
        }


        /* ------------- */
        /* -- HELPERS -- */
        /* ------------- */
        /**
         * Vérifie que l'entrée utilisateur soit un entier compris entre min et max
         * retourne :
         *      True le cas échéant
         *      False sinon
        */
        static bool LireChoixUtilisateur(int min, int max, ConsoleKeyInfo saisie)
        {
            int saisieInt = Convert.ToInt32(saisie.KeyChar) - 48; // Converti la saisie utilisateur en int
            return (saisieInt >= min && saisieInt <= max);
        }

        /**
         * Affiche la string erreur passée en paramètre en rouge et reset les couleurs de la console
         */
        public static void AfficherErreur(string erreur)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erreur);
            Console.ResetColor();
        }
    }
}
