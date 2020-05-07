using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    [SerializeField] float arrowSpeed = 50.0f;
    public GameObject prefabs;
    [SerializeField] float verticalBorder = 12.0f;
    [SerializeField] float horizontalBorder = 16.5f;
    private RangeEnemy rangeEnemy;
    private MeleeEnemy meleeEnemy;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * arrowSpeed);
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
        if (other.gameObject.CompareTag("Range Enemy"))
        {
            prefabs.SetActive(false);
            rangeEnemy = other.GetComponent<RangeEnemy>();
            rangeEnemy.healthRangeEnemy -= 10;
            if(rangeEnemy.healthRangeEnemy <= 0)
            {
                Destroy(other.gameObject);
            }

        }
        if (other.gameObject.CompareTag("Melee Enemy"))
        {
            prefabs.SetActive(false);
            meleeEnemy = other.GetComponent<MeleeEnemy>();
            meleeEnemy.healthMeleeEnemy -= 10;
            if(meleeEnemy.healthMeleeEnemy <= 0)
            {
                Destroy(other.gameObject);
            }

        }
    }

}
