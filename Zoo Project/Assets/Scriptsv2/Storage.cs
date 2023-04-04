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
        {"Rhino", new Dictionary<string, string[]>(){ {"Head", new string[] {"Head", "par 1", "par 2"} },
                                                      {"Ears", new string[] {"Ears", "", ""}},
                                                      {"Body", new string[] {"Body", "", ""}},
                                                      {"Front Legs", new string[] {"Front Legs", "", ""}},
                                                      {"Back Legs", new string[] {"Back Legs", "", ""}},
                                                    } 
        },
    };
}
