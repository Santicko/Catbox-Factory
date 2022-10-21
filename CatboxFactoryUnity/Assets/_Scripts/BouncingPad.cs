using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPad : MonoBehaviour
{
    Rigidbody RB;
    private GameObject objectOnTop;

    public float jumpHeightY;
    public float moveDistanceX;
    public float moveDistanceZ;

    private float jumpHeight;
    private float moveDistance;

    bool jump;

    float bufferTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        jumpHeight = jumpHeightY;
        moveDistance = moveDistanceX;
    }

    private void FixedUpdate()
    {
       if (jump)
       {
           RB.velocity = new Vector3(moveDistance, jumpHeight, moveDistanceZ);
           jump = false;
       }

    }


    private void OnTriggerEnter(Collider other)
    {

        if (bufferTime > 0)
        {
            bufferTime -= Time.deltaTime;
        }
        else
        {
            if (other.tag == "Player" || other.tag == "Box")
            {
                RB = other.GetComponent<Rigidbody>();
                jump = true;
                bufferTime = 0.1f;
            }
        }
    }
}


