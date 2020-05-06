using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ArrowProjectile arrow;
    public GameObject player;
    private Rigidbody enemyRB;
    private GameManager gameManager;
    [SerializeField] float enemySpeed = 5f;
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<GameObject>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(gameManager.isGameActive)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRB.AddForce(lookDirection * enemySpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           
        }
    }

}
