using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    public float speed = 10;
    

    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 movement = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        ).normalized * Time.deltaTime * speed;
        
        transform.Translate(movement);

    } 

   

}
