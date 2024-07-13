using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public float delay=1f;

	void Start () {
		StartCoroutine(Cleanup ());
	}
	
	IEnumerator Cleanup () {
		yield return new WaitForSeconds (delay);
		Destroy(gameObject);
	}
}
