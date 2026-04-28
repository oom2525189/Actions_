using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammer : MonoBehaviour
{
    public Transform Hammer_01;
    public Collider hammerCollider; // ← 追加

    public float swingSpeed = 10f;

    private bool isSwinging = false;

    private float baseAngle = -55f;
    private float targetAngle = 20f;

    private float currentAngle;

    void Start()
    {
        currentAngle = baseAngle;
        Hammer_01.localRotation = Quaternion.Euler(currentAngle, 0f, 90f);

        hammerCollider.enabled = false; // 最初はOFF
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isSwinging)
        {
            StartCoroutine(Swing());
        }
    }

    IEnumerator Swing()
    {
        isSwinging = true;

        float hitStart = -10f;
        float hitEnd = 10f;

        // 振り（-45 → 20）
        while (currentAngle < targetAngle)
        {
            currentAngle += swingSpeed * Time.deltaTime * 100f;
            currentAngle = Mathf.Min(currentAngle, targetAngle);

            // 当たり判定
            if (currentAngle >= hitStart && currentAngle <= hitEnd)
            {
                hammerCollider.enabled = true;
            }
            else
            {
                hammerCollider.enabled = false;
            }

            // 振り中はY固定
            Hammer_01.localRotation = Quaternion.Euler(currentAngle, -35f, 90f);

            yield return null;
        }

        // 戻り用の初期Y
        float returnY = -35f;

        // 戻す（20 → -45）
        while (currentAngle > baseAngle)
        {
            currentAngle -= swingSpeed * Time.deltaTime * 100f;
            currentAngle = Mathf.Max(currentAngle, baseAngle);

            // 🎯 Yを徐々に0へ
            returnY = Mathf.Lerp(returnY, 0f, Time.deltaTime * 10f);

            Hammer_01.localRotation = Quaternion.Euler(currentAngle, returnY, 90f);

            hammerCollider.enabled = false;

            yield return null;
        }

        // 最終的に完全リセット
        Hammer_01.localRotation = Quaternion.Euler(baseAngle, 0f, 90f);

        hammerCollider.enabled = false;
        isSwinging = false;
    }
}