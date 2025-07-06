using DuelDeGuerrier.Interfaces;
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
        public ICombattant Vainqueur { get; set; } // Le vainqueur 
        public int NombreParticipants { get; set; } // Le nombre de participant 
        public DateTime Date { get; set; } // La date
        public List<List<ICombattant>> Classements { get; set; } // Les classements des participantes


        public Tournoi()
        {

        }

        //Constructeur 
        public Tournoi(int numero,  ICombattant vainqueur, int nombreParticipants, DateTime date)
        {
            Numero = numero;
            Vainqueur = vainqueur;
            NombreParticipants = nombreParticipants;
            Date = date;
        }

        public void AfficherDonnees()
        {
            Console.WriteLine("\n" +
                    $"\tTournoi n°{this.Numero} :\n" +
                    $"\t\tVainqueur : {this.Vainqueur.GetNom()} - {this.Vainqueur.GetType()}\n" +
                    $"\t\tParticipants : {this.NombreParticipants}\n" +
                    $"\t\tDate de lancement : {this.Date}\n");
        }

        /**
         * Affiche le classement de la liste Classements sous ce format :
         *      1. A (Gagnante)
         *      2. B (Deuxième)
         *      3. C (Eliminée(s) aux quarts de finale)
         *      4. D,E,F (Eliminée(s) aux huitièmes)
         *      etc...
         */
        public void AfficherClassement()
        {
            // Pour chaque liste de Classements
            for (int i = Classements.Count - 1; i >= 0; i--)
            {
                List<ICombattant> list = Classements[i];
                int place = Classements.Count - i;
                // S'il n'y a qu'une seule combattante, l'afficher directement
                if (list.Count == 1)
                {
                    Console.WriteLine($"{place}. {list[0].GetNom()} ({list[0].GetType()})");
                }
                else
                // Sinon, les afficher avec une virgule
                {
                    Console.Write($"{place}. ");
                    for(int j = 0; j < list.Count; j++)
                    {
                        ICombattant combattante = list[j];
                        Console.Write($"{combattante.GetNom()}{(j < list.Count - 1 ? ", " : "")}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
