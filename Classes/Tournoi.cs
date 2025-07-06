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
        public ICombattant? Vainqueur { get; set; } // Le vainqueur 
        public int NombreParticipants { get; set; } // Le nombre de participant 
        public DateTime Date { get; set; } // La date
        public List<List<ICombattant>> Classements { get; set; } // Les classements des participantes
        public List<(int etape, string nomVainqueur, string nomPerdant)>? HistoriqueCombats { get; set; } // Historique des combats joué pendant l'instance de tournoi

        //Constructeur 
        public Tournoi(int numero, int nombreParticipants, DateTime date, List<List<ICombattant>> classements)
        {
            Numero = numero;
            NombreParticipants = nombreParticipants;
            Date = date;
            Classements = classements;
            HistoriqueCombats = new List<(int, string, string)>();
        }

        // Setter
        public void SetVainqueur(ICombattant vainqueur)
        {
            Vainqueur = vainqueur;
        }

        public void AfficherDonnees()
        {
            Console.WriteLine("\n" +
                    $"\tTournoi n°{this.Numero} :\n" +
                    $"\t\tVainqueur : {this.Vainqueur.GetNom()} - {this.Vainqueur.ObtenirType()}\n" +
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
                    Console.WriteLine($"{place}e : {list[0].GetNom()} ({list[0].ObtenirType()})");
                }
                else
                // Sinon, les afficher avec une virgule
                {
                    Console.Write($"{place}e : ");
                    for(int j = 0; j < list.Count; j++)
                    {
                        ICombattant combattante = list[j];
                        Console.Write($"{combattante.GetNom()}{(j < list.Count - 1 ? ", " : "")}");
                    }
                    Console.WriteLine();
                }
            }
        }

        /**
         * Affiche l'historique des combats du tournoi dans le format suivant :
         *      - Etape : nom de l'étape ou numéro
         *      - Vainqueur : nom du vainqueur
         *      - Vaincu : nom du vaincu
         */
        public void AfficherHistoriqueCombats()
        {
            // Récupérer le nombre d'étapes
            int? nbEtapes = HistoriqueCombats[HistoriqueCombats.Count - 1].etape;
            foreach((int etape, string vainqueur, string vaincu) combat in HistoriqueCombats)
            {
                string etapeTexte;
                if (combat.etape == nbEtapes)
                {
                    etapeTexte = "Finale";
                }
                else if (combat.etape == nbEtapes - 1)
                {
                    etapeTexte = "Demi-Finale";
                }
                else if (combat.etape == nbEtapes - 2)
                {
                    etapeTexte = "Quarts de Finale";
                }
                else if (combat.etape == nbEtapes - 3)
                {
                    etapeTexte = "Huitièmes de Finale";
                }
                else
                {
                    etapeTexte = "";
                }
                Console.WriteLine($"\tEtape: {(etapeTexte == "" ? combat.etape + nbEtapes - 1 : etapeTexte)}\n" +
                    $"\t   Vainqueur/Vaincu : {combat.vainqueur}/{combat.vaincu}\n");
            }
        }
    }
}
