using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject selectPanel;
    public GameObject operationPanel;
    public GameObject configPanel;
    public GameObject quitPanel;
    public Button stage2Button;
    public Button stage3Button;

    void Start()
    {
        Debug.Log("MenuManager Start");
        Debug.Log("Stage1Clear = " + PlayerPrefs.GetInt("Stage1Clear", 0));
        Debug.Log("Stage2Clear = " + PlayerPrefs.GetInt("Stage2Clear", 0));
        stage2Button.interactable =
            PlayerPrefs.GetInt("Stage1Clear", 0) == 1;

        stage3Button.interactable =
            PlayerPrefs.GetInt("Stage2Clear", 0) == 1;
    }

    // ===== Panel切替 =====

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);

        selectPanel.SetActive(false);
        operationPanel.SetActive(false);
        configPanel.SetActive(false);
        quitPanel.SetActive(false);
    }

    public void ShowSelect()
    {
        mainMenuPanel.SetActive(false);
        selectPanel.SetActive(true);
    }

    public void ShowOperation()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void ShowConfig()
    {
        mainMenuPanel.SetActive(false);
        configPanel.SetActive(true);
    }

    // ===== Quit確認 =====

    public void ShowQuitPanel()
    {
        mainMenuPanel.SetActive(false);
        quitPanel.SetActive(true);
    }

    public void CloseQuitPanel()
    {
        mainMenuPanel.SetActive(true);
        quitPanel.SetActive(false);
    }

    // ===== ゲーム開始 =====

    public void StartGame()
    {
        //後でチュートリアル足すかも
        SceneManager.LoadScene("st1");
    }

    public void LoadStage1()
    {
        SceneManager.LoadScene("st1");
    }

    public void LoadStage2()
    {
        if (PlayerPrefs.GetInt("Stage1Clear", 0) == 0)
            return;
        SceneManager.LoadScene("st2");
    }

    public void LoadStage3()
    {
        if (PlayerPrefs.GetInt("Stage2Clear", 0) == 0)
            return;
        SceneManager.LoadScene("st3");
    }

    // ===== 終了 =====

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("終了しました");
#else
        Application.Quit();
#endif
    }
}