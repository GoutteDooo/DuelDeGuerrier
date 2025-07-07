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
            // [ Guerrier fourmi1, FourmiRousse fourmi2, BalleDeFusil fourmi3, ...]
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

        /**
         * Cette méthode permet de créer une liste de fourmis à partir du fichier "sauvegarde.json"
         */
        public static List<ICombattant> ChargerFourmis()
        {
            List<ICombattant> fourmis = new List<ICombattant>();
            // Cas
            // Si le fichier n'existe pas
            if (!File.Exists("sauvegarde.json"))
            {
                Console.WriteLine("Pas de fichier de sauvegarde trouvé :(...");
                return fourmis;
            }
            // Récupérer le fichier sous forme de string
            string sauvegarde = File.ReadAllText("sauvegarde.json");

            try
            {
                // Instancie un objet de type JsonDocument pour effectuer des manipulations importantes dessus
                var sauvegardeRacine = JsonDocument.Parse(sauvegarde).RootElement;

                // Si le fichier a une mauvaise syntaxe
                if (sauvegardeRacine.ValueKind != JsonValueKind.Array)
                {
                    Console.WriteLine("Le fichier ne contient pas de tableau JSON!");
                    return fourmis;
                }
                
                foreach (var element in sauvegardeRacine.EnumerateArray()) // sauvegardeRacine possède la méthode EnumerateArray() pour pouvoir itérer
                {
                    if (!element.TryGetProperty("Type", out var typeProp)) // Vérifie que l'objet json possède bien la propriété "Type"
                    {
                        Console.WriteLine("Element sans type trouvé.");
                        continue;
                    }
                    // Si oui,
                    string? type = typeProp.GetString();
                    // Il va falloir faire la conversion (utf8 ?) "Guerri\u00E8re" => "Guerrière"
                    // Récupère la propriété type et désérialise l'objet json en fonction de celui-ci
                    ICombattant? fourmi = type switch
                    {
                        "Guerrière" => JsonSerializer.Deserialize<Guerrier>(element.GetRawText()),
                        "Noire" => JsonSerializer.Deserialize<FourmiNoire>(element.GetRawText()),
                        "Rousse" => JsonSerializer.Deserialize<FourmiRousse>(element.GetRawText()),
                        "Balle De Fusil" => JsonSerializer.Deserialize<BalleDeFusil>(element.GetRawText()),
                        _ => throw new InvalidOperationException($"Type inconnu : {type}")
                    };
                    // Lorsque toutes les vérifications sont faites, on ajoute la fourmi à la liste
                    fourmis.Add(fourmi);
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erreur de lecture JSON : {ex.Message}");
            }

            Console.WriteLine("Chargement réalisé avec succès.");
            return fourmis;
        }
    }
}
