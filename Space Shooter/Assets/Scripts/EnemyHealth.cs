using UnityEngine;

namespace CompleteProject
{
    public class EnemyHealth : MonoBehaviour
    {
        public int startingHealth = 5;            // The amount of health the enemy starts the game with.
        public int currentHealth;                   // The current health the enemy has.
        public AudioClip deathClip;                 // The sound to play when the enemy dies.

        AudioSource enemyAudio;                     // Reference to the audio source.
        ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
        CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
        bool isDead;                                // Whether the enemy is dead.
        bool isSinking;                             // Whether the enemy has started sinking through the floor.



		public GameObject explosion;
		public GameObject playerExplosion;
		public int scoreValue;
		private Done_GameController gameController;

		public Collider other;

        void Awake ()
        {
            // Setting up the references.
            enemyAudio = GetComponent <AudioSource> ();
            hitParticles = GetComponentInChildren <ParticleSystem> ();
            capsuleCollider = GetComponent <CapsuleCollider> ();

            // Setting the current health when the enemy first spawns.
            currentHealth = startingHealth;
        }

		void Start ()
		{
			GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}


        void Update ()
        {

        }


        public void TakeDamage (int amount/*, Vector3 hitPoint*/)
        {
            // If the enemy is dead...
            if(isDead)
                // ... no need to take damage so exit the function.
                return;

            // Play the hurt sound effect.
           // enemyAudio.Play ();

            // Reduce the current health by the amount of damage sustained.
            currentHealth -= amount;
            
            // Set the position of the particle system to where the hit was sustained.
            //hitParticles.transform.position = hitPoint;

            // And play the particles.
            hitParticles.Play();

            // If the current health is less than or equal to zero...
            if(currentHealth <= 0)
            {
                // ... the enemy is dead.
                Death ();
            }
        }


        void Death ()
        {
            // The enemy is dead.
            isDead = true;

            // Turn the collider into a trigger so shots can pass through it.
            capsuleCollider.isTrigger = true;

            // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
            //enemyAudio.clip = deathClip;
            //enemyAudio.Play ();

			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

			gameController.AddScore(scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
        }
			
    }
}