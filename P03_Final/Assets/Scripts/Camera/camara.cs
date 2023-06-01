﻿using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5f;
    public float distanceFromTarget = 5f; // New variable for camera distance

    private float pitch = 0f;
    private float yaw = 0f;

    void Update()
    {
        // Get the mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Adjust the camera rotation based on mouse movement
        yaw += mouseX * rotationSpeed;
        pitch -= mouseY * rotationSpeed;

        // Clamp the pitch to avoid flipping the camera
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        // Rotate the camera and update its position based on the target
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}