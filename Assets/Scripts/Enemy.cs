using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    private SpawnManager gameManager;
    public int pointValue;
   

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Vehicle");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(1);
        }
    }
}