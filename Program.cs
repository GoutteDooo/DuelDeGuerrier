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
            Console.Title = "Arene de Fourmis";
            GuideUtilisateur.AfficherGuide();
            //AfficherMenuPrincipal();
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
            int pvs = LireEntierValide(10, 100);
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
                Console.WriteLine("Combien de mana aura-t-elle (entre 10 et 100) ? ");
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
            // Si la liste est vide
            if (fourmisGuerrieres.Count == 0)
            {
                AfficherErreur("Aucune fourmi guerrière n'est présente dans le Hall Des Combattantes!");
            }
            else
            {
                Console.WriteLine("Les fourmis guerrières sont :");
                // Pour chaque fourmiGuerriere dans la liste fourmisGuerrieres
                foreach (Guerrier fourmiGuerriere in fourmisGuerrieres)
                {
                    // On affiche les infos de la fourmiGuerriere actuelle
                    fourmiGuerriere.AfficherInfos();
                }
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
                return;
            }
            else if (fourmisGuerrieres.Count == 1) // Une seule participante
            {
                AfficherErreur("Il faut au moins deux participants pour lancer un tournoi !");
                RetourMenuPrincipal();
                return;
            }

            int round = 1; // Affichage sympa pour les rounds pendant le tournoi
            while (fourmisGuerrieres.Count > 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t--- ROUND n°{round} ---");
                Console.ResetColor();
                Console.WriteLine();
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

            string combat = $"--- Combat entre {fourmi1.GetNom()} et {fourmi2.GetNom()} ---";
            Console.WriteLine(new string('-',combat.Length) + "\n" +
                combat + "\n" +
                new string('-', combat.Length) + "\n");
            bool fourmi1Attaque = true; // Booléen permettant de définir l'attaquant et le défenseur (en l'occurence, fourmi1 attaque et fourmi2 défend)
            while (true)
            {
                // Défini qui attaque et qui défend ce tour
                var fourmiAttaquante = fourmi1Attaque ? fourmi1 : fourmi2;
                var fourmiDefenseur = fourmi1Attaque ? fourmi2 : fourmi1;

                int degats = fourmiAttaquante.Attaquer();
                if (degats == 99999)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + (degats > 0 ? $"{fourmiAttaquante.GetNom()} attaque {fourmiDefenseur.GetNom()} avec des dégâts {(degats < 99999 ? $"de {degats}" : "INFINI")}" : "Aucun dégât n'a été distribué ce tour.") +
                    "\n");
                Console.ResetColor();

                fourmiDefenseur.SubirDegats(degats);
                
                fourmiDefenseur.AfficherInfos();
                fourmiAttaquante.AfficherInfos();

                if (fourmiDefenseur.GetPointsDeVie() <= 0)
                {
                    fourmiDefenseur.SetPointsDeVie(0);
                    fourmiAttaquante.ResetMax(); // Remet ses pvs (et manas si en a) au max pour le prochain combat
                    fourmisGuerrieres.Remove(fourmiDefenseur);
                    Console.WriteLine("\n");
                    break;
                }
                fourmi1Attaque = !fourmi1Attaque;
            }
        }

        /**
         * Demande au joueur le nom de la fourmi à supprimer et la supprime si elle existe dans la liste
         */
        public static void SupprimerGuerrier()
        {
            while (true)
            {
                // Si plus aucune fourmi dans la liste
                if (fourmisGuerrieres.Count == 0)
                {
                    AfficherErreur("Plus aucune fourmi présente dans le hall des combattantes !");
                    RetourMenuPrincipal();
                    return;
                }
                Console.WriteLine($"Liste des fourmis guerrières: {String.Join("", fourmisGuerrieres.Select((f, i) => $"\n{i + 1} - {f.GetNom()} ({f.GetType()})"))}");
                // Entrée utilisateur
                Console.WriteLine("Entrez le numéro de la fourmi guerrière à supprimer ('0' pour quitter):");

                // Forcer le joueur à entrer un numéro valide
                int indexMax = fourmisGuerrieres.Count;
                int numero = LireEntierValide(0, indexMax);

                if (numero > 0)
                {
                    // Supprimer la fourmi dont le numero correspond
                    Console.WriteLine($"La fourmi dont le nom est {fourmisGuerrieres[numero - 1].GetNom()} a été supprimée de la liste.");
                    fourmisGuerrieres.RemoveAt(numero - 1);
                    Console.Clear();
                }
                else // numero == 0
                    break;
            }
            RetourMenuPrincipal();
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
            // Si aucun tournoi dans l'historique
            if (historique.Count == 0)
            {
                AfficherErreur("Aucune archive de tournoi n'existe!");
                RetourMenuPrincipal();
                return;
            }
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
            string? input = Console.ReadLine();
            // Contrôles de saisie
            while (input == null || input.Equals("") || !input.All(char.IsLetterOrDigit))
            {
                AfficherErreur("Erreur, veuillez recommencer SVP");
                Console.ForegroundColor = ConsoleColor.Green;
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
            while (true)
            {
                // Vérifie si l'input est un entier et qu'il est compris entre min et max
                if (int.TryParse(Console.ReadLine(), out int input) && (input >= min && input <= max))
                {
                    // Alors on le retourne
                    return input;
                }
                else
                    // Sinon, on redemande à l'utilisateur de saisir un input et on relance la méthode au début
                    AfficherErreur($"Erreur! Veuillez saisir une entrée comprise entre {min} et {max} svp.");
            }
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
        public static void RetourMenuPrincipal()
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
