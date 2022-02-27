using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WakeUp : MonoBehaviour
{
    public GameObject bedCamera;
    public GameObject player;
    [Space]
    [Space]
    public float time;

    void Start()
    {
        StartCoroutine(changeToFirstPerson(time));
    }

    IEnumerator changeToFirstPerson(float value)
    {
        yield return new WaitForSecondsRealtime(value);
        player.SetActive(true);
        bedCamera.SetActive(false);
    }
}