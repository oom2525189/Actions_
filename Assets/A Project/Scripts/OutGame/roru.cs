//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class roru : MonoBehaviour
//{
//    [SerializeField]
//    RectTransform[] telops;

//    [SerializeField]
//    RectTransform startPoint;

//    [SerializeField]
//    RectTransform endPoint;

//    void Update()
//    {
//        for (int i = 0; i < telops.Length; i++)
//        {
//            telops[i].localPosition += Vector3.up * .1f;

//            if (telops[i].localPosition.y > endPoint.localPosition.y)
//            {
//                telops[i].localPosition = new Vector3(
//                    telops[i].localPosition.x,
//                    startPoint.localPosition.y,
//                    telops[i].localPosition.z);
//            }
//        }
//    }
//}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroller : MonoBehaviour
{
    [SerializeField] RectTransform endPoint;
    [SerializeField] float scrollSpeed = 100f;

    bool isFinished = false;

    void Update()
    {
        if (isFinished) return;

        transform.localPosition += Vector3.up * scrollSpeed * Time.deltaTime;

        if (transform.localPosition.y >= endPoint.localPosition.y)
        {
            isFinished = true;
            StartCoroutine(ReturnToTitle());
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