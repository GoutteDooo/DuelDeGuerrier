using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Classes
{
    internal class GuideUtilisateur
    {
        public static void AfficherGuide()
        {
            while (true)
            {
                Console.WriteLine("Bienvenue dans le Manuel Utilisateur!\n" +
                    "Faites votre choix :\n" +
                    "\n" +
                    "\t1. Bref tutoriel sur l'utilisation du Programme\n" +
                    "\t2. Explication du menu \"Créer une fourmi guerrière\"\n" +
                    "\t3. Comment se déroule un duel ?\n" +
                    "\t4. Explication des types de fourmi\n" +
                    "\t5. Explication du menu \"Supprimer une fourmi guerrière\"\n" +
                    "\n" +
                    "\t0. Revenir au Menu Principal\n" +
                    "\n" +
                    "Faites votre choix : ");

                ConsoleKeyInfo input = Console.ReadKey();
                Console.Clear();
                if (!"012345".Contains(input.KeyChar))
                {
                    Program.AfficherErreur("Veuillez entrer une option valide svp.");
                    continue;
                }
                switch (input.KeyChar)
                {
                    case '1':
                        BrefTutoriel();
                        break;
                    case '2':
                        ExplicationsMenuCreerFourmiGuerriere();
                        break;
                    case '3':
                        DeroulementDuel();
                        break;
                    case '4':
                        TypesDeFourmi();
                        break;
                    case '0':
                        Program.MenuPrincipal();
                        break;
                    default:
                        break;
                }
            }
        }

        /**
         * Affiche l'ensemble du tutoriel de la liste présente dans la méthode du type de tutoriel passé en paramètre.
         * (Exemple : si typeDeTutoriel == "bref", alors on exécutera avec la liste tutoriel de la méthode BrefTutoriel())
         * La liste est composée de tuples de 3 types nommés: ConsoleColor couleur, string texte et int etape :
         * 
         *      - (ConsoleColor) couleur permet l'affichage dans la console la couleur de la string
         *      - (string) texte est le texte qui sera affiché à un instant t pendant le tuto
         *      - (int) etape permet de se repérer au niveau d'un affichage dynamique pendant le tutoriel pour une meilleure UX
         * 
         * Le tutoriel affiche le texte en haut de la console, et les affichages dynamiques seront en-dessous.
         */
        private static void AfficherTutoriel(List<(ConsoleColor, string, int)> tuto, string typeDeTutoriel)
        {

            foreach ((ConsoleColor, string, int) affichage in tuto)
            {
                Console.Clear();
                Console.ForegroundColor = affichage.Item1;
                Console.WriteLine(affichage.Item2);
                Console.ResetColor();
                switch (typeDeTutoriel)
                {
                    case "bref":
                        AfficherEtapeBrefTutoriel(affichage.Item3);
                        break;
                    case "menuCreerFourmi":
                        AfficherEtapeMenuCreerFourmi(affichage.Item3);
                        break;
                    case "deroulementDuel":
                        AfficherEtapeDeroulementDuel(affichage.Item3);
                        break;
                    default:
                        break;
                }
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\nAppuyez sur une touche pour continuer...");
                Console.ReadKey();
            }
            Console.Clear();
            Console.ResetColor();
        }
        /**
         * Génère les données du tutoriel bref et lance l'affichage dynamique de ce dernier
         */
        private static void BrefTutoriel()
        {
            // Etapes
            // 1 : Pas d'affichage
            // 2 : Afficher le Menu Principal
            // 3 : Afficher le Menu Principal et surligner en rouge l'option 1
            // 4 : Afficher le Sous-Menu 1
            // 5 : Afficher le Sous-Menu 1 et surligner l'option 2
            // 6 : Afficher "nom fourmi"
            // 7 : Afficher "pvs fourmi"
            // 8 : Afficher le Menu Principal et surligner en rouge l'option 4
            // 9 : Afficher "Battle !!!" pour mettre en suspens le joueur
            List<(ConsoleColor couleur, string texte, int etape)> tuto = new List<(ConsoleColor, string, int)>
            {
                (ConsoleColor.Magenta,"Vous êtes une sorte d'organisateur de combat de fourmi.\n",1),
                (ConsoleColor.Blue,"Au début du jeu, aucune fourmi n'est présente dans \"le Hall des Combattantes\".\n",1),
                (ConsoleColor.Blue,"Le \"Hall des Combattantes\" est là où toutes les fourmis se réunissent avant de combattre.\n",1),
                (ConsoleColor.Green,"Ci-dessous, voici le Menu Principal. (Vous ne pouvez pas y toucher le temps du tutoriel)\n",2),
                (ConsoleColor.Blue,"Lorsque vous sélectionnez l'option \"1. Créer une fourmi guerrière\",\n",3),
                (ConsoleColor.Blue,"Vous entrez dans le sous-menu \"Créer une Guerrière\",\n",4),
                (ConsoleColor.Magenta,"Dans ce sous-menu, vous pouvez créer actuellement 4 types de fourmi.\n",4),
                (ConsoleColor.Magenta,"Supposons que vous voulez créer une Fourmi Noire...\n",5),
                (ConsoleColor.Green,"Alors, vous n'avez qu'à presser la touche 2.\n",5),
                (ConsoleColor.Blue,"Lorsque c'est fait, plusieurs données seront demandées pour pouvoir générer la fourmi dans le Hall des Combattantes.\n",6),
                (ConsoleColor.Blue,"Le nom, les points de vie, et d'autres données qui peuvent être spécifiques au type de fourmi. \n",7),
                (ConsoleColor.Magenta,"Une fois que vous avez généré suffisamment de fourmis, vous pourrez retourner au Menu Principal et d'autres options seront disponibles. \n",2),
                (ConsoleColor.Green,"La principale étant l'option \"4. Lancer un tournoi\" \n",8),
                (ConsoleColor.Magenta,"D'ici là, nous vous laissons le plaisir de tester par vous-même le résultat... \n",9),
                (ConsoleColor.Yellow,"Merci d'avoir essayé le tutoriel et bon jeu!\n",1),
            };
            AfficherTutoriel(tuto, "bref");
        }

        /**
         * Affiche les étapes de la liste de BrefTutoriel()
         */
        private static void AfficherEtapeBrefTutoriel(int etape)
        {
            if (etape != 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\t----- TUTORIEL -----\n");
                Console.ResetColor();
            }
            switch (etape)
            {
                case 1:
                    Console.WriteLine("");
                    break;
                case 2:
                    Program.AfficherMenuPrincipal();
                    break;
                case 3:
                    Console.Write("--- Menu principal ---\n");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write("1. Créer une fourmi guerrière\n");
                    Console.ResetColor();
                    Console.WriteLine("2. Supprimer une fourmi guerrière\n" +
                        "3. Afficher la liste des fourmis guerrières\n" +
                        "4. Lancer un tournoi\n" +
                        "5. Afficher l'historique\n" +
                        "\n" +
                        "6. Consulter le Guide Utilisateur" +
                        "0. Quitter\n\n");
                    break;
                case 4:
                    Program.AfficherMenuAjouterGuerrier();
                    break;
                case 5:
                    Console.Write(
                        $"---- Créer une Guerrière ----\n" +
                        $"\n" +
                        $"\n" +
                        $"Quel type de fourmi souhaitez-vous créer ?\n" +
                        $"\n" +
                        $"1. Fourmi Guerrière (Stats équilibrées)\n");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"2. Fourmi Noire (Défense élevée)\n");
                    Console.ResetColor();
                    Console.WriteLine(
                        $"3. Fourmi Rousse (Attaque élevée)\n" +
                        $"4. Fourmi Balle De Fusil (Peut one shot mais PV faible)\n" +
                        $"\n" +
                        $"0. Quitter le sous-menu\n");
                    break;
                case 6:
                    Console.Write("Quel nom souhaitez-vous lui donner ? (non vide, alphanumérique) ");
                    break;
                case 7:
                    Console.Write("\nCombien de PVs souhaitez-vous lui distribuer ? (entre 10 et 100) ");
                    break;
                case 8:
                    Console.Write("--- Menu principal ---\n" +
                        "1. Créer une fourmi guerrière\n" +
                        "2. Supprimer une fourmi guerrière\n" +
                        "3. Afficher la liste des fourmis guerrières\n");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write("4. Lancer un tournoi\n");
                    Console.ResetColor();
                    Console.WriteLine(
                        "5. Afficher l'historique\n" +
                        "\n" +
                        "6. Consulter le Guide Utilisateur" +
                        "0. Quitter\n\n");
                    break;
                case 9:
                    Console.WriteLine("COMBATS !!!");
                    break;
                default:
                    break;
            }
        }

        /**
         * Petit tutoriel dynamique comme le BrefTuto() mais explique en détail les menus
         */
        private static void ExplicationsMenuCreerFourmiGuerriere()
        {
            // Etapes
            // 1: Afficher le menu principal et surligner l'option 1
            // 2: Afficher le menu créer guerrier
            // 3: Afficher le menu créer guerrier et surligner l'option 4
            // 4: Afficher "quel nom souhaitez vous lui donner ?" Athena
            // 5: Afficher "Combien de PVs souhaitez-vous lui distribuer ?" 50
            // 6: Afficher "Combien de dés d'attaque souhaitez-vous lui donner ?" 5
            // 7: Afficher "Combien de mana aura-t-elle ?" 70
            // 8: Afficher "Une fourmi Balle De Fusil a été créée!\n Athena {PV=50} {Mana=70}" en vert
            List<(ConsoleColor couleur, string texte, int etape)> tuto = new List<(ConsoleColor, string, int)>
            {
                (ConsoleColor.Magenta,"Dans le menu principal, sélectionnez l'option \"1. Créer une fourmi guerrière\"\n",1),
                (ConsoleColor.Magenta,"Dans ce sous-menu, vous pouvez générer toutes les fourmis guerrières que vous souhaitez.\n",2),
                (ConsoleColor.Blue,"Par exemple, générons une \"Fourmi Balle de Fusil\" (lanceuse de sorts).\n",3),
                (ConsoleColor.Cyan,"Nous lui donnons le nom de \"Athéna\".\n",4),
                (ConsoleColor.Blue,"Distribuons-lui un certain nombre de Points de Vie.\n",5),
                (ConsoleColor.Yellow,"Le nombre de dés d'attaque permet de savoir combien d'attaque notre fourmi pourra distribuer.\n",6),
                (ConsoleColor.Yellow,"Par exemple, 5 dés d'attaque permettent de distribuer des dégâts entre 5 et 30 (car 5 dés de six faces seront lancés).\n",6),
                (ConsoleColor.Yellow,"Chaque nombre obtenu sur chaque dé représentant le nombre de dégâts que la fourmi inflige.\n",6),
                (ConsoleColor.Yellow,"Si vous voulez des combats sanglants, alors un grand nombre de dés d'attaque peut être intéressant.\n",6),
                (ConsoleColor.Yellow,"A contrario, si vous voulez des combats plus lents, un petit nombre de dés d'attaque est préférable.\n",6),
                (ConsoleColor.Cyan,"Spécificité de la fourmi Balle de Fusil : Elle possède de la mana.\n",7),
                (ConsoleColor.Cyan,"La mana étant l'énergie nécessaire à la fourmi pour pouvoir lancer des sorts.\n",7),
                (ConsoleColor.Yellow,"Nous avons distribué toutes les données nécessaires à la formation de notre fourmi Balle de Fusil. Bravo !\n",7),
            };
            AfficherTutoriel(tuto, "menuCreerFourmi");
        }


        /**
         * Affiche les étapes de la liste de ExplicationsMenuCreerFourmiGuerriere()
         */
        private static void AfficherEtapeMenuCreerFourmi(int etape)
        {
            if (etape != 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\t----- TUTORIEL -----\n");
                Console.ResetColor();
            }
            switch (etape)
            {
                case 1:
                    Console.Write("--- Menu principal ---\n");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write("1. Créer une fourmi guerrière\n");
                    Console.ResetColor();
                    Console.WriteLine("2. Supprimer une fourmi guerrière\n" +
                        "3. Afficher la liste des fourmis guerrières\n" +
                        "4. Lancer un tournoi\n" +
                        "5. Afficher l'historique\n" +
                        "\n" +
                        "6. Consulter le Guide Utilisateur" +
                        "0. Quitter\n\n");
                    break;
                case 2:
                    Program.AfficherMenuAjouterGuerrier();
                    break;
                case 3:
                    Console.Write(
                        $"---- Créer une Guerrière ----\n" +
                        $"\n" +
                        $"\n" +
                        $"Quel type de fourmi souhaitez-vous créer ?\n" +
                        $"\n" +
                        $"1. Fourmi Guerrière (Stats équilibrées)\n" +
                        $"2. Fourmi Noire (Défense élevée)\n" +
                        $"3. Fourmi Rousse (Attaque élevée)\n");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"4. Fourmi Balle De Fusil (Peut one shot mais PV faible)\n");
                    Console.ResetColor();
                    Console.WriteLine(
                        $"\n" +
                        $"0. Quitter le sous-menu\n");
                    break;
                case 4:
                    Console.WriteLine("\"quel nom souhaitez vous lui donner ?\" Athena");
                    break;
                case 5:
                    Console.WriteLine("\"Combien de PVs souhaitez-vous lui distribuer ?\" 50");
                    break;
                case 6:
                    Console.WriteLine("\"Combien de dés d'attaque souhaitez-vous lui donner ?\" 5");
                    break;
                case 7:
                    Console.WriteLine("\"Combien de mana aura-t-elle\" 70");
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Une fourmi Balle De Fusil a été créée!\r\nAthena {PV=50} {Mana=70}");
                    Console.ResetColor();
                    break;
                default:
                    break;
            }
        }

        /**
         * Petit manuel dynamique qui explique en détail les types de fourmi
         */
        private static void TypesDeFourmi()
        {
            List<string> fourmis = new() { "guerriere", "noire", "rousse", "balleDeFusil" };
            for (int i = 0; i < fourmis.Count; i = i) //particulier : i ne bouge pas dans le step car il est manipulé par l'utilisateur
            {
                AfficherFourmi(fourmis[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                if (i > 0)
                    Console.Write("\t" + "[<-]  ");
                if (i < fourmis.Count - 1)
                    Console.Write("\t" + (i > 0 ? "  [->]" : "      [->]"));
                Coloriser.ColorerTexte(ConsoleColor.Blue,"\n\nAppuyez sur les flèches directionnelles pour naviguer entre les fourmis, et sur n'importe quelle autre touche pour quitter.\n");
                Console.ResetColor();
                Console.SetCursorPosition(0, 0);
                ConsoleKeyInfo input = Console.ReadKey();
                Console.Clear();
                if (i > 0 && input.Key.ToString() == "LeftArrow")
                {
                    i--;
                    continue;
                }
                if (i < fourmis.Count - 1 && input.Key.ToString() == "RightArrow")
                {
                    i++;
                    continue;
                }
                if (input.Key.ToString() != "LeftArrow" && input.Key.ToString() != "RightArrow")
                {
                    break;
                }
            }
        }

        /**
         * Affiche le type de fourmi passé en paramètre
         * Une liste contenant couleur et texte pour les compétences de la fourmi est envoyé à une autre méthode pour la gestion graphique
         */
        private static void AfficherFourmi(string typeDeFourmi)
        {
            Console.WriteLine("\t------ Types de fourmis ------\n" +
                "\t" + new string('-', 30));
            string fourmiASCII; // String qui récupère l'ascii art de la fourmi
            switch (typeDeFourmi)
            {
                case "guerriere":
                    fourmiASCII = "                                 ....\r\n                   .--             ..\r\n               .-+-. :.            ..\r\n              .:.-.--=##*#-        ..\r\n             :-..  :+**###*.=#:      \r\n            .:    .*######+%@%:      \r\n           :+-.    .**##=:::-.*-     \r\n           :##.   .*::::--=%%*=-+.   \r\n    -##+.   -+   .*+=+-:-*%*  .=-*   \r\n      --+++:=- :+#+===+#%%*     :=*: \r\n      :*   :+#%*- .:=-+%%#*-.::-*#-  \r\n      .#*   +*+==++##%%%##%%#*:.%%.  \r\n        =-  ::     .*.***:++:-**##-  \r\n        :.  -:     =*#*:#-+@@%%##*=  \r\n         :.=#-     .** ++#%*@@@@-.   \r\n         .:*-=     :*. =++**#@%@*    \r\n          .: :.   .+#. .***#*#%@*    \r\n          .:.     -#=   .#####%%:    \r\n           .:    .+#.    +*%%%%-     \r\n            -.   -=      :==         \r\n            .- .==        :=         \r\n          .:--=*#***#%%%%%+*%%%##*=. \r\n            ..-=+#*+.   .:=-*%%%%#*: \r\n                          .+--# .... \r\n                              :      \r\n                                ..   ";
                    List<(ConsoleColor, string)> capacitesGuerriere = new List<(ConsoleColor, string)> { 
                        (ConsoleColor.Red, "- Attaque à chaque tour\n"),
                        (ConsoleColor.Yellow, "- A une chance de doubler ses dégâts (Attaque tranchante)")
                    };
                    GenererTableFourmi(fourmiASCII, "Fourmi Guerriere", capacitesGuerriere);
                    break;
                case "noire":
                    fourmiASCII = "                       :+++=                  \r\n                       =  :=:=*:              \r\n                      -- -:                   \r\n                   -#*#**+                    \r\n                  =%##+-@*+                   \r\n         .-===-=**%%%##****:                  \r\n        +*-+******#%%%%###*-                  \r\n        =#*+++###*##%@@%%##:                  \r\n  .  .++*%#####%%%%%%@#  ..                   \r\n  :*%%%%%%%@%@@@@%%#*+=                       \r\n :*%%%####%%@@@@%=::-%@*#%@@%%%*+=-::.....    \r\n+##%@@@%#%%%@@@-     *%-*%%*.     .::----::::.\r\n+##%@@@%%%#=*%=       #%+                     \r\n     -%=     *%.                              \r\n    -%-       ##                              \r\n   :%-         %+                             \r\n  :%.          .%:                            \r\n .%.            .%                            \r\n *%#.            *%##.                        ";
                    List<(ConsoleColor, string)> capacitesNoire = new List<(ConsoleColor, string)> {
                        (ConsoleColor.Red, "- Attaque modérée à chaque tour\n"),
                        (ConsoleColor.Cyan, "- Peut porter une armure lourde (réduction de 50% des dégâts)")
                    };
                    GenererTableFourmi(fourmiASCII, "Fourmi Noire", capacitesNoire);
                    break;

                case "rousse":
                    fourmiASCII = "         %#       %%%                            \r\n        %  @   %%     %#%                        \r\n        %    %                                   \r\n      #####                                      \r\n  %%%%%%%%%%%%#                                  \r\n    %%%%%%%%%%%%                                 \r\n    @@@%%%%%%%%                                  \r\n    @@#+*#%%#%                                   \r\n   %%#%@%#%%%%#%%                                \r\n   %%%%%%@%@%%%%%                                \r\n  #%@@%%%@%%%@@@@                                \r\n @%%##@%%%%%@@ @@                                \r\n @@%%#%@%@%@@  %%%%                              \r\n   %%@%@@@@@  %%@@      **                       \r\n  ##%@@@@@@%@%%       %%%####**++==-=+*+++++***  \r\n @%%@@@@@%%%@@@@@@@@@           %%%@             \r\n  @@@@%%@ @@@@@% #                               \r\n %@@ %%%      @@@##                              \r\n@@   %%        @@@%%                             \r\n                @  @@                            ";
                    List<(ConsoleColor, string)> capacitesRousse = new List<(ConsoleColor, string)> {
                        (ConsoleColor.Red, "- Attaque moyenne plus élevée\n"),
                        (ConsoleColor.Yellow, "- A une faible chance de parer les dégâts")
                    };
                    GenererTableFourmi(fourmiASCII, "Fourmi Rousse", capacitesRousse);
                    break;
                case "balleDeFusil":
                    fourmiASCII = "            :   ..             \r\n          .  . ::-:            \r\n         .  =::-=-.       -.   \r\n             :--=-     .:      \r\n          -  ::===   -.     :  \r\n           .::==:=+=..    -    \r\n            .:-===-====.:      \r\n            ==--==+=.-.=       \r\n           -=-+-===+ :.-=:     \r\n         ==-=:=-==-  .::-      \r\n      .==  .=--+-. -   :=      \r\n    :=.   .-=:.=-==::. :=+     \r\n  :+     -=:.=  :---+::-- .-   \r\n..     =- ..-:  ::==-=--:   :  \r\n    :=.   ..-:  -:-----:.:   :.\r\n  :-      ..=-:.--:=:--=. :    \r\n          :+.:: .---===-.  .:  \r\n           .--.:..-+-=--       \r\n              :::  :-=-=       \r\n              ..    . -:       \r\n             ..     : .        \r\n             .     .:          \r\n           ...     .:          \r\n        ...-:     ::=          \r\n        ..       ..:..         ";
                    List<(ConsoleColor, string)> capacitesBDF = new List<(ConsoleColor, string)> {
                        (ConsoleColor.Blue, "- Lance uniquement des sorts à chaque tour de manière aléatoire contre 10 points de mana :\n"),
                        (ConsoleColor.Red, "\t• Boule de Feu : Inflige 10 points de dégâts\n"),
                        (ConsoleColor.Green, "\t• Soin : Récupère 5 Points de Vie\n"),
                        (ConsoleColor.Cyan, "\t• Bouclier Magique : Réduit les dégâts de 50% contre la prochaine attaque adverse\n"),
                        (ConsoleColor.Yellow, "\t• Tir Balle de Fusil : Lance un dé de 1 à 7. Si le résultat est 7, la fourmi Balle de Fusil remporte le duel.\n"),
                        (ConsoleColor.Red, "\n- /!\\ Lorsque la fourmi Balle de Fusil n'a plus assez de mana, elle lance automatiquement\n"),
                        (ConsoleColor.Red, "       un sort de récupération de mana, qui lui fait récupérer entre 3 et 8 points de mana, au prix d'un tour."),
                    };
                    GenererTableFourmi(fourmiASCII, "Fourmi Balle de Fusil", capacitesBDF);
                    break;
                default:
                    break;
            }
            Console.WriteLine();
        }

        /**
         * Génère graphiquement :
         *      -----------------
         *      Type de la fourmi (param type)
         *      -----------------
         *      ASCII ART de la fourmi (param ascii)
         *      ---------
         *      CAPACITES
         *      ---------
         *      - Compétences de la fourmi (param capacites)
         */
        private static void GenererTableFourmi(string ascii, string type, List<(ConsoleColor, string)> capacites)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t" + new string('-', type.Length) + "\n" +
                "\t\t" + type + "\n" +
                "\t\t" + new string('-', type.Length) + "\n");
            Console.WriteLine(ascii);

            type = "-- Capacités --";
            Console.WriteLine("\t\t" + new string('-', type.Length) + "\n" +
                "\t\t" + type + "\n" +
                "\t\t" + new string('-', type.Length) + "\n");
            foreach ((ConsoleColor, string) capacite in capacites)
            {
                Console.Write("\t");
                Coloriser.ColorerTexte(capacite.Item1, capacite.Item2);
            }
        }

        /**
         * Génère les données du tutoriel déroulement duel et lance l'affichage dynamique de ce dernier
         */
        private static void DeroulementDuel()
        {
            // Etapes
            // 1 : Afficher menu principal avec option 4 surlignée
            // 2 : Afficher "Round n°1 - Combat entre..."
            // 3 : Afficher Action Atalante attaque Athéna
            // 4 : Afficher Action Bouclier Magique Athéna
            // 5 : Afficher Nouvelle Action Atalante attaque Athéna
            List<(ConsoleColor couleur, string texte, int etape)> tuto = new List<(ConsoleColor, string, int)>
            {
                (ConsoleColor.Magenta,"Dans le menu principal, une fois que vous avez au moins deux fourmis présentes dans le Hall Des Combattantes,\n",1),
                (ConsoleColor.Blue,"Lorsque vous sélectionnez \"4. Lancer un tournoi\"...\n",1),
                (ConsoleColor.Yellow,"Un Tournoi débute ! Les fourmis se battent entre elles jusqu'à ce qu'il n'en reste plus qu'une.\n",2),
                (ConsoleColor.Yellow,"Un combat se déroule tour par tour.\n",2),
                (ConsoleColor.Yellow,"Une fourmi effectue une action par tour, et donne ensuite la main à l'autre.\n",2),
                (ConsoleColor.Yellow,"Une action peut être une simplement une attaque, ou alors plus complexe comme une combinaison de sorts.\n",2),
                (ConsoleColor.Blue,"Ici, la fourmi Noire Atalante effectue une attaque simple et inflige 4 dégâts à Athéna\n",3),
                (ConsoleColor.Cyan,"Elle passe la main à Athéna, qui est de type Balle De Fusil. \n",3),
                (ConsoleColor.Cyan,"Athéna effectue une action propre au type Balle de Fusil. Elle active son bouclier, mais en contrepartie n'inflige aucun dégâts ce tour-ci. \n",4),
                (ConsoleColor.Magenta,"La main passe à Atalante, et ainsi de suite jusqu'à ce qu'il y'ait un vainqueur.\n",5),
                (ConsoleColor.Magenta,"Lorsqu'il y'a un vainqueur, le perdant est éliminé et le vainqueur affronte la fourmi suivante.\n",5),
            };
            AfficherTutoriel(tuto, "deroulementDuel");
        }

        private static void AfficherEtapeDeroulementDuel(int etape)
        {
            return;
        }
    }
}
