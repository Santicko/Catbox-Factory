using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public bool isTriggered;
    public float gameSpeed = 1f;

    void Start()
    {

    }

    void Update()
    {
        if(isTriggered)
        {
            GetComponent<Rigidbody>().velocity = transform.right * -1 * gameSpeed;
        }
    }

    public void DestroyRigidbody()
    {
        Destroy(GetComponent<Rigidbody>());
        isTriggered = false;
    }

    public void CreateRigidbody()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
    }
}
