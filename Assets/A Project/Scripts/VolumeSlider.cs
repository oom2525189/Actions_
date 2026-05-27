using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    void Start()
    {
        //起動時に、SoundManagerの現在の音量をスライダーのツマミの位置に反映する
        Slider slider = GetComponent<Slider>();
        if (slider != null && SoundManager.instance != null)
        {
            //保存されていた音量（または0.5）を取得してスライダーにセット
            slider.value = PlayerPrefs.GetFloat("BGM_VOLUME", 0.5f);
        }
    }

    public void SetBGMVolume(float volume)
    {
        SoundManager.instance.SetBGMVolume(volume);
    }
}