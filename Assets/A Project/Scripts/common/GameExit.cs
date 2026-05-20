using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void QuitGame()
    {
        // ビルドしたゲームを終了する
        Application.Quit();
        Debug.Log("ゲームを終了します"); // エディタではここで確認
    }
}
