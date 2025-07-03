using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Classes
{
    internal abstract class Guerrier
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

        public string GetNom()
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

        public void AfficherInfos()
        {
            Console.WriteLine(_nom + "{PV=" + _pointsDeVie + "}");
        }

        public int Attaquer()
        {
            Random random = new Random();
            return random.Next(1, 6);
        }

        public void SubirDegats(int degats)
        {
            _pointsDeVie -= degats;
        }
    }
}

