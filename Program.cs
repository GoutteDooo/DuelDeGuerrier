using DuelDeGuerrier.Classes;

namespace DuelDeGuerrier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FourmiNoire bulbizarre = new FourmiNoire("bulbizarre", 35, 3, false);
            FourmiRousse dracofeu = new FourmiRousse("dracofeu", 30, 4);

            bulbizarre.AfficherInfos();
            dracofeu.AfficherInfos();

            int degats = bulbizarre.Attaquer();
            Console.WriteLine("bulbizarre attaque dracofeu avec des dégâts de " + degats);
            dracofeu.SubirDegats(degats);
            dracofeu.AfficherInfos();
            degats = dracofeu.Attaquer();
            Console.WriteLine("dracofeu attaque bulbizarre avec des dégâts de " + degats);
            bulbizarre.SubirDegats(degats);
            bulbizarre.AfficherInfos();
            AfficherMenuPrincipal();
        }

        public static void AfficherMenuPrincipal()
        {
            Console.WriteLine("1.Menu principal");
            Console.WriteLine("2.Créer un guerrier");
            Console.WriteLine("3.Afficher un guerrier");
            Console.WriteLine("Entrée invalide. Veuillez entrer un nombre");
            Console.WriteLine("0. Quitter");
            Console.WriteLine("Veuillez entrée un nombre");
            string saisie = Console.ReadLine();

        }
        
    }
}
