using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRange : MonoBehaviour
{
	NPC nPC;

	private void Awake()
	{
		nPC = transform.parent.gameObject.GetComponent<NPC>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			
			nPC.ShowPrompt();
		}
	}	
}
