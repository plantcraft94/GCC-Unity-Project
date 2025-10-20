using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
	[SerializeField] float force;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if(collision.gameObject.CompareTag("NPC"))
		{
			// đẩy npc
			collision.gameObject.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.parent.transform.position + Vector3.up * 0.5f) * force, ForceMode2D.Impulse);
			
		}
	}
	
}
