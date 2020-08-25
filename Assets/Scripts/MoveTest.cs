using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public float speed = 10;
    void Update()
    {
        Vector3 movement = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        ).normalized * Time.deltaTime * speed;
        
        transform.Translate(movement);
    }
}
