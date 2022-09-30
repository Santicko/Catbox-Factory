using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{

    private bool haveScript;

    void Start()
    {
        haveScript = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(-1.88f, 1.43f, -7.62f);
        }

        if (Input.GetKeyDown(KeyCode.H) && !haveScript)
        {
            gameObject.AddComponent<BoxRisingMovement>();
            haveScript = true;
        }
    }

    public void TurnOffHaveScript()
    {
        haveScript = false;
    }






}
