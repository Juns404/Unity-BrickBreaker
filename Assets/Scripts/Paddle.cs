using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    Rigidbody2D rb;
    float movement;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementPaddle();
    }
    void MovementPaddle()
    {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        }
    }
}
