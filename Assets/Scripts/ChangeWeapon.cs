using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject actualWeapon;
    public GameObject weapon1;
    public GameObject weapon2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUpFireStone"))
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
            actualWeapon = weapon1;
            other.gameObject.SetActive(false);
            
        }

        if (other.gameObject.CompareTag("PickUpWaterStone"))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
            actualWeapon = weapon2;
            other.gameObject.SetActive(false);
            
        }
    }
}
