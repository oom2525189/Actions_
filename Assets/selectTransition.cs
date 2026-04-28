using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectTransition : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("select");
    }
}
