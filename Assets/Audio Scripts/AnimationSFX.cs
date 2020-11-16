using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AnimationSFX : MonoBehaviour
{
    private AudioSource source;
    public List<AudioClip> audioClipList = new List<AudioClip>();
    // Start is called before the first frame update
    
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float volume = 0.5f;
    public float pitch = 0.5f;
    void PlaySound(){
        int randomClipIndex = Random.Range(0, audioClipList.Count);
        //float randomVol = Random.Range(0.3f, 0.5f);
        source.volume = volume;

        //float randomPitch = Random.Range(1, 3);
        source.pitch = pitch;
        source.PlayOneShot(audioClipList[randomClipIndex]);
    }
}
