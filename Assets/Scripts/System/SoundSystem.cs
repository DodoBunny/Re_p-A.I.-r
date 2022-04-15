using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    static public SoundSystem instance;
    new AudioSource audio;

    [SerializeField]
    public AudioClip[] clips;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        if(instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }

    public void PlaySoundEffect(int i)
    {
        audio.PlayOneShot(clips[i]);
    }

    public void PlaySoundClip(int i)
    {
        audio.clip = clips[i];
        audio.Play();
    }


}
