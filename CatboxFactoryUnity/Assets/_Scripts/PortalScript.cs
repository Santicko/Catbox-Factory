using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject portalExit1;
    public GameObject portalExit2;
    public GameObject player;

    Vector3 portalExit1Position;

    // Start is called before the first frame update
    void Start()
    {
        portalExit1Position = portalExit1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            player.transform.position = portalExit1Position;
            Debug.Log("Hei");
        }
    }
}
