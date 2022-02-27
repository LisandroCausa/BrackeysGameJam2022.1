using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voiceAxis : MonoBehaviour
{
    Transform player;
    public Transform child;
    AudioSource audioSource;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponentInChildren<AudioSource>();
        StartCoroutine(waitForNewPosition());      
    }

    void Update()
    {
        transform.position = player.position;
    }

    IEnumerator waitForNewPosition()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(6.25f, 14f));
            transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            audioSource.volume = Random.Range(0.15f, 0.63f);
            audioSource.Play();
        }
    }
}
