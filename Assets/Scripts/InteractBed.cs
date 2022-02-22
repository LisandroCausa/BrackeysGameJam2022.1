using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractBed : MonoBehaviour
{
    public GameObject PressFText;
    public Image blackScreen;
    public GameObject sleepingCamera;
    bool playerIsColliding = false;
    bool sleeping = false;
    float sleepTimer = 0f;

    void Update()
    {
        PressFText.SetActive(playerIsColliding);
        if(playerIsColliding && Input.GetKeyDown(KeyCode.F) && !sleeping)
        {
            // Do Something...
            sleeping = true;
            playerIsColliding = false;
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
            sleepingCamera.SetActive(true);
        }

        if(sleeping)
        {
            sleepTimer += Time.deltaTime/3;
            blackScreen.color = new Color(0, 0, 0, sleepTimer);
            if(sleepTimer > 1)
            {
                //scenesManagement.scene++;
                scenesManagement.nextScene();
            }
        }
    }


    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
            playerIsColliding = true;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            playerIsColliding = false;
    }

}
