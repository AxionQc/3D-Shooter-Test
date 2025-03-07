using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public Transform target, player;
    float mouseX;
    float mouseY;
    float h;
    float v;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void LateUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);
        CamControl();
    }
    
    void CamControl()
    {
        target.position = player.position + Vector3.up * 1.5f; // Adjust target position

        transform.LookAt(target);
        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        // Rotate camera around the player
        Vector3 direction = new Vector3(0, 0, -5.0f);
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.position = target.position + rotation * direction + Vector3.up * 2.0f;
        transform.LookAt(target);
    }
}