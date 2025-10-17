using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField] float Speed;
	float Movement;
	Rigidbody2D rb;
	[Header("Jump")]
	[SerializeField] float JumpForce;
	[SerializeField] float caiyoteTime;
	[SerializeField] float JumpBufferTime;
	float CurrJumpBufferTime;
	bool isGrounded;
	[SerializeField] LayerMask GroundLayer;
	[SerializeField] Transform GroundCheckPos;
	[SerializeField] bool JumpBuffer;
	[Header("Gravity")]
	float gravityScale = 1f;
	float FallMultiplyer = 2f;

	[Header("Input")]
	InputAction MoveAction;
	InputAction JumpAction;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		MoveAction = InputSystem.actions.FindAction("Move");
		JumpAction = InputSystem.actions.FindAction("Jump");
	}
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(GroundCheckPos.position, new Vector2(0.9f, 0.15f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
        Input();
        //move
        rb.linearVelocityX = Movement * Speed;
        Assist();
        JumpCurve();
        Jump();
        ReleaseJumpEarly();

    }

    private void Assist()
    {
        if (isGrounded)
        {
            caiyoteTime = 0.1f;
        }
        else
        {
            caiyoteTime -= Time.deltaTime;
        }
    }

    private void JumpCurve()
	{
		if (rb.linearVelocityY >= 0.5f)
		{
			caiyoteTime = 0f;
		}
		else if (rb.linearVelocityY <= 0.5f)
		{
			rb.gravityScale = gravityScale * FallMultiplyer;
		}
		else
		{
			rb.gravityScale = gravityScale;
		}
	}

	private void ReleaseJumpEarly()
	{
		if (!JumpAction.IsPressed())
		{
			if (rb.linearVelocityY > 0)
			{
				rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY * 0f);
			}
		}
	}

	private void Jump()
	{
		if (JumpBuffer)
		{
			CurrJumpBufferTime -= Time.deltaTime;
			if (CurrJumpBufferTime > 0 && (caiyoteTime > 0 || (isGrounded && JumpAction.IsPressed())))
			{
				JumpBuffer = false;
				rb.gravityScale = gravityScale;
				rb.linearVelocity = new Vector2(rb.linearVelocityX, JumpForce);


			}
			else if (CurrJumpBufferTime <= 0)
			{
				JumpBuffer = false;
			}
		}
	}

	void Input()
	{
		Movement = MoveAction.ReadValue<float>();
		if (JumpAction.WasPressedThisFrame())
        {
            CurrJumpBufferTime = JumpBufferTime;
            JumpBuffer = true;

        }

	}
}
