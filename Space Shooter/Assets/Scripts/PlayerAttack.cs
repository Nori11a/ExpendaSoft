using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class PlayerAttack: MonoBehaviour
	{
		//public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
		public int attackDamage = 10;               // The amount of health taken away per attack.


		Animator anim;                              // Reference to the animator component.
		//GameObject player;                          // Reference to the player GameObject.
		GameObject enemy;
		//PlayerHealth playerHealth;                  // Reference to the player's health.
		EnemyHealth enemyHealth;                    // Reference to this enemy's health.
		bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
		float timer;    

		void Awake ()
		{
			// Setting up the references.
			//player = GameObject.FindGameObjectWithTag ("Player");
			enemy = GameObject.FindGameObjectWithTag("Enemy");
			//playerHealth = player.GetComponent <PlayerHealth> ();
			enemyHealth = enemy.GetComponent<EnemyHealth>();
			anim = GetComponent <Animator> ();
		}

		void OnTriggerEnter (Collider other)
		{
			// If the entering collider is the player...
			if(other.gameObject == enemy)
			{
				// ... the player is in range.
				//playerInRange = true;
				enemyHealth.TakeDamage (attackDamage);
			}
		}
	}
}
