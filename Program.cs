using DuelDeGuerrier.Classes;

namespace DuelDeGuerrier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AfficherMenuPrincipal();
        }

        public static void AfficherMenuPrincipal()
        {
            Console.WriteLine("--- Menu principal ---");
            Console.WriteLine("1. Créer un guerrier");
            Console.WriteLine("2. Afficher un guerrier\n");
            Console.WriteLine("0. Quitter");
            Console.WriteLine("Veuillez entrée un nombre");
            string saisie = Console.ReadLine();

            if (saisie == "1") // Si le joueur veut créer un guerrier
            {
                AjouterGuerrier();
            }
        }

        /**
         * Permet de créer une fourmi guerrière (Guerrier) personnalisé
         */
        public static void AjouterGuerrier()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"---- Créer un Guerrier ----\n" +
                    $"Quel type de fourmi souhaitez-vous créer ?\n" +
                    $"1. Fourmi Noire (Défense élevée)\n" +
                    $"2. Fourmi Rousse (Attaque élevée)\n\n" +
                    $"0. Quitter le sous-menu");
                Console.Write("> ");
                string saisie = Console.ReadLine();
            }
        }
        
    }
}
