using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Limiter : MonoBehaviour
{

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

}
