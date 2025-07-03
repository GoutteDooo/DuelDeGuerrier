using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Classes
{
    internal class FourmiNoire : Guerrier
    {
        //Attribut 

        private bool _armureLourde; //Détermine si le FourmiNoire porte une armure lourde 
        public FourmiNoire(string nom, int pointsDeVie, int nbDesAttaque, bool armureLourde) : base(nom, pointsDeVie, nbDesAttaque){ 
            _armureLourde = armureLourde;
        }
        public void SubirDegats(int degats) {
            if (_armureLourde == true)
            {
                degats=degats/2;
            }
            _pointsDeVie -= degats;
        }

    }
}