using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public PauseMenu pauseMenu;
    void Start()
    {
        pauseMenu = GameObject.Find("Pause").GetComponent<PauseMenu>();
    }

    public void OnMouseDown()
    {
        pauseMenu.TogglePause();
    }
}
