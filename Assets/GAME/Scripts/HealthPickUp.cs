using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour, IPickable
{
	SpriteRenderer sr;
	private void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
	}
	public void PickUp()
	{
		Debug.Log("+ Máu :)");
		sr.color = Color.red;
	}
}
