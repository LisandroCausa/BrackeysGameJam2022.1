using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityStandardAssets.Characters.FirstPerson;

public class ShrinkHouse : MonoBehaviour
{
    bool metamorphosis = false;
    public Volume post_processing;
    ChromaticAberration chromaticAberration;
    float lensDistortion_Value = 0f;
    LensDistortion lensDistortion;

    Transform player;
    Vector3 playerScale = new Vector3(1, 1, 1);

    void Start()
    {
        if(post_processing.profile.TryGet<ChromaticAberration>(out var _chromaticAberration))
        {
            chromaticAberration = _chromaticAberration;
        }
        if(post_processing.profile.TryGet<LensDistortion>(out var _lensDistortion))
        {
            lensDistortion = _lensDistortion;
        }
    }

    void Update()
    {
        if(metamorphosis)
        {
            chromaticAberration.intensity.value += Time.deltaTime/7;
            if(lensDistortion_Value < 0.8f)
            {
                lensDistortion_Value += Time.deltaTime/12;
                lensDistortion.intensity.value = lensDistortion_Value;
            }
            playerScale.x -= Time.deltaTime/16;
            playerScale.y -= Time.deltaTime/16;
            playerScale.z -= Time.deltaTime/16;
            if(playerScale.x <= 0.1f)
            {
                playerScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
            player.localScale = playerScale;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            var playerGameObject = GameObject.FindGameObjectWithTag("Player");
            player = playerGameObject.transform;
            var fp = playerGameObject.GetComponent<FirstPersonController>();
            fp.m_WalkSpeed = fp.m_WalkSpeed / 3;
            fp.m_RunSpeed = fp.m_RunSpeed / 4;
            metamorphosis = true;
            post_processing.enabled = true;
            GetComponent<BoxCollider>().enabled = false;
        }
    }

}
