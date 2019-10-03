using UnityEngine;

public class Coin : MonoBehaviour {

	public static UnityEngine.UI.Text coinCounter;

	private bool collected;

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.tag.Equals("Player") && !collected) {
			collected = true;
			coinCounter.text = (int.Parse(coinCounter.text) + 1).ToString();

			Destroy(gameObject);
		}
	}
}
