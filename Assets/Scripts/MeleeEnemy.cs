using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    private ArrowProjectile arrow;
    private PlayerController playerStats;
    private Transform player;
    private Rigidbody enemyRB;
    private GameManager gameManager;
    [SerializeField] float enemySpeed = 5f;
    public int healthMeleeEnemy = 100;
    void Start()
    {
        enemyRB = this.GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        transform.LookAt(player);
        transform.position += transform.forward * enemySpeed * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerStats.health -= 10;
            Debug.Log("asdasd" + playerStats.health);
        }
    }

}
