using System;
using System.Collections.Generic;
using System.Linq;
using Bayat.Json;
using Bayat.SaveSystem;
using GameLogic;
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

    public SmoothMouseLook player;
    
    private void Start()
    {
        LoadGame();
    }

    public void SaveGame()
    {
        var cache = new Dictionary<Type, List<BaseInfo>>();

        foreach (var obj in sceneObjects)
        {
            if (!cache.ContainsKey(obj.Value.type))
            {
                cache.Add(obj.Value.type,new List<BaseInfo>());
            }
            cache[obj.Value.type].Add(obj.Value.GetInfo());
        }
        PlayerPrefs.SetString("PlayerSave", JsonConvert.SerializeObject(player.GetTransformInfo()));
        PlayerPrefs.SetString("Save", JsonConvert.SerializeObject(cache, _settings));
    }

    public void DestroyAll()
    {
        foreach (var obj in sceneObjects.Values.ToList())
        {
            obj.ForceRemove();
        }
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
        DestroyAll();
        player.SetTransformInfo(new TransformInfo()
        {
            position = new Vector3(0,1.415f,2.952f),
            scale = Vector3.one
        });
        CreateObjects(baseObjects);
    }
    
    public void LoadSaves()
    {
        DestroyAll();
        player.SetTransformInfo(JsonConvert.DeserializeObject<TransformInfo>(PlayerPrefs.GetString("PlayerSave")));
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