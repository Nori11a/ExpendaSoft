using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class Enemy_WeaponController : MonoBehaviour
	{
		public GameObject shot;
		public Transform shotSpawn;
		public float fireRate;
		public float delay;
		public int sight = 0;

		void Start ()
		{
			InvokeRepeating ("Fire", delay, fireRate);
		}


		void Fire ()
		{

			if(sight > 0)
			{
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}

			//Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			//GetComponent<AudioSource>().Play();
		}

		/*public void sightChange(int amount)
		{
			sight = amount;
		}*/


	}
}