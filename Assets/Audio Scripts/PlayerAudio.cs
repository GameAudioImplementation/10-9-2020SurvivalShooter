using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoBehaviour
{
    public LayerMask enemyAudioMask;
    bool enemyNear;
    public AudioMixerSnapshot enemyNearSnapshot;
    public AudioMixerSnapshot enemyFarSnapshot;
    private AudioSource source;
    public AudioClip creak;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 10f, transform.forward, 0f, enemyAudioMask);
        if (hits.Length > 0)
        {
            enemyNear = true;
        }
        else
        {
            enemyNear = false;
        }

        if (enemyNear)
        {
            if (!AudioManager.manager.layerMusic)
            {
                 
            }
        }
      
         /* AudioManager.cs takes care of this now
         if (hits.Length > 0)
            {
            if (!enemyNear)
                {
                    enemyNearSnapshot.TransitionTo(3f);
                    enemyNear = true;
                }
            }
        else
        {
            if (enemyNear)
                {
                    enemyFarSnapshot.TransitionTo(3f);
                    enemyNear = false;
                }
        } */
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        float randomVol = Random.Range(0.3f, 1f);
        source.volume = randomVol;

        float randomTrigger = Random.Range(0f, 1f);

        if (randomTrigger > 0.2f && other.CompareTag("creak"))
        {
            source.PlayOneShot(creak);
        }
    }
    */

}
