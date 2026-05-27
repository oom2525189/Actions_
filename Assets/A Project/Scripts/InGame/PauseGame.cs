using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject menuUI;
    public float timeLimit = 60f;
    private bool isPaused = false;

    void Start()
    {
        menuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        timeLimit -= Time.deltaTime;

        if (timeLimit < 0)
        {
            timeLimit = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape)&& timeLimit > 0)
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;

        menuUI.SetActive(true);

        Time.timeScale = 0f; // 🎯 ゲーム停止
        AudioListener.pause = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        isPaused = false;

        menuUI.SetActive(false);

        Time.timeScale = 1f;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        TutorialManager.Instance.CompleteCondition(TutorialConditionType.Pause);
    }
    public void ReturnToTitle()
    {
        Time.timeScale = 1f; // 忘れると次のシーンが止まる
        AudioListener.pause = false;
        SceneManager.LoadScene("Title"); // 🎯 タイトルシーン名
    }
}
