using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Classes
{
    internal class Tournoi
    {
        public int Numero { get; set; }// Numero du tournois
        public Guerrier Vainqueur { get; set; } // Le vainqueur 
        public int NombreParticipants { get; set; } // Le nombre de participant 
        public DateTime Date { get; set; } // La date


        //Constructeur 
        public Tournoi(int numero,  Guerrier vainqueur, int nombreParticipants, DateTime date)
        {
            Numero = numero;
            Vainqueur = vainqueur;
            NombreParticipants = nombreParticipants;
            Date = date;
        }

    }
}
