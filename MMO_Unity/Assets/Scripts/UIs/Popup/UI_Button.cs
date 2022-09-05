using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    private int score = 0;

    enum Texts
    {
        PointText,
        ScoreText,
    }

    enum Buttons
    {
        PointButton,
    }

    enum Images
    {
        ItemIcon,
    }

    enum GameObjects
    {
        TestObject,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));

        GetButton((int) Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);

        GameObject obj = GetImage((int) Images.ItemIcon).gameObject;
        AddUIEvent(obj, (data => { obj.transform.position = data.position; }), Define.UIEvent.Drag);
    }

    public void OnButtonClicked(PointerEventData data)
    {
        score++;
        GetText((int) Texts.ScoreText).text = $"점수 : {score}";
    }
}
