using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 10f;
    public float mouseSensitivity = 300f;

    private float mouseX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // マウスをロック
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // マウス左右（体を回転）
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(0f, mouseX, 0f);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // A D
        float v = Input.GetAxis("Vertical");   // W S

        Vector3 move = transform.forward * v + transform.right * h;
        rb.AddForce(move * moveSpeed);
    }
}
