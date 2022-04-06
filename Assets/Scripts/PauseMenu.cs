using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    bool isPaused = false;
    void Start()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePause();
        }
    }
    //public void OnMouseDown()
    //{
    //    TogglePause();
    //}
    public void TogglePause()
    {
        if (isPaused)
        {
            //unpause
            Time.timeScale = 1.0f;
            pauseUI.SetActive(false);
        }
        else
        {
            //pause
            Time.timeScale = 0.0f;
            pauseUI.SetActive(true);
        }
        isPaused = !isPaused;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
