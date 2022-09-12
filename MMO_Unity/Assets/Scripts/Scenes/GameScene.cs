using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private Coroutine co;
    
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Inventory>();

        co = StartCoroutine("ExplodeAfterSeconds", 4f);
        StartCoroutine("StopExplode", 2f);
    }

    public override void Clear()
    {
        
    }

    IEnumerator ExplodeAfterSeconds(float seconds)
    {
        Debug.Log("Explode Enter");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Exploded");
        co = null;
    }

    IEnumerator StopExplode(float seconds)
    {
        Debug.Log("Stop Enter");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Stop Execute");
        if (co != null)
        {
            StopCoroutine(co);
            co = null;
        }
    }
}
