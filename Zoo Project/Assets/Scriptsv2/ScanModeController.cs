using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ScanModeController : MonoBehaviour
{
    // Animal
    public string animalID = "";

    // Camera
    public Camera viewCamera;

    // UI Panels
    public GameObject informationPanel;
    public GameObject selectionMenu;
    public GameObject foodSelectionMenu;
    public GameObject stickerInformationalPanel;

    // Sticker bool
    private bool rhinoStickerActive = false;
    private bool lionStickerActive = false;
    private bool giraffeStickerActive = false;

    //Sticker objects
    public GameObject rhinoSticker;
    public GameObject lionSticker;
    public GameObject giraffeSticker;

    // UI text in informationPanel
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI extraText;
    
    // Selection menu animation
    public Animator selectionAnimator;

    // On/off variables
    private bool scanMode = false;
    private bool foodPanel = false;

    void Update()
    {   
        // Check for E key for scanmode, control state of modes
        if (Input.GetKeyDown(KeyCode.F))
        {
            scanMode = !scanMode;
            if (scanMode)
            {
                OpenSelectionPanel();
            }
            else
            {
                CloseScanMode();
            }
        }
        // If scanmode is active, check for gaze (aka. check if clicked on part to display info) and control interaction menu
        if (scanMode)
        {
            CheckGaze();
            
            // If Q is pressed open food selection menu 
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // If food menu active, close it, else open it
                foodPanel = !foodPanel;
                if (foodPanel)
                {
                    OpenFoodPanel();
                }
                else
                {
                    CloseFoodPanel();
                }
            }
            // If food panel is open choose food
            if (foodPanel)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Debug.Log("Feed 1");
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Debug.Log("Feed 2");
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Debug.Log("Feed 3");
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    Debug.Log("Feed 4");
                }
            }

            // If E is pressed, brush animal
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Brushing animal");
            }
        }
    }

    // Check for raycast to animal part and display correct info
    private void CheckGaze()
    {
        // Cast ray
        Ray gazeRay = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(gazeRay, out hit, Mathf.Infinity))
        {
            // If button clicked
            if (Input.GetMouseButtonDown(0))
            {
                // Check ray collider tag and display correct text based on tag
                var part = hit.collider.tag;
                switch (part)
                {
                    case "Body":
                        OpenInformationPanel("Body", "Body is big!", "Check under the foot");
                        break;
                    case "Head":
                        OpenInformationPanel("Head", "Head is dumb", "head is not round");
                        break;
                    case "Back Legs":
                        OpenInformationPanel("Back Legs", "He can't run lol", "leg short");
                        break;
                    case "Front Legs":
                        OpenInformationPanel("Front Legs", "They are in the front", "leg shorter");
                        break;
                    case "Ears":
                        OpenInformationPanel("Ears", "Hearing is bad", "he hear you");
                        break;
                    case "Sticker":
                        rhinoStickerActive = true;
                        StickerInformationalPanel();
                        break;
                    default:
                        CloseInformationPanel();
                        break;
                }
            }
        }
        else
        {
            // If click is not on collider close panel
            if (Input.GetMouseButtonDown(0))
            {
                CloseInformationPanel();
            }
        }
    }

    // Information panel controllers ------------------------------
    private void OpenInformationPanel(string header, string main, string extra)
    {
        CloseInformationPanel();
        headerText.text = header;
        mainText.text = main;
        extraText.text = extra;
        informationPanel.SetActive(true);
    }

    private void CloseInformationPanel()
    {
        informationPanel.SetActive(false);
    }

    // Sticker panel
    private void StickerInformationalPanel()
    {
        rhinoSticker.SetActive(rhinoStickerActive);
        stickerInformationalPanel.SetActive(true);
            

    }

    // Selection panel controllers --------------------------------
    private void OpenSelectionPanel()
    {
        selectionAnimator.SetBool("open", true);
    }

    private void CloseSelectionPanel()
    {
        selectionAnimator.SetBool("open", false);
    }

    private void CloseScanMode()
    {
        CloseInformationPanel();
        CloseSelectionPanel();
        CloseFoodPanel();
    }

    // Food panel controller ---------------------------------------

    private void CloseFoodPanel()
    {
        foodSelectionMenu.SetActive(false);
    }

    private void OpenFoodPanel()
    {
        foodSelectionMenu.SetActive(true);
    }
}
