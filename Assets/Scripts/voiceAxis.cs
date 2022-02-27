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
            transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            child.position = new Vector3(Random.Range(15f, 40f), 0f, 0f);
            audioSource.Play();
            yield return new WaitForSecondsRealtime(Random.Range(5f, 10f));
        }
    }
}
