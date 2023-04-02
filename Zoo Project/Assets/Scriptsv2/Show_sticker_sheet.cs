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
        if (Input.GetKeyDown(KeyCode.X)) // if user pressess X button
        {
            if (sticker_sheet.activeSelf) // check if the sticker sheet is already active
            {
                sticker_sheet.SetActive(false); // turn off the sticker sheet
            }
            else
            {
                sticker_sheet.SetActive(true); // turn on the sticker sheet
            }
        }
    }
}

