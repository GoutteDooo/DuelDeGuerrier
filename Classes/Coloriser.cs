using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Classes
{
    internal class Coloriser
    {

        public static void ColorerTexte(ConsoleColor couleur, string texte)
        {
            Console.ForegroundColor = couleur;
            Console.Write(texte);
            Console.ResetColor();
        }
    }
}
