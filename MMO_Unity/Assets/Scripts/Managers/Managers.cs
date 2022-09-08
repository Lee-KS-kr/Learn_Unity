using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers instance; // 유일성이 보장된다
    static Managers Instance
    {
        get
        {
            Init();
            return instance;
        }
    }

    private InputManager _input = new InputManager();
    private ResourceManager _resourceManager = new ResourceManager();
    private UIManager _ui = new UIManager();
    private SceneManagerEx _scene = new SceneManagerEx();
    private SoundManager _sound = new SoundManager();
    private PoolManager _pool = new PoolManager();
    
    public static InputManager Input
    {
        get => Instance._input;
    }
    public static ResourceManager ResourceManager
    {
        get => Instance._resourceManager;
    }
    public static UIManager UI
    {
        get => Instance._ui;
    }
    public static SceneManagerEx Scene
    {
        get => Instance._scene;
    }
    public static SoundManager Sound
    {
        get => Instance._sound;
    }
    public static PoolManager Pool
    {
        get => Instance._pool;
    }
    
    void Start()
    {
        Init();
    }

    void Update()
    {
        _input.OnUpdate();
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
            instance._pool.Init();
            instance._sound.Init();
        }
    }

    public static void Clear()
    {
        Input.Clear();
        Sound.Clear();
        UI.Clear();
        Scene.Clear();
        Pool.Clear();
    }
}
