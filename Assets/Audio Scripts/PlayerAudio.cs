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
    public AudioClip heartBeatClip;
 
  
    //public ParticleSystemEmitterVelocityMode; 
    public AudioMixer mixer;
    public float maxDistance;
    //public AnimationCurve GetCustomCurve(CustomRolloff type);
    public float heartBeatLowPass = 0.5f;
    public void LowPass(float lowpass){
        mixer.SetFloat("lowPass", lowpass);
    }
    //public void ClearFloat(float lowpass){
    //    mixer.ClearFloat("lowPass");
    //}
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        LowPass(heartBeatLowPass);
        enemyNear = false;
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 5f, transform.forward, 0f, enemyAudioMask);
        
        if (hits.Length > 0)
        {
            Debug.Log("hit length:" + hits.Length + " " + hits[0].collider.gameObject.name);
            foreach(RaycastHit hit in hits){
                 Debug.Log("Ray: " + hit.collider.gameObject.name + " " + hit.distance);
            }
          
            float distance = Vector3.Distance(hits[0].transform.position, transform.position);
            Debug.Log("distance:" + distance);
            if(distance > 1.5f){
                float lowPassCutoff = -56 * distance + 290;
                LowPass(lowPassCutoff);
            }
            else{
                LowPass(22000);
            }
        
            if (!enemyNear)
            {
               if (!source.isPlaying){
                   source.PlayOneShot(heartBeatClip);
               }
                
        
                //source.loop = true;
                //enemyNearSnapshot.TransitionTo(3f);
                enemyNear = true;
            }
        }
       else
       {
           if (enemyNear)
            {
                //enemyFarSnapshot.TransitionTo(3f);
                enemyNear = false;
            }
        }
          /*  private void OnDrawGizmos()
            {
                Gizmos.DrawWireSphere(transform.position, 5f);
            }*/
    }
}

        /*foreach (var hit in hits)
        {
           if (hit.collider.CompareTag("enemy"))
            {
                enemyNear = true;
            }
            
        }
        
        if (enemyNear && !source.isPlaying)
        {
           source.loop = true;
            source.PlayOneShot(heartBeatClip);
            enemyNearSnapshot.TransitionTo(3f);
        }
        else
        {
            enemyFarSnapshot.TransitionTo(3f);
        }
        //if (hits.Length > 0)
        */




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
                if (enemyNear)
       {
           if (!AudioManager.manager.layerMusic)
           {

           }
       }
       } */
    
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
