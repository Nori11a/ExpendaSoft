using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
	public class Node : MonoBehaviour
	{
		private float nextFire;

		public GameObject shot;
		public Transform shotSpawn;

		void Update()
		{
			//this allows the player to shoot lasers
			if (Input.GetButton("Fire1") && Time.time > nextFire && Done_PlayerController.gun == true) //Input.GetKey is used to figure out what key needs to be pushed, and it'll know it's the Space Bar because of "KeyCode.Space"
			{
				nextFire = Time.time + Done_PlayerController.fireRate + 2;

				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource>().Play();
			}
		}


	}
}