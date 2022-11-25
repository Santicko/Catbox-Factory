using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLever : MonoBehaviour
{
    public List<GameObject> conveyors;
    public GameObject conveyorDaddy;
    public bool fast;
    public int speedModifier = 2;
    private float temp;
    private bool changed;


    private void Start()
    {
        changed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fast && !changed && conveyorDaddy)
        {
            var spdVal = conveyorDaddy.GetComponent<ConveyorControllerForParent>().speed;
            spdVal = spdVal * speedModifier;
        }
        if (!fast && !changed && conveyorDaddy)
        {
            var spdVal = conveyorDaddy.GetComponent<ConveyorControllerForParent>().speed;
            spdVal = spdVal / speedModifier;
        }

        if (fast && !changed && !conveyorDaddy)
        {
            foreach (GameObject conv in conveyors)
            {
                temp = conv.GetComponent<ConveyorController>().gameSpeed;
                conv.GetComponent<ConveyorController>().gameSpeed = temp * speedModifier;
            }
            changed = true;
        }
        if (!fast && !changed && !conveyorDaddy)
        {
            foreach (GameObject conv in conveyors)
            {
                temp = conv.GetComponent<ConveyorController>().gameSpeed;
                conv.GetComponent<ConveyorController>().gameSpeed = temp / speedModifier;
            }
            changed = true;
        }
    }

    public void ClickedLever()
    {
        if (fast)
        {
            fast = false;
            changed = false;
        }
        else 
        {
            fast = true;
            changed = false;
        }
    }
}

