using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleReturn : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Title");
    }
}
