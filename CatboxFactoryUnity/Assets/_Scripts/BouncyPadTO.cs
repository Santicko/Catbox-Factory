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
    public float bufferTime;

    private float resolution = 0.2f;
    Vector3 dirToMove;

    // Start is called before the first frame update
    private void Start()
    {
        waypoints = new Vector3[numWaypoints];
        offset = waypoints.Length / 2;
        dirToMove = transform.forward;
    }
    void Update()
    {
        if (bufferTime > 0)
        {
            bufferTime -= Time.deltaTime;
            
        }
        if(bufferTime <= 0)
        {
            Launch();
        }
    }
    private void PrepareToMove(Vector3 dir)
    {
        for (int i = 0; i < numWaypoints; i++)
        {
            waypoints[i] = transform.position + Vector3.up * 0.775f + new Vector3(0f, 0.5f - 0.5f * ((i-offset) * resolution) * ((i - offset) * resolution), 0f)*height + i * dir * 0.6f;
        }
    }

    void Launch()
    {
        dirToMove = transform.forward;
        PrepareToMove(dirToMove);
        iTween.MoveTo(obj, iTween.Hash("path", waypoints, "time", 1f, "easetype", iTween.EaseType.easeOutQuad));
        obj.transform.rotation = Quaternion.LookRotation(dirToMove);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            obj = other.gameObject;
            bufferTime = 0.5f;
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

