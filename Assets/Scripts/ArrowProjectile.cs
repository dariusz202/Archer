using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    [SerializeField] float arrowSpeed = 50.0f;
    public GameObject prefabs;
    [SerializeField] float verticalBorder = 50.0f;
    [SerializeField] float horizontalBorder = 50.5f;
    private RangeEnemy rangeEnemy;
    private MeleeEnemy meleeEnemy;
    private EnemySpawnManager enemySpawnManager;
    private PlayerStats playerStats;
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * arrowSpeed);
        if (transform.position.x < -horizontalBorder)
        {
            prefabs.SetActive(false);
        }
        if (transform.position.x > horizontalBorder)
        {
            prefabs.SetActive(false);
        }
        if (transform.position.z < -verticalBorder)
        {
            prefabs.SetActive(false);
        }
        if (transform.position.z > verticalBorder)
        {
            prefabs.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        enemySpawnManager = GameObject.Find("Enemy Spawn Manager").GetComponent<EnemySpawnManager>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        if (other.gameObject.CompareTag("Range Enemy"))
        {
            prefabs.SetActive(false);
            rangeEnemy = other.GetComponent<RangeEnemy>();
            rangeEnemy.healthRangeEnemy -= playerStats.attackPower;
            if (rangeEnemy.healthRangeEnemy <= 0)
            {
                other.gameObject.SetActive(false);
                rangeEnemy.healthRangeEnemy = 100;
                other.gameObject.transform.position = enemySpawnManager.RandomPosition();
                rangeEnemy.weaponIsActive = true;
            }
        }
        if (other.gameObject.CompareTag("Melee Enemy"))
        {
            prefabs.SetActive(false);
            meleeEnemy = other.GetComponent<MeleeEnemy>();
            meleeEnemy.healthMeleeEnemy -= playerStats.attackPower;
            if (meleeEnemy.healthMeleeEnemy > 0)
            {
                meleeEnemy.SkeletonAnim.SetTrigger("GetDamage");
            }
        }
    }

}
