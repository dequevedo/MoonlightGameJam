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
        yield return new WaitForSeconds(5f);
        for(int i = 0; i < 400; i++){
            yield return new WaitForSeconds(0.01f);
            canvasManager.commandsTips.transform.Translate(new Vector3(0,-0.7f,0)); //Mover a tela de dicas de comandos para baixo
        }
        canvasManager.commandsTips.SetActive(false);
    }

    public void MonsterCountKill(){ 
        this.monsterKill ++;
        canvasManager.countText.text = "Monstros mortos: " + monsterKill;
    }

    public void HealthUpdate(){
        canvasManager.healthBar.fillAmount = playerHealth.getActualHealth()/100;
    }
}
