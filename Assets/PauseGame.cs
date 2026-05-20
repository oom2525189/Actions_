using System.Collections;
using System.Collections.Generic;
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

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        isPaused = false;

        menuUI.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ReturnToTitle()
    {
        Time.timeScale = 1f; // 忘れると次のシーンが止まる

        SceneManager.LoadScene("Title"); // 🎯 タイトルシーン名
    }
}
