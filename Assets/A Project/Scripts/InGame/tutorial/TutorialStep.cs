using UnityEngine;

[System.Serializable]
public class TutorialStep
{
    [TextArea]
    public string message;

    public TutorialConditionType conditionType;

    public float nextDelay;
}

public enum TutorialConditionType
{
    None,
    Move,
    Jumpperspective,
    Attack,
    Pause,
    restart,
    Destroy

}