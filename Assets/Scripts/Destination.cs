using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {

    public PlayerLife player;

	void OnTriggerEnter (Collider col) {
		if (col.CompareTag ("Enemy")) {
            int damge = col.transform.GetComponent<Enemy>().hurt;
            player.UpdateLife(damge);
            WaveSpawner.EnemiesAlive--;
            Destroy (col.gameObject);
		}
	}
}

