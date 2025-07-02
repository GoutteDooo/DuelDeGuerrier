using DuelDeGuerrier.Classes;

namespace DuelDeGuerrier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Guerrier lancelot = new Guerrier("Lancelot", 35, 3);
            Guerrier galahad = new Guerrier("Galahad", 30, 4);

            lancelot.AfficherInfos();
            galahad.AfficherInfos();

            int degats = lancelot.Attaquer();
            Console.WriteLine("Lancelot attaque Galahad avec des dégâts de " + degats);
            galahad.SubirDegats(degats);
            galahad.AfficherInfos();
            degats = galahad.Attaquer();
            Console.WriteLine("Galahad attaque Lancelot avec des dégâts de "+ degats);
            lancelot.SubirDegats(degats);
            lancelot.AfficherInfos();
        }
    }
}
