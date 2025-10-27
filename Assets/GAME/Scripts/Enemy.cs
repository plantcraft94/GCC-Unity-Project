using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	[SerializeField] protected float Hp;
	[SerializeField] protected float Speed;
	protected int dir = 1;

	bool IsFacingRight = true;
	protected void Flip()
	{
		if (IsFacingRight)
		{
			dir = -1;
			Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
			transform.rotation = Quaternion.Euler(rotator);
			IsFacingRight = !IsFacingRight;
		}
		else
		{
			dir = 1;
			Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
			transform.rotation = Quaternion.Euler(rotator);
			IsFacingRight = !IsFacingRight;
		}
	}
}
