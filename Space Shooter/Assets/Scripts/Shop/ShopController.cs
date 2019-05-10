using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
	public class ShopController : MonoBehaviour
	{
		public GameObject shopPanel;

		void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Player")
			{
				OpenShop();
			}
		}

		void OpenShop()
		{
			Done_PlayerController.gun = false;
			shopPanel.SetActive(true);
			Time.timeScale = 0;
		}

		public void CloseShop()
		{
			Done_PlayerController.gun = true;
			shopPanel.SetActive(false);
			Time.timeScale = 1;
		}
			
	}
}
