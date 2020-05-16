using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    private PlayerStats playerStats;
    private Transform player;
    //private GameManager gameManager;
    [SerializeField] float meleeEnemySpeed = 5f;
    public int healthMeleeEnemy = 100;
    public bool weaponIsActive = true;
    public bool isReady = true;
    public Animator SkeletonAnim;
    private EnemySpawnManager enemySpawnManager;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 50.0f && Vector3.Distance(transform.position, player.transform.position) > 3 && healthMeleeEnemy > 0)
        {
            transform.LookAt(player);
            transform.position += transform.forward * meleeEnemySpeed * Time.deltaTime;
            SkeletonAnim.SetBool("InRange", true);
        }
        if (Vector3.Distance(transform.position, player.transform.position) > 20.0f)
        {
            //transform.LookAt(player);
            //transform.position += transform.forward * meleeEnemySpeed * Time.deltaTime;
            SkeletonAnim.SetBool("InRange", false);
        }
        if (Vector3.Distance(transform.position, player.transform.position) <= 3 && weaponIsActive && healthMeleeEnemy > 0)
        {
            weaponIsActive = false;
            SkeletonAnim.SetBool("InRange", false);
            transform.LookAt(player);
            SkeletonAnim.SetTrigger("Attack");
            StartCoroutine(MeleeAtack());
        }
        if(healthMeleeEnemy == 0 && isReady)
        {
            isReady = false;
            SkeletonAnim.SetTrigger("Death");
            //StartCoroutine(MeleeDeath());
        }
        if(enemySpawnManager.enemyCount == 0)
        {
            gameObject.SetActive(false);
            isReady = true;
            enemySpawnManager = GameObject.Find("Enemy Spawn Manager").GetComponent<EnemySpawnManager>();
            healthMeleeEnemy = 100;
            transform.position = enemySpawnManager.RandomPosition();

        }
        
        //transform.LookAt(player);
        // transform.position += transform.forward * meleeEnemySpeed * Time.deltaTime;
        //if(Vector3.Distance(transform.position, player.position) <= 3f && weaponIsActive)
        // {
        //     playerStats.health -= 10;
        //     weaponIsActive = false;
        //     StartCoroutine(AtackPlayer());
        // }

    }
    IEnumerator MeleeAtack()
    {
        yield return new WaitForSeconds(5f);
        weaponIsActive = true;

    }
    IEnumerator MeleeDeath()
    {
        yield return new WaitForSeconds(3f);
        isReady = true;
        enemySpawnManager = GameObject.Find("Enemy Spawn Manager").GetComponent<EnemySpawnManager>();
        gameObject.SetActive(false);
        healthMeleeEnemy = 100;
        transform.position = enemySpawnManager.RandomPosition();

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
