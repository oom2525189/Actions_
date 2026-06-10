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
    public LayerMask wallLayer;
    public float rayRadius = 0.5f;
    public GameObject gamekuriaPanel;
    private bool isLoading = false;

    void Start()
    {
        if (gamekuriaPanel != null)
        {
            gamekuriaPanel.SetActive(false);
        }
    }
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !isLoading)
            {
                Ray ray = new Ray(
                    mainCamera.transform.position,
                    mainCamera.transform.forward
                );

                LayerMask hitLayers =
                    targetLayer |
                    dummyLayer |
                    wallLayer;

                if (Physics.SphereCast(
                    ray,
                    rayRadius,
                    out RaycastHit hit,
                    distance,
                    hitLayers))
                {
                    int hitLayer = 1 << hit.collider.gameObject.layer;

                    // 壁ならここで終了
                    if ((hitLayer & wallLayer) != 0)
                    {
                        Debug.Log("壁に当たった");
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

                        TutorialManager.Instance.CompleteCondition(
                            TutorialConditionType.Destroy
                        );
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

