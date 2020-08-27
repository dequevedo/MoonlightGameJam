using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage = 5;
    public GameObject hitEffect;
    private Vector2 moveDirection;
    private Rigidbody2D rigidbody;

    void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + transform.right * Time.fixedDeltaTime * speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        if(col.transform.tag == "Player"){
            col.gameObject.GetComponent<Player>().takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
