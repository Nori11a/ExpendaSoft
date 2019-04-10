using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public GameObject player;

	void Update()
	{
		Vector3 position = this.transform.position;

		//first number is the position of the camera, the second is the position of the player, the third is the speed
		position.z = Mathf.Lerp(this.transform.position.z, player.transform.position.z, 17);
		//position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, 17);
		position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, 17);

		this.transform.position = position;
	}
}

//makes sure to set "Player" as the playable ship after putting this script onto the camera