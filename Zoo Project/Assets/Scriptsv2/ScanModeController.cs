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
    public TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        CheckGaze();
    }

    private void CheckGaze()
    {
        Ray gazeRay = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(gazeRay, out hit, Mathf.Infinity))
        {
            if (Input.GetMouseButtonDown(0))
            {
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
            if (Input.GetMouseButtonDown(0))
            {
                CloseInformationPanel();
            }
        }
    }

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

}
