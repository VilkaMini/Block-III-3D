using TMPro;
using UnityEngine;
using System;
using System.Linq;

public class ScanModeController : MonoBehaviour
{
    // Animal
    public string animalID = "";
    private int partsScannedCount = 0;

    // Camera
    public Camera viewCamera;

    // UI Panels
    public GameObject informationPanel;
    public GameObject selectionMenu;
    public GameObject foodSelectionMenu;
    public GameObject stickerInformationalPanel;

    //Sticker objects
    public GameObject rhinoSticker;
    public GameObject lionSticker;
    public GameObject giraffeSticker;
    public GameObject stickerObject;

    // UI text in informationPanel
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI extraText;
    public TextMeshProUGUI partsScanned;

    // On/off variables
    private bool foodPanel = false;

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenStickerPanel();
        }

        CheckGaze();
            
        // If Q is pressed open food selection menu 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // If food menu active, close it, else open it
            foodPanel = !foodPanel;
            ControlFoodPanel();
        }
        // If food panel is open choose food
        if (foodPanel)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // Meat
                if (animalID == "Rhino")
                {
                    OpenInformationPanel("Food Selection", "Hey! I can't eat meat, I am strictly vegan and am planning to stay that way!", "I see you have something else in your pocket, may I try that?");
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // Twig
                if (animalID == "Rhino")
                {
                    OpenInformationPanel("Food Selection", "Aww I love this, that is my second-favorite food, can I get more?!", "I see more in your pockets.");
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                // Leaves
                if (animalID == "Rhino")
                {
                    OpenInformationPanel("Food Selection", "Aww I love this, that is my favorite food, can I get more?!", "I see more in your pockets.");
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                // Chocolate
                if (animalID == "Rhino")
                {
                    OpenInformationPanel("Food Selection", "Hey! I can't eat chocolate, my tummy will bubble if I eat that, although it smells really nice.", "I see you have something else in your pocket, may I try that?");

                }
            }
        }

        // If E is pressed, brush animal
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Brushing animal");
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
                if (stickerInformationalPanel.activeSelf){CloseStickerPanel();}
                // Check ray collider tag and display correct text based on tag
                string part = hit.collider.tag;
                string[] partList = { "Head", "Body", "Ears", "Back Legs", "Front Legs", "Sticker", "Egg"};

                // Check if list contains the part
                if (partList.Contains(part))
                {
                    if (part == "Egg")
                    {
                        OpenInformationPanel("Spoopy The Queen!", "You found Spoopy the Queen easter cat!", "You may proceed now...");
                    }
                    else if(part == "Sticker")
                    {
                        if (animalID == "Rhino"){ Storage.rhinoStickerActive = true;}
                        if (animalID == "Lion"){ Storage.lionStickerActive = true;}
                        if (animalID == "Giraffe"){ Storage.giraffeStickerActive = true;}

                        Destroy(stickerObject);
                        CloseInformationPanel();
                        OpenStickerPanel();
                    }
                    else
                    {
                        UpdateStats(part);
                        OpenInformationPanel(Storage.animalInfo[animalID][part][0], Storage.animalInfo[animalID][part][1], Storage.animalInfo[animalID][part][2]);
                    }
                }
                else
                {
                    CloseInformationPanel();
                }
            }
        }
        else
        {
            // If click is not on collider close panel
            if (Input.GetMouseButtonDown(0))
            {
                CloseStickerPanel();
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
    private void OpenStickerPanel()
    {
        if (stickerInformationalPanel.activeSelf) { CloseStickerPanel(); }
        else
        {
            if (Storage.rhinoStickerActive){ rhinoSticker.SetActive(true);}
            if (Storage.lionStickerActive){ lionSticker.SetActive(true);}
            if (Storage.giraffeStickerActive){ giraffeSticker.SetActive(true);}

            stickerInformationalPanel.SetActive(true);
        }
    }

    private void CloseStickerPanel()
    {
        stickerInformationalPanel.SetActive(false);
    }

    // Food panel controller ---------------------------------------
    public void ControlFoodPanel()
    {
        foodSelectionMenu.SetActive(foodPanel);
    }

    // Update stats

    private void UpdateStats(string part)
    {
        if (!Storage.animalPartsScanned[animalID].Contains(part))
        {
            Storage.animalPartsScanned[animalID].Add(part);
            partsScannedCount++;
            partsScanned.text = String.Format("Scanned: {0} / 5", partsScannedCount);
;
        }
    }
}
