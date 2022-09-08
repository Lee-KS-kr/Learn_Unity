using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    // MP3 Player => Audio Source
    // Mp3 음원 => Audio Clip
    // 관객 => Audio Listener

    private AudioSource[] _audioSources = new AudioSource[(int) Define.Sound.MaxCount];
    private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    public void Init()
    {
        GameObject root = GameObject.Find(@"Sound");
        if (root == null)
        {
            root = new GameObject {name = "@Sound"};
            Object.DontDestroyOnLoad(root);

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));
            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject obj =  new GameObject {name = soundNames[i]};
                _audioSources[i] = obj.AddComponent<AudioSource>();
                obj.transform.parent = root.transform;
            }

            _audioSources[(int) Define.Sound.Bgm].loop = true;
        }
    }

    public void Clear()
    {
        foreach (var source in _audioSources)
        {
            source.clip = null;
            source.Stop();
        }
        _audioClips.Clear();
    }
    
    public void Play(string path, Define.Sound type = Define.Sound.Effect,  float pitch = 1.0f)
    {
        AudioClip clip = GetOrAddAudioClip(path, type);
        
        Play(clip, type, pitch);
    }

    public void Play(AudioClip clip, Define.Sound type = Define.Sound.Effect,  float pitch = 1.0f)
    {
        if (clip == null) return;
        if (type == Define.Sound.Bgm)
        {
            AudioSource source = _audioSources[(int) Define.Sound.Bgm];
            if (source.isPlaying)
                source.Stop();
            
            source.pitch = pitch;
            source.clip = clip;
            source.Play();
        }
        else
        {
            AudioSource source = _audioSources[(int) Define.Sound.Effect];
            source.pitch = pitch;
            source.PlayOneShot(clip);
        }
    }

    private AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
    {
        if (!path.Contains("Sounds/"))
            path = $"Sounds/{path}";
        
        AudioClip clip = null;
        if (type == Define.Sound.Bgm)
        {
            clip = Managers.ResourceManager.Load<AudioClip>(path);
        }
        else
        {
            if (!_audioClips.TryGetValue(path, out clip))
            {
                clip = Managers.ResourceManager.Load<AudioClip>(path);
                _audioClips.Add(path, clip);
            }
        }
        
        if (clip == null)
            Debug.Log($"Audio Clip missing! {path}");

        return clip;
    }
}
