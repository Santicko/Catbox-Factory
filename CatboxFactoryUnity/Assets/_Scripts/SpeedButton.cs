using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedButton : MonoBehaviour
{
    private GameObject[] conveyors;
    private GameObject[] players;

    private float temp;
    public int speedModifier = 2;

    // Start is called before the first frame update
    void Start()
    {
        if(conveyors == null)
        {
            conveyors = GameObject.FindGameObjectsWithTag("Belt");
            players = GameObject.FindGameObjectsWithTag("Player");

        }
    }

    public void Pressed()
    {
        /*
        foreach (GameObject conv in conveyors)
        {
            temp = conv.GetComponent<ConveyorController>().gameSpeed;
            conv.GetComponent<ConveyorController>().gameSpeed = temp * speedModifier;
        }*/
        foreach (GameObject player in conveyors)
        {
            temp = player.GetComponent<ConveyorController>().gameSpeed;
            player.GetComponent<ConveyorController>().gameSpeed = temp * speedModifier;
        }
    }
    public void Released()
    {/*
        foreach (GameObject conv in conveyors)
        {
            temp = conv.GetComponent<ConveyorController>().gameSpeed;
            conv.GetComponent<ConveyorController>().gameSpeed = temp / speedModifier;
        }*/
        foreach (GameObject player in conveyors)
        {
            temp = player.GetComponent<ConveyorController>().gameSpeed;
            player.GetComponent<ConveyorController>().gameSpeed = temp / speedModifier;
        }
    }

}
