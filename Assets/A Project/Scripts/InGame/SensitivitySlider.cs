using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MOUSE_SENSITIVITY", 300f);

        slider.onValueChanged.AddListener(ChangeSensitivity);
    }

    private void ChangeSensitivity(float value)
    {
        PlayerPrefs.SetFloat("MOUSE_SENSITIVITY", value);
        PlayerPrefs.Save();
    }
}