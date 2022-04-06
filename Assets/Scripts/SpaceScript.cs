using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceScript : MonoBehaviour
{
    public int id;
    public int icon;
    //public int iconEdited;
    public bool hasIcon = false;
    public bool redTile = false;
    public PlayerScript playerScript;
    public GameObject[] iconList;
    public Placeables placeables;
    public TheGame theGame;
    //public Color color;
    public Renderer rd;
    // Start is called before the first frame update
    void Start()
    {
        theGame = GameObject.Find("GameStuff").GetComponent<TheGame>();
        placeables = GameObject.Find("Placeable").GetComponent<Placeables>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        if (theGame.gameLevel == 3 && Mathf.Floor(id / 9f) == id / 9f && id >= 45)
        {
            RedTile();
        }
        if (theGame.gameLevel == 6)
        {
            RedTiles();
        }
        //RecreateIcon();
    }

    // Update is called once per frame
    void Update()
    {
        icon = theGame.grid[id];
        if (icon >= 1 && !hasIcon)
        {
            GameObject createIcon = Instantiate(iconList[icon - 1], transform.position - Vector3.forward / 105, Quaternion.identity);
            if (icon == 1)
            {
                createIcon.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (icon == 2)
            {
                createIcon.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (icon == 3)
            {
                createIcon.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (icon == 4)
            {
                createIcon.transform.rotation = Quaternion.Euler(0, 0, 270);
            }
            if (createIcon.TryGetComponent<IconScript>(out IconScript cmpt))
            {
                cmpt.id = this.id;
                cmpt.iconEdited = this.theGame.grid[id];
            }
            hasIcon = true;
        }
        if (icon == 0)
        {
            hasIcon = false;
        }
    }
    //void RecreateIcon()
    //{
    //    icon = theGame.grid[id];
    //    if (icon >= 1)
    //    {
    //        GameObject createIcon = Instantiate(iconList[icon - 1], transform.position - Vector3.forward / 105, Quaternion.identity);
    //        if (icon == 1)
    //        {
    //            createIcon.transform.rotation = Quaternion.Euler(0, 0, 0);
    //        }
    //        else if (icon == 2)
    //        {
    //            createIcon.transform.rotation = Quaternion.Euler(0, 0, 180);
    //        }
    //        else if (icon == 3)
    //        {
    //            createIcon.transform.rotation = Quaternion.Euler(0, 0, 90);
    //        }
    //        else if (icon == 4)
    //        {
    //            createIcon.transform.rotation = Quaternion.Euler(0, 0, 270);
    //        }
    //    }
    //}
    public void OnMouseDown()
    {
        if (theGame.spacesRemaining[placeables.sel - 1] >= 1 && placeables.sel >= 1 && theGame.grid[id] <= 7 && !redTile && !playerScript.moving)
        {
            theGame.spacesRemaining[placeables.sel - 1] -= 1;
            theGame.grid[id] = placeables.sel - 1;
            //theGame.CreateGrid();
            theGame.UpdateBottomText();
            //RecreateIcon();
            hasIcon = false;
        }
    }
    public void RedTiles()
    {
        if (id >= 20 && id <= 24)
        {
            RedTile();
        }
        if (id >= 29 && id <= 33)
        {
            RedTile();
        }
        if (id >= 38 && id <= 42)
        {
            RedTile();
        }
        if (id >= 47 && id <= 51)
        {
            RedTile();
        }
        if (id >= 56 && id <= 60)
        {
            RedTile();
        }
    }
    public void RedTile()
    {
        rd.material.color = new Color(1f, 155f / 255f, 155f / 255f, 1f);
        redTile = true;
    }
    public void DeleteGrid()
    {
        Destroy(this.gameObject);
    }
}
