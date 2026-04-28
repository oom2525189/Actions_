using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class operationTransition : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("operation");
    }
}
