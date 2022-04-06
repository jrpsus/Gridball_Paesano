using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public TheGame theGame;
    public bool moving = false;
    public bool jumping = false;
    public bool startDetecting = true;
    public float jumpForce;
    public float jumpScale = 1;
    public int id;
    public int prevId;
    public Vector3 xy;
    public float accel;
    bool pos;
    // Start is called before the first frame update
    void Start()
    {
        theGame = GameObject.Find("GameStuff").GetComponent<TheGame>();
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= -3)
        {
            startDetecting = true;
        }
        if (moving)
        {
            if (accel <= 2f)
            {
                accel += 1.5f * Time.deltaTime;
            }
            transform.position += xy * (accel + 2.5f) * Time.deltaTime;
            DetectSpace();
            if (transform.position.x <= -5.5)
            {
                theGame.ResetLevel();
            }
            if (transform.position.x >= 6)
            {
                theGame.ResetLevel();
            }
            if (transform.position.y <= -5)
            {
                theGame.ResetLevel();
            }
            if (transform.position.y >= 5)
            {
                theGame.ResetLevel();
            }
            if (theGame.grid[id] >= 1 && prevId != id && id >= 0 && id <= 81)
            {
                prevId = id;
                DetectSpaceType();
            }
        }
        if (jumping)
        {
            jumpForce -= 5 * Time.deltaTime;
            jumpScale += jumpForce * Time.deltaTime;
            transform.localScale = new Vector3(jumpScale, jumpScale, 1);
            if (transform.localScale.x <= 0.99)
            {
                transform.localScale = Vector3.one;
                jumping = false;
            }
        }
    }
    public void Respawn()
    {
        if (theGame.gameLevel == 5)
        {
            transform.position = new Vector3(-4f, 0f, -0.03f);
        }
        else
        {
            transform.position = new Vector3(-4f, -2f, -0.03f);
        }
        prevId = -1;
        xy = Vector3.right;
        startDetecting = false;
    }
    public void Launch()
    {
        accel = -0.1f;
        moving = true;
        xy = Vector3.right;
        id = -1;
        prevId = -1;
        startDetecting = false;
    }
    public void DetectSpace()
    {
        if (xy == Vector3.up)
        {
            pos = false;
        }
        else if (xy == Vector3.right)
        {
            pos = true;
        }
        else if (xy == Vector3.down)
        {
            pos = true;
        }
        else if (xy == Vector3.left)
        {
            pos = false;
        }
        if (startDetecting && transform.position.x >= -3.2 && transform.position.x <= 5.2 && transform.position.y >= -5.2 && transform.position.y <= 4.2)
        {
            if (pos)
            {
                id = (int)Mathf.Floor(transform.position.x + 3) + ((int)Mathf.Floor((transform.position.y * -1) + 4) * 9);
            }
            else
            {
                id = (int)Mathf.Ceil(transform.position.x + 3) + ((int)Mathf.Ceil((transform.position.y * -1) + 4) * 9);
            }
        }
    }
    public void DetectSpaceType()
    {
        if (!jumping && id >= 0 && id <= 80)
        {
            if (theGame.grid[id] == 8)
            {
                moving = false;
                //while (transform.position.z <= 1)
                //{
                //    transform.position += Vector3.forward * Time.deltaTime;
                //}
                if (theGame.gameLevel >= 3)
                {
                    theGame.lives += 1;
                }
                theGame.NextLevel();
                prevId = -1;
                xy = Vector3.right;
                theGame.UpdateBottomText();
            }
            if (theGame.grid[id] == 7)
            {
                moving = false;
                //while (transform.position.z <= 1)
                //{
                //    transform.position += Vector3.forward * Time.deltaTime;
                //}
                theGame.ResetLevel();
                prevId = -1;
                theGame.lives -= 1;
                xy = Vector3.right;
                theGame.UpdateBottomText();
            }
            if (theGame.grid[id] == 6)
            {
                xy *= -1;
            }
            if (theGame.grid[id] == 5)
            {
                jumpScale = 1f;
                jumpForce = 2f;
                jumping = true;
            }
            if (theGame.grid[id] == 4)
            {
                xy = Vector3.down;
            }
            if (theGame.grid[id] == 3)
            {
                xy = Vector3.up;
            }
            if (theGame.grid[id] == 2)
            {
                xy = Vector3.left;
            }
            if (theGame.grid[id] == 1)
            {
                xy = Vector3.right;
            }
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), -0.03f);
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls" && !jumping)
        {
            xy *= -1;
            prevId = -1;
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), -0.03f);
            //transform.position += xy * 2 * (accel + 2.5f) * Time.deltaTime;
        }
    }
}
