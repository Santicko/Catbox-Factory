using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPadTO : MonoBehaviour
{
    [SerializeField]
    private Vector3[] waypoints;

    private int numWaypoints = 11;
    private int offset;
    public int height = 5;
    private GameObject obj;
    private float bufferTime;

    private float resolution = 0.2f;
    private Vector3[] direction = { 
        Vector3.forward, 
        Vector3.forward + Vector3.right, 
        Vector3.right, 
        -Vector3.forward + Vector3.right, 
        -Vector3.forward, 
        -Vector3.forward - Vector3.right,
        -Vector3.right,
        Vector3.forward - Vector3.right   
    };
    Vector3 dirToMove;

    // Start is called before the first frame update
    private void Start()
    {
        waypoints = new Vector3[numWaypoints];
        offset = waypoints.Length / 2;
        dirToMove = direction[0];
    }
    private void PrepareToMove(Vector3 dir)
    {
        for (int i = 0; i < numWaypoints; i++)
        {
            waypoints[i] = transform.position + new Vector3(0f, 0.5f - 0.5f * ((i-offset) * resolution) * ((i - offset) * resolution), 0f)*height + i * dir * 0.5f;
        }
    }

    void OnMouseDown()
    {
        PrepareToMove(dirToMove);
        iTween.MoveTo(gameObject, iTween.Hash("path", waypoints, "time", 1f, "easetype", iTween.EaseType.easeOutQuad));
        dirToMove = direction[Random.Range(0, direction.Length)];
        transform.rotation = Quaternion.LookRotation(dirToMove);
    }
    void update()
    {
        if (bufferTime > 0)
        {
            bufferTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            obj = other.gameObject;
            bufferTime = 0.2f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            obj = null;
        }
    }
}

