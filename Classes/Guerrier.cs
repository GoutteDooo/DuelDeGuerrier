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
        private int _pointsDeVie; //Pv
        private int _nbDesAttaque; //Nombre de des attaques

        public Guerrier(string nom, int pointsDeVie, int nbDesAttaque)
        { //Constructeur
            _nom = nom;
            _pointsDeVie = pointsDeVie;
            _nbDesAttaque = nbDesAttaque;
        }

        //Methode 

        public string GetNom(int pointsDeVie)
        {
            return _nom;
        }
        public int GetPointsDeVie ()
        {
            return _pointsDeVie;
        }
        public void SetPointsDeVie(int pointsDeVie) //Paramètre
        {
            _pointsDeVie = pointsDeVie;    
        }

        public int GetNbDesAttaque()
        {
            return _nbDesAttaque;
        }

    }
}

