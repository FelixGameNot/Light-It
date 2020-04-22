using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Channel",menuName ="Assets/Color")]
public class ColorChannels : ScriptableObject
{
    public Vector2 clamp;

    public delegate void Rebuild();
    public event Rebuild OnChanged;

    private float _value = 1;
    public float Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (value > clamp.y) _value = clamp.y;
            else if (value < clamp.x) _value = clamp.x;
            else _value = value;

            OnChanged?.Invoke();
        }
    }
}
