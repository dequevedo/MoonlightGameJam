using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public Text countText;
    public string stoneType = "";
    public RuneSpawner runeSpawnerFire;
    public RuneSpawner runeSpawnerWater;

    void Start()
    {
        SetStoneText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUpFireStone"))
        {
            //other.gameObject.SetActive(false);

            stoneType = "Fire";
            SetStoneText();
            runeSpawnerFire.createRune();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("PickUpWaterStone"))
        {
            //other.gameObject.SetActive(false);

            stoneType = "Water";
            SetStoneText();
            runeSpawnerWater.createRune();
            Destroy(other.gameObject);
        }
    }

    void SetStoneText()
    {
        countText.text = "Pedra: " + stoneType;
    }
}
