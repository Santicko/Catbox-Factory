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
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(-1.88f, 1.43f, -7.62f);
        }

        if (Input.GetKey(KeyCode.H))
        {
            gameObject.AddComponent<BoxRisingMovement>();
        }
    }






}
