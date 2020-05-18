using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] float meleeRange = 30.0f;
    private PlayerStats playerStats;
    private Transform player;
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
        enemySpawnManager = GameObject.Find("Enemy Spawn Manager").GetComponent<EnemySpawnManager>();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < meleeRange && Vector3.Distance(transform.position, player.transform.position) > 2 && healthMeleeEnemy > 0)
        {
            transform.LookAt(player);
            transform.position += transform.forward * meleeEnemySpeed * Time.deltaTime;
            SkeletonAnim.SetBool("InRange", true);
        }
        if (Vector3.Distance(transform.position, player.transform.position) >= meleeRange && healthMeleeEnemy < 100)
        {
            transform.LookAt(player);
            transform.position += transform.forward * meleeEnemySpeed * Time.deltaTime;
            SkeletonAnim.SetBool("InRange", true);
        }
        if(Vector3.Distance(transform.position, player.transform.position) > meleeRange && healthMeleeEnemy == 100)
        {
            SkeletonAnim.SetBool("InRange", false);
        }
        
        if (Vector3.Distance(transform.position, player.transform.position) <= 2 && weaponIsActive && healthMeleeEnemy > 0)
        {
            weaponIsActive = false;
            SkeletonAnim.SetBool("InRange", false);
            transform.LookAt(player);
            SkeletonAnim.SetTrigger("Attack");
            playerStats.health -= 10;
            Debug.Log("asdasd" + playerStats.health);
            StartCoroutine(MeleeAtack());
        }
        if(healthMeleeEnemy == 0 && isReady)
        {
            isReady = false;
            SkeletonAnim.SetTrigger("Death");
            StartCoroutine(MeleeDeath());
        }

    }
    IEnumerator MeleeAtack()
    {
        yield return new WaitForSeconds(5f);
        weaponIsActive = true;
    }
    IEnumerator MeleeDeath()
    {
        yield return new WaitForSeconds(5f);
        isReady = true;
        gameObject.SetActive(false);
        healthMeleeEnemy = 100;
        transform.position = enemySpawnManager.RandomPosition();

    }


}
