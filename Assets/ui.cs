using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    public UnityEngine.Camera mainCamera;
    public RectTransform uiImage;
    public float distance = 5f;
    public LayerMask targetLayer;

    public float rayRadius = 0.5f; // 当たり判定の大きさ

    private bool isLoading = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isLoading)
        {
            Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(
                null,
                uiImage.position
            );

            Ray ray = mainCamera.ScreenPointToRay(screenPos);

            // Raycast → SphereCast に変更
            if (Physics.SphereCast(ray, rayRadius, out RaycastHit hit, distance, targetLayer))
            {
                Debug.Log("当たった: " + hit.collider.name);
                Destroy(hit.collider.gameObject);
                StartCoroutine(LoadSceneDelay(1f)); // 2秒後に移動
                isLoading = true;
            }
            else
            {
                Debug.Log("何も当たってない");
            }
        }
    }

    System.Collections.IEnumerator LoadSceneDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("kuria");
    }
}

