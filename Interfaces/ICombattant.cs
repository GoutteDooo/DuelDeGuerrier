using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Interfaces
{
    internal interface ICombattant
    {
        public string GetNom();
        public int GetPointsDeVie();
        public int GetPointsDeVieMax();
        public void SetPointsDeVie(int pointsDeVie);
        public int Attaquer();
        public void SubirDegats(int degats);
        public void AfficherInfos();
        public void ResetMax();
        public void IncrementerVictoires();
        public string ObtenirType();
        public string ObtenirInfos();
        public string GetAscii();
    }
}
