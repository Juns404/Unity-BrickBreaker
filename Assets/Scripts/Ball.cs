using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Manager manager;
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
        CheckInput();
    }
    private void CheckInput()
    {
        if (!launched)
        {
            MovementBall();
        }
        if (Input.GetKeyDown(KeyCode.B) && !launched)
        {
            Launch();
        }
    }
    private void MovementBall()
    {
        movement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }
    private void Launch()
    {
        launched = true;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(x, 1).normalized * speed;
    }
    public void Reset(Vector2 pos)
    {
        launched = false;
        rb.velocity = Vector2.zero;
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Goal")
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Debug.Log("Ball Desrtoy.");
    }
}
