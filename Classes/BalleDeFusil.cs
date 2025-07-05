using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Classes
{
    /**
     * Les Fourmis Balle de Fusil peuvent one shot leur adversaire si le dés tombe sur une valeur définie
     */
    internal class BalleDeFusil : Guerrier
    {
        private int _mana = 50;
        private List<string> sorts = new List<string> { "Boule de Feu", "Soin", "Bouclier Magique", "Tir à Bout Portant" };
        public int Mana { get; set; }
        public bool BouclierActif { get; set; }
        public BalleDeFusil(string nom, int pointsDeVie, int nbDesAttaque, int mana = 50, bool bouclierActif = false) : base(nom, pointsDeVie, nbDesAttaque)
        {
            Mana = mana;
            BouclierActif = bouclierActif;
        }

        /**
         * Méthode redéfinie de la classe mère Guerrier
         */
        public new int Attaquer()
        {
            Random rng = new Random();
            int degats = rng.Next(1, 6);
            if (Mana >= 10)
            {
                // Lance un dés entre [0, sorts.Count - 1] pour récupérer un index aléatoire de sorts
                int indexSort = rng.Next(0, sorts.Count - 1);
                // On affiche le sort trouvé
                Console.WriteLine($"{this.GetNom()} consomme 10 mana pour utiliser {sorts[indexSort]}!!");
                /* SORTS */
                Console.ForegroundColor = ConsoleColor.Yellow; // Les sorts seront affichés en Jaune
                switch (indexSort)
                {
                    case 0:
                        Console.WriteLine("La Boule de Feu inflige 10 points de dégâts supplémentaires!!");
                        degats += 10;
                        break;

                    case 1:
                        Console.WriteLine($"{this.GetNom()} récupère 5 PV !");
                        Console.WriteLine($"Test, PV avant : {this.GetPointsDeVie()}");
                        this.SetPointsDeVie(5);
                        Console.WriteLine($"Test, PV après : {this.GetPointsDeVie()}");
                        break;

                    case 2:
                        Console.WriteLine($"Un bouclier Magique s'active, réduisant les dégâts subits de 50% contre la prochaine attaque.");
                        Console.WriteLine($"Test, bouclier avant : {this.BouclierActif}");
                        BouclierActif = true;
                        Console.WriteLine($"Test, bouclier après : {this.BouclierActif}");
                        break;

                    case 4:
                        Console.WriteLine($"{this.GetNom()} tente une attaque {sorts[indexSort]} !\n" +
                            $"Lancé de dés en cours... Si le résultat est 6, l'adversaire perd le round.");
                        int resultat = rng.Next(1, 6);
                        Console.WriteLine(resultat < 6 ? $"Le résultat est {resultat}, rien ne se passe et {this.GetNom()} a simplement perdu du mana." : $"6 ! BOOM ! {this.GetNom()} ouvre ses mandibules bien grandes et une sorte de balle part à tout vitesse en direction de son adversaire !!!");
                        degats = resultat < 6 ? degats : 99999;
                        break;

                    default:
                        break;
                }
                Console.ResetColor();
            }
            return degats;
        }

        public override void SubirDegats(int degats)
        {
            base.SubirDegats(BouclierActif ? degats / 2 : degats);
            // On désactive le bouclierActif s'il l'était
            if (BouclierActif)
            {
                Console.WriteLine($"Le bouclier de {this.GetNom()} était activé, les dégâts sont réduits par 2 !");
                BouclierActif = false;
            }
        }
    }
}
