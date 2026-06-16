using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ui : MonoBehaviour
{
    public Camera mainCamera;

    public float distance = 20f;
    public LayerMask targetLayer;
    public LayerMask dummyLayer;
    public LayerMask wallLayer;
    public float rayRadius = 0.5f;

    public GameObject gamekuriaPanel;

    private bool isLoading = false;
    //private LineRenderer lineRenderer;

    void Start()
    {
        //lineRenderer = gameObject.AddComponent<LineRenderer>();

        //lineRenderer.positionCount = 2;
        //lineRenderer.startWidth = 0.2f;
        //lineRenderer.endWidth = 0.2f;
        //lineRenderer.useWorldSpace = true;

        //Material mat = new Material(
        //    Shader.Find("Sprites/Default")
        //);

        //mat.color = Color.red;
        //lineRenderer.material = mat;

        //lineRenderer.startColor = Color.red;
        //lineRenderer.endColor = Color.red;

        if (gamekuriaPanel != null)
        {
            gamekuriaPanel.SetActive(false);
        }
    }

    void Update()
    {
        //Vector3 startPos =
        //    mainCamera.transform.position +
        //    mainCamera.transform.forward * 0.5f;

        Ray ray = new Ray(
            mainCamera.transform.position,
            mainCamera.transform.forward
        );

        LayerMask hitLayers =
            targetLayer |
            dummyLayer |
            wallLayer;

        //// レーザー表示
        //if (Physics.SphereCast(
        //    ray,
        //    rayRadius,
        //    out RaycastHit laserHit,
        //    distance,
        //    hitLayers))
        //{
        //    lineRenderer.SetPosition(0, startPos);
        //    lineRenderer.SetPosition(1, laserHit.point);
        //}
        //else
        //{
        //    lineRenderer.SetPosition(0, startPos);
        //    lineRenderer.SetPosition(
        //        1,
        //        startPos + mainCamera.transform.forward * distance
        //    );
        //}

        // クリック時
        if (Input.GetMouseButtonDown(0) && !isLoading)
        {
            if (Physics.SphereCast(
                ray,
                rayRadius,
                out RaycastHit hit,
                distance,
                hitLayers,
        QueryTriggerInteraction.Ignore))
            {
                int hitLayer = 1 << hit.collider.gameObject.layer;

                // 壁
                if ((hitLayer & wallLayer) != 0)
                {
                    Debug.Log("壁に当たった");
                    TutorialManager.Instance.CompleteCondition(
                       TutorialConditionType.Destroy
                   );
                    return;
                }

                // Target
                if ((hitLayer & targetLayer) != 0)
                {
                    Debug.Log("当たった: " + hit.collider.name);

                    Destroy(hit.collider.gameObject);

                    isLoading = true;
                    StartCoroutine(LoadSceneDelay(1f));
                }
                // Dummy
                else if ((hitLayer & dummyLayer) != 0)
                {
                    Debug.Log("ダミー");

                    Destroy(hit.collider.gameObject);

                   
                }
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
        //SceneManager.LoadScene("kuria");
        if (gamekuriaPanel != null)
        {
            gamekuriaPanel.SetActive(true);
        }
        Time.timeScale = 0f;
        }
    }

