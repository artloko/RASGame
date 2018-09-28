using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject gameObject;

    public void Resume()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        isPaused = false;
    }

    public void Pause()
    {
        Debug.Log("PAUSED");
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Save()
    {
        GameProcess.instance.SaveGameProcess();
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
