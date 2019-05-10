using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
	public class NodeActive : MonoBehaviour
	{
		public GameObject node1;
		public GameObject node2;
		public GameObject node3;
		public GameObject node4;

	    void Update()
	    {
			switch(Done_PlayerController.node)
			{
				case 1:
					node1.SetActive(true);
					break;
				case 2:
					node1.SetActive(true);
					node2.SetActive(true);
					break;
				case 3:
					node1.SetActive(true);
					node2.SetActive(true);
					node3.SetActive(true);
					break;
				case 4:
					node1.SetActive(true);
					node2.SetActive(true);
					node3.SetActive(true);
					node4.SetActive(true);
					break;
			}

			if(Done_PlayerController.node > 4)
			{
				Done_PlayerController.node = 4;
			}
	    }
	}
}