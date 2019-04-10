using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
	public class FirstAid : MonoBehaviour
	{
		public int recover = 4;

		GameObject player;
		PlayerHealth playerHealth; 

		void Awaken()
		{
			player = GameObject.FindGameObjectWithTag ("Player");
			playerHealth = player.GetComponent <PlayerHealth> ();
		}

	    // Update is called once per frame
	    void Update()
	    {
	        
	    }

		void OnTriggerEnter (Collider other)
		{
			if (other.gameObject == player)
			{
				playerHealth.HealDamage(recover);
				gameObject.SetActive(false);

			}
		}
	}
}