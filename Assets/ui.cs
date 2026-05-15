using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ui : MonoBehaviour
{
    public UnityEngine.Camera mainCamera;
    public RectTransform uiImage;
    public float distance = 100f;
    public LayerMask targetLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(
                null,
                uiImage.position
            );

            Ray ray = mainCamera.ScreenPointToRay(screenPos);

            if (Physics.Raycast(ray, out RaycastHit hit, distance, targetLayer))
            {
                Debug.Log("当たった: " + hit.collider.name);
                Destroy(hit.collider.gameObject);
            }
           
        }
    }
}
