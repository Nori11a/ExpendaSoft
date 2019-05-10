using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class Done_Mover : MonoBehaviour
	{
		public float speed;
		public Light myLight;

		public float coolDown = 5;
		private bool isParry = false;

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

		void FixedUpdate()
		{
			if (isParry == true)
			{
				coolDown -= Time.deltaTime * 20;
				if (coolDown <= 0)
				{
					Time.timeScale = 1;
					coolDown = 5;
					isParry = false;
				}
			}
		}

		void OnTriggerEnter (Collider Reflect)
		{
			if(Reflect.tag == "Reflect")
			{
				if (Reflect.gameObject.layer == LayerMask.NameToLayer("Parry") && tag == "Enemy")
				{
					Time.timeScale = 0.25f;
					isParry = true;
				}

				switch(tag)
				{
					case "Enemy":
						tag = "Nu";
						GetComponent<Rigidbody>().velocity = transform.forward * speed * -1;
						break;
					case "Bullet":
						GetComponent<Rigidbody>().velocity = transform.forward * speed * -2;
						break;
				}

				//tag = "Nu";
				myLight.enabled = true;
				//GetComponent<Rigidbody>().velocity = transform.forward * speed * -1;
			}
		}
			
	}
}
