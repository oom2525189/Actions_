using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;

    public const string BGM_VOLUME_KEY = "BGM_VOLUME";
    public const string SE_VOLUME_KEY = "SE_VOLUME";
    public const string CLOCK_VOLUME_KEY = "CLOCK_VOLUME";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            LoadVolume();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetBGMVolume(float volume)
    {
        bgmAudioSource.volume = volume;

        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    public void SetSEVolume(float volume)
    {
        seAudioSource.volume = volume;

        PlayerPrefs.SetFloat(SE_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    public void SetClockVolume(float volume)
    {
        PlayerPrefs.SetFloat(CLOCK_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    private void LoadVolume()
    {
        float savedBGMVolume =
            PlayerPrefs.GetFloat(BGM_VOLUME_KEY, 0.5f);

        float savedSEVolume =
            PlayerPrefs.GetFloat(SE_VOLUME_KEY, 0.5f);

        bgmAudioSource.volume = savedBGMVolume;
        seAudioSource.volume = savedSEVolume;
    }
}