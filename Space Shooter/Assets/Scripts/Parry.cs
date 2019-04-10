using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
	private Light myLight;

	public Sprite knob;  
	public int coolDown = 150;

    void Start()
    {
		myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
		if (myLight.enabled == false)
		{
			if(coolDown < 150)
			{
				coolDown++;
			}
			else
			{
				if(Input.GetKeyUp(KeyCode.Space))
				{
					myLight.enabled = true;
				}
			}
		}
		else
		{
			coolDown -= 5;

			if (coolDown == 0)
			{
				myLight.enabled = false;
			}
		}





    }
}
