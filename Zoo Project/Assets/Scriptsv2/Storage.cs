using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Storage
{
    // Information on animals
    public static Dictionary<string, Dictionary<string, string[]>> animalInfo = new Dictionary<string, Dictionary<string, string[]>>()
    {
        {"Rhino", new Dictionary<string, string[]>(){ {"Head", new string[] {"Head", "Prominent forehead and a tapering snout. The skin on the head is thick and textured, providing protection and resilience in their natural habitat.", "The rhino's ears are relatively small and rounded, while its eyes are relatively small and forward-facing, allowing for a good field of vision." } },
                                                      {"Ears", new string[] {"Ears", "The ears of a rhinoceros are relatively small. Positioned on the sides of the head, they serve an important role in detecting sounds and potential threats in the environment.", "The ears' location and sensitivity allow the rhino to be alert to its surroundings, enhancing its ability to detect approaching predators or other rhinos nearby."}},  
                                                      {"Body", new string[] {"Body", "The rhinoceros has a massive body covered in thick, providing protection against predators. Its muscular build enables swift movement and activities like foraging and defending territories.", "Additionally, rhinos possess adaptations for herbivory, allowing them to consume fibrous plant material efficiently."}},
                                                      {"Front Legs", new string[] {"Front Legs", "The front legs of a rhinoceros are powerful and adapted to support its massive body. These legs provide stability and strength for the rhino's movements.", "They allow it to navigate challenging terrain. They play a crucial role in activities such as running or defending territories."}},
                                                      {"Back Legs", new string[] {"Back Legs", "The back legs of a rhinoceros are strong and vital for its mobility and survival. They provide the necessary power to move quickly and efficiently, allowing it to escape from predators.", "The back legs also play a crucial role in supporting the rhino's weight and balance, enabling it to navigate uneven terrain."}},
                                                      {"Horns", new string[] {"Horns", "The horn of a rhinoceros is a prominent and iconic feature. It is composed of keratin, the same material as human hair and nails, and grows from the skin on the rhino's nose.", "The horns are used for defense against predators and to establish dominance within their social hierarchy."}},
                                                      {"Mouth", new string[] {"Mouth", "", ""}},
                                                      {"Tree", new string[] {"Tree", "", ""}},
                                                    } 
        },
    };

    public static Dictionary<string, List<string>> animalPartsScanned = new Dictionary<string, List<string>>()
    {
        {"Rhino", new List<string>() { } },
    };
}
