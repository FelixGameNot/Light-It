using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private Light _light;

    public ColorChannels[] channels;

    private void Start()
    {
        _light = GetComponent<Light>();
        foreach(var ch in channels)
        {
            ch.OnChanged += RebuildTheColor;
        }
        RebuildTheColor();
    }

    public void RebuildTheColor()
    {
        _light.color = new Color(channels[0].Value, channels[1].Value, channels[2].Value);
    }
}