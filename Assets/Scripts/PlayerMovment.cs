using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float verticalBorder = 12.0f;
    [SerializeField] float horizontalBorder = 16.5f;
    private float horizontalInput;
    private float verticalInput;
    private PlayerStats playerStats;
    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerStats.playerSpeed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * playerStats.playerSpeed);
        if (transform.position.x < -horizontalBorder)
        {
            transform.position = new Vector3(-horizontalBorder, transform.position.y, transform.position.z);
        }
        if (transform.position.x > horizontalBorder)
        {
            transform.position = new Vector3(horizontalBorder, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -verticalBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -verticalBorder);
        }
        if (transform.position.z > verticalBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, verticalBorder);
        }
    }
}
