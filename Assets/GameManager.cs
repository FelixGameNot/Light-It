using System;
using System.Collections.Generic;
using Info;
using Objects;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameManager : SerializedMonoBehaviour
{
    
    public readonly Dictionary<Type, BaseObject> objects;
    [ReadOnly] public Dictionary<GameObject, BaseObject> sceneObjects;

    public readonly Dictionary<GameObject, BaseObject> baseObjects;
    public Dictionary<Type, List<BaseInfo>> loadedObjectsInfo;
    
    private void Start()
    {
        sceneObjects = baseObjects;
    }

    public void SaveGame()
    {
        var cache = new Dictionary<Type, List<BaseInfo>>();

        foreach (var obj in sceneObjects)
        {
            var objType = obj.Value.type;
        }
    }

    public void LoadGame()
    {
        
    }

    public void SpawnObject(RaycastHit hit, Type objectType)
    {
        var obj = Instantiate(objects[objectType], hit.point, Quaternion.identity);
        obj.onRemove += () => { sceneObjects.Remove(obj.gameObject); };
        sceneObjects.Add(obj.gameObject,obj);
    }
    
}

public enum Type
{
    LAMP,
    BOX,
    TANK
}