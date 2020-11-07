using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject ExitDialogRoot;
    public SceneField Scene;

    void Awake()
    {
        ExitDialogRoot.SetActive(false);
    }

    public void StartGameClicked()
    {
        SceneManager.LoadScene(Scene.SceneName);
    }

    public void CreditsClicked()
    {
    }

    public void ExitClicked()
    {
        ExitDialogRoot.SetActive(true);        
    }

    public void ExitDialogResult(bool result)
    {
        ExitDialogRoot.SetActive(false);
        if (result)
        {
            Debug.Log("Qutting...");
            Application.Quit();
        }
    }
}
