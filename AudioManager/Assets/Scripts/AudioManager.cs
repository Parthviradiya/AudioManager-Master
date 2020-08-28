using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager> {
    public override void Awake () {
        base.Awake ();
        PrepareAudioDictionary ();
    }

    [Header ("Audio Source")]
    public List<Audiosource> AudioSources;

    [Header ("Sounds Collection")]
    public List<Audioclip> Audioclips;
    Dictionary<AudioType, AudioClip> AudioDictionary;
    Dictionary<SourceType, AudioSource> sourceDictionary;
    public void PrepareAudioDictionary () {
        AudioDictionary = new Dictionary<AudioType, AudioClip> ();
        sourceDictionary = new Dictionary<SourceType, AudioSource> ();
        foreach (Audioclip audioclip in Audioclips) {
            AudioDictionary.Add (audioclip._AudioType, audioclip._Audio);
        }
        foreach (Audiosource source in AudioSources) {
            sourceDictionary.Add (source._SourceType, source._Source);
        }
    }
    public void PlayAudio (SourceType sourceType, AudioType audioType) {
        switch (sourceType) {
            case SourceType.Sfx:
                sourceDictionary[sourceType].loop = false;
                sourceDictionary[sourceType].PlayOneShot (AudioDictionary[audioType]);
                break;
            case SourceType.Loop:
                sourceDictionary[sourceType].clip = AudioDictionary[audioType];
                sourceDictionary[sourceType].loop = true;
                sourceDictionary[sourceType].Play ();
                break;
            case SourceType.Background:
                sourceDictionary[sourceType].loop = true;
                sourceDictionary[sourceType].playOnAwake = true;
                sourceDictionary[sourceType].clip = AudioDictionary[audioType];
                sourceDictionary[sourceType].Play ();
                break;
        }
    }
    public void StopAudio (SourceType sourceType) {
        sourceDictionary[sourceType].Stop ();
    }
    public void Mute () {
        foreach (Audiosource source in AudioSources) {
            source._Source.mute = true;
        }
    }

    public void UnMute () {
        foreach (Audiosource source in AudioSources) {
            source._Source.mute = false;
        }
    }
}

[Serializable]
public class Audioclip {
    public AudioType _AudioType;
    public AudioClip _Audio;
}
public enum AudioType {
    Background,
    happy,
    eat,
}

[Serializable]
public class Audiosource {
    public SourceType _SourceType;
    public AudioSource _Source;
}

public enum SourceType {
    Background,
    Loop,
    Sfx
}