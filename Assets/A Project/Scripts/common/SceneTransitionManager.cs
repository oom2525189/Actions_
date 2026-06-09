using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    /// <summary>
    /// インスペクターから遷移先のシーン名を指定して呼び出す
    /// </summary>
    /// <param name="sceneName">遷移先のシーン名</param>
    public void LoadScene(string sceneName)
    {
        // 空文字チェックなどの安全対策を入れておくと堅牢になります
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("シーン名が指定されていません。");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }
}