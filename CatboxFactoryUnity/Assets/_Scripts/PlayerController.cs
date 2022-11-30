using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{

    void Start()
    {

    }

    void Update()
    {

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
