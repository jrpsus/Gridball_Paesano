using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceablesMain : MonoBehaviour
{
    public int placeableId;
    public Placeables placeables;
    public TheGame theGame;
    public PlayerScript playerScript;
    public Color color;
    public Renderer rd;
    // Start is called before the first frame update
    void Start()
    {
        theGame = GameObject.Find("GameStuff").GetComponent<TheGame>();
        placeables = GameObject.Find("Placeable").GetComponent<Placeables>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }
    public void OnMouseDown()
    {
        //if (!playerScript.moving)
        //{
            if (placeables.sel == placeableId)
            {
                placeables.sel = 0;
            }
            else
            {
                placeables.sel = placeableId;
            }
        //}
    }
    // Update is called once per frame
    void Update()
    {
        if (placeables.sel == placeableId)
        {
            color = new Color(99f / 255f, 99f / 255f, 99f / 255f, 1f);
        }
        else
        {
            color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1f);
        }
        rd.material.color = color;
    }
}
