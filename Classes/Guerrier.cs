using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Classes
{
    internal class Guerrier
    {
        //Attributs
        private string _nom; //Nom du guerrier
        private int _pointsDeVie; // Points de vie du guerrier
        private int _nbDesAttaque; // Nombre de dés attaque du guerrier

        // Propriétés
        public string Nom { get { return _nom; } }
        public int NbDesAttaques { get; set; }

        // Constructeur
        public Guerrier(string nom, int pointsDeVie, int nbDesAttaque)
        {
            _nom = nom;
            _pointsDeVie = pointsDeVie;
            _nbDesAttaque = nbDesAttaque;
        }

        // Méthodes
        /**
         * Récupére le nom de l'instance
         */
        public string GetNom()
        {
            return _nom;
        }
        /**
         * Récupére les PV de l'instance
         */
        public int GetPointsDeVie ()
        {
            return _pointsDeVie;
        }
        /**
         * Modifie les PV de l'instance
         */
        public void SetPointsDeVie(int pointsDeVie)
        {
            _pointsDeVie = pointsDeVie;
        }
        /**
         * Récupère le nombre de dés d'attaque de l'instance
         */
        public int GetNbDesAttaque()
        {
            return _nbDesAttaque;
        }

        /**
         * Affiche le nom et les points de vie de l'instance dans le format suivant :
         *  [nom] {PV=xx}
         */
        public void AfficherInfos()
        {
            Console.WriteLine(_nom + " {PV=" + _pointsDeVie + "}");
        }
        /**
         * Renvoie un entier entre 1 et 6
         */
        public virtual int Attaquer()
        {
            Random random = new Random();
            return random.Next(1, 6);
        }

        /**
         * Soustrait le nombre de points de vie de l'instance du parametre int degats
         */
        public virtual void SubirDegats(int degats)
        {
            _pointsDeVie -= degats;
        }
    }
}

