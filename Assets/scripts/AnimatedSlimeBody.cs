using UnityEngine;

public class AnimatedSlimeBody : MonoBehaviour {
	
	[SerializeField] private float walkScale = 4;
	[SerializeField] private int jumpScale = 500;

	[SerializeField] public new Rigidbody2D rigidbody;

	[SerializeField] private Transform groundCheckLeft;
	[SerializeField] private Transform groundCheckRight;
	[SerializeField] private LayerMask groundLayer;

	[SerializeField] private Animator animator;

	private const float groundRadius = 0.015F;

	// Update is called once per physics update frame
	private void FixedUpdate() {
		animator.SetFloat("speed", Mathf.Abs(rigidbody.velocity.x));
		animator.SetFloat("velocity", rigidbody.velocity.y);

		if(OnGround()) {
			animator.SetBool("grounded", true);
		} else {
			animator.SetBool("grounded", false);
		}
	}

	private bool OnGround() {
		return Physics2D.OverlapCircle(groundCheckLeft.position, groundRadius, groundLayer) || Physics2D.OverlapCircle(groundCheckRight.position, groundRadius, groundLayer);
	}

	public void TryJump() {
		if(OnGround()) {
			animator.SetBool("grounded", false);

			rigidbody.AddForce(new Vector2(0, jumpScale));
		}
	}

	public void TryMove(float horizontal) {
		if(horizontal != 0) {
			GetComponent<SpriteRenderer>().flipX = horizontal < 0;
		}

		rigidbody.velocity = new Vector2(horizontal * walkScale, rigidbody.velocity.y);
	}
}
