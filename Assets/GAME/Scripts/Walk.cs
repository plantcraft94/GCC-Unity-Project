using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : Enemy
{
	[SerializeField] LayerMask GroundLayer;
	Rigidbody2D rb;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
    {
        Move();
    }

    private void Move()
    {
        RaycastHit2D hit;
        rb.velocity = new Vector2(Speed * dir, rb.velocity.y);
        hit = Physics2D.Raycast(transform.position, transform.right, 1f, GroundLayer);
        if (hit)
        {
            Flip();
        }
    }
}
