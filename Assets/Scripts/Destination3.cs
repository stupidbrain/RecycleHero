using UnityEngine;
using System.Collections;

public class Destination3 : MonoBehaviour
{

    public playerLife3 player;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            int damge = col.transform.GetComponent<Enemy2>().hurt;
            player.UpdateLife(damge);
            WaveSpawner2.EnemiesAlive--;
            Destroy(col.gameObject);
        }
    }
}

