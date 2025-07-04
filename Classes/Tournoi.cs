using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Classes
{
    internal class Tournoi
    {

        // Numero du tournois
        // Le vainqueur 
        // Le nombre de participant 
        // La date

        public int Numero { get; set; }
        public Guerrier Vainqueur { get; set; }
        public int NombreParticipants { get; set; }
        public int Date { get; set; }

        //Constructeur 

        public Tournoi(int numero,  Guerrier vainqueur, int nombreParticipants, int date)
        {
            Numero = numero;
            Vainqueur = vainqueur;
            NombreParticipants = nombreParticipants;
            Date = date;
        }

    }
}
