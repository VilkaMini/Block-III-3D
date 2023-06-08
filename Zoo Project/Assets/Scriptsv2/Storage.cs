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
                                                      {"Body", new string[] {"Body", "The rhinoceros has a massive body covered in thick skin, providing protection against predators. Its muscular build enables swift movement and activities like foraging and defending territories.", "Additionally, rhinos possess adaptations for herbivory, allowing them to consume fibrous plant material efficiently."}},
                                                      {"Front Legs", new string[] {"Front Legs", "The front legs of a rhinoceros are powerful and adapted to support its massive body. These legs provide stability and strength for the rhino's movements.", "They allow it to navigate challenging terrain. They play a crucial role in activities such as running or defending territories."}},
                                                      {"Back Legs", new string[] {"Back Legs", "The back legs of a rhinoceros are strong and vital for its mobility and survival. They provide the necessary power to move quickly and efficiently, allowing it to escape from predators.", "The back legs also play a crucial role in supporting the rhino's weight and balance, enabling it to navigate uneven terrain."}},
                                                      {"Horns", new string[] {"Horns", "The horn of a rhinoceros is a prominent and iconic feature. It is composed of keratin, the same material as human hair and nails, and grows from the skin on the rhino's nose.", "The horns are used for defense against predators and to establish dominance within their social hierarchy."}},
                                                      {"Mouth", new string[] {"Mouth", "Rhinos can produce ten different types of vocalizations, including honks for head-to-head fights, bleats for submission, and moo-grunts for communication between mothers and calves. ", ""}},
                                                      {"Tree", new string[] {"Tree", "Acacias are well adapted to deserts and tropical areas. Therefore, they have a wide distribution and are native to Australia, South Africa and South America", "The tall acacia trees of Africa provide an important food source for many animals and are safe host for insects such as ants."}},
                                                      {"Grass", new string[] {"Grass", "The common finger grass is the African savanna's most important forage grass. Animals rely on the long-lived foliage through the dry season when most other types of grass become unpalatable.", ""}},
                                                      {"Waterhole", new string[] {"Waterhole", "Animals flock from all over to congregate at the few vital sources of permanent water left in the landscape.", "As the dry season progresses, waterholes increasingly become dynamic communities of competition, predation, and social interaction."}},
                                                      {"Bird", new string[] {"Bird", "The bird that often hitches a ride on rhinos' backs is called an oxpecker\r\nthey eat bugs and ticks off the rhino's skin.", "The oxpecker's important role is to serve as a warning system for rhinos, helping them stay vigilant and aware of threats. They are known as the \"rhino's guard\" in Swahili."}},
                                                      {"Feces", new string[] {"Feces", "Rhino droppings are unique identifiers, meaning that a rhino can take one whiff of a dung heap and instantly know the animal's age, sex, and reproductive status.", "All rhinos in a particular area head to a communal dumping ground to defecate called a “midden.”"}},
                                                    } 
        },
    };

    public static Dictionary<string, List<string>> animalPartsScanned = new Dictionary<string, List<string>>()
    {
        {"Rhino", new List<string>() { } },
    };
}
