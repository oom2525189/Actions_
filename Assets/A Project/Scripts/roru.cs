using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roru : MonoBehaviour
{
    [SerializeField]
    RectTransform[] telops;

    [SerializeField]
    RectTransform startPoint;

    [SerializeField]
    RectTransform endPoint;

    void Update()
    {
        for (int i = 0; i < telops.Length; i++)
        {
            telops[i].localPosition += Vector3.up * .1f;

            if (telops[i].localPosition.y > endPoint.localPosition.y)
            {
                telops[i].localPosition = new Vector3(
                    telops[i].localPosition.x,
                    startPoint.localPosition.y,
                    telops[i].localPosition.z);
            }
        }
    }
}
