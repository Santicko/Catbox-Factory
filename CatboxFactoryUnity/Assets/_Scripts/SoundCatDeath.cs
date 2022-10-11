using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCatDeath : MonoBehaviour
{

    public AudioClip soundCatDeath;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = soundCatDeath;
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
    }
}
