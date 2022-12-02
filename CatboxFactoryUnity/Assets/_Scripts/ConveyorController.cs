using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    public float gameSpeed = 1f;

    // my private parts
    private GameObject objectOnTop;

    void Start()
    {
        gameSpeed = transform.root.GetComponent<ConveyorControllerForParent>().speed;
    }

/*
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            objectOnTop = other.gameObject;
            Rigidbody obj = objectOnTop.GetComponent<Rigidbody>();
            obj.velocity = transform.right * -1 * gameSpeed;
        }
    }*/
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.GetComponent<PlayerController>().isTriggered != true)
            {
                other.GetComponent<PlayerController>().isTriggered = true;
                other.GetComponent<PlayerController>().gameSpeed = gameSpeed;
                other.transform.rotation = transform.rotation;
            }
            other.GetComponent<PlayerController>().gameSpeed = gameSpeed;
        }
        if(other.tag == "Box")
        {
            objectOnTop = other.gameObject;
            Rigidbody obj = objectOnTop.GetComponent<Rigidbody>();
            obj.velocity = transform.right * -1 * gameSpeed;
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            other.GetComponent<PlayerController>().isTriggered = true;
            other.GetComponent<PlayerController>().gameSpeed = gameSpeed;
            other.transform.rotation = transform.rotation;
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().isTriggered = false;
        }
    }
}
