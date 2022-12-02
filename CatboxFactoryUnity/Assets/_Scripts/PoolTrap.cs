using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTrap : MonoBehaviour
{

    private GameObject screen;
    private GameObject Go;
    private BoxCollider coll;
    private float timer = 0.5f;
    private bool playerDetected;
    private bool somethingDetected;
    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.FindGameObjectWithTag("LoseManager");
        somethingDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDetected)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if(timer <= 0)
            {
                //ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
                //em.enabled = true;
                Go.GetComponent<Rigidbody>().velocity = Vector3.zero;
                Go.GetComponent<PlayerController>().gameSpeed = 0f;
                Go.GetComponent<PlayerController>().isTriggered = false;
                coll = Go.GetComponent<BoxCollider>();
                coll.enabled = false;
                screen.GetComponent<LooseControllerManager>().shouldLose = true;
                Go = null;
                coll = null;
                playerDetected = false;
                timer = 0.5f;
            }
            
        }
        if(somethingDetected)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if(timer <= 0)
            {
                //ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
                //em.enabled = true;
                Go.GetComponent<Rigidbody>().velocity = Vector3.zero;
                coll = Go.GetComponent<BoxCollider>();
                coll.enabled = false;
                Go = null;
                coll = null;
                somethingDetected = false;
                timer = 0.5f;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" )
        {
            Go = other.gameObject;
            playerDetected = true;
        }
        if(other.tag == "Box" )
        {
            Go = other.gameObject;
            somethingDetected = true;
        }
    }
}
