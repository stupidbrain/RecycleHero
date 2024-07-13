﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent NM;
    Transform dest;
    public float speed = 3.5f;

    public float maxLife;
    private float life;
    public GameObject explosion;
    public AudioClip hitSound;
    public int prize = 100;
    public int hurt = 1;
    AudioSource AS;

    void Start()
    {
        dest = GameObject.Find("EndPoint").transform;
        NM = GetComponent<NavMeshAgent>();
        NM.SetDestination(dest.position);
        NM.speed = speed;
        AS = GetComponent<AudioSource>();
        life = maxLife;
        Debug.Log(life);
    }

    void Hit(float damage)
    {
        life -= damage;
        Debug.Log(life);
        MoneyCount.UpdateMoney(5);
        if (life <= 0)
        {
            Kill();
            return;
        }
        AS.pitch = Random.Range(0.95f, 1.05f);
        AS.PlayOneShot(hitSound);
    }

    void Kill()
    {
        MoneyCount.UpdateMoney(prize);
        KillCount.UpdateKilled (1);
        WaveSpawner.EnemiesAlive--;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

