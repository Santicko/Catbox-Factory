using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTheThing : MonoBehaviour
{

  

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box" )
        {
            other.gameObject.transform.position = transform.position;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

}
