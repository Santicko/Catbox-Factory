using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBehaviour2 : MonoBehaviour
{
    // my public parts
    public float movSpeed = 0.5f;
    public bool canImove = true;
    public float howLong = 5f;
    public List<GameObject> objectsOnTop;
    public bool activated = false;

    // my private parts
    private GameObject objectOnTop;
    public float activeTimer;
    public Vector3 childPos;
    private Vector3 daddyPos;
    private GameObject player;
    private bool somethingIsOntop;


    void Start()
    {
        //childPos = GetComponentInChildren<Transform>().transform.position;
        childPos = (transform.GetChild(0).localPosition);
        activeTimer = howLong;
        somethingIsOntop = false;
        canImove = false;
    }

    void Update()
    {
        var step = movSpeed * Time.deltaTime;
        if (canImove && somethingIsOntop)
        {
            childPos = (transform.GetChild(0).localPosition);
            daddyPos = GetComponentInParent<Transform>().position;

                childPos = (transform.GetChild(0).localPosition);
                daddyPos = GetComponentInParent<Transform>().position;
                player.GetComponent<Transform>().transform.position = Vector3.MoveTowards(player.transform.position, daddyPos + childPos, step);

            if(player.transform.position == daddyPos + childPos)
            {
                somethingIsOntop = false;
                objectsOnTop.Remove(player);
                canImove = false;
            }
            
            
        }
        if (Input.GetKey(KeyCode.K))
        {
            childPos = (transform.GetChild(0).localPosition);
            daddyPos = GetComponentInParent<Transform>().position;
            player.GetComponent<Transform>().transform.position = Vector3.MoveTowards(player.transform.position, daddyPos + childPos, step);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Activate();
        }
        if(activated)
        {
            Activate();
            activated = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            objectsOnTop.Add(other.gameObject);
            player = other.gameObject;
            somethingIsOntop = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //objectsOnTop.Remove(other.gameObject);
    }
    
    public void Activate()
    {
        if(somethingIsOntop)
        {
            canImove = true;
        }
        return;
    }
}
