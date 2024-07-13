using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetVariables : MonoBehaviour {

    /* Aims to reset:   Life (playerLife2), 
                        EnemiesAlive,waveIndex (WaveSpawner2)
    */
    public playerLife2 playerlife;
    public WaveSpawner2 wavespawner;
    public int Relife = 10;
    public int alive = 0;
    public int setwaveindex = 0;

    private void Update()
    {
        playerlife.SendMessage("SetLife", Relife);
        wavespawner.SendMessage("SetEnemiesAlive", alive);
        wavespawner.SendMessage("SetwaveIndex", setwaveindex);
    }
}
