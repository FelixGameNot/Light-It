using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class LightFader : MonoBehaviour
{
    [SerializeField] private Light lamp;
    [SerializeField] private BoolValue bv;

    private void Start()
    {
        bv.OnChanged += () => StartCoroutine(Fade(bv.Value));
        lamp.intensity = bv.Value ? 1 : 0;
    }

    private IEnumerator Fade(bool @in)
    {
        if(@in)
            for (var t = 0f; t <= 1f; t += Time.fixedDeltaTime)
            {
                lamp.intensity = t;
                yield return new WaitForFixedUpdate();
            }
        else
            for (var t = 1f; t >= 0f; t -= Time.fixedDeltaTime)
            {
                lamp.intensity = t;
                yield return new WaitForFixedUpdate();
            }
    }

}