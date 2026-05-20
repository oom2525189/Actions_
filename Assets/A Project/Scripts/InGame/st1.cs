using UnityEngine;
using UnityEngine.SceneManagement;

public class st1 : MonoBehaviour
{
    public void OnClick()
    {
        Resume();
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("st1");
    }
    public void ReturnToTitle()
    {
        Time.timeScale = 1f; // 忘れると次のシーンが止まる
        SceneManager.LoadScene("Title"); // 🎯 タイトルシーン名
    }
}
