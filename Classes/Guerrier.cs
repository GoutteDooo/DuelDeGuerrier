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
        // Propriétés
        public string Nom { get ; set; }//Nom du guerrier
        public int PointsDeVieMax { get; }// Nombre de pvs max du guerrier
        public int PointsDeVie { get; set; }// Points de vie du guerrier
        public int NbDesAttaque { get; set; }// Nombre de dés attaque du guerrier
        public int Victoires { get; set; }// Nombre de victoires
        public string Type { get; }

        // Constructeur
        public Guerrier(string nom, int pointsDeVie, int nbDesAttaque)
        {
            Nom = nom;
            PointsDeVieMax = pointsDeVie;
            PointsDeVie = pointsDeVie;
            NbDesAttaque = nbDesAttaque;
            Victoires = 0;
            Type = "Guerrière";
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

        public new string GetType() => Type;
        /**
         * Affiche le nom et les points de vie de l'instance dans le format suivant :
         *  [nom] {PV=xx}
         */
        public virtual void AfficherInfos()
        {
            if (GetPointsDeVie() <= 0)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Nom + " {PV=" + (PointsDeVie < 0 ? 0 : PointsDeVie) + "}");
            Console.ResetColor();
        }
        /**
         * Renvoie un entier entre 1 et 6
         */
        public virtual int Attaquer() => new Random().Next(1, 6 + 1);

        /**
         * Soustrait le nombre de points de vie de l'instance du parametre int degats
         */
        public virtual void SubirDegats(int degats)
        {
            SetPointsDeVie(PointsDeVie - degats);
        }
    }
}

