using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	bool allowReload = false;

	void Start () {
		Invoke ("ReloadScene", 2);
	}

	void Update () {
		if (Input.touchCount > 0  
			&& Input.GetTouch(0).phase == TouchPhase.Ended
			&& allowReload) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			Time.timeScale = 1;
		}
	}

	void ReloadScene () {
		allowReload = true;
	}
}
