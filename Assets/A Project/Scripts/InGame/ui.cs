using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ui : MonoBehaviour
{
    public UnityEngine.Camera mainCamera;

    public float distance = 5f;
    public LayerMask targetLayer;
    public LayerMask dummyLayer;
    public float rayRadius = 0.5f;

    private bool isLoading = false;

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !isLoading)
        {
            Vector3 origin = mainCamera.transform.position;
            Vector3 direction = mainCamera.transform.forward;

            Ray ray = new Ray(origin, direction);

            // ===== targetLayer =====
            if (Physics.SphereCast(ray, rayRadius, out RaycastHit Hit, distance, targetLayer))
            {
                Debug.Log("当たった: " + Hit.collider.name);

                Destroy(Hit.collider.gameObject);

                StartCoroutine(LoadSceneDelay(1f));

                isLoading = true;
            }

            // ===== dummyLayer =====
            if (Physics.SphereCast(ray, rayRadius, out RaycastHit hit, distance, dummyLayer))
            {
                Debug.Log("ダミー");

                Destroy(hit.collider.gameObject);

                //// ヒットストップ
                //StartCoroutine(HitStop(0.5f));
            }
        }
    }


    IEnumerator HitStop(float time)
    {
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(time);

        Time.timeScale = 1f;
    }

    System.Collections.IEnumerator LoadSceneDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("kuria");
        }
    }
