using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float actualHealth = 100;

    public SpriteRenderer healthBar;

    public float speed = 10;
    public Text countText;
    public string stoneType = "";
    public GameObject crosshair;


    public GameObject playerDeathFX;

    void Start()
    {
        SetStoneText();
    }

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

    public void takeDamage(float damage){
        actualHealth -= damage;
        actualHealth = Mathf.Clamp(actualHealth, 0, maxHealth);
        healthBar.size = new Vector2(actualHealth/100, 0.18f);

        if(actualHealth <= 0){
            Instantiate(playerDeathFX, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUpFireStone"))
        {   
            other.gameObject.SetActive(false);
            stoneType = "Fire";
            SetStoneText();
        }

        if (other.gameObject.CompareTag("PickUpWaterStone"))
        {
            other.gameObject.SetActive(false);
            stoneType = "Water";
            SetStoneText();
        }
    }

    void SetStoneText()
    {
        countText.text = "Pedra: " + stoneType;
    }

    void Aim()
    {
  
    }
}
