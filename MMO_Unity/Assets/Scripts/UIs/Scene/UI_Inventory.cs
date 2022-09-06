﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : UI_Scene
{
    enum GameObjects
    {
        GridPanel,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int) GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
        {
            Managers.ResourceManager.Destroy(child.gameObject);
        }

        for (int i = 0; i < 8; i++)
        {
            // GameObject item = Managers.ResourceManager.Instantiate($"UI/Scene/UI_Inven_Item");
            // item.transform.SetParent(gridPanel.transform);

            GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(parent: gridPanel.transform).gameObject;
            UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();
            invenItem.SetInfo($"집행검 {i + 1}");
        }
    }
}
