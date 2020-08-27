using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWall : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D other) {
        print("colidindo");
    }


    void Update(){
        
    }
}
