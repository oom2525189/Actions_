using TMPro;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    public static ClockManager Instance;

    [Header("表示")]
    public TMP_Text realClockText;
    public TMP_Text dummyClockText;

    private int realCount;
    private int dummyCount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CountClocks();
    }

    // 最初に時計を数える
    public void CountClocks()
    {
        realCount = 0;
        dummyCount = 0;

        GameObject[] objects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in objects)
        {
            if (obj.layer == LayerMask.NameToLayer("Clock"))
            {
                realCount++;
            }
            else if (obj.layer == LayerMask.NameToLayer("dummy"))
            {
                dummyCount++;
            }
        }

        UpdateText();
    }

    // 時計が壊れた時に呼ぶ
    public void ClockDestroyed(GameObject obj)
    {
        if (obj.layer == LayerMask.NameToLayer("Clock"))
        {
            realCount--;
        }
        else if (obj.layer == LayerMask.NameToLayer("dummy"))
        {
            dummyCount--;
        }

        UpdateText();
    }

    void UpdateText()
    {
        
        dummyClockText.text = $"ダミー：{dummyCount}";
        realClockText.text = $"本体：{realCount}";
    }
}