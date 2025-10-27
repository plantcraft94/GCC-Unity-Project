using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("ItemDrop"))
		{
			IPickable pickable = collision.GetComponent<IPickable>();
			pickable.PickUp();
		}
	}
}
