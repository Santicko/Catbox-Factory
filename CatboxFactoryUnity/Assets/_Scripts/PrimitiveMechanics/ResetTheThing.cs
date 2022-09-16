using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTheThing : MonoBehaviour
{

    private bool didIDoTheThing;

    private void Start()
    {
        didIDoTheThing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box" && didIDoTheThing)
        {
            other.gameObject.transform.position = transform.position;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            didIDoTheThing = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        didIDoTheThing = true;
    }
}
