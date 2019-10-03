using UnityEngine;

public class SlimeProjectile : MonoBehaviour {

	[SerializeField] private new Rigidbody2D rigidbody;
	[SerializeField] private float speedRatio = 10;
	//[SerializeField] private int groundLayer;

	[SerializeField] private Sprite spriteUp;
	[SerializeField] private Sprite spriteUpRight;
	[SerializeField] private Sprite spriteRight;
	[SerializeField] private Sprite spriteDownRight;
	[SerializeField] private Sprite spriteDown;
	[SerializeField] private Sprite spriteDownLeft;
	[SerializeField] private Sprite spriteLeft;
	[SerializeField] private Sprite spriteUpLeft;

	public void Launch(Vector2 direction) {
		rigidbody.velocity = direction.normalized * speedRatio;
	}

	// Update is called once per physics update frame
	private void FixedUpdate() {
		float angle = Mathf.Rad2Deg * Mathf.Atan2(rigidbody.velocity.y, rigidbody.velocity.x);
		/*
		 *				90
		 *			112.5	67.5	
		 *		135				45
		 *	157.5					22.5
		 *		
		 *	+-180						0
		 *	
		 *	-157.5					-22.5
		 *		-135			-45
		 *			-112.5	-67.5
		 *				-90
		 */
		if(angle > -22.5F && angle < 22.5F) {
			GetComponent<SpriteRenderer>().sprite = spriteRight;
		} else if(angle > 22.5F && angle < 67.5F) {
			GetComponent<SpriteRenderer>().sprite = spriteUpRight;
		} else if(angle > 67.5F && angle < 112.5F) {
			GetComponent<SpriteRenderer>().sprite = spriteUp;
		} else if(angle > 112.5F && angle < 157.5F) {
			GetComponent<SpriteRenderer>().sprite = spriteUpLeft;
		} else if(angle > 157.5F && angle < -157.5F) {
			GetComponent<SpriteRenderer>().sprite = spriteLeft;
		} else if(angle > -157.5F && angle < -112.5F) {
			GetComponent<SpriteRenderer>().sprite = spriteDownLeft;
		} else if(angle > -112.5F && angle < -67.5F) {
			GetComponent<SpriteRenderer>().sprite = spriteDown;
		} else if(angle > -67.5F && angle < -22.5F) {
			GetComponent<SpriteRenderer>().sprite = spriteDownRight;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(!collision.gameObject.tag.Equals("Projectile") && !collision.gameObject.tag.Equals("Coin")) {
			if(!collision.gameObject.tag.Equals("Player")) {
				if(collision.gameObject.tag.Equals("Enemy")) {
					Destroy(collision.gameObject);
				}

				Destroy(gameObject);
			}
		}
	}
}
