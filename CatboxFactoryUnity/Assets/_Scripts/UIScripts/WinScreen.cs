using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject screen;

    private void Start()
    {
        screen = GameObject.FindGameObjectWithTag("Wins");
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

