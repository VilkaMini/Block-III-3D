using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Canvas c;

    public void ExitGame()
    {
        print("Exit Game");
        Application.Quit();
    }
}
