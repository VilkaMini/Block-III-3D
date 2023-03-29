using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ScanModeController : MonoBehaviour
{
    public Camera viewCamera;
    public GameObject informationPanel;
    public GameObject selectionMenu;
    public GameObject foodSelectionMenu;
    public TextMeshProUGUI text;
    public Animator selectionAnimator;
    public Animator foodAnimator;
    private bool scanMode = false;
    private bool foodPanel = false;

    // Update is called once per frame
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
                        OpenInformationPanel("That is body!");
                        break;
                    case "Head":
                        OpenInformationPanel("That is head!");
                        break;
                    case "Back Legs":
                        OpenInformationPanel("That is back legs!");
                        break;
                    case "Front Legs":
                        OpenInformationPanel("That is front legs!");
                        break;
                    case "Ears":
                        OpenInformationPanel("That is ears!");
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
    private void OpenInformationPanel(string info)
    {
        CloseInformationPanel();
        text.text = info;
        informationPanel.SetActive(true);
    }

    private void CloseInformationPanel()
    {
        informationPanel.SetActive(false);
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
