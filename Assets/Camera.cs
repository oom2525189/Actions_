using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float Speed = 20;
    private float mouseInputX;
    private float mouseInputY;

    // Update is called once per frame
    void Update()
    {
        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y");

        transform.Rotate(0, mouseInputX * Time.deltaTime * Speed, 0);
        transform.Rotate(-mouseInputY * Time.deltaTime * Speed, 0,0);
    }
}
