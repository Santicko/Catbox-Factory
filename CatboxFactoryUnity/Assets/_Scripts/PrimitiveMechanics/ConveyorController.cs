using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    // my public parts
    public float movSpeedX = 1f;
    public float movSpeedZ = 0f;
    public float movSpeedY = 0f;
    public float gameSpeed = 1f;

    // my private parts
    private GameObject objectOnTop;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            objectOnTop = other.gameObject;
            Rigidbody obj = objectOnTop.GetComponent<Rigidbody>();
            obj.velocity = new Vector3(obj.velocity.x + movSpeedX, obj.velocity.y + movSpeedY, obj.velocity.z + movSpeedZ).normalized * gameSpeed;
        }
    }
}
