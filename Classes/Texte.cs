using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelDeGuerrier.Classes
{
    internal class Texte
    {
        /**
         * Affiche le texte passé en paramètre au centre de la console
         */
        public static void WriteLineCentree(string texte)
        {
            int largeurConsole = Console.WindowWidth;
            int positionX = (largeurConsole - texte.Length) / 2;
            if (positionX < 0) positionX = 0;
            Console.SetCursorPosition(positionX, Console.CursorTop);
            Console.WriteLine(texte);
        }
    }
}
