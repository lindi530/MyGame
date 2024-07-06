using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("速度")]
    [SerializeField]
    private float MoveSpeed = 5f; 
    [SerializeField]
    private float RevolveSpeed = 8f;
    [SerializeField]
    private float ScrollSpeed = 15f;

    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private CameraController cameraController;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void PlayerMovement()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");
        Vector3 velocity = (transform.right * movex + transform.forward * movey).normalized * MoveSpeed;
        playerController.Move(velocity);
    }

    private void PlayerRotation()
    {
        float rotatex = Input.GetAxisRaw("Mouse X");
        float rotatey = Input.GetAxisRaw("Mouse Y");
        Vector3 yRotaion = new Vector3(0f, rotatex, 0f).normalized * RevolveSpeed;
        Vector3 xRotaion = new Vector3(-rotatey, 0f, 0f).normalized * RevolveSpeed;
        playerController.Rotate(yRotaion, xRotaion);
    }

    private void CreamerField()
    {
        float scroll =  Input.GetAxisRaw("Mouse ScrollWheel");
        cameraController.Field(scroll * ScrollSpeed);
    }

    private void CreamerMovement()
    {
        float movex = Input.GetAxisRaw("Mouse X");
        float movey = Input.GetAxisRaw("Mouse Y");
        //cameraController.Move();
    }
    void Update()
    {
        PlayerMovement();
        PlayerRotation();
        CreamerField();
        CreamerMovement();
    }
}
