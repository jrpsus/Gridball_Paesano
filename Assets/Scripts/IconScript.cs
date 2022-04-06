using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconScript : MonoBehaviour
{
    public int id;
    public int iconEdited;
    public TheGame theGame;
    void Start()
    {
        theGame = GameObject.Find("GameStuff").GetComponent<TheGame>();
        iconEdited = theGame.grid[id];
    }

    // Update is called once per frame
    void Update()
    {
        if (iconEdited != theGame.grid[id])
        {
            Destroy(this.gameObject);
        }
        //if (theGame.grid[id] == 0)
        //{
        //    Destroy(this.gameObject);
        //}
    }
}
