using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forestManCollider : MonoBehaviour
{
    public GameObject man;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            man.SetActive(false);
    }
}
