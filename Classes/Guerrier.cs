using DuelDeGuerrier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Classes
{
    class Guerrier : ICombattant
    {
        private object rnd;

        // Propriétés
        public string Nom { get; set; }//Nom du guerrier
        public int PointsDeVieMax { get; }// Nombre de pvs max du guerrier
        public int PointsDeVie { get; set; }// Points de vie du guerrier
        public int NbDesAttaque { get; set; }// Nombre de dés attaque du guerrier
        public int Victoires { get; set; }// Nombre de victoires
        public virtual string Type => "Guerrière";

        // Constructeur
        public Guerrier(string nom, int pointsDeVie, int nbDesAttaque)
        {
            Nom = nom;
            PointsDeVieMax = pointsDeVie;
            PointsDeVie = pointsDeVie;
            NbDesAttaque = nbDesAttaque;
            Victoires = 0;
        }

        // Méthodes
        /**
         * Récupére le nom de l'instance
         */
        public string GetNom() => Nom;
        /**
         * Récupére les PV de l'instance
         */
        public int GetPointsDeVie() => PointsDeVie;
        /**
         * Modifie les PV de l'instance
         */
        public void SetPointsDeVie(int pointsDeVie)
        {
            PointsDeVie = pointsDeVie > 0 ? pointsDeVie : 0;
        }

        /**
         * Remet les points de vie de l'instance à son maximum
         */
        public virtual void ResetMax()
        {
            PointsDeVie = PointsDeVieMax;
        }
        /**
         * Récupère le nombre de dés d'attaque de l'instance
         */
        public int GetNbDesAttaque() => NbDesAttaque;
        /**
         * Incrémente le nombre de victoires de l'instance
         */
        public void IncrementerVictoires()
        {
            Victoires++;
        }
        public int GetNbVictoires() => Victoires;

        public string ObtenirType() => Type;
        /**
         * Affiche le nom et les points de vie de l'instance dans le format suivant :
         *  [nom] {PV=xx}
         */
        public virtual void AfficherInfos()
        {
            if (GetPointsDeVie() <= 0)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Nom + "(" + ObtenirType() + ")" +  " {PV=" + (PointsDeVie < 0 ? 0 : PointsDeVie) + "}");
            Console.ResetColor();
        }

        public virtual string ObtenirInfos()
        {
            return $"{{PV={(PointsDeVie < 0 ? 0 : PointsDeVie)}}}";
        }
        /**
         * Renvoie un entier comprenant le nombre de dés d'attaque multiplié par un chiffre aléatoire entre 1 et 6
         *  Exemple :
         *      - Si le Guerrier possède 3 nombre de dés d'attaque. Alors, le résultat se situe entre (3*1 et 3*6) { 3 ; 18 }
         *      ( par exemple 9 )
         */
        public virtual int Attaquer()
        {
            int total = 0;
            Random rnd = new Random();

            for (int i = 0; i < NbDesAttaque; i++)
            {
                int lancer = rnd.Next(1, 7);
                total += lancer;
            }

            return total;
        }


        /**
         * Soustrait le nombre de points de vie de l'instance du parametre int degats
         */
        public virtual void SubirDegats(int degats)
        {
            SetPointsDeVie(PointsDeVie - degats);
        }
    }
}

