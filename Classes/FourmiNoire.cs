using DuelDeGuerrier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Classes
{
    internal class FourmiNoire : Guerrier, ICombattant
    {
        // Attributs
        private bool _armureLourde; //Détermine si le FourmiNoire porte une armure lourde 
        // Propriétés
        public bool ArmureLourde { get; set; }
        public string Type { get; }
        // Constructeur
        public FourmiNoire(string nom, int pointsDeVie, int nbDesAttaque, bool armureLourde) : base(nom, pointsDeVie, nbDesAttaque){ 
            _armureLourde = armureLourde;
            Type = "Noire";
        }
        public override void SubirDegats(int degats) {
            if (_armureLourde && degats > 0)
            {
                degats = degats / 2;
                Console.WriteLine($"L'armure lourde de {this.GetNom()} réduit les dégâts subis par deux et prend donc {(degats < 1000 ? degats : "INFINI")}!");
            }

            base.SubirDegats(degats);
        }
    }
}