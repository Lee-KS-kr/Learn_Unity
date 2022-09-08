using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip clip;
    public AudioClip clip2;
    private int i = 0;
    private void OnTriggerEnter(Collider other)
    {
        // AudioSource audio = GetComponent<AudioSource>();
        // audio.PlayOneShot(clip);
        // audio.PlayOneShot(clip2);
        // float liftTime = Math.Max(clip.length, clip2.length);
        //
        // Destroy(gameObject, liftTime);
        i++;

        Managers.Sound.Play(clip2);

        if (i % 2 == 0) 
            Managers.Sound.Play( clip, Define.Sound.Bgm);
        else
            Managers.Sound.Play( clip2, Define.Sound.Bgm);
    }
}
