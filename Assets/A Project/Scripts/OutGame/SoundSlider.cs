using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    
    private enum SoundType
    {
        BGM,
        SE,
        CLOCK
    }

    [SerializeField]
    private SoundType soundType;
    [SerializeField]
    private AudioClip previewSE;
    [SerializeField]
    private AudioClip previewClock;

    void Start()
    {
        Slider slider = GetComponent<Slider>();

        if (slider == null)
        {
            return;
        }

        string key = "";

        switch (soundType)
        {
            case SoundType.BGM:
                key = SoundManager.BGM_VOLUME_KEY;
                break;

            case SoundType.SE:
                key = SoundManager.SE_VOLUME_KEY;
                break;

            case SoundType.CLOCK:
                key = SoundManager.CLOCK_VOLUME_KEY;
                break;
        }

        slider.value = PlayerPrefs.GetFloat(key, 0.5f);

        slider.onValueChanged.AddListener(OnVolumeChanged);

        //Debug.Log(gameObject.name + " のSoundSlider Start");
        //Slider slider = GetComponent<Slider>();

        //if (slider == null) return;

        //string key = "";

        //switch (soundType)
        //{
        //    case SoundType.BGM:
        //        key = SoundManager.BGM_VOLUME_KEY;
        //        break;

        //    case SoundType.SE:
        //        key = SoundManager.SE_VOLUME_KEY;
        //        break;

        //    case SoundType.CLOCK:
        //        key = SoundManager.CLOCK_VOLUME_KEY;
        //        break;
        //}

        //slider.value = PlayerPrefs.GetFloat(key, 0.5f);

        //slider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float volume)
    {
        if (SoundManager.instance == null) return;

        switch (soundType)
        {
            case SoundType.BGM:
                SoundManager.instance.SetBGMVolume(volume);
                break;

            case SoundType.SE:
                SoundManager.instance.SetSEVolume(volume);
                break;

            case SoundType.CLOCK:
                SoundManager.instance.SetClockVolume(volume);
                break;
        }
    }

    // SEテストボタン用
    public void PlaySE()
    {
        if (previewSE == null ||
            SoundManager.instance == null)
            return;

        float volume =
            PlayerPrefs.GetFloat(
                SoundManager.SE_VOLUME_KEY,
                0.5f);

        SoundManager.instance.PlayPreviewSE(
            previewSE,
            volume);
    }

    // 時計テストボタン用
    public void PlayClock()
    {
        if (previewClock == null ||
            SoundManager.instance == null)
            return;

        float volume =
            PlayerPrefs.GetFloat(
                SoundManager.CLOCK_VOLUME_KEY,
                0.5f);

        SoundManager.instance.PlayPreviewSE(
            previewClock,
            volume);
    }
}