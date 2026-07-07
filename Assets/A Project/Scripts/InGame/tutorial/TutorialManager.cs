using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    public TutorialStep[] steps;
    public TextMeshProUGUI tutorialText;

    private int currentStep = 0;
    private bool isProcessing = false; // 連打防止

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (steps.Length > 0)
            ShowStep();
    }

    void ShowStep()
    {
        if (currentStep < steps.Length)
        {
            tutorialText.text = steps[currentStep].message;
        }
    }

    public void CompleteCondition(TutorialConditionType type)
    {
        if (currentStep >= steps.Length || isProcessing) return;

        if (steps[currentStep].conditionType == type)
        {
            StartCoroutine(NextStepWithDelay());
        }
    }

    IEnumerator NextStepWithDelay()
    {
        isProcessing = true;

        float delay = steps[currentStep].nextDelay;

        yield return new WaitForSeconds(delay);

        currentStep++;

        if (currentStep < steps.Length)
        {
            ShowStep();
        }
        else
        {
            tutorialText.text = "チュートリアル" +
                "完了！";
            StartCoroutine(LoadSceneDelay(2f));
        }
        isProcessing = false;
    }
    System.Collections.IEnumerator LoadSceneDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Title");
    }
}

