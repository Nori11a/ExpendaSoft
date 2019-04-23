using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpin : MonoBehaviour
{
	float speed = 100f;
	public GameObject pickUp;

	AudioSource collectAudio;

	void Awake()
	{
		collectAudio = GetComponent <AudioSource> ();
	}

    void Update()
    {
		transform.Rotate(Vector3.right, speed * Time.deltaTime);
    }

	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player")
		{
			collectAudio.Play();
			//AudioSource.PlayClipAtPoint();

			pickUp.SetActive(false);
		}

	}

	public void Sound()
	{
		collectAudio.Play();
	}
}
