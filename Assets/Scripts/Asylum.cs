using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Asylum : MonoBehaviour
{
    Volume post_processing;

    ChromaticAberration chromaticAberration;
    ColorAdjustments colorAdjustments;
    float saturation_value = -100f;
    bool increase_saturation = true;

    DepthOfField depthOfField;
    float depthOfField_value = 0.1f;
    bool increase_depth = true;

    Vignette vignette;
    float vignette_value = -5f;


    public blackFade fader;

    void Start()
    {
        StartCoroutine(waitToFinishScene());
        post_processing = GetComponent<Volume>();
        if(post_processing.profile.TryGet<ColorAdjustments>(out var _colorAdjustments))
        {
            colorAdjustments = _colorAdjustments;
        }
        if(post_processing.profile.TryGet<ChromaticAberration>(out var _chromaticAberration))
        {
            chromaticAberration = _chromaticAberration;
        }
        if(post_processing.profile.TryGet<Vignette>(out var _vignette))
        {
            vignette = _vignette;
        }
        if(post_processing.profile.TryGet<DepthOfField>(out var _depthOfField))
        {
            depthOfField = _depthOfField;
        }
    }

    void Update()
    {
        chromaticAberration.intensity.value += Time.deltaTime/8;
        if(increase_saturation)
        {
            saturation_value += Time.deltaTime*10;
            if(saturation_value > 100f)
            {
                saturation_value = 100f;
                increase_saturation = false;
            }
        }
        else
        {
            saturation_value -= Time.deltaTime*10;
            if(saturation_value < -100f)
            {
                saturation_value = -100f;
                increase_saturation = true;
            }
        }
        colorAdjustments.saturation.value = saturation_value;

        if(increase_depth)
        {
            depthOfField_value += Time.deltaTime/3;
            if(depthOfField_value > 2f)
            {
                depthOfField_value = 2f;
                increase_depth = false;
            }
        }
        else
        {
            depthOfField_value -= Time.deltaTime/3;
            if(depthOfField_value < 0.1f)
            {
                depthOfField_value = 0.1f;
                increase_depth = true;
            }
        }
        depthOfField.focusDistance.value = depthOfField_value;
    }

    IEnumerator waitToFinishScene()
    {
        yield return new WaitForSecondsRealtime(42f);
        float time = 5f;
        fader.fade(0f, time, blackFade.fadingModes.In);
        yield return new WaitForSecondsRealtime(time + 0.5f);
        scenesManagement.nextScene();
    }
}