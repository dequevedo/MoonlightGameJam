using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float actualHealth = 100;
    public int monsterKill = 0;
    public Text countText;
    
    public GameObject deathFX;

    //public SpriteRenderer healthBar;

    void Start() {
        countText = GameObject.FindGameObjectWithTag("monsterCount").GetComponent<Text>();
    }

    public void takeDamage(float damage)
    {
        actualHealth -= damage;
        actualHealth = Mathf.Clamp(actualHealth, 0, maxHealth);
        //healthBar.size = new Vector2(actualHealth / 100, 0.18f);

        if (actualHealth <= 0)
        {
            Instantiate(deathFX, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            MonsterCountKill();
        }
    }
    void MonsterCountKill(){ 
        monsterKill = monsterKill+1;
        countText.text = "Monstros mortos: " + monsterKill;
    }
}
