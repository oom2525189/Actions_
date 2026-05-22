using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public float timeLimit = 60f;

    // 通常タイマー
    public TMP_Text timerText;

    // 中央の大きい数字
    public TMP_Text centerTimerText;

    // 白フラッシュ
    public Image flashImage;

    public GameObject gameOverPanel;

    private bool isGameOver = false;

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        centerTimerText.gameObject.SetActive(false);

        // フラッシュ透明化
        Color color = Color.white;
        color.a = 0f;
        flashImage.color = color;
    }

    void Update()
    {
        //時間停止中でも動く
        //void Update()
        //{
        //    if (isGameOver) return;

        //    // ★ ここを変更
        //    timeLimit -= Time.unscaledDeltaTime;

        //    if (timeLimit < 0)
        //    {
        //        timeLimit = 0;
        //    }

        //    int displayTime = Mathf.CeilToInt(timeLimit);

        //    // 以下そのまま
        //}
        if (isGameOver) return;

        timeLimit -= Time.deltaTime;

        if (timeLimit < 0)
        {
            timeLimit = 0;
        }

        int displayTime = Mathf.CeilToInt(timeLimit);

        // ===== 上のタイマー =====

        if (timeLimit <= 10f)
        {
            bool blink =
                Mathf.FloorToInt(Time.time * 4) % 2 == 0;

            if (blink)
            {
                timerText.text =
                    "Time : <color=red>" + displayTime + "</color>";
            }
            else
            {
                timerText.text =
                    "Time : <color=#00000000>" + displayTime + "</color>";
            }
        }
        else
        {
            timerText.text = "Time : " + displayTime;
        }

        // ===== 残り5秒演出 =====

        if (timeLimit <= 5f && timeLimit > 0)
        {
            centerTimerText.gameObject.SetActive(true);

            // 点滅
            bool centerBlink =
                Mathf.FloorToInt(Time.time * 4) % 2 == 0;

            if (centerBlink)
            {
                centerTimerText.text =
                    "<color=red>" + displayTime + "</color>";
            }
            else
            {
                centerTimerText.text =
                    "<color=#00000000>" + displayTime + "</color>";
            }

            // ===== 拡大縮小 =====

            float scale =
                1f + Mathf.Abs(Mathf.Sin(Time.time * 10f)) * 0.3f;

            centerTimerText.transform.localScale =
                Vector3.one * scale;

            // ===== 白フラッシュ =====

            float alpha =
                Mathf.Abs(Mathf.Sin(Time.time * 8f)) * 0.3f;

            Color flashColor = Color.white;
            flashColor.a = alpha;

            flashImage.color = flashColor;
        }
        else
        {
            centerTimerText.gameObject.SetActive(false);

            // サイズ戻す
            centerTimerText.transform.localScale =
                Vector3.one;

            // フラッシュ消す
            Color flashColor = Color.white;
            flashColor.a = 0f;

            flashImage.color = flashColor;
        }

        // ===== 時間切れ =====

        if (timeLimit <= 0)
        {
            GameOver();
        }
    }
   

    void GameOver()
    {
        isGameOver = true;

        Debug.Log("ゲーム終了");

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

       
    }
}
