using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSpeedTest : MonoBehaviour
{
    public GameObject player;
    AudioSource audioSource;
    AudioMixerGroup pitchBendGroup;
    PlayerHealth playerHealth;
    void Start()
    {
        //////Debug.Log("Player: " + player.GetComponentsInChildren)
        playerHealth = player.GetComponentInChildren<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();
        pitchBendGroup = Resources.Load<AudioMixerGroup>("MasterMixer");
        audioSource.outputAudioMixerGroup = pitchBendGroup;
   
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("playerhealth:"+ playerHealth.currentHealth);
        if(playerHealth.currentHealth <= 50){
            float pitchFactor = (-1 / 50) * playerHealth.currentHealth + 2;
            audioSource.pitch = pitchFactor;
            pitchBendGroup.audioMixer.SetFloat("pitch", 1f / pitchFactor);
            Debug.Log("pitchfactor:" + pitchFactor);

        }
        
    }
}
