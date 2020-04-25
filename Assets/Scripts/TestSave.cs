using System.Collections;
using System.Collections.Generic;
using Bayat.SaveSystem;
using Sirenix.OdinInspector;
using UnityEngine;

public class TestSave : SerializedMonoBehaviour
{
    
    public List<GameObject> integers = new List<GameObject>();
    [Button]
    public async void SaveDictionary()
    {
        await SaveSystemAPI.SaveAsync("gamno.txt", integers);
    }

    [Button]
    public async void LoadDictionary()
    {
        await SaveSystemAPI.LoadIntoAsync("gamno.txt", integers);
    }
    
}