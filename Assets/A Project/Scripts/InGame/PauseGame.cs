using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject menuUI;
    private bool isPaused = false;
    NewBehaviourScript time;//取得したいスクリプトを宣言
    ui kuria;//取得したいスクリプトを宣言
    void Start()
    {//取得したいスクリプトがアタッチしてあるオブジェクトを取得
        GameObject game = GameObject.Find("GameObject");
        //取得したオブジェクトのスクリプトを宣言したスクリプトに入れる
        time = game.GetComponent<NewBehaviourScript>();
        kuria = game.GetComponent<ui>();
        menuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log(time);
        Debug.Log(kuria);
        Debug.Log(kuria?.gamekuriaPanel);
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && time.timeLimit > 0 && !kuria.gamekuriaPanel.activeSelf)
        {
            TutorialManager.Instance.CompleteCondition(TutorialConditionType.Pause);
            Debug.Log("ポーズ");
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
        TutorialManager.Instance.CompleteCondition(TutorialConditionType.restart);
    }
    public void ReturnToTitle()
    {
        Time.timeScale = 1f; // 忘れると次のシーンが止まる
        AudioListener.pause = false;
        SceneManager.LoadScene("Title"); // 🎯 タイトルシーン名
    }
}
