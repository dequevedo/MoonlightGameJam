using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    private GameObject player;
    public GameObject gameOverPrefab;
    public GameObject canvas;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.Find("Canvas");
        StartCoroutine("isGameOver");
    }

    void Update()
    {

    }

    private IEnumerator isGameOver()
    {
        yield return new WaitForSeconds(0.1f);
        if(!player.activeInHierarchy){
            Instantiate(gameOverPrefab, canvas.transform);
            StopCoroutine("isGameOver");
        } else {
            StartCoroutine("isGameOver");
        }
    }


}
