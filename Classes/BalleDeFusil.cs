using DuelDeGuerrier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Classes
{
    /**
     * Les Fourmis Balle de Fusil peuvent one shot leur adversaire si le dés tombe sur une valeur définie
     */
    internal class BalleDeFusil : Guerrier, ICombattant
    {
        // Propriétés
        private List<string> sorts = new List<string> { "Boule de Feu", "Soin", "Bouclier Magique", "Tir Balle De Fusil" };
        public int Mana { get; set; }
        public int ManaMax { get; set; }
        public bool BouclierActif { get; set; }
        public string Type { get; }
        public BalleDeFusil(string nom, int pointsDeVie, int nbDesAttaque, int mana = 50, bool bouclierActif = false) : base(nom, pointsDeVie, nbDesAttaque)
        {
            ManaMax = mana;
            Mana = mana;
            BouclierActif = bouclierActif;
            Type = "Balle De Fusil";
        }

        //Méthodes 

        /**
         * Méthode redéfinie de la classe mère Guerrier
         */
        public override int Attaquer()
        {
            if (Mana >= 10)
            {
                Random rng = new Random();
                int degats = 0;
                // Lance un dés entre [0, sorts.Count - 1] pour récupérer un index aléatoire de sorts
                int indexSort = rng.Next(0, sorts.Count);
                // Cas particulier : Si indexSort tombe sur le bouclier et qu'il est déjà actif, alors on relance le dés
                while (BouclierActif && sorts[indexSort] == "Bouclier Magique")
                    indexSort = rng.Next(0, sorts.Count);

                Mana -= 10;

                /* SORTS */
                Console.ForegroundColor = ConsoleColor.Yellow; // Les sorts seront affichés en Jaune
                // On affiche le sort trouvé
                Console.WriteLine($"{this.GetNom()} consomme 10 mana pour utiliser {sorts[indexSort]}!! (mana restants: {this.Mana})");
                switch (indexSort)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("La Boule de Feu inflige 10 points de dégâts!!");
                        degats += 10;
                        break;

                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{this.GetNom()} récupère 5 PV !");
                        this.SetPointsDeVie(this.GetPointsDeVie() + 5);
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Un bouclier Magique s'active, réduisant les dégâts subits de 50% contre la prochaine attaque.");
                        BouclierActif = true;
                        break;

                    case 3:
                        int resultatAttendu = 7;
                        Console.WriteLine($"{this.GetNom()} tente une attaque {sorts[indexSort]} !\n" +
                            $"Lancer de dés en cours... Si le résultat est {resultatAttendu}, l'adversaire perd le round.");
                        int resultat = rng.Next(1, resultatAttendu + 1);
                        if (resultat < resultatAttendu)
                            Console.ForegroundColor = ConsoleColor.Gray;
                        else
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(resultat < resultatAttendu ? $"Le résultat est {resultat}, rien ne se passe et {this.GetNom()} a simplement perdu du mana." : $"\n\t{resultatAttendu}!!! BOOM ! {this.GetNom()} ouvre ses mandibules bien grandes et une sorte de balle part à toute vitesse en direction de son adversaire !!!\n");
                        degats = resultat < resultatAttendu ? degats : 99999;
                        break;

                    default:
                        break;
                }
                Console.ResetColor();
                return degats;
            }
            else
            {
                // Si plus de mana, on lance RegenererMana()
                RegenererMana();
                return 0;
            }
        }

        public override void SubirDegats(int degats)
        {
            // On désactive le bouclierActif s'il l'était
            if (BouclierActif)
            {
                degats = degats / 2;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Le bouclier de {this.GetNom()} est activé, les dégâts sont réduits par 2, {this.GetNom()} subi donc {degats} dégâts !");
                Console.ResetColor();
                BouclierActif = false;
            }
            base.SubirDegats(degats);
        }

        /**
         * Méthode utilisée lorsque l'instance n'a plus assez de mana pour Attaquer.
         * Lance un dés qui régénère son mana entre 5 et 10
         */
        private void RegenererMana()
        {
            Random rng = new Random();
            int resultatDes = rng.Next(3, 10+1);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{this.GetNom()} n'a pas assez de mana pour lancer un sort ! Elle utilise donc sa capacité de régénération et récupère {resultatDes} points de mana...");
            Console.ResetColor();
            Mana += resultatDes;
        }

        public override void AfficherInfos()
        {
            if (GetPointsDeVie() <= 0)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{this.GetNom()} {{PV={ this.GetPointsDeVie()}}} {{Mana={this.Mana}}}");
            Console.ResetColor();
        }
        public override void ResetMax()
        {
            base.ResetMax();
            Mana = ManaMax;
        }
    }
}
