using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractBed : MonoBehaviour
{
    public GameObject PressFText;
    public Image blackScreen;
    public GameObject sleepingCamera;
    bool playerIsColliding = false;
    bool sleeping = false;
    float sleepTimer = 0f;

    public TextMeshProUGUI subtitleTired;

    void Update()
    {
        PressFText.SetActive(playerIsColliding);
        if(playerIsColliding && Input.GetKeyDown(KeyCode.F) && !sleeping && scenesManagement.scene == 1)
        {
            sleeping = true;
            sleepTimer = 0f;
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
                StartCoroutine(waitBlackScreen());
                sleeping = false;
            }
        }
    }

    IEnumerator waitBlackScreen()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        scenesManagement.nextScene();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsColliding = true;
            subtitleTired.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsColliding = false;
            subtitleTired.enabled = true;
        }
    }
}