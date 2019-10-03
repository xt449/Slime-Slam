using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour {

	private const string nextScene = "Gameplay";

	// Update is called once per frame
	void Update() {
		if(Time.realtimeSinceStartup > 3) {
			if(Input.anyKey) {
				SceneManager.LoadScene(nextScene);
			}
		}
	}
}
