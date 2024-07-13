using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	GameObject target;
	float speed = 10;
	float damage=1;

	void OnEnable() {
		target = null;
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject == target) {
			col.gameObject.SendMessage ("Hit",damage, SendMessageOptions.DontRequireReceiver);
			gameObject.SetActive(false);
		}
	}

	void Update () {
		if (target != null) {
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
		} else
			gameObject.SetActive(false);
	}

	void SetTarget(GameObject myTarget){
		target = myTarget;
	}

	void SetDamage (float power) {
		damage = power;
	}
}


