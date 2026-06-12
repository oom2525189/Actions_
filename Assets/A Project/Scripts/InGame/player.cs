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
        mouseSensitivity = PlayerPrefs.GetFloat("MOUSE_SENSITIVITY", 300f);
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("SE_VOLUME", 0.5f);
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

        // 1. まずは入力の方向ベクトルを作る
        Vector3 inputDir = new Vector3(h, 0f, v);

        // 2. 入力が一定以上の強さ（斜めなど）なら、長さを1に正規化する
        if (inputDir.magnitude > 1f)
        {
            inputDir.Normalize();
        }

        // 3. 正規化した入力方向を、プレイヤーの向き（ローカル空間）に変換
        Vector3 move = transform.forward * inputDir.z + transform.right * inputDir.x;

        // 4. 速度を適用
        rb.velocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed); //

        bool nowMoving = (h != 0 || v != 0); //

        // 🎯 動き始めたとき
        if (nowMoving && !isMoving)
        {
            audioSource.Play();
            TutorialManager.Instance.CompleteCondition(TutorialConditionType.Move);
        }

        // 🎯 止まったとき
        if (!nowMoving && isMoving)
        {
            audioSource.Stop();
          
        }

        isMoving = nowMoving;
    }
}
