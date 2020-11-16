using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootSteps : MonoBehaviour
{
    private AudioSource source;
    public AudioClip footstep;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Footstep(){
        source.PlayOneShot(footstep, 0.5f);
    }
}
