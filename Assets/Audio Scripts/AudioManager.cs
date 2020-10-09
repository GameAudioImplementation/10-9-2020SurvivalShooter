using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource mainMusic;
    public AudioSource layerMusic;
    public AudioSource ambSound;
    public AudioSource reverb;
    public AudioSource eventMusic;

    public AudioMixerSnapshot eventSnapshot;
    public AudioMixerSnapshot noEventSnapshot;

    public bool eventRunning;
    public bool layer;

    public static AudioManager manager;

    private void Awake()
    {
        manager = this;
    }

    public IEnumerator PlayEventMusic()
    {
        eventRunning = true;
        eventSnapshot.TransitionTo(0.25f);
        yield return new WaitForSeconds(0.3f);

        eventMusic.Play();
        while (eventMusic.isPlaying)
        {
            yield return null;
        }
        eventRunning = false;
        noEventSnapshot.TransitionTo(0.5f);
        yield break;
        
    }
}
