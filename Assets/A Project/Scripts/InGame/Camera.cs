using UnityEngine;

public class Camera : MonoBehaviour
{
    public float mouseSensitivity = 300f;
    private float xRotation = 0f;


    void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("MOUSE_SENSITIVITY", 300f);
    }
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        // è„â∫ÇæÇØâÒì]ÅiZÇÕäÆëSÇ…0Åjfloat mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        TutorialManager.Instance.CompleteCondition(TutorialConditionType.Jumpperspective);
    }
}
