using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickUp : MonoBehaviour, IPickable
{
	SpriteRenderer sr;
	private void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
	}
	public void PickUp()
	{
		Debug.Log("+ Score :)");
		sr.color = Color.red;
	}
}
