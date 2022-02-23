using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class House_PlayerVoice : MonoBehaviour
{
    TextMeshProUGUI subtitle;
    [SerializeField]
    float timeToWait = 0;

    void Start()
    {
        subtitle = GetComponent<TextMeshProUGUI>();
        StartCoroutine(waitToSpeak(timeToWait));
    }

    IEnumerator waitToSpeak(float value)
    {
        yield return new WaitForSecondsRealtime(value);
        subtitle.enabled = true;
        GetComponent<AudioSource>().Play();
    }
}
