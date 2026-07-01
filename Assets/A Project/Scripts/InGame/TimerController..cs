using System.Collections;
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

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private AudioClip gameoverBGM;
    [SerializeField] private AudioSource warningAudioSource;

    private bool warningPlayed = false;
    private bool isGameOver = false;

    // 20秒・10秒表示済みフラグ
    private bool shown20 = false;
    private bool shown10 = false;

    // 中央表示中フラグ
    private bool isShowingCenterNumber = false;

    void Start()
    {
        Debug.Log("Start");

        if (warningAudioSource != null)
        {
            warningAudioSource.Stop();
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        centerTimerText.gameObject.SetActive(false);
    }

    void Awake()
    {
        if (warningAudioSource != null)
        {
            warningAudioSource.Stop();
        }
    }

    void Update()
    {
        if (isGameOver)
            return;

        timeLimit -= Time.deltaTime;

        if (timeLimit < 0)
        {
            timeLimit = 0;
        }

        int displayTime = Mathf.CeilToInt(timeLimit);

        // ==========================
        // 20秒・10秒表示
        // ==========================

        if (displayTime == 20 && !shown20)
        {
            shown20 = true;
            StartCoroutine(ShowCenterNumber("20"));
        }

        if (displayTime == 10 && !shown10)
        {
            shown10 = true;
            StartCoroutine(ShowCenterNumber("10"));
        }

        // ==========================
        // 上のタイマー
        // ==========================

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

        // ==========================
        // 残り5秒演出
        // ==========================

        if (timeLimit <= 5f && timeLimit > 0)
        {
            centerTimerText.gameObject.SetActive(true);

            if (!warningPlayed)
            {
                warningPlayed = true;

                Debug.Log("警告音");
                warningAudioSource.Play();
            }

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

            float scale =
                1f + Mathf.Abs(Mathf.Sin(Time.time * 10f)) * 0.3f;

            centerTimerText.transform.localScale =
                Vector3.one * scale;

            float alpha =
                Mathf.Abs(Mathf.Sin(Time.time * 8f)) * 0.3f;

            Color flashColor = Color.white;
            flashColor.a = alpha;
        }
        else if (!isShowingCenterNumber)
        {
            centerTimerText.gameObject.SetActive(false);

            warningPlayed = false;

            if (warningAudioSource != null)
            {
                warningAudioSource.Stop();
            }

            centerTimerText.transform.localScale = Vector3.one;
        }

        // ==========================
        // 時間切れ
        // ==========================

        if (timeLimit <= 0)
        {
            GameOver();
        }
    }

    IEnumerator ShowCenterNumber(string number)
    {
        isShowingCenterNumber = true;

        centerTimerText.gameObject.SetActive(true);

        centerTimerText.text = $"<color=red>{number}</color>";
        centerTimerText.transform.localScale = Vector3.one * 2f;

        yield return new WaitForSeconds(1f);

        if (timeLimit > 5f)
        {
            centerTimerText.gameObject.SetActive(false);
        }

        isShowingCenterNumber = false;
    }

    void GameOver()
    {
        isGameOver = true;

        if (warningAudioSource != null)
        {
            warningAudioSource.Stop();
        }

        warningPlayed = false;
        centerTimerText.gameObject.SetActive(false);

        ClockVolume[] clocks =
            FindObjectsByType<ClockVolume>(FindObjectsSortMode.None);

        foreach (ClockVolume clock in clocks)
        {
            AudioSource audio = clock.GetComponent<AudioSource>();

            if (audio != null)
            {
                audio.Stop();
            }
        }

        Debug.Log("ゲーム終了");

        Time.timeScale = 0f;
        AudioListener.pause = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            if (SoundManager.instance != null && gameoverBGM != null)
            {
                SoundManager.instance.PlayBGM(gameoverBGM);
            }
        }
    }

    public void StopWarningSE()
    {
        if (warningAudioSource != null)
        {
            warningAudioSource.Stop();
        }

        centerTimerText.gameObject.SetActive(false);
    }
}