using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Storage
{
    // Information on animals
    public static Dictionary<string, Dictionary<string, string[]>> animalInfo = new Dictionary<string, Dictionary<string, string[]>>()
    {
        {"Rhino", new Dictionary<string, string[]>(){ {"Head", new string[] {"Head", "Rhinos use their horns primarily for self-defense and territorial battles with other rhinos. They are also used for digging up soil, roots, and branches while foraging for food.", "Poachers kill rhinos to sell their horns on the black market. The horns are fashioned into jewelry, medicine, and figurines." } },
                                                      {"Ears", new string[] {"Ears", "Rhinos are capable of producing 10 different types of vocalizations.", "Furthermore rhinos make use of grunts as a form of greeting and produce a <color=#FFFF00> “mmwonk” </color> sound to indicate a state of happiness."}},  
                                                      {"Body", new string[] {"Body", "Rhinos can spray urine in a distance of over 16 feet. It has multiple purposes and is typically done in the presence of other males or breeding-age females for marking the territory.", "Female rhinos spray the area before giving birth, likely to mask the scent of the calf."}},
                                                      {"Front Legs", new string[] {"Front Legs", "To avoid wearing out their sensitive feet rhinos typically put most of their weight on their toenails.", "By feeling vibrations through their feet, they can detect the presence of other animals or potential dangers."}},
                                                      {"Back Legs", new string[] {"Back Legs", "Rhinos have evolved to rely on their sense of touch and hearing to navigate their environment, as their eyesight is relatively poor.", "Wait... Something is stuck under his foot! Could you help the Rhino take it off?"}},
                                                    } 
        },
    };

    public static Dictionary<string, List<string>> animalPartsScanned = new Dictionary<string, List<string>>()
    {
        {"Rhino", new List<string>() { } },
    };
}
