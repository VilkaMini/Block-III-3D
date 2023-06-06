using TMPro;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;


public class ScanModeController : MonoBehaviour
{
    // Animal
    public string animalID = "";
    public Animator animalAnimator;
    public string lastPartHit;

    // Camera
    public Camera viewCamera;

    // Watergun
    public ParticleSystem watergun;

    // UI Panels
    public GameObject informationPanel;
    public GameObject foodSelectionMenu;

    //Sticker objects
    public GameObject rhinoSticker;
    public GameObject rhinoStickerSilouete;
    public bool isStickerObtained;

    // UI text in informationPanel
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI extraText;

    public List<GameObject> bodyParts;

    public Animator settingsAnim;
    public GameObject settingsExtendButton;

    public GameObject poop;

    private void Awake()
    {
        watergun.Stop();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckGaze();
        }
    }

    // Check for raycast to animal part and display correct info
    private void CheckGaze()
    {
        // Cast ray
        //Ray gazeRay = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        //RaycastHit hit;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Check ray collider tag and display correct text based on tag
            string part = hit.collider.tag;
            string[] partList = { "Head", "Body", "Ears", "Back Legs", "Front Legs", "Horns", "Mouth", "Tree", "Grass", "Waterhole", "Bird", "Feces"};
            if (lastPartHit != part) {
                // Check if list contains the part
                if (partList.Contains(part))
                {
                    lastPartHit = part;
                    UpdateStats(part);
                    OpenInformationPanel(Storage.animalInfo[animalID][part][0], Storage.animalInfo[animalID][part][1], Storage.animalInfo[animalID][part][2]);
                }
                else
                {
                    lastPartHit = null;
                    CloseInformationPanel();
                }
            }
        }
        else
        {
            lastPartHit = null;
            CloseInformationPanel();
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

    public void CloseInformationPanel()
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
            animalAnimator.Play("Angry", 0, 0.0f);
        }
    }

    // Twig
    public void FoodChoiceTwo()
    {
        print("Food choice 2");
        if (animalID == "Rhino")
        {
            animalAnimator.Play("Happy", 0, 0.0f);
            SpawnPoop();
        }
    }

    // Leaves
    public void FoodChoiceThree()
    {
        print("Food choice 3");
        if (animalID == "Rhino")
        {
            animalAnimator.Play("Happy", 0, 0.0f);
            SpawnPoop();
        }
    }

    // Chocolate
    public void FoodChoiceFour()
    {
        print("Food choice 4");
        if (animalID == "Rhino")
        {
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
        // Update list with new part if it is new part
        if (!Storage.animalPartsScanned[animalID].Contains(part))
        {
            Storage.animalPartsScanned[animalID].Add(part);
            for (int i=0; i< bodyParts.Count; i++)
            {
                if (bodyParts[i].name == part)
                {
                    bodyParts[i].SetActive(true);
                }
            }
        }
        // Check if sticker is collected
        if (!isStickerObtained)
        {
            // Check all bodyparts if they are collected
            List<string> allBodyParts = new List<string> { "Head", "Body", "Ears", "Back Legs", "Front Legs", "Horns", "Mouth"}; 
            for (int i=0; i < allBodyParts.Count; i++)
            {
                if (Storage.animalPartsScanned[animalID].Contains(allBodyParts[i]))
                {
                    // If all collected disable individual parts and display full sticker
                    if (allBodyParts.Count-1 == i)
                    {
                        rhinoStickerSilouete.SetActive(false);
                        rhinoSticker.SetActive(true);
                        for (int k=0; k < bodyParts.Count; k++)
                        {
                            if (allBodyParts.Contains(bodyParts[k].name))
                            {
                                bodyParts[k].SetActive(false);
                            }
                        }
                        isStickerObtained = true;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }

    public void ControlSettingsPanel()
    {
        settingsAnim.SetBool("State", !settingsAnim.GetBool("State"));
        settingsExtendButton.SetActive(!settingsExtendButton.activeSelf);
    }

    public void SpawnPoop()
    {
        print("SpawnPoop");
        GameObject new_poop = Instantiate(poop);
        new_poop.transform.position = new Vector3(-1.525879e-05f, 1.5f, -1.995f);
        new_poop.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5.0f);
    }
}
