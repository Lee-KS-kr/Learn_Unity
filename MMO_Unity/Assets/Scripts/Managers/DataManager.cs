using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, Status> StatusDict { get; private set; } = new Dictionary<int, Status>();

    public void Init()
    {
        StatusDict = LoadJason<StatusData, int, Status>("StatusData").MakeDict();
    }

    Loader LoadJason<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.ResourceManager.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
