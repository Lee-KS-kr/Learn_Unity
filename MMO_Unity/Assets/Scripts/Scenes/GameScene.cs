﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Inventory>();
        
        for (int i = 0; i < 5; i++)
            Managers.ResourceManager.Instantiate("UnityChan");
    }

    public override void Clear()
    {
        
    }
}
