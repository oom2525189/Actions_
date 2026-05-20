using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f;
    public float mouseSensitivity = 300f;

    private float mouseX;

    public AudioClip sound1;
    AudioSource audioSource;

    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound1;
        audioSource.loop = true; // 🎯 ループ再生
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(0f, mouseX, 0f);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * v + transform.right * h;

        rb.velocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed);

        bool nowMoving = (h != 0 || v != 0);

        // 🎯 動き始めたとき
        if (nowMoving && !isMoving)
        {
            audioSource.Play();
        }

        // 🎯 止まったとき
        if (!nowMoving && isMoving)
        {
            audioSource.Stop();
        }

        isMoving = nowMoving;
    }
}
