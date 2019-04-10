using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
	public GameObject movePlatform;

	private void OnTriggerStay()
	{
		if (tag == "Up")
		{
			movePlatform.transform.position += movePlatform.transform.up * Time.deltaTime * 20;
		}
		else if (tag == "Down")
		{
			movePlatform.transform.position += movePlatform.transform.up * Time.deltaTime * -20;
		}
	}
}
