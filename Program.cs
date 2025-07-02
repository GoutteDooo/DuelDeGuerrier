using DuelDeGuerrier.Classes;

namespace DuelDeGuerrier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Guerrier fourmi = new Guerrier("titi", 150, 10);
            fourmi.AfficherInfos();
            fourmi.SubirDegats(fourmi.Attaquer());
            fourmi.AfficherInfos();

        }
    }
}
