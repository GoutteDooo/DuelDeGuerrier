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
        //Attributs
        private string _nom; //Nom du guerrier
        private int _pointsDeVieMax; // Nombre de pvs max du guerrier
        private int _pointsDeVie; // Points de vie du guerrier
        private int _nbDesAttaque; // Nombre de dés attaque du guerrier

        // Propriétés
        public string Nom { get { return _nom; } }
        public int NbDesAttaques { get; set; }

        // Constructeur
        public Guerrier(string nom, int pointsDeVie, int nbDesAttaque)
        {
            _nom = nom;
            _pointsDeVieMax = pointsDeVie;
            _pointsDeVie = pointsDeVie;
            _nbDesAttaque = nbDesAttaque;
        }

        // Méthodes
        /**
         * Récupére le nom de l'instance
         */
        public string GetNom() => _nom;
        /**
         * Récupére les PV de l'instance
         */
        public int GetPointsDeVie() => _pointsDeVie;
        /**
         * Modifie les PV de l'instance
         */
        public void SetPointsDeVie(int pointsDeVie)
        {
            _pointsDeVie = pointsDeVie > 0 ? pointsDeVie : 0;
        }

        /**
         * Remet les points de vie de l'instance à son maximum
         */
        public virtual void ResetMax()
        {
            _pointsDeVie = _pointsDeVieMax;
        }
        /**
         * Récupère le nombre de dés d'attaque de l'instance
         */
        public int GetNbDesAttaque() => _nbDesAttaque;

        /**
         * Affiche le nom et les points de vie de l'instance dans le format suivant :
         *  [nom] {PV=xx}
         */
        public virtual void AfficherInfos()
        {
            if (GetPointsDeVie() <= 0)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(_nom + " {PV=" + (_pointsDeVie < 0 ? 0 : _pointsDeVie) + "}");
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
            SetPointsDeVie(_pointsDeVie - degats);
        }
    }
}

