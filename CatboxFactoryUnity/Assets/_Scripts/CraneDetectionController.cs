using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneDetectionController : MonoBehaviour
{

    private float timer;


    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void OnMouseOver()
    {
        timer = 0.3f;
    }
}
