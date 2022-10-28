using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPad : MonoBehaviour
{
    Rigidbody RB;

    public float jumpHeightY = 9f;
    public float moveDistanceX = 5f;
    public float moveDistanceZ;

    bool jumpForward;

    bool jumpBackward;

    float bufferTime = 0;

    private void FixedUpdate()
    {
       if (Input.GetKey(KeyCode.Q))
        {
            jumpForward = true;
        }

       if (Input.GetKey(KeyCode.W))
        {
            jumpBackward = true;
        }

       if (jumpForward)
       {
           RB.velocity = new Vector3(moveDistanceX, jumpHeightY, moveDistanceZ);
           jumpForward = false;
       }

       if (jumpBackward)
        {
            RB.velocity = new Vector3(0f, 9f, 5f);
            jumpBackward = false;
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
                bufferTime = 0.1f;
            }
        }
    }
}


