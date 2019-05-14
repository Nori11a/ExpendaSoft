using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
	public class Parry : MonoBehaviour
	{
		public GameObject parry;
		public GameObject parryEX;

		public GameObject knob;
		private float knobLocation = 0f;

		public float coolDown = 6; //tells the shield how long to stay active and how long will it be unusable

		int whileActive = 30;
		int whileRecover = 5;

		//int upgrade = 0;

		bool EX = false;

		AudioSource hitAudio;
		private bool play = false; //suppose to prevent parry sound from going off more than once.

		void Awake()
		{
			//this takes the audio source from the parry object
			hitAudio = parry.GetComponent <AudioSource> ();
		}

		void Start()
	    {
			parry.SetActive(false); //the shield starts out inactive
			parryEX.SetActive(false);
	    }
			
	    void Update()
	    {
			if(EX == true)
			{
				if(Input.GetKey(KeyCode.Space) && coolDown == 6) //sets off the shield, but only when the cooldown is full
				{
					parryEX.SetActive(true);
				}

				if(parryEX.activeSelf)
				{
					coolDown -= Time.deltaTime * whileActive; //checks to see how long the shield can be active
				}
				else //while the shield is inactive the cooldown will try to fill itself back up
				{
					coolDown += Time.deltaTime * whileRecover;
					if (coolDown > 6) //insures that the coolDown never surpasses 5, making the parry unusable
					{
						coolDown = 6;
					}
				}

				if (coolDown < 1) //wheen the cooldown hits 0, the shield deactives
				{
					play = false;
					parryEX.SetActive(false);
				}
			}
			else
			{
				if(Input.GetKey(KeyCode.Space) && coolDown == 6) //sets off the shield, but only when the cooldown is full
				{
					parry.SetActive(true);
				}

				if(parry.activeSelf)
				{
					coolDown -= Time.deltaTime * whileActive; //checks to see how long the shield can be active
				}
				else //while the shield is inactive the cooldown will try to fill itself back up
				{
					coolDown += Time.deltaTime * whileRecover;
					if (coolDown > 6) //insures that the coolDown never surpasses 5, making the parry unusable
					{
						coolDown = 6;
					}
				}

				if (coolDown < 1) //wheen the cooldown hits 0, the shield deactives
				{
					play = false;
					parry.SetActive(false);
				}
			}
	    }

		void FixedUpdate()
		{
			Upgrade();

			//Vector2 position = knob.transform.position;
			knobLocation = 166 - (coolDown * 24f);

			knob.transform.position = new Vector3(knobLocation, 67f, 0f);
		}

		void OnTriggerEnter (Collider other)
		{
			if (other.gameObject.layer == LayerMask.NameToLayer("Projectile") && play == false)
			{
				hitAudio.Play(); //when a projectile hits the parry shield, it will play the reflect audio
				play = true;
			}
		}

		void Upgrade()
		{
			if (Done_PlayerController.reflector == 1)
			{
				whileActive = 25;
				whileRecover = 10;
			}
			else if (Done_PlayerController.reflector == 2)
			{
				whileActive = 20;
				whileRecover = 15;
			}
			else if (Done_PlayerController.reflector > 2)
			{
				EX = true;
				whileActive = 19;
				whileRecover = 16;
			}

		}
			
	}
}