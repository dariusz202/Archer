using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject playerParent;
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CamControl();
    }
    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;

        transform.LookAt(Target);
        Target.position = Player.position;
        Target.rotation = Quaternion.Euler(0, mouseX, 0);

    }
}
