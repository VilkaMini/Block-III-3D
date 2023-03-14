using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInteraction : MonoBehaviour {

    private void OnCollisionStay(Collision collision) {
       
        //Check if player is next to an animal 
       if (collision.gameObject.tag == "Player") {

            //Check if button is pressed 
            if (Input.GetKey(KeyCode.E)) {
                Debug.Log("clicked");

            }
        }

    }

}

