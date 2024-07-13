using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner2 : MonoBehaviour {

    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 0.5f;
    private float countdown = 1f;
    public Text waveCountdownText;
    public playerLife2 levelcontrol;

    private int waveIndex = 0;

    private void Start()
    {
        waveIndex = 0;
        EnemiesAlive = 0;
    }

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            levelcontrol.WinLevel();

            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        
        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    void SetEnemiesAlive(int alive)
    {
        EnemiesAlive = alive;
    }

    void SetwaveIndex(int setwaveindex)
    {
        waveIndex = 0;
        countdown = 0;
    }

    public void ResetVariable()
    {
        //waveIndex = 0;
        countdown = 0;
        EnemiesAlive = 0;
    }
}


