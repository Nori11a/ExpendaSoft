using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
	public class Lift : MonoBehaviour
	{
		public GameObject movePlatform;
		//GameObject player;
		//Done_PlayerController playerController; 

		void Start()
		{
			//player = GameObject.FindGameObjectWithTag ("Player");
			//playerController = player.GetComponent<Done_PlayerController>();
		}

		private void OnTriggerStay(Collider other)
		{
			movePlatform.transform.position += movePlatform.transform.up * Time.deltaTime * 20;
		}
	}
}