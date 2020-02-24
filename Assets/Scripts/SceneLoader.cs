using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void HomeScene()
    {
        SceneManager.LoadScene(2);
    }

    public void PickupsScene()
    {
        SceneManager.LoadScene(5);
    }

    public void SeeControls()
    {
        SceneManager.LoadScene(3);
    }

    public void WeaponsScene()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}