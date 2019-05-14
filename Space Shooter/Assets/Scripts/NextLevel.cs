using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CompleteProject
{
	public class NextLevel : MonoBehaviour
	{

		public int level = 1;
		//Done_PlayerController player;

		//private Vector3 place;

		//private Transform player;
		//public Transform start;

		void Start()
		{
			//player = GameObject.FindGameObjectWithTag("Player").transform;
		}

		void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.tag == "Player")
			{
				//player.position = start.position;

				Application.LoadLevel(level);
				/*player.position = start.position;
				level++;*/

			}
		}

	}
}