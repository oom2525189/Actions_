using UnityEngine;

public class ClockVolume : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.volume =
            PlayerPrefs.GetFloat(
                SoundManager.CLOCK_VOLUME_KEY,
                0.5f);
    }

    void Update()
    {
        audioSource.volume =
            PlayerPrefs.GetFloat(
                SoundManager.CLOCK_VOLUME_KEY,
                0.5f);
    }
}