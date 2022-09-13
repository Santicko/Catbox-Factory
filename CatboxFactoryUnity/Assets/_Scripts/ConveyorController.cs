using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    // my public parts
    public float movSpeedX = 1f;
    public float movSpeedY = 0f;
    public bool canImove = true;
    public float howLong = 5f;

    // my private parts
    private GameObject objectOnTop;
    public float activeTimer;
    private bool objOnTop;

    void Start()
    {
        activeTimer = howLong;
        objOnTop = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            objectOnTop = other.gameObject;
            objOnTop = true;
        }
        if (canImove && objOnTop)
        {
            if (activeTimer > 0)
            {
                //activeTimer -= Time.deltaTime/10;
                objectOnTop.GetComponent<Rigidbody>().velocity = new Vector3(movSpeedX, 0, movSpeedY).normalized;
            }
            else
            {
                canImove = false;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            objOnTop = false;
        }
    }

    public void Activate()
    {
        canImove = true;
        activeTimer = howLong;
        return;
    }
}
