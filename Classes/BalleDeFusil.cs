using System;
using System.Collections.Generic;
using System.Linq;
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
        public int Attaquer()
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
                switch (indexSort)
                {
                    case 0:
                        Console.WriteLine("La Boule de Feu inflige 10 points de dégâts supplémentaires!!");
                        degats += 10;
                        break;
                    case 1:
                        Console.WriteLine($"{this.GetNom()} récupère 5 PV !");
                        Console.WriteLine($"Test, PV avant : {this.PointsDeVie}");
                        this.PointsDeVie += 5;
                        Console.WriteLine($"Test, PV après : {this.PointsDeVie}");
                        break;
                    case 2:
                        Console.WriteLine($"Un bouclier Magique s'active, réduisant les dégâts subits de 50% contre la prochaine attaque.");
                        BouclierActif = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
