using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    public abstract void Init();
    
    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if(typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);

            if (objects[i] == null)
                Debug.Log($"Failed to bind! : {names[i]}");
        }
    }

    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[index] as T;
    }

    protected Text GetText(int index)
    {
        return Get<Text>(index);
    }
    
    protected Button GetButton(int index)
    {
        return Get<Button>(index);
    }
    
    protected Image GetImage(int index)
    {
        return Get<Image>(index);
    }

    protected GameObject GetObject(int index)
    {
        return Get<GameObject>(index);
    }

    public static void BindEvent(GameObject obj, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler handler = Util.GetOrAddComponent<UI_EventHandler>(obj);

        switch (type)
        {
            case Define.UIEvent.Click:
                handler.OnClickHandler -= action;
                handler.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                handler.OnDragHandler -= action;
                handler.OnDragHandler += action;
                break;
        }
    }
}
