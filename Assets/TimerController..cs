using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public float timeLimit = 60f;

    public TMP_Text timerText;

    public GameObject gameOverPanel;

    private bool isGameOver = false;

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (isGameOver) return;

        timeLimit -= Time.deltaTime;

        if (timeLimit < 0)
        {
            timeLimit = 0;
        }

        // 表示する秒数
        int displayTime = Mathf.CeilToInt(timeLimit);

        // 残り10秒以下
        if (timeLimit <= 10f)
        {
            // 点滅処理
            bool blink = Mathf.FloorToInt(Time.time * 4) % 2 == 0;

            if (blink)
            {
                // 数字だけ赤
                timerText.text = "Time : <color=red>" + displayTime + "</color>";
            }
            else
            {
                // 数字を透明にする
                timerText.text = "Time : <color=#00000000>" + displayTime + "</color>";
            }
        }
        else
        {
            // 通常表示
            timerText.text = "Time : " + displayTime;
        }

        // 時間切れ
        if (timeLimit <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;

        Debug.Log("ゲーム終了");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}
