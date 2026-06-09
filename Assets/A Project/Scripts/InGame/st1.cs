using UnityEngine;
using UnityEngine.SceneManagement;

public class st1 : MonoBehaviour
{
    public void OnClick()
    {
        Resume1();
        Resume2();
        Resume3();
    }
    public void Resume1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("st1");
        AudioListener.pause = false;
    }
        public void Resume2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("st2");
        AudioListener.pause = false;
    }

    public void Resume3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("st3");
        AudioListener.pause = false;
    }
    public void ReturnToTitle()
    {
        Time.timeScale = 1f; // 忘れると次のシーンが止まる
        AudioListener.pause = false;
        SceneManager.LoadScene("Title"); // 🎯 タイトルシーン名
    }
}
