using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenesManagement : MonoBehaviour
{
    public static int scene = 0;

    public static void nextScene()
    {
        scene++;
        SceneManager.LoadScene(scene);
    }
}