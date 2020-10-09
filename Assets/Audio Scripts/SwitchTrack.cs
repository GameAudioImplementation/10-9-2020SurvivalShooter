using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrack: MonoBehaviour
{
    public AudioClip mainMusicClip;
    public AudioClip altMusic;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("music"))
        {
            AudioManager.manager.mainMusic.clip = mainMusicClip;
            AudioManager.manager.layerMusic.clip = altMusic;

            AudioManager.manager.mainMusic.Play();
            AudioManager.manager.layerMusic.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
