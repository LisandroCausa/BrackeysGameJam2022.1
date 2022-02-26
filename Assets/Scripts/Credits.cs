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
        yield return new WaitForSecondsRealtime(3f);
        scenesManagement.scene = -1;
        scenesManagement.nextScene();
    }
}
