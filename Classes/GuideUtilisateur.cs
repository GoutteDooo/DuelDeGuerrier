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
                Console.Write("Bienvenue dans le Manuel Utilisateur!\n" +
                    "Faites votre choix :\n" +
                    "\n" +
                    "\t1. Bref tutoriel sur l'utilisation du Programme\n" +
                    "\t2. Fonctionnement des menus et sous-menus\n" +
                    "\t3. Explication des types de fourmi\n" +
                    "\n" +
                    "\t0. Revenir au Menu Principal\n" +
                    "\n" +
                    "Faites votre choix : ");
                ConsoleKeyInfo input = Console.ReadKey();
                Console.Clear();
                if (!"012".Contains(input.KeyChar))
                {
                    Program.AfficherErreur("Veuillez entrer une option valide svp.");
                    continue;
                }
                switch (input.KeyChar)
                {
                    case '1':
                        Console.WriteLine("bref tuto");
                        //BrefTutoriel();
                        break;
                    case '2':
                        Console.WriteLine("Comment fct les menus");
                        //FonctionnementDesMenus();
                        break;
                    case '3':
                        Console.WriteLine("Types de fourmis");
                        //TypesDeFourmis();
                        break;
                    case '0':
                        Program.RetourMenuPrincipal();
                        break;
                    default:
                        break;
                }
            }
        }

        /**
         * Affiche l'ensemble du tutoriel de la liste présente au début de la méthode.
         * La liste est composée de tuples de 3 types nommés: ConsoleColor couleur, string texte et int etape :
         * 
         *      - (ConsoleColor) couleur permet l'affichage dans la console la couleur de la string
         *      - (string) texte est le texte qui sera affiché à un instant t pendant le tuto
         *      - (int) etape permet de se repérer au niveau d'un affichage dynamique pendant le tutoriel pour une meilleure UX
         * 
         * Le tutoriel affiche le texte en haut de la console, et les affichages dynamiques seront en-dessous.
         */
        private static void BrefTutoriel()
        {
            List<(ConsoleColor couleur, string texte, int etape)> tuto = new List<(ConsoleColor, string, int)>
            {
                (ConsoleColor.Magenta,"Vous êtes une sorte d'organisateur de combat de fourmi.\n",1),
                (ConsoleColor.Blue,"Au début du jeu, aucune fourmi n'est présente dans le Hall des Combattantes.\n",1),
                (ConsoleColor.Green,"Ci-dessous, voici le Menu Principal. (Vous ne pouvez pas y toucher le temps du tuto)\n",2),
                (ConsoleColor.Blue,"Lorsque vous sélectionnez l'option \"1. Créer une fourmi guerrière\",\n",4),
                (ConsoleColor.Blue,"Vous entrez dans le sous-menu \"Créer une Guerrière\",\n",4),
                (ConsoleColor.Magenta,"Dans ce sous-menu, vous pouvez créer actuellement 4 types de fourmis.\n",4),
                (ConsoleColor.Magenta,"Supposons que vous vouliez créer une Fourmi Noire...\n",4),
                (ConsoleColor.Green,"Alors, vous n'avez qu'à presser la touche 2.\n",4),
                (ConsoleColor.Blue,"Lorsque c'est fait, plusieurs données seront demandées pour pouvoir générer la fourmi dans le Hall des Combattantes.\n",5),
                (ConsoleColor.Blue,"Le nom, les points de vie, et d'autres données qui peuvent être spécifiques au type de fourmi. \n",5),
                (ConsoleColor.Magenta,"Une fois que vous avez généré suffisamment de fourmis, vous pourrez retourner au Menu Principal et d'autres options seront disponibles. \n",2),
                (ConsoleColor.Green,"La principale étant l'option \"4. Lancer un tournoi\" \n",6),
                (ConsoleColor.Magenta,"D'ici là, nous vous laissons le plaisir de tester par vous-même le résultat... \n",6),
                (ConsoleColor.Yellow,"Merci d'avoir essayé le tutoriel et bon jeu!\n",6),
            };
            // Etapes
            // 1 : Pas d'affichage
            // 2 : Afficher le Menu Principal
            // 3 : Afficher le Menu Principal et surligner en rouge l'option 1
            // 4 : Afficher le Sous-Menu 1
            // 5 : Afficher "nom fourmi"
            // 6 : Afficher le Menu Principal et surligner en rouge l'option 4



        }
    }
}
