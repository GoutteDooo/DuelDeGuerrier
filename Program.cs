using DuelDeGuerrier.Classes;
using DuelDeGuerrier.Interfaces;
using Spectre.Console;
using System.ComponentModel.DataAnnotations;
using System.Media;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace DuelDeGuerrier
{
    internal class Program
    {
        static List<ICombattant> fourmisGuerrieres = new List<ICombattant>(); // Liste contenant les fourmis guerrières instanciées
        static List<Tournoi> historique = new List<Tournoi>(); // Liste contenant les tournois lancés et terminés
        static void Main(string[] args)
        {
            Console.Title = "Arene de Fourmis";
            EcranTitre();
        }
        /**
         * Affiche dans la console le menu principal
         */
        public static void AfficherMenuPrincipal()
        {
            // Affichage de la Rule (Menu Principal)
            var rule = new Rule("[orange1]Menu principal[/]\n");
            AnsiConsole.Write(rule);

            // Créer une table
            var table = new Table();

            // Définir le type de bordure de la table
            table.Border(TableBorder.Double);
            // Créer une colonne
            table.Width(60); // largeur de la table
            table.AddColumn("");
            table.AddColumn(new TableColumn("[gray]Options[/]"));

            // Add some rows
            table.AddRow("1", "[green]Créer une fourmi guerrière[/]");
            table.AddRow("2", "[red]Supprimer une fourmi guerrière[/]");
            table.AddRow("3", "[cyan]Afficher la liste des fourmis guerrières[/]");
            table.AddRow("4", "[yellow]Lancer un tournoi[/]");
            table.AddRow("5", "[gray]Afficher l'historique[/]");
            table.AddRow("6", "[green]Sauvegarder la liste des fourmis guerrières[/]");
            table.AddRow("7", "[blue]Charger la dernière sauvegarde des fourmis guerrières[/]");
            table.AddRow("", "");
            table.AddRow("8", "Consulter le Guide Utilisateur");
            table.AddRow("0", "Quitter");
            table.ShowRowSeparators();
            // Centrer la table
            table.Centered();
            // 
            table.Columns[0].Width = 1;
            // Render the table to the console
            AnsiConsole.Write(table);
        }

        /**
         * Affiche le menu principal et propose les interactions avec le joueur
         */
        public static void MenuPrincipal()
        {
            //Musique
            Audio.LancerMusiqueBoucle("menu_principal");
            AfficherMenuPrincipal();
            Console.Write("Veuillez entrer un nombre: ");

            ConsoleKeyInfo saisie = Console.ReadKey();

            // Une fois que l'utilisateur a fait une saisie, on nettoie la console
            Console.Clear();
            // Si le joueur saisie une autre option que celles disponibles
            int nombreOptions = 8;
            if (!LireChoixUtilisateur(0, nombreOptions, saisie))
            {
                AfficherErreur("Veuillez saisir une des options disponibles SVP.");
                MenuPrincipal();
            }
            switch (saisie.KeyChar)
            {
                case '1':
                    AjouterGuerrier(); // Si le joueur veut créer un guerrier
                    break;
                case '2':
                    SupprimerGuerrier(); // Si le joueur veut supprimer une guerrière
                    break;
                case '3':
                    AfficherFourmisGuerrieres(); // Si l'utilisateur veut voir la liste des fourmis guerrières
                    break;
                case '4':
                    LancerTournoi(); // Si le joueur veut lancer le tournoi
                    break;
                case '5':
                    AfficherHistorique(); // Si le joueur affiche l'historique
                    break;
                case '6':
                    ChargerSauvegarder.SauvegarderFourmis(fourmisGuerrieres); // Si le joueur souhaite enregistrer la liste de fourmis
                    MenuPrincipal();
                    break;
                case '7':
                    var fourmisTemp = ChargerSauvegarder.ChargerFourmis();
                    // Ajouter chaque fourmi dans la liste principale
                    foreach (var fourmiT in fourmisTemp)
                        fourmisGuerrieres.Add(fourmiT);
                    MenuPrincipal();
                    break;
                case '8':
                    GuideUtilisateur.AfficherGuide(); // Si le joueur affiche l'historique
                    break;
                case '0':
                    QuitterProgramme(); // Si le joueur veut quitter le programme
                    break;
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
            MenuPrincipal();
        }

        /**
         * Affiche le sous-menu pour ajouter un guerrier à la liste fourmisGuerrieres
         */
        public static void AfficherMenuAjouterGuerrier()
        {
            // Affichage de la Rule (Menu Principal)
            var rule = new Rule("[blue]Créer une guerrière[/]\n");
            AnsiConsole.Write(rule);

            // Créer une table
            var table = new Table();

            // Définir le type de bordure de la table
            table.Border(TableBorder.Double);
            // Créer une colonne
            table.Width(60); // largeur de la table
            table.AddColumn("");
            table.AddColumn(new TableColumn("[gray]Options[/]"));

            // Add some rows
            table.AddRow("1", "[red]Fourmi Guerrière (Stats équilibrées)[/]");
            table.AddRow("2", "[yellow]Fourmi Noire (Défense élevée)[/]");
            table.AddRow("3", "[orange1]Fourmi Rousse (Attaque élevée)[/]");
            table.AddRow("4", "[cyan]Fourmi Balle De Fusil (Peut one shot mais PV faible)[/]");
            table.AddRow("", "");
            table.AddRow("0", "[gray]Revenir au Menu Principal[/]");
            table.ShowRowSeparators();
            // Centrer la table
            table.Centered();
            // 
            table.Columns[0].Width = 1;
            // Render the table to the console
            AnsiConsole.Write(table);
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
            Console.Write("\nCombien de PVs souhaitez-vous lui distribuer ? (entre 50 et 100) ");
            int pvs = LireEntierValide(50, 100);
            Console.Write("\nCombien de dés d'attaque souhaitez-vous lui donner ? (entre 1 et 4) ");
            int desAttaque = LireEntierValide(1, 4);

            if (classe.Equals("Guerrier"))
            {
                ICombattant fourmiGuerriere = CreerFourmiGuerriere(nom, pvs, desAttaque);
                Coloriser.ColorerTexte(ConsoleColor.Green, "Une fourmi guerrière a été créée!\n");
                fourmiGuerriere.AfficherInfos();
                fourmisGuerrieres.Add(fourmiGuerriere);
            }
            else if (classe.Equals("FourmiNoire"))
            {
                Console.WriteLine("Portera-t-elle une armure lourde ? (O/n)");
                bool armureLourde = LireBoolValide();
                FourmiNoire fourmiNoire = CreerFourmiNoire(nom, pvs, desAttaque, armureLourde); // On crée une nouvelle instance de FourmiNoire (nommée fourmiTest)
                Coloriser.ColorerTexte(ConsoleColor.Green, "Une fourmi noire a été créée !\n");
                fourmiNoire.AfficherInfos(); // On utilise la méthode AfficherInfos de la classe FourmiNoire
                fourmisGuerrieres.Add(fourmiNoire); // Ajouter l'instance de fourmiNoire à la liste des fourmis guerrières
            }
            else if (classe.Equals("FourmiRousse"))
            {
                FourmiRousse fourmiRousse = CreerFourmiRousse(nom, pvs, desAttaque);
                Coloriser.ColorerTexte(ConsoleColor.Green, "Une fourmi rousse a été créée !\n");
                fourmiRousse.AfficherInfos();
                fourmisGuerrieres.Add(fourmiRousse);
            }
            else if (classe.Equals("BalleDeFusil"))
            {
                Console.WriteLine("Combien de mana aura-t-elle (entre 40 et 100) ? ");
                int mana = LireEntierValide(40, 100);
                BalleDeFusil balleDeFusil = CreerFourmiBalleDeFusil(nom, pvs, desAttaque, mana);
                Coloriser.ColorerTexte(ConsoleColor.Green, "Une fourmi Balle De Fusil a été créée!\n");
                balleDeFusil.AfficherInfos();
                fourmisGuerrieres.Add(balleDeFusil);
            }
            Console.Clear();
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
        public static ICombattant CreerFourmiGuerriere(string nom, int pvs, int desAttaque)
        {
            return new Guerrier(nom, pvs, desAttaque);
        }

        /**
         * Retourne une instance Balle De Fusil avec stats aléatoires
        */
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
                var table = new Table();
                table.Title = new TableTitle("Hall Des Combattantes");
                table.AddColumn(new TableColumn("Nom").Centered());
                table.AddColumn(new TableColumn("Type").Centered());
                table.AddColumn(new TableColumn("Stats").Centered());
                table.ShowRowSeparators();
                // Pour chaque fourmiGuerriere dans la liste fourmisGuerrieres
                foreach (Guerrier fourmiGuerriere in fourmisGuerrieres)
                {
                    // On affiche les infos de la fourmiGuerriere actuelle
                    table.AddRow(fourmiGuerriere.Nom, fourmiGuerriere.ObtenirType(), fourmiGuerriere.ObtenirInfos());
                }
                table.Centered();
                AnsiConsole.Write(table);
                Console.WriteLine("\n\n");
            }
            RetourMenuPrincipal();
        }

        /**
         * Affiche l'écran "FIGHT" du tournoi avant de le lancer
         */
        public static void EcranTournoi()
        {
            // son "fight"
            Audio.LancerMusique("fight");
            // Titre principal
            var font = FigletFont.Load("Fonts/3d.flf");
            Console.WriteLine("\n\n\n\n\n\n");
            AnsiConsole.Write(
            new FigletText(font, "FIGHT")
            .Centered()
            .Color(Color.Red));
            Thread.Sleep(1500);
            Console.Clear();
        }

        /**
         * Fait se combattre toutes les fourmis de la liste fourmisGuerrieres jusqu'à ce qu'il n'en reste plus qu'une victorieuse
         * Lorsqu'il n'en reste plus qu'une, affiche la fourmi victorieuse
         */
        public static void LancerTournoi()
        {
            /* -- Variables globales du tournoi -- */
            /* ----------------------------------- */
            int numeroDeTournoi = historique.Count + 1;
            int nbParticipants = fourmisGuerrieres.Count;
            DateTime dateDuTournoi = DateTime.Now;
            List<List<ICombattant>> classements = new List<List<ICombattant>>();
            Tournoi tournoi = new Tournoi(numeroDeTournoi, nbParticipants, dateDuTournoi, classements);

            // -- Gestion d'erreurs --
            // -----------------------
            // S'il n'y a aucune ou 1 seule fourmi dans la liste
            if (fourmisGuerrieres.Count <= 1)
            {
                AfficherErreur("Il faut au moins deux participants pour lancer un tournoi !");
                RetourMenuPrincipal();
                return;
            }
            EcranTournoi();
            // -- Démarrage du Tournoi --
            // --------------------------
            int round = 1; // Affichage sympa pour les rounds pendant le tournoi
            int duelID = 0; // Permet de savoir précisément à quel duel on se situe dans le tournoi
            int etape = 0; // Pour savoir exactement à quelle étape (huitième, quarts...) l'on se situe dans le tournoi
            tournoi.Classements.Add(new List<ICombattant>()); // On crée une nouvelle liste pour le classement de l'étape actuelle
                                                              //
            Audio.LancerMusiqueBoucle("tournoi");

            while (fourmisGuerrieres.Count > 1)
            {
                // Affichage du round
                var rule = new Rule($"[red]ROUND n°{round}[/]");
                AnsiConsole.Write(rule);
                Console.WriteLine("\n");

                Combattre(duelID, tournoi.Classements[etape], tournoi.HistoriqueCombats, etape); // Fait se combattre la fourmi duelID et duelID+1 de la liste (si elles existent) et supprime la perdante de la liste
                round++;
                duelID++;
                // Si on a atteint la fin de la liste, ou qu'une fourmi n'a pas d'adversaire (nombre de participants impair)
                if (duelID >= fourmisGuerrieres.Count - 1)
                {
                    // On lance l'étape suivante du tournoi
                    tournoi.Classements.Add(new List<ICombattant>()); // On crée une nouvelle liste pour le classement de l'étape actuelle
                    etape++;
                    // Donc on remet duelID à 0 pour repartir au début de la liste.
                    duelID = 0;

                    // /!\ Cas particulier ! /!\
                    //     ----------------
                    // Si la liste est un nombre impair, on déplace le dernier participant au premier rang
                    // Car sinon, il ne participe jamais et ne combat qu'à la finale (injuste)
                    // Avec cette méthode, tout le monde combat le même nombre de fois, même si parfois un candidat saute une étape (tant pis on ne peut rien faire contre)
                    if (fourmisGuerrieres.Count % 2 != 0)
                    {
                        int dernierIndex = fourmisGuerrieres.Count - 1;
                        ICombattant temp = fourmisGuerrieres[dernierIndex];
                        fourmisGuerrieres.RemoveAt(dernierIndex);
                        fourmisGuerrieres.Insert(0, temp);
                    }
                }
            }

            // -- Fin du tournoi --
            // --------------------
            // S'il ne reste plus qu'une seule fourmi guerrière dans la liste, alors c'est la gagnante
            if (fourmisGuerrieres.Count == 1)
            {
                // Son de victoire
                Audio.LancerSon("victoire");
                // Affichage
                Console.Clear();
                var rule = new Rule("[yellow]FIN DU TOURNOI[/]");
                AnsiConsole.Write(rule);
                AnsiConsole.Write(new Align(
                    new Text($"La fourmi {fourmisGuerrieres[0].GetNom()} a remporté le tournoi!"),
                    HorizontalAlignment.Center,
                    VerticalAlignment.Middle
                ));
                //Console.WriteLine($"------ FIN DU TOURNOI ------\n");
                //Coloriser.ColorerTexte(ConsoleColor.Yellow, $"La fourmi {fourmisGuerrieres[0].GetNom()} a remporté le tournoi!\n");
                // Afficher le classement
                Console.WriteLine($"Voici le classement :");
                ICombattant vainqueur = fourmisGuerrieres[0];
                vainqueur.IncrementerVictoires(); // Incrémenter le compteur de victoire de la fourmi victorieuse
                tournoi.SetVainqueur(vainqueur);
                tournoi.Classements[etape].Add(vainqueur);
                tournoi.AfficherClassement();
                // Insérer le tournoi dans l'historique de tournois
                historique.Insert(0, tournoi);
                //Entrée utilisateur pour revenir au menu principal
                RetourMenuPrincipal();
            }
            else
            {
                throw new Exception($"Erreur lors de la fin du tournoi. Il reste {fourmisGuerrieres.Count} dans la liste.");
            }
        }

        /**
         * Gère l'affichage des duels
         * Fait se combattre les deux premières fourmis de la liste fourmisGuerrieres à l'index duelID jusqu'à ce qu'une des deux gagne.
         * Lorsqu'une fourmi remporte son duel, elle récupère tout ses PVs par défaut
         * Lorsqu'une fourmi perd son duel, elle est insérée dans la liste classements
         * Lorsqu'un duel est terminé, il est ajouté à la liste de l'historique de combats du tournoi
         */
        public static void Combattre(int duelID, List<ICombattant> etapeDeClassement, List<(int, string, string)> historiqueCombats, int etape)
        {
            // On déclare les deux fourmis qui se battent en duel
            var fourmi1 = fourmisGuerrieres[duelID];
            var fourmi2 = fourmisGuerrieres[duelID + 1];

            // Affichage
            /*
            string combat = $"--- Combat entre {fourmi1.GetNom()}({fourmi1.ObtenirType()}) et {fourmi2.GetNom()}({fourmi2.ObtenirType()}) ---";
            Console.WriteLine(new string('-', combat.Length) + "\n" +
                combat + "\n" +
                new string('-', combat.Length) + "\n");
            */
            // Test nouvel affichage
            // 3 layouts côte à côte [F1][DESC][F2]
            var layout = new Layout("Root")
                .SplitColumns(
                    new Layout("Left")
                    .SplitRows(
                        new Layout("Top-Left"),
                        new Layout("Middle-Left"),
                        new Layout("Bottom-Left")),
                    new Layout("Center")
                    .SplitRows(
                        new Layout("Top-Center"),
                        new Layout("Bottom-Center")),
                    new Layout("Right")
                    .SplitRows(
                        new Layout("Top-Right"),
                        new Layout("Middle-Right"),
                        new Layout("Bottom-Right")));

            //Définir la taille
            layout["Left"].Size(50);
            layout["Top-Left"].Size(10);
            layout["Middle-Left"].Size(10);
            layout["Right"].Size(50);
            layout["Top-Right"].Size(10);
            layout["Middle-Right"].Size(10);
            layout["Top-Center"].Size(10);
            layout["Bottom-Center"].Size(50);

            // Afficher les caractères ASCII à l'intérieur
            layout["Bottom-Left"].Update(
                new Panel(
                    Align.Center(
                        new Markup(fourmi1.GetAscii()),
                        VerticalAlignment.Middle)));

            layout["Bottom-Right"].Update(
                new Panel(
                    Align.Center(
                        new Markup(fourmi2.GetAscii()),
                        VerticalAlignment.Middle)));

            //Afficher qui vs qui
            layout["Top-Center"].Update(
                new Panel(
                    Align.Center(
                        new Markup($"Combat entre {fourmi1.GetNom()}({fourmi1.ObtenirType()}) et {fourmi2.GetNom()}({fourmi2.ObtenirType()})"),
                    VerticalAlignment.Middle)));
            //Afficher les noms
            layout["Middle-Left"].Update(
                new Panel(
                    Align.Center(
                        new Markup(fourmi1.GetNom() + $"({fourmi1.ObtenirType()})"),
                        VerticalAlignment.Middle)));
            layout["Middle-Right"].Update(
                new Panel(
                    Align.Center(
                        new Markup(fourmi2.GetNom() + $"({fourmi2.ObtenirType()})"),
                        VerticalAlignment.Middle)));

            // Booléen permettant de définir l'attaquant et le défenseur (en l'occurence, fourmi1 attaque et fourmi2 défend)
            bool fourmi1Attaque = true;
            // Contient toute la description d'un combat
            string descriptionCombat = "";
            while (true)
            {
                // Défini qui attaque et qui défend ce tour
                var fourmiAttaquante = fourmi1Attaque ? fourmi1 : fourmi2;
                var fourmiDefenseur = fourmi1Attaque ? fourmi2 : fourmi1;

                int degats = fourmiAttaquante.Attaquer();
                /*
                if (degats == 99999) // Si une attaque spéciale fait des dégâts infinis
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + (degats > 0 ? $"{fourmiAttaquante.GetNom()} attaque {fourmiDefenseur.GetNom()} avec des dégâts {(degats < 99999 ? $"de {degats}" : "INFINI")}" : "Aucun dégât n'a été distribué ce tour.") +
                    "\n");
                Console.ResetColor();
                */
                descriptionCombat += "\n" + (degats > 0 ? $"{fourmiAttaquante.GetNom()} attaque {fourmiDefenseur.GetNom()} avec des dégâts {(degats < 99999 ? $"de {degats}" : "INFINI")}" : "Aucun dégât n'a été distribué ce tour.") + "\n";
                layout["Bottom-Center"].Update(
                    new Panel(
                        Align.Center(
                            new Markup(descriptionCombat),
                            VerticalAlignment.Middle)));

                // vider la string si elle devient trop longue
                if (descriptionCombat.Length > 660)
                    descriptionCombat = "";
                        
                // Après l'attaque, la fourmi défenseur prend les dégâts adverses
                fourmiDefenseur.SubirDegats(degats);

                // Test affichage type bar chart
                layout["Top-Left"].Update(
                    new Panel(
                        Align.Center(
                            new BreakdownChart()
                            .Width(fourmi1.GetPointsDeVieMax())
                            .AddItem("PV", fourmi1.GetPointsDeVie(), Color.Green)
                            .AddItem("", fourmi1.GetPointsDeVieMax() - fourmi1.GetPointsDeVie(), Color.Red))));

                layout["Top-Right"].Update(
                    new Panel(
                        Align.Center(
                            new BreakdownChart()
                            .Width(fourmi2.GetPointsDeVieMax())
                            .AddItem("PV", fourmi2.GetPointsDeVie(), Color.Green)
                            .AddItem("", fourmi2.GetPointsDeVieMax() - fourmi2.GetPointsDeVie(), Color.Red))));

                AnsiConsole.Write(layout);

                Thread.Sleep(1000);
                Console.Clear();
                // Enfin, on affiche les informations des deux fourmis
                //fourmiDefenseur.AfficherInfos();
                //fourmiAttaquante.AfficherInfos();
                // Si la fourmi qui défend perd
                if (fourmiDefenseur.GetPointsDeVie() <= 0)
                {
                    // Insérer les détails intéressants du combat dans l'historique de combats
                    historiqueCombats.Add((etape, fourmiAttaquante.GetNom(), fourmiDefenseur.GetNom()));

                    // Afficher le vainqueur
                    /*
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{fourmiAttaquante.GetNom()} remporte le duel face à {fourmiDefenseur.GetNom()} !");
                    Console.ResetColor();
                    */

                    layout["Bottom-Center"].Update(
                        new Panel(
                            Align.Center(
                                new Markup($"{fourmiAttaquante.GetNom()} remporte le duel face à {fourmiDefenseur.GetNom()} !", Color.Purple),
                                VerticalAlignment.Middle)));
                    AnsiConsole.Write(layout);
                    Thread.Sleep(2000);

                    fourmiDefenseur.SetPointsDeVie(0);
                    fourmiAttaquante.ResetMax(); // Remet les pvs (et manas si en a) au max du vainqueur pour le prochain combat
                    // Insérer le perdant dans la liste de classement actuelle
                    etapeDeClassement.Add(fourmiDefenseur);
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
                Console.WriteLine($"Liste des fourmis guerrières: {String.Join("", fourmisGuerrieres.Select((f, i) => $"\n{i + 1} - {f.GetNom()} ({f.ObtenirType()})"))}");
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
            while (true)
            {
                foreach (Tournoi tournoi in historique)
                {
                    tournoi.AfficherDonnees();
                }
                Console.WriteLine("Entrez le numéro d'un tournoi pour consulter son tableau de classement et ses combats : (0 pour annuler)");

                // Entrée utilisateur pour afficher en détail un tournoi
                int input = LireEntierValide(0, historique.Count);
                // Si utilisateur a entré '0', alors on quitte le menu
                if (input == 0)
                    break;

                Console.Clear();
                Console.WriteLine($"Voici les classements du tournoi n°{input} : \n");
                historique.Find(h => h.Numero == input).AfficherClassement();
                historique.Find(h => h.Numero == input).AfficherHistoriqueCombats();
                Console.WriteLine("\n\tApppuyez sur une touche pour revenir aux archives...");
                Console.ReadKey();
                Console.Clear();
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

        /**
         * Affiche le Menu Titre
         */
        public static void EcranTitre()
        {
            // Musique
            Audio.LancerMusiqueBoucle("menu_principal");
            Audio.LecteurMusique.PlayLooping(); // ou .PlaySync() pour attendre la fin
            // Titre principal
            var font = FigletFont.Load("Fonts/3d.flf");
            Console.WriteLine("\n\n\n\n\n\n");
            AnsiConsole.Write(
            new FigletText(font, "L'arene des \n fourmis")
            .Centered()
            .Color(Color.Gold3_1));

            // Crédits
            AnsiConsole.Write(
            new FigletText(FigletFont.Load("Fonts/eftipiti.flf"), "\n\n\n\t Donovan  Othman\n\n\n\n")
            .Centered()
            .Color(Color.Blue));

            // Entrée utilisateur
            AnsiConsole.Write(
                new Align(
                    new Markup("[rapidblink]Appuyez sur entrée pour démarrer le jeu[/]\n"),
                    HorizontalAlignment.Center
                ));

            ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            MenuPrincipal();
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
         * Lit une entrée utilisateur et vérifie qu'elle est conforme (entre min et max)
         * Retourne l'entier entré le cas échéant
         * Sinon, un message d'erreur est affiché, invitant l'utilisateur a entrer de nouveau
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
            MenuPrincipal();
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
