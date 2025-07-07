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
    internal class ChargerSauvegarder
    {
        /**
         * Enregistre dans un fichier JSON la liste de fourmis passée en paramètre
        */
        public static void SauvegarderFourmis(List<ICombattant> fourmis)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            List<string> ElementsJSON = new List<string>();
            // Pour chaque fourmi
            foreach (ICombattant fourmi in fourmis)
            {
                string StringJSON = JsonSerializer.Serialize(fourmi, fourmi.GetType(), options); // Serialiser la fourmi en une string json
                Console.WriteLine(StringJSON); // test
                ElementsJSON.Add(StringJSON); // Ajouter cette string JSON à la liste de string
            }
            //Convertir la liste en une seule string
            string ConversionJSONString = "[\n" + string.Join(",\n", ElementsJSON) + "\n]";

            // Effectuer l'enregistrement dans un fichier
            File.WriteAllText("sauvegarde.json", ConversionJSONString);
        }
    }
}
