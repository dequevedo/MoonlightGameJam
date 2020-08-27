using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float actualHealth = 100;

    public SpriteRenderer healthBar;

    public float speed = 10;

    public GameObject playerDeathFX;
    void Update()
    {
        Vector3 movement = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        ).normalized * Time.deltaTime * speed;
        
        transform.Translate(movement);
    }

    public void takeDamage(float damage){
        actualHealth -= damage;
        actualHealth = Mathf.Clamp(actualHealth, 0, maxHealth);
        healthBar.size = new Vector2(actualHealth/100, 0.18f);

        if(actualHealth <= 0){
            Instantiate(playerDeathFX, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
