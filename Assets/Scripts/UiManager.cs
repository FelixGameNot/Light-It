using System;
using System.Collections;
using System.Collections.Generic;
using _0Game.Scripts.Text;
using Sirenix.OdinInspector;
using UnityEngine;

public class UiManager : SerializedMonoBehaviour
{
    public ITextSetter playerPosText;
    public ITextSetter viewedObjectText;
    
    public static UiManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
