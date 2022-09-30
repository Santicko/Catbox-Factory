using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSkin : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;


    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void EnableSkin()
    {
        timer = 0.1f;
    }
}
