using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CompleteProject
{
	public class NewGameReset : MonoBehaviour
	{

	    public void Reset()
	    {
			Done_PlayerController.fireRate = 1.75f;
			Done_PlayerController.power = 0;
			Done_PlayerController.speed = 4;
			Done_PlayerController.reflector = 0;
			Done_PlayerController.node = 0;

			Done_GameController.lives = 3;
	    }
	}
}