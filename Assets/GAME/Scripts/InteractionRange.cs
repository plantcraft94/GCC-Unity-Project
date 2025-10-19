using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRange : MonoBehaviour
{
	NPC nPC;
	PlayerAttack pa;

	private void Awake()
	{
		nPC = transform.parent.gameObject.GetComponent<NPC>();
		pa = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			
			nPC.ShowPrompt();
		}
	}	
}
