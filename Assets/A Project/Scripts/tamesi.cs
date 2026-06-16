using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamesi : MonoBehaviour
{
    //    float speed = 5.0f;
    //    float Speed = 200;
    //    void Update()
    //    {
    //        // Wキー（前方移動）
    //        if (Input.GetKey(KeyCode.W))
    //        {
    //            transform.position += speed * transform.forward * Time.deltaTime;
    //        }

    //        // Sキー（後方移動）
    //        if (Input.GetKey(KeyCode.S))
    //        {
    //            transform.position -= speed * transform.forward * Time.deltaTime;
    //        }
    //        //transform.position -= speed * transform.up * Time.deltaTime; 上下
    //        float h = Input.GetAxis("Horizontal");
    //        transform.Rotate(0, h * Speed * Time.deltaTime, 0);

    //        // Dキー（右移動）
    //        //if (Input.GetKey(KeyCode.D))
    //        //{
    //        //    transform.position += speed * transform.right * Time.deltaTime;
    //        //}

    //        //// Aキー（左移動）
    //        //if (Input.GetKey(KeyCode.A))
    //        //{
    //        //    transform.position -= speed * transform.right * Time.deltaTime;
    //        //}
    //    }

    public float speed = 15f;
    public float turnSpeed = 120f;
    public float driftGrip = 2f;
    private Vector3 moveDir;
    void Start()
    {
        moveDir = transform.forward;
    }

    void Update()
    {
        // ハンドル操作
        float h = Input.GetAxis("Horizontal");
        transform.Rotate(0, h * turnSpeed * Time.deltaTime, 0);

        // 移動方向をゆっくり車体の向きへ追従させる
        moveDir = Vector3.Lerp(
            moveDir,
            transform.forward,
            driftGrip * Time.deltaTime
        ).normalized;

        // 移動
        if (Input.GetKey(KeyCode.W))
            transform.position += moveDir * speed * Time.deltaTime;
    }
}