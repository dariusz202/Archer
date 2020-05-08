using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    private ArrowProjectile arrow;
    private PlayerController playerStats;
    private Transform player;
    private Rigidbody enemyRB;
    private GameManager gameManager;
    [SerializeField] float enemyRange = 15f;
    [SerializeField] float enemySpeed = 5f;
    public int healthRangeEnemy = 50;
    public Vector3 a;
    private bool weaponIsActive = true;
    void Start()
    {
        enemyRB = this.GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > enemyRange)
        {
            transform.LookAt(player);
            transform.position += transform.forward * enemySpeed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, player.position) < enemyRange)
        {
            transform.LookAt(player);
            transform.position -= transform.forward * enemySpeed * Time.deltaTime;
            GameObject spearProjectile = SpearSpawnManager.SharedInstance.GetSpear();
            if (spearProjectile != null && weaponIsActive)
            {
                weaponIsActive = false;
                StartCoroutine(AtackPlayer());
                spearProjectile.SetActive(true);
                spearProjectile.transform.position = transform.position;
                spearProjectile.transform.rotation = transform.rotation;
            }

        }

    }
    IEnumerator AtackPlayer()
    {
        yield return new WaitForSeconds(3);
        weaponIsActive = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStats.health -= 10;
            Debug.Log("asdasd" + playerStats.health);
        }
    }


}
