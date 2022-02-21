using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBed : MonoBehaviour
{
    public GameObject PressFText;
    bool playerIsColliding = false;

    void Update()
    {
        PressFText.SetActive(playerIsColliding);
        if(playerIsColliding && Input.GetKeyDown(KeyCode.F))
        {
            // Do Something...
        }
    }


    void OnTriggerStay(Collider other)
    {
        playerIsColliding = true;
    }

    void OnTriggerExit(Collider other)
    {
        playerIsColliding = false;
    }

}
