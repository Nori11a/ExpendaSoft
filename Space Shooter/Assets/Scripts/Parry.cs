using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
	public GameObject parry;

	//public Sprite knob;  
	public float coolDown = 5; //tells the shield how long to stay active and how long will it be unusable

    void Start()
    {
		parry.SetActive(false); //the shield starts out inactive
    }
		
    void Update()
    {
		if(Input.GetKey(KeyCode.Space) && coolDown == 5) //sets off the shield, but only when the cooldown is full
		{
			parry.SetActive(true);
		}

		if(parry.activeSelf)
		{
			coolDown -= Time.deltaTime * 20; //checks to see how long the shield can be active
		}
		else //while the shield is inactive the cooldown will try to fill itself back up
		{
			coolDown += Time.deltaTime * 10;
			if (coolDown > 5) //insures that the coolDown never surpasses 5, making the parry unusable
			{
				coolDown = 5;
			}
		}

		if (coolDown < 1) //wheen the cooldown hits 0, the shield deactives
		{
			parry.SetActive(false);
		}

    }
}
