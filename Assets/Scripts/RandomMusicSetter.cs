using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusicSetter : MonoBehaviour
{
    public List<AudioClip> musicList;
    public AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicList[Random.Range(0,musicList.Count)];
        audioSource.Play();
    }
}
