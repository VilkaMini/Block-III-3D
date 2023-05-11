using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    // Objects
    public GameObject focalPoint;
    public GameObject settingsPanel;
    public GameObject stickerPanel;

    // Controllers
    public ViewCameraControl cameraController;

    // Movement Sensitivity
    public Slider movementSensSlider;
    public TextMeshProUGUI movSensNumber;

    // Camera Sensitivity
    public Slider cameraSensSlider;
    public TextMeshProUGUI camSensNumber;

    private void Start()
    {
        // Setup movement sensitivity slider
        movementSensSlider.value = cameraController.cameraSpeed;
        movSensNumber.text = ((int)movementSensSlider.value).ToString();
        movementSensSlider.onValueChanged.AddListener(delegate { MovementSensitivityControl(); });
        // Setup camera sensitivity slider
        cameraSensSlider.value = cameraController.cameraMoveSpeed;
        camSensNumber.text = ((int)cameraSensSlider.value).ToString();
        cameraSensSlider.onValueChanged.AddListener(delegate { CameraSensitivityControl(); });
    }

    // Settings 

    public void ControlSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void MovementSensitivityControl()
    {
        cameraController.cameraSpeed = movementSensSlider.value;
        movSensNumber.text = ((int) movementSensSlider.value).ToString();
    }

    public void CameraSensitivityControl()
    {
        cameraController.cameraMoveSpeed = cameraSensSlider.value;
        camSensNumber.text = ((int)cameraSensSlider.value).ToString();
    }

    // Sticker panel

    public void ControlStickerPanel()
    {
        stickerPanel.SetActive(!stickerPanel.activeSelf);
    }
}
