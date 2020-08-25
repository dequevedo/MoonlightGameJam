using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public GameObject player;
    private Vector2 moveDirection;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.Translate(new Vector2(
            moveDirection.x * Time.deltaTime * speed, 
            moveDirection.y * Time.deltaTime * speed));
    }

    public void setMoveDirection(Vector2 direction){
        moveDirection = direction;
    }
}
