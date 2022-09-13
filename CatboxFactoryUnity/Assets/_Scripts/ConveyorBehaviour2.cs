using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBehaviour2 : MonoBehaviour
{
    // my public parts
    public float movSpeed = 1f;
    public bool canImove = true;
    public float howLong = 5f;
    public List<GameObject> objectsOnTop;

    // my private parts
    private GameObject objectOnTop;
    public float activeTimer;
    private bool objOnTop;
    public Vector3 childPos;
    private Vector3 daddyPos;

    void Start()
    {
        //childPos = GetComponentInChildren<Transform>().transform.position;
        childPos = (transform.GetChild(0).localPosition);
        activeTimer = howLong;
        objOnTop = false;
    }

    void Update()
    {
        if (canImove)
        {
            activeTimer = howLong;
        }
        if(Input.GetKey(KeyCode.K))
        {
            childPos = (transform.GetChild(0).localPosition);
            daddyPos = GetComponentInParent<Transform>().position;
            daddyPos.x = daddyPos.x / GetComponentInParent<Transform>().localScale.x;
            daddyPos.y = daddyPos.y / GetComponentInParent<Transform>().localScale.y;
            daddyPos.z = daddyPos.z / GetComponentInParent<Transform>().localScale.z;
            var step = movSpeed * Time.deltaTime;
            Debug.Log("childpos:  "+ childPos+ " and daddy: " + daddyPos);
            objectsOnTop[0].GetComponent<Transform>().transform.position = Vector3.MoveTowards(objectsOnTop[0].transform.position, daddyPos + childPos, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            objectsOnTop.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        objectsOnTop.Remove(other.gameObject);
    }
    
    public void Activate()
    {
        canImove = true;
        return;
    }
}
