using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public Text countText;
    public string stoneType = "";

    void Start()
    {
        SetStoneText();
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
}
