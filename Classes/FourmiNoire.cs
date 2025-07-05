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
        // Attributs
        private bool _armureLourde; //Détermine si le FourmiNoire porte une armure lourde 
        // Propriétés
        public bool ArmureLourde { get; set; }
        // Constructeur
        public FourmiNoire(string nom, int pointsDeVie, int nbDesAttaque, bool armureLourde) : base(nom, pointsDeVie, nbDesAttaque){ 
            _armureLourde = armureLourde;
        }
        public override void SubirDegats(int degats) {
            if (_armureLourde)
                Console.WriteLine($"L'armure lourde de {this.GetNom()} réduit les dégâts subis par deux!");

            base.SubirDegats(_armureLourde ? degats / 2 : degats);
        }
    }
}