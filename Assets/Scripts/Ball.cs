using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    private bool launched;
    private float speed = 5, movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        launched = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovementBall();
    }
    private void MovementBall()
    {
        if (!launched)
        {
            movement = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        }
    }
}
