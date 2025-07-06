using DuelDeGuerrier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DuelDeGuerrier.Classes
{
    /**
     * Cette classe a pour but de gérer l'enregistrement et le chargement des fourmis
     */
    internal class Ecriture
    {

        /**
         * Enregistre dans un fichier JSON la liste de fourmis passée en paramètre
        */
        public static void SauvegarderFourmis(List<ICombattant> fourmis)
        {
            // test
            Guerrier combattant = new Guerrier("toto", 13, 4);

            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string jsonString = JsonSerializer.Serialize(combattant);
            Console.WriteLine(jsonString);
        }
    }
}
