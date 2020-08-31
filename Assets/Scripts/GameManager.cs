using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    private GameObject player;
    private Health playerHealth;
    public int monsterKill = 0;
    
    public List<GameObject> spawnerList;

    private CanvasManager canvasManager;

    void Start()
    {
        canvasManager = GameObject.Find("Canvas").GetComponent<CanvasManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Health>();
        
        StartCoroutine("isGameOver");
        StartCoroutine("commandsTipsDisplay");
    }

    void Update(){
        HealthUpdate();
        if(Input.GetKeyDown(KeyCode.Escape)){
            canvasManager.commandsTips.SetActive(false);
        }
    }

    private IEnumerator isGameOver()
    {
        yield return new WaitForSeconds(0.1f);
        if(player == null){
            canvasManager.gameOverObj.SetActive(true);
            StopCoroutine("isGameOver");
        } else {
            StartCoroutine("isGameOver");
        }
    }

    private IEnumerator commandsTipsDisplay()
    {
        yield return new WaitForSeconds(8f);
        canvasManager.commandsTips.SetActive(false);
    }

    public void MonsterCountKill(){ 
        this.monsterKill ++;
        canvasManager.countText.text = "Monsters Killed: " + monsterKill;
    }

    public void HealthUpdate(){
        canvasManager.healthBar.fillAmount = playerHealth.getActualHealth()/100;
    }
}
