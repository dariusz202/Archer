using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float RotationSpeed = 1;
    private bool weaponIsActive = true;
    public Animator anim;
    [SerializeField] float smooth = 50.0f;
    float tiltAngle = 90.0f;
    float mouseX;
    public Transform TargetShoot;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
            Quaternion target = Quaternion.Euler(0, tiltAroundZ + mouseX, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            anim.SetBool("Moving", true);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
            Quaternion target = Quaternion.Euler(0, tiltAroundZ + mouseX, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            anim.SetBool("Moving", true);

        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Moving", false);
            StartCoroutine(Stop());

        }
        

        if (Input.GetMouseButtonDown(0) && weaponIsActive)
        {

            GameObject arrowProjectile = ArrowSpawnManager.SharedInstance.GetArrow();
            if(arrowProjectile != null)
            {
                weaponIsActive = false;
                anim.SetTrigger("Attack1Trigger");
                anim.SetBool("Attack", true);
                StartCoroutine(Atack());
                arrowProjectile.transform.position = transform.position + new Vector3(0,4,0);
                arrowProjectile.transform.rotation = transform.rotation;
                arrowProjectile.transform.rotation *= Quaternion.Euler(0, 90, 0);
                arrowProjectile.SetActive(true);
            }
        }
    }
    IEnumerator Atack()
    {
        yield return new WaitForSeconds(0.8f);
        weaponIsActive = true;

    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.18f);
        Vector3 dirFromMeToTarget = TargetShoot.position - transform.position;
        dirFromMeToTarget.y = 0.0f;
        Quaternion lookRotation = Quaternion.LookRotation(dirFromMeToTarget);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * smooth);
    }

}
