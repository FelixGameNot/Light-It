using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFader : MonoBehaviour
{
    public Light lerntine;

    public BoolValue bv;

    private void Start()
    {
        bv.OnChanged += () => StartCoroutine(Fade(bv.Value));
        lerntine.intensity = bv.Value ? 1 : 0;
    }

    IEnumerator Fade(bool _in)
    {
        if(_in)
            for (float t = 0f; t <= 1f; t += Time.fixedDeltaTime)
            {
                lerntine.intensity = t;
                yield return new WaitForFixedUpdate();
            }
        else
            for (float t = 1f; t >= 0f; t -= Time.fixedDeltaTime)
            {
                lerntine.intensity = t;
                yield return new WaitForFixedUpdate();
            }
    }

}