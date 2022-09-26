using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneControllerTeleport : MonoBehaviour
{

    public GameObject player;
    public List<GameObject> objectsOnTop;

    private Vector3 childPos;
    private Vector3 daddyPos;
    private bool imTriggered;
    public float teleportPosZ;
    public float teleportPosX;

    // Start is called before the first frame update
    void Start()
    {
        childPos = GetComponentInChildren<Transform>().position;
        daddyPos = GetComponentInParent<GetMyPosition>().thisPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.H) || imTriggered)
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.transform.position = new Vector3 (childPos.x + teleportPosX, childPos.y, childPos.z + teleportPosZ);
            Debug.Log("daddy pos: " + daddyPos + " and childPos" + childPos);
            imTriggered = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            objectsOnTop.Add(other.gameObject);
            player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        objectsOnTop.Remove(other.gameObject);
        player = null;
    }

    public void Activate()
    {
        if (!imTriggered && player)
        {
            imTriggered = true;
        }
    }
}
