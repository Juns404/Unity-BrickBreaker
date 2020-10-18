using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Ball initialBall, prefabBall;
    public Brick initialBrick, prefabBrick;
    public Paddle initialPaddle, prefabPaddle;
    public GameObject padfab;
    public bool gameRunning;
    public int rows, columns;
    public float space;
    //public GameObject ball, brick;
    public List<GameObject> bricksList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        BallManager();
        PaddleManager();
        BrickManager();
        //prefabBrick = GetComponent <
        //brick.GetComponent<b>;
    }
    void init()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void BallManager()
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

    private void BrickManager()
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
            }
        }
    }
    private void PaddleManager()
    {
        Vector2 spawnpos = padfab.gameObject.transform.position;
        GameObject padd = Instantiate(padfab, spawnpos, Quaternion.identity);
    }

    private void Reset()
    {

    }
}
