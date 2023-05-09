using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMouseLook : MonoBehaviour
{
    private Movement movementController;
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    [SerializeField] private float clamp = 90f;
    Camera cam;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private void Start()
    {
        movementController = FindObjectOfType<Movement>();
        cam = GetComponentInChildren<Camera>();
        
    }

    private void Update()
    {
        if (movementController.canMove)
        {
            MyInput();
            cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void MyInput() {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
         
        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation, clamp * -1f, clamp);
    }
}