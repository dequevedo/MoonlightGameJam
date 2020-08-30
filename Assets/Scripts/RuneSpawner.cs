using System.Collections;
using UnityEngine;

public class RuneSpawner : MonoBehaviour
{
    public GameObject rune;
    public GameObject spawnFX;

    void Start()
    {
        createRune();
    }

    public void createRune()
    {
        StartCoroutine("SpawnNewRuneCoroutine");
    }

    private IEnumerator SpawnNewRuneCoroutine()
    {
        yield return new WaitForSeconds(1);
        Instantiate(spawnFX, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        newRune();
    }

    public void newRune()
    {
        GameObject runeInstance = Instantiate(rune, transform.position, Quaternion.identity);
        //runeInstance.GetComponent<PickUpItem>().runeSpawnerFire = this;

    }
}
