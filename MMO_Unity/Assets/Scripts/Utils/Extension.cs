using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    public static void AddUIEvent(this GameObject obj, Action<PointerEventData> action,
        Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.BindEvent(obj, action, type);
    }
    
    public static T GetOrAddComponent<T>(this GameObject obj) where T : UnityEngine.Component
    {
        return Util.GetOrAddComponent<T>(obj);
    }
}
