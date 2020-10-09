using UnityEngine;
using System.Collections.Generic; //needed to create List

namespace CompleteProject
{
    public class EnemyHealth : MonoBehaviour
    {
        public int startingHealth = 100;            // The amount of health the enemy starts the game with.
        public int currentHealth;                   // The current health the enemy has.
        public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
        public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
        //public AudioClip deathClip;                 // The sound to play when the enemy dies.
        public List<AudioClip> hurtAudioClips = new List<AudioClip>();
        public AudioClip[] deathClips;
        private AudioSource aSource;

        Animator anim;                              // Reference to the animator.
        //AudioSource audioSource;                     // Reference to the audio source.

        ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
        CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
        bool isDead;                                // Whether the enemy is dead.
        bool isSinking;                             // Whether the enemy has started sinking through the floor.


        void Awake()
        {
            // Setting up the references.
            anim = GetComponent<Animator>();
            aSource = GetComponent<AudioSource>();
            hitParticles = GetComponentInChildren<ParticleSystem>();
            capsuleCollider = GetComponent<CapsuleCollider>();

            // Setting the current health when the enemy first spawns.
            currentHealth = startingHealth;
        }


        void Update()
        {
            // If the enemy should be sinking...
            if (isSinking)
            {
                // ... move the enemy down by the sinkSpeed per second.
                transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            }
        }


        public void TakeDamage(int amount, Vector3 hitPoint)
        {
            // If the enemy is dead...
            if (isDead)
                // ... no need to take damage so exit the function.
                return;

            int randomclip = Random.Range(0, hurtAudioClips.Count);
            Debug.Log("OnTriggerEnter" + Time.time);
            float randomVol = Random.Range(0.3f, 0.8f);
            aSource.volume = randomVol;

            float randomPitch = Random.Range(1, 3);
            aSource.pitch = randomPitch;

            // Play the hurt sound effect.
            aSource.PlayOneShot(hurtAudioClips[randomclip]);

            // Reduce the current health by the amount of damage sustained.
            currentHealth -= amount;

            // Set the position of the particle system to where the hit was sustained.
            hitParticles.transform.position = hitPoint;

            // And play the particles.
            hitParticles.Play();

            // If the current health is less than or equal to zero...
            if (currentHealth <= 0)
            {
                // ... the enemy is dead.
                Death();
            }
        }


        void Death()
        {
            // The enemy is dead.
            isDead = true;

            // Turn the collider into a trigger so shots can pass through it.
            capsuleCollider.isTrigger = true;

            // Tell the animator that the enemy is dead.
            anim.SetTrigger("Dead");

            int randomclip = Random.Range(0, hurtAudioClips.Count);
            // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
            aSource.PlayOneShot(hurtAudioClips[randomclip]);
        }


        public void StartSinking()
        {
            // Find and disable the Nav Mesh Agent.
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

            // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
            GetComponent<Rigidbody>().isKinematic = true;

            // The enemy should no sink.
            isSinking = true;

            // Increase the score by the enemy's score value.
            ScoreManager.score += scoreValue;

            // After 2 seconds destory the enemy.
            Destroy(gameObject, 2f);
        }
    }
}