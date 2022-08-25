using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers instance; // 유일성이 보장된다

    public static Managers Instance
    {
        get
        {
            Init();
            return instance;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void Init()
    {
        if (instance == null)
        {
            // 초기화
            GameObject obj = GameObject.Find("@Managers");
            if (obj == null)
            {
                obj = new GameObject {name = "@Managers"};
                obj.AddComponent<Managers>();
            }

            DontDestroyOnLoad(obj);
            instance = obj.GetComponent<Managers>();
        }
    }
}
