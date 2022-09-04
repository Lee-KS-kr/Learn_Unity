using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Util
{
    public static T GetOrAddComponent<T>(GameObject obj) where T : UnityEngine.Component
    {
        T comp = obj.GetComponent<T>();
        if (comp == null)
            comp = obj.AddComponent<T>();

        return comp;
    }
    
    public static T FindChild<T>(GameObject obj, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (obj == null) return null;

        if (!recursive)
        {
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                Transform transform = obj.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }  
        else
        {
            foreach (var component in obj.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }

    public static GameObject FindChild(GameObject obj, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(obj, name, recursive);
        if (transform == null)
            return null;

        return transform.gameObject;
    }
}
