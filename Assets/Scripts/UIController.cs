using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void GoToURL(string url)
    {
        Application.OpenURL(url);
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GoToARScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
