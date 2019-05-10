using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{
	public class ItemButton : MonoBehaviour
	{
		public Done_PlayerController player;
		public Done_GameController gameController;
		//public ShopController controller;
		public int itemNum;

		public Text name;
		public Text cost;
		public Text description;

		private AudioSource source;



		void Start()
	    {
			source = GetComponent<AudioSource>();
			SetButton();
	    }

	    // Update is called once per frame
	    void SetButton()
	    {
			string costString = player.items[itemNum].cost.ToString();
			name.text = player.items[itemNum].name;
			cost.text = player.items[itemNum].cost + " coin";
			description.text = player.items[itemNum].description;
	    }

		public void OnClick()
		{
			if(Done_GameController.coin >= player.items[itemNum].cost)
			{
				//gameController.coin -= player.items[itemNum].cost;
				gameController.AddCoin(player.items[itemNum].cost * -1);

				if(player.boughtItem < itemNum)
				{
					player.boughtItem = itemNum;
				}
					
				player.amount[itemNum]++;
			}
			else
			{
				source.Play();
			}
		}
	}
}
