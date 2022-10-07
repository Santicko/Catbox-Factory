using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    public GameObject screen;
    private bool danger;

    private void Start()
    {
        screen = GameObject.FindGameObjectWithTag("LoseManager");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player" && danger)
        {
            screen.GetComponent<LooseControllerManager>().shouldLose = true;
        }
    }

    public void Loose()
    {
        danger = true;
    }
    public void NotLoose()
    {
        danger = false;
    }
}
