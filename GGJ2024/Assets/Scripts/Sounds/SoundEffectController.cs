using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SoundEffectController : MonoBehaviour
{
    public AudioSource AudioSource; 

    public List<SoundClipDefinition> SoundClipDefinitions;

    Dictionary<string,  SoundClipDefinition> SoundClips;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();

        SoundClips = new Dictionary<string, SoundClipDefinition>();
        foreach (SoundClipDefinition definition in SoundClipDefinitions)
            SoundClips.Add(definition.name, definition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlaySound(string name)
    {
        if (SoundClips.ContainsKey(name))
        {
            AudioSource.clip = SoundClips[name].clip;
            AudioSource.Play();
        }
    }
}

[Serializable]
public class SoundClipDefinition
{
    public string name;

    public string type; 

    public AudioClip clip;
}
