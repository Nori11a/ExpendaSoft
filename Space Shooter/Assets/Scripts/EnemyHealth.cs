using UnityEngine;

namespace CompleteProject
{
    public class EnemyHealth : MonoBehaviour
    {
        public float startingHealth = 5;            // The amount of health the enemy starts the game with.
        public float currentHealth;                   // The current health the enemy has.

		//public AudioClip hurtClip;
		//public AudioClip deathClip;                 // The sound to play when the enemy dies.

        AudioSource enemyAudio;                     // Reference to the audio source.
        //ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
        CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
        //bool isDead;                                // Whether the enemy is dead.

		public GameObject explosion;
		public GameObject playerExplosion;
		public int scoreValue;
		private Done_GameController gameController;

		//public Collider other;

        void Awake ()
        {
            // Setting up the references.
            enemyAudio = GetComponent <AudioSource> ();
           // hitParticles = GetComponentInChildren <ParticleSystem> ();
            capsuleCollider = GetComponent <CapsuleCollider> ();

            // Setting the current health when the enemy first spawns.
            currentHealth = startingHealth;
        }

		void Start ()
		{
			GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}


        /*void Update ()
        {

        }*/

        void Death ()
        {
			enemyAudio.Play();
			Instantiate(playerExplosion, transform.position, transform.rotation);

			// The enemy is dead.
            //isDead = true;

			gameController.AddScore(scoreValue);
			//Destroy (other.gameObject);
			Destroy (gameObject);
        }

		void OnTriggerEnter (Collider other) //this creates an explosion when the enemy gets hit
		{
			if(other.gameObject.layer ==LayerMask.NameToLayer("Projectile") && other.tag != "Enemy")
			{
				// Play the hurt sound effect.
				enemyAudio.Play();

				Instantiate(playerExplosion, transform.position, transform.rotation);

				if (other.tag == "Nu") //when getting hit by their own bullet
				{
					currentHealth -= 1;
				}
				else //when it's you shooting them
				{
					currentHealth -= 1 + Done_PlayerController.power;  //figures out how much damage is taken
				}

				if (currentHealth <= 0) //runs death code if HP hits zero
				{
					Death();
				}
			}

			if (other.tag == "Player")
			{
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver();
			}
			else
			{
				return;
			}
				
		}
			
    }
}