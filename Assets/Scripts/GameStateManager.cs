using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public GameObject menuUI;
    public static bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        menuUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        paused = true;
        Time.timeScale = 0.0f;
        menuUI.gameObject.SetActive(true);
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        menuUI.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Resume();
        Application.Quit();
    }
}
