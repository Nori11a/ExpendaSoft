using UnityEngine;
using System.Collections;

public class Done_DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{

		if (other.gameObject.layer == LayerMask.NameToLayer("Projectile"))
		{
			Destroy(other.gameObject);
		}
	}
}