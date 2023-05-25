using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName: "ZooRoomRhino");
    }
    public void OpenProfile()
    {
        // Open panel with profile
    }
}
