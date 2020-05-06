using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    [SerializeField] float arrowSpeed = 50.0f;
    public GameObject prefabs;
    [SerializeField] float verticalBorder = 12.0f;
    [SerializeField] float horizontalBorder = 16.5f;

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
    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
