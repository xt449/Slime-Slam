using UnityEngine;

[RequireComponent(typeof(AnimatedSlimeBody))]
public class SlimeEnemy : MonoBehaviour {

	[SerializeField] private AnimatedSlimeBody slimeBody;

	private Rigidbody2D target;

	// Use this for initialization
	private void Start() {
		target = FindObjectOfType<SlimePlayer>().gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per physics update frame
	private void FixedUpdate() {
		if(Vector2.Distance(target.position, slimeBody.rigidbody.position) > 16) {
			slimeBody.TryJump();
			return;
		}

		float distanceX = target.position.x - slimeBody.rigidbody.position.x;
		float distanceY = target.position.y - slimeBody.rigidbody.position.y;

		if(Mathf.Abs(distanceX) > 1) {
			if(distanceX > 0) {
				slimeBody.TryMove(1);
			} else {
				slimeBody.TryMove(-1);
			}
		}

		if(distanceY > 4) {
			slimeBody.TryJump();
		}
	}
}
