using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperControls : MonoBehaviour
{
    private float x;
    private float y;
    private float z;

    private Vector3 rotValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.O))
        {
            rotValue.y += Time.deltaTime;
            if (rotValue.y < 0.2f)
            {
                rotValue.y = 0.2f;
            }
            transform.Rotate(x, rotValue.y, z, Space.Self);
        }

        if (Input.GetKey(KeyCode.P))
        {
            rotValue.y -= Time.deltaTime;
            if (rotValue.y > -0.2f)
            {
                rotValue.y = -0.2f;
            }
            transform.Rotate(x, rotValue.y, z, Space.Self);
        }
    }
}
