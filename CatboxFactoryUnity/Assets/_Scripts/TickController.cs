using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickController : MonoBehaviour
{
    private float tickDelay = 2f;

    public List<GameObject> machineList;

    public float timer;
    private int inList;

    // Start is called before the first frame update
    void Start()
    {
        timer = tickDelay;
        inList = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = tickDelay;
            /*
            foreach(GameObject machine in machineList)
            {
                ConveyorBehaviour2 script = machine.GetComponent<ConveyorBehaviour2>();
                script.activated = true;
            }
            */
            for(int i = machineList.Count; i > 0; i--)
            {
                machineList[i-1].GetComponent<ConveyorBehaviour2>().activated = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Belt" || other.tag == "Machine") 
        {
            machineList.Add(other.gameObject);
            inList++;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Belt" || other.tag == "Machine")
        {
            machineList.Remove(other.gameObject);
            inList--;
        }
    }
}
