using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class LooseControllerManager : MonoBehaviour
{
    public bool shouldLose = false;
    private GameObject screen;

    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.FindGameObjectWithTag("Lose");
        screen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldLose)
        {
            screen.SetActive(true);
        }
    }
}
