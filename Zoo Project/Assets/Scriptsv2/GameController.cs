using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public GameObject focalPoint;
    public GameObject settingsPanel;
    public GameObject stickerPanel;

    // Settings 

    public void OpenSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    // Sticker panel

    public void ControlStickerPanel()
    {
        if (stickerPanel.activeSelf)
        {
            stickerPanel.SetActive(false);
        }
        else
        {
            //if (Storage.rhinoStickerActive) { rhinoSticker.SetActive(true); }
            //if (Storage.lionStickerActive) { lionSticker.SetActive(true); }
            //if (Storage.giraffeStickerActive) { giraffeSticker.SetActive(true); }

            stickerPanel.SetActive(true);
        }
    }
}
