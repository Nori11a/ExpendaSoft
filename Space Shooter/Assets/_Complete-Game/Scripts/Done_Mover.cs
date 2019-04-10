using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class Done_Mover : MonoBehaviour
	{
		public float speed;

		void Start ()
		{
			GetComponent<Rigidbody>().velocity = transform.forward * speed;
		}

		void OnTriggerEnter (Collider Reflect)
		{
			if(Reflect.tag == "Reflect")
			{
				GetComponent<Rigidbody>().velocity = transform.forward * speed * -1;
			}
		}
			
	}
}
