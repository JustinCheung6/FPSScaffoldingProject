using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 50f;

    [Tooltip("Invert mouse across Y-axis")]
    [SerializeField] private bool invertedHorizontal = false;
    
    [Header("Vertical Rotation")]
    [Tooltip("Vertical Rotation in the Camera transform")]
    [SerializeField] private Transform playerCam = null;
    [Tooltip("Invert mouse across X-axis")]
    [SerializeField] private bool invertedVertical = false;

    [SerializeField] private float maxVerticalRotation = 90f;
    [SerializeField] private float minVerticalRotation = -90f;


    private float vRotation = 0f;

    private void Start()
    {
        //Sets playerCam if not already set
        if (playerCam == null)
            if (GetComponentInChildren<Camera>() != null)
                playerCam = GetComponentInChildren<Camera>().transform;

        //Set vertical rotation to player's default
        vRotation = playerCam.eulerAngles.x;
    }
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        //HORIZONTAL
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        if (invertedHorizontal)
            mouseX = -mouseX;

        //Rotating the y-axis rotates left and right
        transform.Rotate(Vector3.up, mouseX);

        //VERTICAL
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        //Adding inputs creates inverted movement
        if (invertedVertical)
            vRotation += mouseY;
        else
            vRotation -= mouseY;


        vRotation = Mathf.Clamp(vRotation, minVerticalRotation, maxVerticalRotation);

        playerCam.localRotation = Quaternion.Euler(vRotation, 0f, 0f);

    }
}
