using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blackFade : MonoBehaviour
{
    Image background;
    Color color;

    bool doFade = false;
    float alpha;
    int sign = 1;
    float _fadeDuration;

    /* PARAMETERS */
    [SerializeField]
    bool fadeOut = false;
    [SerializeField]
    float blackTime = 0f;
    [SerializeField]
    float duration = 0f;
    /*============*/

    void Start()
    {
        background = GetComponent<Image>();
        color = new Color(0, 0, 0, 0);
        if(fadeOut)
        {
            fade(blackTime, duration, fadingModes.Out);
        }
    }

    void Update()
    {
        if(doFade)
        {
            alpha += sign * Time.deltaTime/_fadeDuration;
            setAlpha(alpha);
            if((sign == 1 && alpha >= 1f) || (sign == -1 && alpha <= 0f))
                doFade = false;
        }
    }

    void setAlpha(float value)
    {
        color.a = value;
        background.color = color;
    }

    public enum fadingModes { Out, In };
    public void fade(float priorWaitingTime, float fadeDuration, fadingModes mode)
    {
        _fadeDuration = fadeDuration;
        if(mode == fadingModes.In)
        {
            alpha = 0f;
            sign = 1;
        }
        else
        {
            alpha = 1f;
            sign = -1;
        }
        setAlpha(alpha);
        StartCoroutine(waitToStartFading(priorWaitingTime));
    }

    IEnumerator waitToStartFading(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        doFade = true;
    }
}