using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    private ArrowProjectile arrow;
    public PlayerController playerStats;
    public Transform player;
    private Rigidbody enemyRB;
    private GameManager gameManager;
    [SerializeField] float enemyRange = 20f;
    [SerializeField] float enemySpeed = 5f;
    void Start()
    {
        enemyRB = this.GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerController>();
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > enemyRange)
        {
            transform.LookAt(player);
            transform.position += transform.forward * enemySpeed * Time.deltaTime;
        }
        if (Vector3.Distance(transform.position, player.position) <= enemyRange)
        {
            AtackPlayer();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStats.health -= 10;
            Debug.Log("asdasd" + playerStats.health);
        }
    }
    IEnumerator AtackPlayer()
    {
        yield return new WaitForSeconds(5);
        GameObject arrowProjectile = ArrowSpawnManager.SharedInstance.GetArrow();
        if (arrowProjectile != null)
        {
            arrowProjectile.SetActive(true);
            arrowProjectile.transform.position = transform.position;
            arrowProjectile.transform.rotation = transform.rotation;
        }

    }

}
