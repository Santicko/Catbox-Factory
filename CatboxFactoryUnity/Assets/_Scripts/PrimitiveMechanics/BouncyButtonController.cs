using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyButtonController : MonoBehaviour
{
    public bool redButton;
    public bool blueButton;
    public bool greenButton;

    private GameObject[] pads;

    void Start()
    {
        if(redButton)
        {
            pads = GameObject.FindGameObjectsWithTag("RedBouncy");
        }
        if(blueButton)
        {
            pads = GameObject.FindGameObjectsWithTag("BlueBouncy");
        }
        if(greenButton)
        {
            pads = GameObject.FindGameObjectsWithTag("GreenBouncy");
        }
    }

    public void Pressed()
    {
        foreach (GameObject Go in pads)
        {
            Go.GetComponent<BouncyPadTO>().RotateClockwise();
        }
    }
}
