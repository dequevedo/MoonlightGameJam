using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public GameObject hitEffect;
    private Vector2 moveDirection;

    void Update()
    {
        transform.Translate(new Vector2(
            moveDirection.x * Time.deltaTime * speed, 
            moveDirection.y * Time.deltaTime * speed));
    }

    public void setMoveDirection(Vector2 direction){
        moveDirection = direction.normalized;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
