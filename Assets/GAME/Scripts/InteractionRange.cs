using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRange : MonoBehaviour
{
	NPC nPC;
	IShape shape;

	private void Awake()
	{
		nPC = transform.parent.gameObject.GetComponent<NPC>();
		shape = transform.parent.gameObject.GetComponent<IShape>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if(nPC != null)
			{
				nPC. ShowPrompt();
			}
			if(shape != null)
            {
				shape.debug();
            }
		}
	}	
}
