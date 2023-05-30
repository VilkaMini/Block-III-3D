using TMPro;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class ScanModeController : MonoBehaviour
{
    // Animal
    public string animalID = "";
    private int partsScannedCount = 0;
    public Animator animalAnimator;

    // Camera
    public Camera viewCamera;

    // Watergun
    public ParticleSystem watergun;

    // UI Panels
    public GameObject informationPanel;
    public GameObject foodSelectionMenu;

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

    public List<TextMeshProUGUI> bodyPartTexts;

    private void Awake()
    {
        watergun.Stop();
    }

    void Update()
    {
        if (Input.touchCount > 0) 
        {
            CheckGaze();
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
            // Check ray collider tag and display correct text based on tag
            string part = hit.collider.tag;
            string[] partList = { "Head", "Body", "Ears", "Back Legs", "Front Legs", "Egg", "Horns"};
            print(part);

            // Check if list contains the part
            if (partList.Contains(part))
            {
                UpdateStats(part);
                OpenInformationPanel(Storage.animalInfo[animalID][part][0], Storage.animalInfo[animalID][part][1], Storage.animalInfo[animalID][part][2]);
            }
            else
            {
                CloseInformationPanel();
            }
        }
    }

    // Watergun
    public void ControlWaterGun()
    {
        // Changes state of partical system
        if (watergun.isPlaying){watergun.Stop();}
        else{watergun.Play();}
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

    // Food controller ---------------------------------------
    public void ControlFoodPanel()
    {
        print("Food Control");
        foodSelectionMenu.SetActive(!foodSelectionMenu.activeSelf);
    }

    // Meat
    public void FoodChoiceOne()
    {
        print("Food choice 1");
        if (animalID == "Rhino")
        {
            OpenInformationPanel("Food Selection", "Hey! I can't eat meat, I am strictly vegan and am planning to stay that way!", "I see you have something else in your pocket, may I try that?");
            animalAnimator.Play("Angry", 0, 0.0f);
        }
    }

    // Twig
    public void FoodChoiceTwo()
    {
        print("Food choice 2");
        if (animalID == "Rhino")
        {
            OpenInformationPanel("Food Selection", "Aww I love this, that is my second-favorite food, can I get more?!", "I see more in your pockets.");
            animalAnimator.Play("Happy", 0, 0.0f);
        }
    }

    // Leaves
    public void FoodChoiceThree()
    {
        print("Food choice 3");
        if (animalID == "Rhino")
        {
            OpenInformationPanel("Food Selection", "Aww I love this, that is my favorite food, can I get more?!", "I see more in your pockets.");
            animalAnimator.Play("Happy", 0, 0.0f);
        }
    }

    // Chocolate
    public void FoodChoiceFour()
    {
        print("Food choice 4");
        if (animalID == "Rhino")
        {
            OpenInformationPanel("Food Selection", "Hey! I can't eat chocolate, my tummy will bubble if I eat that, although it smells really nice.", "I see you have something else in your pocket, may I try that?");
            animalAnimator.Play("Angry", 0, 0.0f);

        }
    }

    // Brush control
    public void ControlBrush()
    {
            animalAnimator.Play("Happy", 0, 0.0f);
            Debug.Log("Brushing animal");
    }


    // Update stats

    private void UpdateStats(string part)
    {
        if (!Storage.animalPartsScanned[animalID].Contains(part))
        {
            Storage.animalPartsScanned[animalID].Add(part);
            for (int i=0; i< bodyPartTexts.Count; i++)
            {
                if (bodyPartTexts[i].text == part)
                {
                    bodyPartTexts[i].color = Color.green;
                }
            }
        }
    }

    private void UpdateScannedObjects()
    {

    }
}
