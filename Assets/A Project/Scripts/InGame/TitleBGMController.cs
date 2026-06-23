using UnityEngine;

public class TitleBGMController : MonoBehaviour
{
    [SerializeField] private AudioClip titleBGM;

    void Start()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.PlayBGM(titleBGM);
        }
    }
}
