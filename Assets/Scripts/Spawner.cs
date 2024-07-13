using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject [] spawnObject;
    //public GameObject spawnObject2;
	public float startDelay=0;
	public float spawnInterval=1.5f;


	void Start () {
		InvokeRepeating ("Spawn", startDelay, spawnInterval);
        //InvokeRepeating ("Spawn2", (startDelay + 1f), spawnInterval);
	}

	void Spawn () {
        for (int i=0; i < spawnObject.Length; i++)
        {
            Instantiate (spawnObject[i], transform.position, transform.rotation);
        }
             
    }
    /*void Spawn2 ()
    {
        Instantiate (spawnObject2, transform.position, transform.rotation);
    }*/

	public void StopSpawn () {
		CancelInvoke ("Spawn");
	}
}


