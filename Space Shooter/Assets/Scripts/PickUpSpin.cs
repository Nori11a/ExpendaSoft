using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpin : MonoBehaviour
{
	float speed = 100f;

    void Update()
    {
		transform.Rotate(Vector3.right, speed * Time.deltaTime);
    }

	/*void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			GetComponent<AudioSource>().Play();
			if(gameObject.tag == "Coin")
			{
				GetComponent<AudioSource>().Play();
			}

		}
	}*/
}
