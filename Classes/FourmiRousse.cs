using DuelDeGuerrier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Classes
{
    internal class FourmiRousse : Guerrier, ICombattant
    {
        // Attributs
        // Propriétés
        public override string Type => "Rousse";
        public override string PersonnageAscii => "                               \r\n      .      .      ::=        \r\n         -  *%*%      =%=      \r\n        . + +#*#       -%=     \r\n             .***%*-    %      \r\n           .%%+++#%%+  .=      \r\n          .=  ##+#    ##       \r\n  =#@%%%+%  =+%%+#             \r\n -=       -%%%%#+##            \r\n          +%#*%%*#@+           \r\n       -+**%#%#+%#*## %*       \r\n     .-  +=  =      .  **      \r\n    ==  *-             :-*     \r\n    =  %*              .# +:   \r\n   *. *                  =.*   \r\n     =:                  .+ #  \r\n    =:                      *- \r\n                            =+ ";

        // Constructeur
        public FourmiRousse(string nom, int pointsDeVie, int nbDesAttaque) : base(nom, pointsDeVie, nbDesAttaque)
        {
        }

        // Méthodes
        /**
         * Une Fourmi Rousse infligera toujours au minimum 2 points de dés
         * Si le dés roule sur 1 ou 2, elle infligera 2
         * Si le dés roule sur 3 ou +, elle infligera le dégât indiqué sur le dés
         */
        public override int Attaquer()
        {
            Random random = new Random();
            int rng = random.Next(1, 6+1);
            if (rng <= 2) 
            {
                return 2;
            }
            else
            {
                return rng;
            }
        }

        public override void SubirDegats(int degats)
        {
            Random rng = new Random();
            if (rng.Next(1,7) != 7) // 7 = pare les dégâts
                base.SubirDegats(degats);
        }
    }
}
