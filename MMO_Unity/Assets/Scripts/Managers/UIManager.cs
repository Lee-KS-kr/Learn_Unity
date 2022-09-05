using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private int _order = 10;

    private Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    private UI_Scene _scene = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find($"@UI_Root");
            if (root == null)
                root = new GameObject() {name = $"@UI_Root"};
            return root;
        }
    }

    public void SetCanvus(GameObject obj, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(obj);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject obj = Managers.ResourceManager.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(obj);
        obj.transform.SetParent(Root.transform);
        _popupStack.Push(popup);

        return popup;
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject obj = Managers.ResourceManager.Instantiate($"UI/Scene/{name}");
        T sceneUI = Util.GetOrAddComponent<T>(obj);
        obj.transform.SetParent(Root.transform);
        _scene = sceneUI;

        return sceneUI;
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0) return;

        UI_Popup popup = _popupStack.Pop();
        Managers.ResourceManager.Destroy(popup.gameObject);
        popup = null;

        _order--;
    }

    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0) return;

        if (_popupStack.Peek() != popup)
        {
            Debug.Log("Close Pooup Failed!");
            return;
        }

        ClosePopupUI();
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
        {
            ClosePopupUI();
        }
    }
}