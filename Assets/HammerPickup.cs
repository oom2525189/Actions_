using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPickup : MonoBehaviour
{
    public Transform playerCamera;
    public Vector3 holdOffset = new Vector3(0.4f, -0.3f, 0.5f);

    public float throwForce = 8f;
    public float holdToThrowTime = 0.5f; // 長押し判定時間

    private bool isPicked = false;
    private bool isTouchingPlayer = false;

    private float fHoldTime = 0f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isTouchingPlayer && isPicked)
        {
            // 既に持っている場合 → 投げる判定
            if (Input.GetKey(KeyCode.F))
            {
                fHoldTime += Time.deltaTime;

                if (fHoldTime >= holdToThrowTime)
                {
                    Throw();
                }
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                // 短押しなら何もしない（拾った状態維持）
                fHoldTime = 0f;
            }
        }
        else if (isTouchingPlayer && !isPicked)
        {
            // 拾う
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickUp();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }

    void PickUp()
    {
        isPicked = true;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.isKinematic = true;
        rb.useGravity = false;

        transform.SetParent(playerCamera);
        transform.localPosition = holdOffset;
        transform.localRotation = Quaternion.identity;

        // 🎯 衝突を完全に無効化
        Collider col = GetComponent<Collider>();
        col.enabled = false;
    }

    void Throw()
    {
        isPicked = false;
        fHoldTime = 0f;

        transform.SetParent(null);

        rb.isKinematic = false;
        rb.useGravity = true;

        rb.velocity = playerCamera.forward * throwForce + Vector3.up * 1.5f;

        // 🎯 衝突を戻す
        GetComponent<Collider>().enabled = true;
    }
}
