using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public SceneField Scene;
    public SceneField BackScene;

    public void StartGame()
    {
        SceneManager.LoadScene(Scene.SceneName);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(BackScene.SceneName);
    }
}
