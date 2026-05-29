using UnityEngine;
using UnityEngine.UI;

public class SESlider : MonoBehaviour
{
    void Start()
    {
        Slider slider = GetComponent<Slider>();

        if (slider != null)
        {
            slider.value =
                PlayerPrefs.GetFloat("SE_VOLUME", 0.5f);
        }
    }

    public void SetSEVolume(float volume)
    {
        SoundManager.instance.SetSEVolume(volume);
    }
}