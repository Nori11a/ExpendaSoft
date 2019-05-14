using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        public Transform player;               // Reference to the player's position.
		public Enemy_WeaponController weapon;

		public int speed = 3;
		public int maxDist = 20;
		public int minDist = 4;

        void Update ()
        {
			if(Vector3.Distance(transform.position, player.position) >= maxDist)
			{
				//transform.LookAt(0 * transform.position - player.position);
				transform.position += (-1 * transform.forward) * 0 * Time.deltaTime;

				weapon.sight = 0;
			}
			else if (Vector3.Distance(transform.position, player.position) >= minDist)
			{
				transform.LookAt(2 * transform.position - player.position);
				transform.position += (-1 * transform.forward) * speed * Time.deltaTime;

				weapon.sight = 1;
			}
			else
			{
				transform.LookAt(2 * transform.position - player.position);
				transform.position += (-1 * transform.forward) * 0 * Time.deltaTime;

				weapon.sight = 1;
			}
        }

    }
}