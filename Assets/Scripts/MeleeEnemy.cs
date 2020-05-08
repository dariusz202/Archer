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
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {

        transform.LookAt(player);
        transform.position += transform.forward * meleeEnemySpeed * Time.deltaTime;
        if(Vector3.Distance(transform.position, player.position) <= 3f && weaponIsActive)
        {
            playerStats.health -= 10;
            weaponIsActive = false;
            StartCoroutine(AtackPlayer());
}

    }
    IEnumerator AtackPlayer()
    {
        yield return new WaitForSeconds(2);
        weaponIsActive = true;
        Debug.Log(playerStats.health);

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
