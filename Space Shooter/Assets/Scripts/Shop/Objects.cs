using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objects : ScriptableObject
{
	public string item = "Power Up";
	public int cost = 5;
	public string description;

	public float rate;
	public float power;
	public float speed;
}
