using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEmeny : Enemy
{
	// Start is called before the first frame update
	[SerializeField] LayerMask GroundLayer;
	Rigidbody2D rb;
	[SerializeField] AnimationCurve animationCurve;
	float CurrentTime;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Move();
	}

	private void Move()
	{
		CurrentTime += Time.deltaTime;
		RaycastHit2D hit;
		rb.velocity = new Vector2(Speed * dir, animationCurve.Evaluate(CurrentTime)*1.5f);
		hit = Physics2D.Raycast(transform.position, transform.right, 2f, GroundLayer);
		if (hit)
		{
			Flip();
		}
	}
}
