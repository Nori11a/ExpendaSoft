using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyAttack : MonoBehaviour
    {
        public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
        public float attackDamage = 10;               // The amount of health taken away per attack.


        Animator anim;                              // Reference to the animator component.
        GameObject player;                          // Reference to the player GameObject.
		GameObject enemy;
        PlayerHealth playerHealth;                  // Reference to the player's health.
        EnemyHealth enemyHealth;                    // Reference to this enemy's health.
        bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
        float timer;                                // Timer for counting up to the next attack.

		public GameObject explosion;
		public GameObject playerExplosion;

        void Awake ()
        {
            // Setting up the references.
            player = GameObject.FindGameObjectWithTag ("Player");
			enemy = GameObject.FindGameObjectWithTag("Enemy");
			playerHealth = player.GetComponent <PlayerHealth>();
            enemyHealth = enemy.GetComponent<EnemyHealth>();
            anim = GetComponent <Animator> ();
        }


        void OnTriggerEnter (Collider other)
        {
			if(other.gameObject == player)
			{
				// ... the player is in range.
				//playerInRange = true;
				playerHealth.TakeDamage (attackDamage);
			}

        }
			
    }
}