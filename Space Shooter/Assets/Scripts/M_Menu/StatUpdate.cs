using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
	public class StatUpdate : MonoBehaviour
	{
	    
	    public void Stat()
	    {
			NewGameLoad.f = Done_PlayerController.fireRate;
			NewGameLoad.p = Done_PlayerController.power;
			NewGameLoad.s = Done_PlayerController.speed;
			NewGameLoad.r = Done_PlayerController.reflector;
			NewGameLoad.n = Done_PlayerController.node;

			if(Done_GameController.lives < 3)
			{
				Done_GameController.lives = 3;
			}
	    }

	}
}