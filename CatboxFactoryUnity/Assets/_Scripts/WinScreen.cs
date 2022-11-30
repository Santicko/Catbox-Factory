using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject screen;
    private bool didWin;
    private float didWinTimer;
    private int playerCount;
    private int catsSaved;

    private void Start()
    {
        screen = GameObject.FindGameObjectWithTag("Wins");
        screen.SetActive(false);
        playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
    }

    private void Update()
    {
        if (didWin)
        {
            didWinTimer += Time.deltaTime;
            if (didWinTimer >= 2f)
            {
                screen.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            catsSaved++;
            if (playerCount == catsSaved)
            {
                didWin = true;
                GetComponent<ParticleSystem>().Play();
                ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
                em.enabled = true;
            }
        }
    }
}

