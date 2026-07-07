using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroller : MonoBehaviour
{
    [SerializeField] RectTransform endPoint;
    [SerializeField] float scrollSpeed = 100f;
    [SerializeField] GameObject skipText;

    [SerializeField] float holdTime = 1f;

    private float holdTimer = 0f;

    bool isFinished = false;

    void Update()
    {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            skipText.SetActive(true);
        }
        if (isFinished) return;

        transform.localPosition += Vector3.up * scrollSpeed * Time.deltaTime;

        if (transform.localPosition.y >= endPoint.localPosition.y)
        {
            isFinished = true;
            StartCoroutine(ReturnToTitle());
        }

        if (skipText.activeSelf)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                holdTimer += Time.deltaTime;

                if (holdTimer >= holdTime && !isFinished)
                {
                    isFinished = true;
                    SceneManager.LoadScene("Title");
                }
            }
            else
            {
                holdTimer = 0f;
            }
        }
    }

    IEnumerator ReturnToTitle()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.StopBGM();
        }
        yield return new WaitForSeconds(2f); // 2秒待つ
        SceneManager.LoadScene("Title");
    }
}