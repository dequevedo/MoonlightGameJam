using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject bulletPrefab;

    public float bulletSpeed = 30.0f;

    public Vector3 target;

    public GameObject weapon1;
    public GameObject weapon2;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);

        Vector3 crosshairDirection = target - transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            fireBullet(crosshairDirection);
        }

    }

    void fireBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.right = direction;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUpFireStone"))
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
            bulletPrefab = weapon1;
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("PickUpWaterStone"))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
            bulletPrefab = weapon2;
            other.gameObject.SetActive(false);

        }
    }

}
