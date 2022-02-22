using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blackFadeOut : MonoBehaviour
{
    public float blackTime;
    public float FadeOut_duration;

    bool fadeOut = false;
    float alpha;
    Image background;
    Color color;

    void Start()
    {
        background = GetComponent<Image>();
        StartCoroutine(waitForBlackTime(blackTime));
        alpha = 1f;
        color = new Color(0, 0, 0, alpha);
    }

    void Update()
    {
        if(fadeOut && alpha > 0)
        {
            alpha -= Time.deltaTime/FadeOut_duration;
            color.a = alpha;
            background.color = color;
        }
    }

    IEnumerator waitForBlackTime(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        fadeOut = true;
    }
}
