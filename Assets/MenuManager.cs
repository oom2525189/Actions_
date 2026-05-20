using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject selectPanel;
    public GameObject operationPanel;
    public GameObject configPanel;
    public GameObject quitPanel;

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
        mainMenuPanel.SetActive(false);
        operationPanel.SetActive(true);
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
        SceneManager.LoadScene("st2");
    }

    public void LoadStage3()
    {
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