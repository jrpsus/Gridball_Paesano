using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TheGame : MonoBehaviour
{
    public int[] grid;
    public int[] spacesRemaining;
    public GameObject[] icons;
    public GameObject[] walls;
    public Text[] texts;
    public int lives;
    public int gameLevel;
    public int id;
    public float goalMove = 0;
    public PlayerScript playerScript;
    public SpaceScript spaceScript;
    public GameObject gridObject;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        NextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLevel == 6)
        {
            goalMove += Time.deltaTime;
            if (goalMove >= 3f)
            {
                if (grid[30] == 8)
                {
                    PlaceThis(0, 3, 3);
                    PlaceThis(8, 5, 3);
                }
                else if (grid[32] == 8)
                {
                    PlaceThis(0, 5, 3);
                    PlaceThis(8, 5, 5);
                }
                else if (grid[50] == 8)
                {
                    PlaceThis(0, 5, 5);
                    PlaceThis(8, 3, 5);
                }
                else
                {
                    PlaceThis(0, 3, 5);
                    PlaceThis(8, 3, 3);
                }
                goalMove = -0.1f;
            }
        }
    }
    public void ResetLevel()
    {
        if (playerScript.moving)
        {
            lives -= 1;
            playerScript.moving = false;
        }
        gameLevel -= 1;
        NextLevel();
    }
    public void NextLevel()
    {
        gameLevel += 1;
        CreateGrid();
        LevelData(gameLevel);
        UpdateBottomText();
        playerScript.Respawn();
    }
    public void CreateGrid()
    {
        icons = GameObject.FindGameObjectsWithTag("Icon");
        walls = GameObject.FindGameObjectsWithTag("Walls");
        //while (icons.Length >= 1)
        //{
        //    Destroy(icons[0].gameObject);
        //    icons = GameObject.FindGameObjectsWithTag("Icon");
        //}
        //while (walls.Length >= 1)
        //{
        //    Destroy(walls[0].gameObject);
        //    walls = GameObject.FindGameObjectsWithTag("Walls");
        //}
        for (int i = 0; i < icons.Length; i += 1)
        {
            Destroy(icons[i].gameObject);
        }
        for (int i = 0; i < walls.Length; i += 1)
        {
            Destroy(walls[i].gameObject);
        }
        id = 0;
        transform.position = new Vector3(-3, 4, 0);
        if (gameLevel <= 6 && lives >= 1)
        {
            for (int i = 0; i < 9; i += 1)
            {
                for (int i2 = 0; i2 < 9; i2 += 1)
                {
                    GameObject gridSpace = Instantiate(gridObject, transform.position, Quaternion.identity);
                    if (gridSpace.TryGetComponent<SpaceScript>(out SpaceScript cmpt))
                    {
                        cmpt.id = id;
                        grid[id] = 0;
                        id += 1;
                    }
                    transform.position += Vector3.right;
                }
                transform.position = new Vector3(-3, transform.position.y - 1, 0);
            }
        }
    }

    //0 blank
    //1 right
    //2 left
    //3 up
    //4 down
    //5 trampoline
    //6 wall
    //7 water
    //8 goal
    void LevelData(int lvl)
    {
        for (int i = 0; i < 7; i += 1)
        {
            spacesRemaining[i] = 0;
        }
        if (lvl == 1)
        {
            PlaceThis(6, 2, 2);
            PlaceThis(6, 2, 3);
            PlaceThis(6, 6, 2);
            PlaceThis(6, 6, 3);
            PlaceThis(6, 3, 4);
            PlaceThis(6, 4, 4);
            PlaceThis(6, 5, 4);
            PlaceThis(1, 1, 0);
            PlaceThis(2, 7, 0);
            PlaceThis(8, 4, 3);
            spacesRemaining[3] = 1;
            spacesRemaining[4] = 1;
        }
        if (lvl == 2)
        {
            PlaceThis(3, 1, 7);
            PlaceThis(4, 2, 2);
            PlaceThis(3, 3, 4);
            PlaceThis(4, 4, 3);
            PlaceThis(3, 5, 6);
            PlaceThis(4, 6, 8);
            PlaceThis(6, 8, 0);
            PlaceThis(6, 8, 1);
            PlaceThis(6, 8, 2);
            PlaceThis(6, 7, 0);
            PlaceThis(6, 6, 0);
            PlaceThis(4, 7, 3);
            PlaceThis(2, 5, 1);
            PlaceThis(6, 5, 2);
            PlaceThis(8, 7, 1);
            spacesRemaining[0] = 1;
            spacesRemaining[1] = 1;
            spacesRemaining[2] = 1;
        }
        if (lvl == 3)
        {
            PlaceThis(6, 0, 4);
            PlaceThis(6, 1, 4);
            PlaceThis(6, 2, 4);
            PlaceThis(6, 3, 4);
            PlaceThis(6, 2, 5);
            PlaceThis(6, 2, 6);
            PlaceThis(6, 2, 7);
            PlaceThis(6, 2, 8);
            PlaceThis(5, 3, 5);
            PlaceThis(8, 2, 0);
            PlaceThis(1, 0, 0);
            PlaceThis(2, 3, 3);
            spacesRemaining[3] = 2;
            spacesRemaining[5] = 1;
            spacesRemaining[6] = 2;
        }
        if (lvl == 4)
        {
            PlaceThis(5, 2, 6);
            PlaceThis(7, 5, 6);
            PlaceThis(7, 5, 7);
            PlaceThis(7, 4, 7);
            PlaceThis(7, 3, 7);
            PlaceThis(7, 5, 8);
            PlaceThis(7, 4, 8);
            PlaceThis(7, 3, 8);
            PlaceThis(6, 3, 6);
            for (int i = 0; i < 6; i += 1)
            {
                PlaceThis(7, 2, i);
                PlaceThis(7, 1, i);
                PlaceThis(7, 0, i);
                PlaceThis(7, i + 3, 4);
                PlaceThis(7, i + 3, 5);
            }
            for (int i = 0; i < 9; i += 1)
            {
                PlaceThis(7, i, 0);
                PlaceThis(7, i, 1);
            }
            PlaceThis(8, 4, 6);
            PlaceThis(2, 8, 2);
            spacesRemaining[0] = 4;
            spacesRemaining[3] = 1;
            spacesRemaining[4] = 1;
        }
        if (lvl == 5)
        {
            for (int i = 0; i < 9; i += 1)
            {
                if (i != 6)
                {
                    PlaceThis(7, i, 5);
                }
                //if (i != 1)
                //{
                    PlaceThis(7, i, 3);
                //}
                
            }
            PlaceThis(7, 1, 6);
            PlaceThis(3, 1, 8);
            PlaceThis(2, 6, 8);
            PlaceThis(6, 3, 0);
            PlaceThis(6, 3, 1);
            PlaceThis(6, 3, 2);
            PlaceThis(3, 4, 2);
            PlaceThis(4, 8, 0);
            PlaceThis(5, 8, 2);
            PlaceThis(8, 8, 8);
            PlaceThis(6, 7, 8);
            spacesRemaining[1] = 2;
            spacesRemaining[4] = 1;
            spacesRemaining[5] = 2;
            spacesRemaining[6] = 1;
        }
        if (lvl == 6)
        {
            PlaceThis(7, 4, 4);
            PlaceThis(6, 2, 3);
            PlaceThis(7, 3, 2);
            PlaceThis(7, 2, 5);
            PlaceThis(6, 3, 6);
            PlaceThis(7, 6, 3);
            PlaceThis(6, 5, 2);
            PlaceThis(6, 6, 5);
            PlaceThis(7, 5, 6);
            PlaceThis(2, 1, 6);
            PlaceThis(4, 1, 0);
            PlaceThis(1, 8, 3);
            PlaceThis(6, 0, 5);
            PlaceThis(6, 3, 1);
            PlaceThis(6, 5, 1);
            PlaceThis(6, 3, 8);
            PlaceThis(6, 5, 7);
            PlaceThis(3, 7, 8);
            PlaceThis(3, 0, 2);
            PlaceThis(4, 6, 1);
            PlaceThis(1, 4, 8);
            PlaceThis(2, 7, 4);
            for (int i = 0; i < 5; i += 1)
            {
                spacesRemaining[i + 1] = 1;
            }
        }
    }
    //lvl 1: 1 up 1 down
    //lvl 2: 1 blank 1 left 1 right
    //lvl 3: 1 trampoline 2 wall 2 up
    //lvl 4: 4 blank 1 up 1 down
    //lvl 5: 1 wall 2 trampoline 1 down 2 right
    //lvl 6: 1 left 1 right 1 up 1 down 1 trampoline 1 wall
    public void UpdateBottomText()
    {
        texts[0].text = "LEVEL: " + gameLevel;
        texts[1].text = "LIVES: " + lives;
        for (int i = 0; i < 7; i += 1)
        {
            texts[i + 2].text = "x " + spacesRemaining[i];
        }
    }
    void PlaceThis(int type, int x, int y)
    {
        grid[(y * 9 + x)] = type;
    }
}
