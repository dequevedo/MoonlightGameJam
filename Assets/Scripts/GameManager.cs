﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    private GameObject player;
    public GameObject gameOverPrefab;
    public GameObject canvas;
    public int monsterKill = 0;
    public Text countText;

    public List<GameObject> spawnerList;

    void Start()
    {
        countText = GameObject.FindGameObjectWithTag("monsterCount").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.Find("Canvas");
        StartCoroutine("isGameOver");
    }

    private IEnumerator isGameOver()
    {
        yield return new WaitForSeconds(0.1f);
        if(player == null){
            Instantiate(gameOverPrefab, canvas.transform);
            StopCoroutine("isGameOver");
        } else {
            StartCoroutine("isGameOver");
        }
    }

    public void MonsterCountKill(){ 
        this.monsterKill ++;
        countText.text = "Monstros mortos: " + monsterKill;
    }
}
