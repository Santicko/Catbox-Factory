using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLever : MonoBehaviour
{
    public List<GameObject> conveyors;
    public bool fast;
    private float temp;
    private bool changed;

    private void Start()
    {
        changed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fast && !changed)
        {
            foreach (GameObject conv in conveyors)
            {
                temp = conv.GetComponent<ConveyorController>().gameSpeed;
                conv.GetComponent<ConveyorController>().gameSpeed = temp * 2;
            }
            changed = true;
        }
        if (!fast && !changed)
        {
            foreach (GameObject conv in conveyors)
            {
                temp = conv.GetComponent<ConveyorController>().gameSpeed;
                conv.GetComponent<ConveyorController>().gameSpeed = temp / 2;
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

