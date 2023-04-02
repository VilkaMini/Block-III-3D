using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Show_sticker_sheet : MonoBehaviour
{
    public GameObject sticker_sheet;

    void Start()
    {
        sticker_sheet.SetActive(false);
    }

    void Update()
    {
        // if user pressess X button
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            // check if the sticker sheet is already active
            if (sticker_sheet.activeSelf)
            {
                // turn off the sticker sheet
                sticker_sheet.SetActive(false); 
            }
            else
            {
                // turn on the sticker sheet
                sticker_sheet.SetActive(true); 
            }
        }
    }
}

