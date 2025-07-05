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
                    "\t2. Comment fonctionne les menus ?\n" +
                    "\n" +
                    "\t0. Revenir au Menu Principal\n" +
                    "\n" +
                    "Faites votre choix : ");
                ConsoleKeyInfo input = Console.ReadKey();
                if (!"012".Contains(input.KeyChar))
                {
                    Program.AfficherErreur("Veuillez entrer une option valide svp.");
                    continue;
                }
                switch (input.KeyChar)
                {
                    case '1':
                        Console.WriteLine("bref tuto");
                        break;
                    case '2':
                        Console.WriteLine("Comment fct les menus");
                        break;
                    case '0':
                        Program.RetourMenuPrincipal();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
