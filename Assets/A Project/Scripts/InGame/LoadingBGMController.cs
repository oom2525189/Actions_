using UnityEngine;

public class LoadingBGMController : MonoBehaviour
{
    void Start()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.StopBGM();
        }
    }
}