using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMyPosition : MonoBehaviour
{

    public Vector3 thisPos;


    // Start is called before the first frame update
    void Start()
    {
        thisPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
