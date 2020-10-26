using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Ball initialBall, prefabBall;
    public Brick initialBrick, prefabBrick;
    public Paddle initialPaddle, prefabPaddle;
    public GameObject padfab, balfab;
    public bool gameRunning;
    public int rows, columns;
    public float space;
    //public GameObject ball, brick;
    public List<GameObject> bricksList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        // ManagerBrickDestroy();
        ManagerBallSpawn();
        ManagerPaddleSpawn();
        ManagerBrickSpawn();
        //prefabBrick = GetComponent <
        //brick.GetComponent<b>;
    }
    void init()
    {
        Debug.Log("init function.");
    }

    // Update is called once per frame
    void Update()
    {
        if (initialBall == null && gameRunning)
        {
            Debug.Log("Detected ball destroyed.");
            Reset();
        }
    }
    private void ManagerBallSpawn()
    {
        //Ball spawn, once.
        //if (!gameRunning)
        //{
        Vector3 paddlePos = prefabPaddle.gameObject.transform.position;
        Vector3 ballPos = new Vector3(paddlePos.x, paddlePos.y + .2f);
        initialBall = Instantiate(prefabBall, ballPos, Quaternion.identity);
        gameRunning = true;
        //}
    }

    private void ManagerBrickSpawn()
    {
        //create rows and cols for bricks
        for (int y = 0; y < rows; y++)
        {
            Vector2 brickPos = prefabBrick.gameObject.transform.position;
            brickPos.y += y;
            for (int x = 0; x < columns; x++)
            {
                initialBrick = Instantiate(prefabBrick, brickPos, Quaternion.identity);
                brickPos.x += space;
                bricksList.Add(initialBrick.gameObject);
                //Debug.Log(bricksList.Count);
            }
        }
    }

    private void ManagerBrickDestroy()
    {
        foreach (GameObject brick in bricksList)
        {
            Destroy(brick);
            Debug.Log("ManagerBrickDestroy.");
        }
        bricksList.Clear();
    }

    private void ManagerPaddleSpawn()
    {
        Vector2 spawnpos = padfab.gameObject.transform.position;
        GameObject padd = Instantiate(padfab, spawnpos, Quaternion.identity);
        //Debug.Log(padd);
    }

    public void Reset()
    {
        Debug.Log("Manager Reset.");
        ManagerBrickDestroy();
        // Remake Bricks and Ball
        gameRunning = false;
    }
}
