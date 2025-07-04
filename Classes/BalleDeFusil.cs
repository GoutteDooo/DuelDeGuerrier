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
        public int Mana {  get; set; }
        public BalleDeFusil(string nom, int pointsDeVie, int nbDesAttaque, int mana) : base(nom, pointsDeVie, nbDesAttaque)
        {
            Mana = mana;
        }
    }
}
