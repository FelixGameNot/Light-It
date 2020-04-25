using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameManager : SerializedMonoBehaviour
{
    
    public readonly Dictionary<Type, GameObject> Objects = new Dictionary<Type, GameObject>();
    [ReadOnly]
    public Dictionary<GameObject, BaseObject> SceneObjects = new Dictionary<GameObject, BaseObject>();

    public readonly Dictionary<GameObject, BaseObject> BaseObjects = new Dictionary<GameObject, BaseObject>();

    private void Start()
    {
        SceneObjects = BaseObjects;
    }

    public void SaveGame()
    {
        
    }

    public void LoadGame()
    {
        
    }
    
}

public enum Type
{
    LAMP
}