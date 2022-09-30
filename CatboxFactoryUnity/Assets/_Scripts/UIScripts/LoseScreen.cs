using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    public GameObject screen;

    private void Start()
    {
        screen = GameObject.FindGameObjectWithTag("LoseManager");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            screen.GetComponent<LooseControllerManager>().shouldLose = true;
        }
    }
}
