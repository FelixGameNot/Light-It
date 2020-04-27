using System;
using System.Collections.Generic;
using Bayat.Json;
using Bayat.SaveSystem;
using Info;
using Objects;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class BaseObjectDefaults
{
    public BaseObject defaultObject;
    public BaseInfo defaultInfo;
}

public class GameManager : SerializedMonoBehaviour
{
    
    public readonly Dictionary<Type, BaseObjectDefaults> objectsStorage;
    public readonly Dictionary<Type, List<BaseInfo>> baseObjects;

    [ReadOnly] public Dictionary<GameObject, BaseObject> sceneObjects;

    private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All
    };
    
    
    private void Start()
    {
        LoadGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void SaveGame()
    {
        Dictionary<Type, List<BaseInfo>> cache = new Dictionary<Type, List<BaseInfo>>();

        foreach (var obj in sceneObjects)
        {
            if (!cache.ContainsKey(obj.Value.type))
            {
                cache.Add(obj.Value.type,new List<BaseInfo>());
            }
            cache[obj.Value.type].Add(obj.Value.GetInfo());
        }

        PlayerPrefs.SetString("Save", JsonConvert.SerializeObject(cache, _settings));
    }
    
    public  void LoadGame()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            LoadSaves();
        }
        else
        {
            LoadDefaults();
        }
    }
    
    public void LoadDefaults()
    {
        CreateObjects(baseObjects);
    }
    
    public void LoadSaves()
    {
        CreateObjects(JsonConvert.DeserializeObject<Dictionary<Type, List<BaseInfo>>>(
                PlayerPrefs.GetString("Save"), _settings));
    }
    
    private void CreateObjects(Dictionary<Type, List<BaseInfo>> collection)
    {
        foreach (var baseObj in collection)
        {
            var type = baseObj.Key;
            foreach (var baseInf in baseObj.Value)
            {
                CreateObject(objectsStorage[type].defaultObject, baseInf);
            }
            
            //switch (type)
            //{
            //    case Type.WINDOW:
            //        foreach (var baseInf in baseObj.Value)
            //        {
            //            CreateObject(objectsStorage[type].defaultObject, baseInf as WindowInfo);
            //        }
            //        break;
            //    case Type.SWITCH:
            //        foreach (var baseInf in baseObj.Value)
            //        {
            //            CreateObject(objectsStorage[type].defaultObject, baseInf as SwitchInfo);
            //        }
            //
            //        break;
            //    case Type.DIMMERB:
            //        foreach (var baseInf in baseObj.Value)
            //        {
            //            CreateObject(objectsStorage[type].defaultObject, baseInf as DimmerInfo);
            //        }
            //        break;
            //    case Type.DIMMERR:
            //        foreach (var baseInf in baseObj.Value)
            //        {
            //            CreateObject(objectsStorage[type].defaultObject, baseInf as DimmerInfo);
            //        }
            //        break;
            //    case Type.DIMMERG:
            //        foreach (var baseInf in baseObj.Value)
            //        {
            //            CreateObject(objectsStorage[type].defaultObject, baseInf as DimmerInfo);
            //        }
            //        break;
            //    default:
            //
            //        break;
            //}

        }
    }



    public void CreateObject(BaseObject prefub, BaseInfo info)
    {
        var obj = Instantiate(prefub);
        obj.Initialize(info);
        obj.onRemove += () => { sceneObjects.Remove(obj.gameObject); };
        sceneObjects.Add(obj.gameObject,obj);
    }
    
    public void SpawnObject(RaycastHit hit, Type objectType)
    {
        var data = objectsStorage[objectType];
        var baseCache = data.defaultInfo;
        baseCache.transformInfo.position = hit.point;
        CreateObject(objectsStorage[objectType].defaultObject, baseCache);
    }
    
}