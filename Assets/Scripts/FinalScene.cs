using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(waitToFadeIn());
    }

    IEnumerator waitToFadeIn()
    {
        yield return new WaitForSecondsRealtime(6.5f);
        float time = 3f;
        GetComponent<blackFade>().fade(0f, time, blackFade.fadingModes.In);
        yield return new WaitForSecondsRealtime(time + 1f);
        scenesManagement.nextScene();
    }
}