using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class Done_Mover : MonoBehaviour
	{
		public float speed;

		public Light myLight;

		void Start ()
		{
			myLight = GetComponent<Light>();
			GetComponent<Rigidbody>().velocity = transform.forward * speed;
		}

		void Update()
		{
			if(tag == "Nu")
			{
				myLight.enabled = true;
			}
		}

		void OnTriggerEnter (Collider Reflect)
		{
			if(Reflect.tag == "Reflect")
			{
				tag = "Nu";
				myLight.enabled = true;
				GetComponent<Rigidbody>().velocity = transform.forward * speed * -1;
			}
		}
			
	}
}
