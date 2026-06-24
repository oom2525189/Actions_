using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ui : MonoBehaviour
{
    public Camera mainCamera;

    public float distance = 20f;
    public LayerMask targetLayer;
    public LayerMask dummyLayer;
    public LayerMask wallLayer;
    public LayerMask Tutorial;
    public float rayRadius = 0.5f;
    [SerializeField] private int stageNumber;

    public GameObject gamekuriaPanel;
    [SerializeField] private Image fadeImage;
    [Header("クリア時に流すBGM")]
    [SerializeField] private AudioClip clearBGM;
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
        Ray ray = new Ray(
            mainCamera.transform.position,
            mainCamera.transform.forward
        );

        LayerMask hitLayers =
            targetLayer |
            dummyLayer |
            wallLayer|
            Tutorial;

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
                else if ((hitLayer & Tutorial) != 0)
                {

                    GameObject obj = hit.collider.gameObject;

                    // 複製を作成
                    GameObject clone = Instantiate(
                        obj,
                        obj.transform.position,
                        obj.transform.rotation
                    );

                    // 元のオブジェクトを削除
                    Destroy(obj);

                    TutorialManager.Instance.CompleteCondition(
                       TutorialConditionType.Destroy
                   );
                    return;
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
        if (SoundManager.instance != null && clearBGM != null)
        {
            SoundManager.instance.PlayBGM(clearBGM);
        }
        if (gamekuriaPanel != null)
        {
            gamekuriaPanel.SetActive(true);
            PlayerPrefs.SetInt($"Stage{stageNumber}Clear", 1);
            PlayerPrefs.Save();
            Debug.Log($"Stage{stageNumber}Clear を保存");
        }
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(13f);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.unscaledDeltaTime;

            Color c = fadeImage.color;
            c.a = t;
            fadeImage.color = c;

            yield return null;
        }
        Time.timeScale = 1;

        SceneManager.LoadScene("enndororu");
    }
}

