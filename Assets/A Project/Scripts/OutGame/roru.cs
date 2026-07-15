using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroller : MonoBehaviour
{
    [SerializeField] RectTransform endPoint;
    [SerializeField] float scrollSpeed = 100f;

    [Header("スキップ")]
    [SerializeField] GameObject skipText;
    [SerializeField] float holdTime = 1f;

    private float holdTimer = 0f;
    private bool isFinished = false;
    private bool isShowingSkipText = false;

    void Start()
    {
        if (skipText != null)
        {
            skipText.SetActive(false);
        }
    }

    void Update()
    {
        if (isFinished) return;

        // 何か入力されたらスキップ説明を2秒表示
        if ((Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            && !isShowingSkipText)
        {
            StartCoroutine(ShowSkipText());
        }

        // エンドロールを上へスクロール
        transform.localPosition += Vector3.up * scrollSpeed * Time.deltaTime;

        // スペース長押しでスキップ
        if (Input.GetKey(KeyCode.Space))
        {
            holdTimer += Time.deltaTime;

            if (holdTimer >= holdTime)
            {
                isFinished = true;

                if (SoundManager.instance != null)
                {
                    SoundManager.instance.StopBGM();
                }

                SceneManager.LoadScene("Title");
            }
        }
        else
        {
            holdTimer = 0f;
        }

        // エンドロール終了
        if (transform.localPosition.y >= endPoint.localPosition.y)
        {
            isFinished = true;
            StartCoroutine(ReturnToTitle());
        }
    }

    IEnumerator ShowSkipText()
    {
        isShowingSkipText = true;

        if (skipText != null)
        {
            skipText.SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        if (skipText != null)
        {
            skipText.SetActive(false);
        }

        isShowingSkipText = false;
    }

    IEnumerator ReturnToTitle()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.StopBGM();
        }

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Title");
    }
}