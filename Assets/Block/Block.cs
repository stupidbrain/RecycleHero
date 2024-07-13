using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {


	public GameObject turret;
	public bool occupied;

	void Start () {
		occupied = false;
		turret = null;
		GetComponent<MeshRenderer>().enabled=false;
	}

	void OnDrawGizmos () {
		Gizmos.DrawWireCube (transform.position, transform.localScale);
	}

}
