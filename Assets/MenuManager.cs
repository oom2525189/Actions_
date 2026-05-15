using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject selectPanel;
    public GameObject operationPanel;
    public GameObject configPanel;
    public GameObject quitPanel;

    public void ShowSelect()
    {
        mainMenuPanel.SetActive(false);
        selectPanel.SetActive(true);
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);

        selectPanel.SetActive(false);
        operationPanel.SetActive(false);
        configPanel.SetActive(false);
        quitPanel.SetActive(false);
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

    public void StartGame()
    {
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

    public void QuitGame()
    {
        Debug.Log("終了しました");
        Application.Quit();
    }
}