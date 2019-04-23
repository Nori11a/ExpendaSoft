using UnityEngine;
using System.Collections;


namespace CompleteProject
{
	public class Done_DestroyByContact : MonoBehaviour
	{
		public GameObject explosion;
		public GameObject playerExplosion;
		public int scoreValue;
		private Done_GameController gameController;

		GameObject player;  
		PlayerHealth playerHealth;

		void Start ()
		{
			player = GameObject.FindGameObjectWithTag ("Player");
			playerHealth = player.GetComponent <PlayerHealth> ();
		}

		void OnTriggerEnter (Collider other)
		{
			if (other.tag == "Boundary" || other.tag == "Enemy")
			{
				return;
			}

			if (explosion != null)
			{
				Instantiate(explosion, transform.position, transform.rotation);
			}

			if (other.tag == "Player")
			{
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
				playerHealth.TakeDamage (10);

			}
			
			//gameController.AddScore(scoreValue); //this is here incase everything keeps blowing up.
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}