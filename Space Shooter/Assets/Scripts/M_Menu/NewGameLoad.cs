using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
	public class NewGameLoad : MonoBehaviour
	{
	    
		static public float f = 1.75f;
		static public float p = 0;
		static public float s = 4;
		static public int r = 0;
		static public int n = 0;

		public void CarryOver()
		{
			Done_PlayerController.fireRate = f;
			Done_PlayerController.power = p;
			Done_PlayerController.speed = s;
			Done_PlayerController.reflector = r;
			Done_PlayerController.node = n;
		}

	}
}