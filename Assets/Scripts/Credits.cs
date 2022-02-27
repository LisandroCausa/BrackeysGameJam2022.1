using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(waitToGoToMenu());
    }

    IEnumerator waitToGoToMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitForSecondsRealtime(6f);
        scenesManagement.scene = -1;
        scenesManagement.nextScene();
    }
}
