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
        public BalleDeFusil(string nom, int pointsDeVie, int nbDesAttaque, int mana = 50) : base(nom, pointsDeVie, nbDesAttaque)
        {
            Mana = mana;
        }
    }
}
