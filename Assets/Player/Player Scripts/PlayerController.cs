using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float RotationSpeed = 1;
    private bool weaponIsActive = true;
    public Animator anim;
    float smooth = 20.0f;
    float tiltAngle = 90.0f;
    float mouseX;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            // Smoothly tilts a transform towards a target rotation.
            float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;

            // Rotate the cube by converting the angles into a quaternion.
            Quaternion target = Quaternion.Euler(0, tiltAroundZ + mouseX, 0);

            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            anim.SetBool("moving", true);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
            Quaternion target = Quaternion.Euler(0, tiltAroundZ + mouseX, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            anim.SetBool("moving", true);
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            anim.SetBool("moving", false);
        }
        

        if (Input.GetMouseButtonDown(0) && weaponIsActive)
        {
            GameObject arrowProjectile = ArrowSpawnManager.SharedInstance.GetArrow();
            if(arrowProjectile != null)
            {
                weaponIsActive = false;
                StartCoroutine(Atack());
                arrowProjectile.SetActive(true);
                arrowProjectile.transform.position = transform.position;
                arrowProjectile.transform.rotation = transform.rotation;
            }
        }
    }
    IEnumerator Atack()
    {
        yield return new WaitForSeconds(0.5f);
        weaponIsActive = true;

    }

}
