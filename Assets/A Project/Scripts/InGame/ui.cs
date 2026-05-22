using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    public UnityEngine.Camera mainCamera;

    public float distance = 5f;
    public LayerMask targetLayer;

    public float rayRadius = 0.5f;

    private bool isLoading = false;

    //private LineRenderer lineRenderer;

    //void Start()
    //{
    //    // LineRenderer 作成
    //    lineRenderer = gameObject.AddComponent<LineRenderer>();

    //    lineRenderer.startWidth = 0.03f;
    //    lineRenderer.endWidth = 0.03f;

    //    lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

    //    lineRenderer.positionCount = 2;
    //}

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isLoading)
        {
            // ===== カメラ位置 =====
            Vector3 origin = mainCamera.transform.position;

            // ===== カメラが向いている方向 =====
            Vector3 direction = mainCamera.transform.forward;

            // Ray 作成
            Ray ray = new Ray(origin, direction);

            // ===== Gameビューに表示 =====
            //lineRenderer.enabled = true;

            //lineRenderer.SetPosition(0, origin);
            //lineRenderer.SetPosition(1, origin + direction * distance);

            // SphereCast
            if (Physics.SphereCast(ray, rayRadius, out RaycastHit hit, distance, targetLayer))
            {
                Debug.Log("当たった: " + hit.collider.name);

                //lineRenderer.startColor = Color.green;
                //lineRenderer.endColor = Color.green;

                Destroy(hit.collider.gameObject);

                StartCoroutine(LoadSceneDelay(1f));

                isLoading = true;
            }
            else
            {
                Debug.Log("何も当たってない");

                //lineRenderer.startColor = Color.red;
                //lineRenderer.endColor = Color.red;
            }
        }
    }

    System.Collections.IEnumerator LoadSceneDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("kuria");
    }
}

