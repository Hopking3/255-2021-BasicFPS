using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2;
    public float mouseSensX = 1;
    public float mouseSensY = 1;

    private CharacterController pawn;
    private Camera cam;

    public float cameraPitch = 0;
    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        turnPlayer();
    }
    void movePlayer()
    {
        //get input
        float v = Input.GetAxis("Vertical");//W + S, UP + DOWN, CONTROLLER UP + CONTROLLER DOWN | value between -1 & 1
        float h = Input.GetAxis("Horizontal");//A + D, LEFT + RIGHT, CONTROLLER LEFT + CONTROLLER RIGHT | value between -1 & 1

        //transform.position += transform.right * moveSpeed * Time.deltaTime * h;
        //transform.position += transform.forward * moveSpeed * Time.deltaTime * v;
        Vector3 speed = (transform.right * h + transform.forward * v) * moveSpeed;
        pawn.SimpleMove(speed);
    }
    void turnPlayer()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        transform.Rotate(0, h * mouseSensX, 0);
        // cam.transform.Rotate(v * mouseSensY, 0, 0);
        cameraPitch += v * mouseSensY;
        cameraPitch = Mathf.Clamp(cameraPitch, -80, 80);
        cam.transform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
    }
}
