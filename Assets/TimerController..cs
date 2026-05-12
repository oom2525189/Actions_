using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // 制限時間（秒）
    public float timeLimit = 60f;

    // UIテキスト
    public TMP_Text timerText;

    // ゲーム終了表示
    public GameObject gameOverPanel;

    private bool isGameOver = false;

    void Start()
    {
        // パネルを非表示
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        // ゲーム終了後は処理しない
        if (isGameOver) return;

        // 時間を減らす
        timeLimit -= Time.deltaTime;

        // 0未満にならないように
        if (timeLimit < 0)
        {
            timeLimit = 0;
        }

        // UI更新
        timerText.text = "のこり" + Mathf.Ceil(timeLimit).ToString();

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

        // パネル表示
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // ゲーム停止
        Time.timeScale = 0f;
    }
}
