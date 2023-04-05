using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Storage
{
    // Sticker bool
    public static bool rhinoStickerActive = false;
    public static bool lionStickerActive = false;
    public static bool giraffeStickerActive = false;

    // Information on animals
    public static Dictionary<string, Dictionary<string, string[]>> animalInfo = new Dictionary<string, Dictionary<string, string[]>>()
    {
        {"Rhino", new Dictionary<string, string[]>(){ {"Head", new string[] {"Head", "Rhinos are capable of producing 10 different types of vocalizations.", "Furthermore rhinos make use of grunts as a form of greeting and produce a <color=#FFFF00> “mmwonk” </color> sound to indicate a state of happiness." } },
                                                      {"Ears", new string[] {"Ears", "", ""}},  
                                                      {"Body", new string[] {"Body", "", ""}},
                                                      {"Front Legs", new string[] {"Front Legs", "", ""}},
                                                      {"Back Legs", new string[] {"Back Legs", "", ""}},
                                                    } 
        },
    };
}
