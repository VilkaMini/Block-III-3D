using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Check for F press to start game
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeToGame();
        }
    }

    public void ChangeToGame()
    {
        SceneManager.LoadScene("ZooRoomRhino");
    }
}
