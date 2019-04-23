using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class PlayerAttack: MonoBehaviour
	{
		public float attackDamage;               // The amount of health taken away per attack.

		Animator anim;                              // Reference to the animator component.
		GameObject player;                          // Reference to the player GameObject.
		GameObject enemy;
		PlayerHealth playerHealth;                  // Reference to the player's health.
		EnemyHealth enemyHealth;                   // Reference to this enemy's health.  

		void Awake ()
		{
			// Setting up the references.
			player = GameObject.FindGameObjectWithTag ("Player");
			enemy = GameObject.FindGameObjectWithTag("Enemy");

			playerHealth = player.GetComponent<PlayerHealth>();
			enemyHealth = enemy.GetComponent<EnemyHealth>();
			anim = GetComponent <Animator> ();
		}

		void OnTriggerEnter (Collider other)
		{
			// If the entering collider is the player...

			if(tag == "Nu")
			{
				if(other.gameObject == player)
				{
					playerHealth.TakeDamage(attackDamage);
				}
				else if(other.gameObject == enemy)
				{
					enemyHealth.TakeDamage(attackDamage);
				}
			}
			else if(tag != "Nu")
			{
				if(other.gameObject == enemy)
				{
					enemyHealth.TakeDamage (attackDamage);
				}
			}

		}
			
	}
}
