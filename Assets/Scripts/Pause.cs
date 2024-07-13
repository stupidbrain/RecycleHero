using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public void PauseGame () {
		Time.timeScale = 0;
		return;
	}

	public void ResumeGame () {
		Time.timeScale = 1;
	}
}
