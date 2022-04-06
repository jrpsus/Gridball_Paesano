using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchButton : MonoBehaviour
{
    public TheGame theGame;
    public PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        theGame = GameObject.Find("GameStuff").GetComponent<TheGame>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    public void OnMouseDown()
    {
        if (!playerScript.moving)
        {
            playerScript.xy = Vector3.right;
            playerScript.Launch();
        }
    }
    void Update()
    {
        
    }
}
