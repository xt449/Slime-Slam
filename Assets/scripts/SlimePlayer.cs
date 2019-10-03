using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AnimatedSlimeBody))]
public class SlimePlayer : MonoBehaviour {

	[SerializeField] private UnityEngine.UI.Text coinCounter;

	[SerializeField] private AnimatedSlimeBody slimeBody;

	[SerializeField] private GameObject slimeShot;
	[SerializeField] private float shootDelay = 1;
	[SerializeField] private float abilityDelay = 1;

	private float shootTime = 0;
	private float abilityTime = 0;

	// Use this for initialization
	private void Start() {
		Coin.coinCounter = coinCounter;
	}

	// Update is called once per frame
	private void Update() {
		bool shoot = Input.GetMouseButton(0);
		bool ability = Input.GetMouseButton(1);

		if(shoot) {
			if(Time.unscaledTime - shootDelay > shootTime) {
				Instantiate(slimeShot, slimeBody.rigidbody.position, new Quaternion())
					.GetComponent<SlimeProjectile>()
					.Launch(((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - slimeBody.rigidbody.position) + slimeBody.rigidbody.velocity / 2);

				shootTime = Time.unscaledTime;
			}
		}

		if(ability) {
			if(Time.unscaledTime - abilityDelay > abilityTime) {
				for(int angle = 0; angle <= 315; angle += 45) {
					Instantiate(slimeShot, slimeBody.rigidbody.position + slimeBody.rigidbody.velocity.normalized, new Quaternion())
						.GetComponent<SlimeProjectile>()
						.Launch(new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)));
				}

				abilityTime = Time.unscaledTime;
			}
		}
	}

	// Update is called once per physics update frame
	private void FixedUpdate() {
		float horizontal = Input.GetAxis("Horizontal");
		bool jump = Input.GetButton("Jump") || Input.GetAxisRaw("Vertical") > 0;

		slimeBody.TryMove(horizontal);

		if(jump) {
			slimeBody.TryJump();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag.Equals("Enemy")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
