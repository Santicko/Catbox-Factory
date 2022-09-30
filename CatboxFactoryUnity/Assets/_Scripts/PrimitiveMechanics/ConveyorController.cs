using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    // my public parts
    public float movSpeedX = 1f;
    public float movSpeedZ = 0f;
    public float movSpeedY = 0f;
    public float gameSpeed = 1;

    // my private parts
    private GameObject objectOnTop;

    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            objectOnTop = other.gameObject;
            Rigidbody obj = objectOnTop.GetComponent<Rigidbody>();
            obj.velocity = new Vector3(obj.velocity.x + movSpeedX, 0, obj.velocity.z + movSpeedZ).normalized * gameSpeed;
        }
    }
}
