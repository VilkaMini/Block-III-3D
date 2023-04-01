using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_sticker_sheet : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject sticker_sheet;
    void Start()
    {
        sticker_sheet.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

            sticker_sheet.SetActive(true);
         
        }
    }
}
