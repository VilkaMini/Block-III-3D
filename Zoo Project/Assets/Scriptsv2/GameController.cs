using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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
        movementSensSlider.value = cameraController.cameraArmMovementSpeed;
        movSensNumber.text = (movementSensSlider.value).ToString();
        movementSensSlider.onValueChanged.AddListener(delegate { MovementSensitivityControl(); });
        // Setup camera sensitivity slider
        cameraSensSlider.value = cameraController.cameraMoveSpeed;
        camSensNumber.text = (cameraSensSlider.value).ToString();
        cameraSensSlider.onValueChanged.AddListener(delegate { CameraSensitivityControl(); });
    }

    // Settings 

    public void ControlSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void MovementSensitivityControl()
    {
        cameraController.cameraArmMovementSpeed = movementSensSlider.value;
        movSensNumber.text = (Math.Round((decimal)movementSensSlider.value, 2)).ToString();
    }

    public void CameraSensitivityControl()
    {
        cameraController.cameraMoveSpeed = cameraSensSlider.value;
        camSensNumber.text = (Math.Round((decimal)cameraSensSlider.value, 2)).ToString();
    }

    // Sticker panel

    public void ControlStickerPanel()
    {
        stickerPanel.SetActive(!stickerPanel.activeSelf);
    }

    
}
