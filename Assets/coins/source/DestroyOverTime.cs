using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour {

	public float delay=1f;

	void Start () {
		Destroy(gameObject, delay);
	}
}
