using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPadTO : MonoBehaviour
{
    [SerializeField]
    private Vector3[] waypoints;

    private int numWaypoints = 11;
    private int offset;
    private float height = 0.1f;
    private GameObject obj;
    private float bufferTime;
    public float launchDelay = 0.5f;

    private float resolution = 1f;
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
        if(bufferTime <= 0 && obj)
        {
            Launch();
        }
    }
    private void PrepareToMove(Vector3 dir)
    {
        for (int i = 0; i < numWaypoints; i++)
        {   
            waypoints[i] = obj.transform.position + Vector3.up * 1.1f + new Vector3(0f, 0.5f - 0.5f * ((i-offset) * resolution + height) * ((i - offset) * resolution), 0f)* height + i * dir * 0.6f;
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
            bufferTime = launchDelay;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            obj = null;
        }
    }

    public void RotateClockwise()
    {
        transform.Rotate(0f,transform.rotation.y +90f,0f,Space.Self);
    }

    public void RotateCounterClockwise()
    {
        transform.Rotate(0f,transform.rotation.y -90f,0f,Space.Self);
    }
}

