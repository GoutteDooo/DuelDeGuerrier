using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace DuelDeGuerrier.Classes
{
    /**
     * S'occupe de la musique du jeu
     */
    internal class Audio
    {
        // Dictionnaire contenant tout les chemins des musiques
        static public Dictionary<string, string> cheminAudios = new Dictionary<string, string>
        {
            ["menu_principal"] = "Audio/menu_principal.wav",
            ["guide_utilisateur"] = "Audio/guide_utilisateur.wav",
            ["tournoi"] = "Audio/tournoi.wav",
            ["fight"] = "Audio/fight.wav",
            ["victoire"] = "Audio/victoire.wav"
        };
        static public string musiqueActuelle = cheminAudios["menu_principal"]; // Pour pouvoir jouer/Arrêter la musique à tout instant
        static public SoundPlayer LecteurMusique = new SoundPlayer(musiqueActuelle); // S'occupe de jouer la musique

        public static void LancerMusiqueBoucle(string chemin)
        {
            if (musiqueActuelle != cheminAudios[chemin])
            {
                musiqueActuelle = cheminAudios[chemin];
                LecteurMusique = new SoundPlayer(musiqueActuelle);
                LecteurMusique.PlayLooping();
            }
        }
        public static void LancerMusique(string chemin)
        {
            if (musiqueActuelle != cheminAudios[chemin])
            {
                musiqueActuelle = cheminAudios[chemin];
                LecteurMusique = new SoundPlayer(musiqueActuelle);
                LecteurMusique.Play();
            }
        }

        public static void LancerSon(string chemin)
        {

            SoundPlayer son = new SoundPlayer(cheminAudios[chemin]);
            son.Play();
        }

    }
}
