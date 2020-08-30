using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public float dashDistance = 12000;
    private Vector3 movement;
    private Rigidbody2D rb;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if (Input.GetMouseButtonDown(1))
        {
            Dash();
        }
    }
    
    void FixedUpdate() {
        Move();
    }

    public void Move()
    {
        movement = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        ).normalized * Time.deltaTime * speed;

        rb.MovePosition(transform.position + movement);
    }

    void Dash(){
        rb.AddRelativeForce(movement * dashDistance);
    }
}
