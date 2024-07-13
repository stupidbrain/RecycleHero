using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationCola3 : MonoBehaviour
{
    public playerLife3 player;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            int damge = col.transform.GetComponent<EnemyCola>().hurt;    
            player.UpdateLife(damge);
            WaveSpawner2.EnemiesAlive--;
            Destroy(col.gameObject);
        }
    }
}