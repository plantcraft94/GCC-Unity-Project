using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	PlayerMovement PM;
	Animator anim;
	Rigidbody2D rb;
	private void Awake()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		PM = GetComponent<PlayerMovement>();
	}
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
    private void LateUpdate()
    {
        Animation();
    }
    void Animation()
	{
		anim.SetBool("IsMoving", PM.Movement != 0);
		anim.SetBool("IsJumping", !PM.isGrounded);
		anim.SetFloat("VelocityY", rb.velocity.y);
	}
	public void Attack()
	{
		anim.SetTrigger("Attack");
	}
}
