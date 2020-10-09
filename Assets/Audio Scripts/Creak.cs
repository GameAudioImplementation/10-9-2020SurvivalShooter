using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Creak : MonoBehaviour
{
    private AudioSource source;
    public List<AudioClip> audioClips = new List<AudioClip>();
    private bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!waiting)
        {
            int randomclip = Random.Range(0, audioClips.Count);
            Debug.Log("OnTriggerEnter" + Time.time);
            float randomVol = Random.Range(0.4f, 0.7f);
            source.volume = randomVol;

            float randomPitch = Random.Range(1, 3);
            source.pitch = randomPitch;

            float randomTrigger = Random.Range(0f, 1f);
            if (randomTrigger > 0.2f && (other.CompareTag("Creak") || other.CompareTag("Player")))
            {
                source.PlayOneShot(audioClips[randomclip]);
                Debug.Log("Creak Script");
                waiting = true;
                StartCoroutine(PauseSound());
            }
        }
    }

    private IEnumerator PauseSound()
    {
        float randTime = Random.Range(1f, 5f);
        yield return new WaitForSeconds(randTime);
        waiting = false;
    }
}
