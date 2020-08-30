using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float dashDistance = 12000;
    private Vector3 movement;
    private Rigidbody2D rb;
    public Animator anim;

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
        float H = Input.GetAxisRaw("Horizontal");
        float V = Input.GetAxisRaw("Vertical");

        movement = new Vector3(H, V, 0).normalized * Time.deltaTime * speed;

        if (H != 0)
        {
            transform.localScale = new Vector3(-(H/4), transform.localScale.y, transform.localScale.z);
        }

        


        rb.MovePosition(transform.position + movement);

        if (movement.magnitude > 0){
            anim.SetBool("isRunning", true);
        } else { 
            anim.SetBool("isRunning", false);
        }


    }

    void Dash(){
        rb.AddRelativeForce(movement * dashDistance);
    }
}
