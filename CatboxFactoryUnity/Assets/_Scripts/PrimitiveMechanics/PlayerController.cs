using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    //private bool craneActivate;
    //public bool rotatingDone;

    void Start()
    {
        //craneActivate = false;
        //rotatingDone = false;
    }

    void Update()
    {

        //if (Input.GetKey(KeyCode.R))
        //{
        //    transform.position = new Vector3(-1.88f, 1.43f, -7.62f);
        //}

        /* if (Input.GetKeyDown(KeyCode.H) && craneActivate)
         {
             craneActivate = false;
             gameObject.AddComponent<BoxRisingMovement>();
             Destroy(GetComponent<Rigidbody>());
         }

         if (rotatingDone)
         {
             gameObject.AddComponent<Rigidbody>();
             GetComponent<Rigidbody>().freezeRotation = true;
             rotatingDone = false;
         }
     }

     private void OnTriggerEnter(Collider other)
     {
         if (other.tag == "Crane")
         {
             craneActivate = true;
         }
     }
     private void OnTriggerExit(Collider other)
     {
         if (other.tag == "Crane")
         {
             craneActivate = false;
         }
        */
    }

    public void DestroyRigidbody()
    {
        Destroy(GetComponent<Rigidbody>());
    }

    public void CreateRigidbody()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
    }
}
