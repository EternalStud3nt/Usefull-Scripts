using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLibrary : MonoBehaviour
{
    [SerializeField] List<Sound> library;
    public void PlaySound(string id)
    {
        Sound sound = GetSound(id);
        if(sound!=null)
        {
            if (sound.audioSource == null)
            {
                sound.audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
                sound.audioSource.volume = sound.volume;
                sound.audioSource.clip = sound.audioClip;
            }
            sound.audioSource.Play();
        } 
    }

    private Sound GetSound(string id)
    {
        for(int i = 0; i<library.Count; i++)
        {
            if(library[i].soundID == id)
            {
                return library[i];
            }
        }

        Debug.LogError("There is no sound with the id: " + id + " in the gameObject: " + gameObject.name);
        return null;
    }
}

[System.Serializable]
public class Sound
{
    public string soundID;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume;
    [HideInInspector] public AudioSource audioSource;
}