using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitterController : MonoBehaviour
{
    // my public parts
    public float movSpeedX = 1f;
    public float movSpeedZ = 0f;
    public float movSpeedY = 0f;

    // my private parts
    private GameObject objectOnTop;

    void ToggleDir()
    {
        if (movSpeedX != 0)
        {
            movSpeedX = movSpeedX * -1;
        }
        if (movSpeedY != 0)
        {
            movSpeedY = movSpeedY * -1;
        }
        if (movSpeedZ != 0)
        {
            movSpeedZ = movSpeedZ * -1;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            objectOnTop = other.gameObject;
            Rigidbody obj = objectOnTop.GetComponent<Rigidbody>();
            obj.velocity = new Vector3(obj.velocity.x + movSpeedX, obj.velocity.y + movSpeedY, obj.velocity.z + movSpeedZ).normalized;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            ToggleDir();
        }
    }
}
