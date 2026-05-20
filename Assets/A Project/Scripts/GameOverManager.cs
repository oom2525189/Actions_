using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // ゲームオーバー前のシーン番号を保存
    private static int previousSceneIndex;

    // ===== ゲームオーバーへ行く前に呼ぶ =====
    public static void SetPreviousScene()
    {
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // ===== リトライ =====
    public void RetryStage()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }

    // ===== タイトルへ戻る =====
    public void BackToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
