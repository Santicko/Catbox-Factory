using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    public GameObject screen;

    private void Start()
    {
        screen = GameObject.FindGameObjectWithTag("Lose");
        screen.SetActive(false);

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            screen.SetActive(true);
        }
    }
}
