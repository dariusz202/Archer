using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearProjectiles : MonoBehaviour
{
    [SerializeField] float spearSpeed = 25.0f;
    public GameObject prefabs;
    [SerializeField] float verticalBorder = 12.0f;
    [SerializeField] float horizontalBorder = 16.5f;
    private PlayerController player;

    private void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * spearSpeed);
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

        if (other.gameObject.CompareTag("Player"))
        {
            prefabs.SetActive(false);
            player = other.GetComponent<PlayerController>();
            player.health -= 10;
            if (player.health <= 0)
            {
                other.gameObject.SetActive(false);
            }
            Debug.Log("asdasd" + player.health);

        }


    }
}
