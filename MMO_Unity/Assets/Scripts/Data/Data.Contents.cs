using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Status

[Serializable]
public class Status
{
    // json에 저장된 이름과 반드시 같게 설정해야 한다
    public int level;
    public int hp;
    public int attack;
}

[Serializable]
public class StatusData : ILoader<int, Status>
{
    public List<Status> status = new List<Status>();

    public Dictionary<int, Status> MakeDict()
    {
        Dictionary<int, Status> dict = new Dictionary<int, Status>();
        foreach (var VARIABLE in status)
            dict.Add(VARIABLE.level, VARIABLE);
        return dict;
    }
}

#endregion

