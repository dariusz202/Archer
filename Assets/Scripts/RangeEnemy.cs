using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    private GameObject p;
    private PlayerStats playerStats;
    private Transform player;
    //private GameManager gameManager;
    [SerializeField] float rangeEnemyRange = 15f;
    [SerializeField] float rangeEnemySpeed = 5f;
    public int healthRangeEnemy = 50;
    public bool weaponIsActive = true;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > rangeEnemyRange)
        {
            transform.LookAt(player);
            transform.position += transform.forward * rangeEnemySpeed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, player.position) <= rangeEnemyRange)
        {
            transform.LookAt(player);
            transform.position -= transform.forward * rangeEnemySpeed * Time.deltaTime;
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
