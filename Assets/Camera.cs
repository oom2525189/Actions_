using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float mouseSensitivity = 300f;
    private float xRotation = 0f;

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // ã‰º‚¾‚¯‰ñ“]iZ‚ÍŠ®‘S‚É0j
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
