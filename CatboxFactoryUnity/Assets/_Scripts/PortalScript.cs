using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject portalExit1;
    public GameObject portalExit2;
    public GameObject player;
    private bool didTeleport;
    private float teleportTimer;

    Vector3 portalExit1Position;
    Vector3 portalExit2Position;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        portalExit1Position = portalExit1.transform.position;
        portalExit2Position = portalExit2.transform.position;

        teleportTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (didTeleport)
        {
            teleportTimer -= Time.deltaTime;
        }

        if (!didTeleport && teleportTimer <= 0f)
        {
            if (player.transform.position.x > portalExit1Position.x - 1 && player.transform.position.x < portalExit1Position.x + 1
            && player.transform.position.z > portalExit1Position.z - 1 && player.transform.position.z < portalExit1Position.z + 1)
            {
                player.transform.position = portalExit2Position;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, player.transform.position.z);
                player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                didTeleport = true;
                teleportTimer = 2f;
            }

            else if (player.transform.position.x > portalExit2Position.x - 1 && player.transform.position.x < portalExit2Position.x + 1
                && player.transform.position.z > portalExit2Position.z - 1 && player.transform.position.z < portalExit2Position.z + 1)
            {
                player.transform.position = portalExit1Position;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, player.transform.position.z);
                player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                didTeleport = true;
                teleportTimer = 2f;
            }
        }
    }
}
