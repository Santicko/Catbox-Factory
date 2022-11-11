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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            objectOnTop = other.gameObject;
            Rigidbody obj = objectOnTop.GetComponent<Rigidbody>();
            obj.velocity = transform.root.right * gameSpeed;
        }
    }
}
