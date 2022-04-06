using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public TheGame theGame;
    public PlayerScript playerScript;
    void Start()
    {
        theGame = GameObject.Find("GameStuff").GetComponent<TheGame>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }
    public void OnMouseDown()
    {
        theGame.ResetLevel();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
