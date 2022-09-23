using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Vector3 startHitbox1;
    Vector3 startHitbox2;
    Vector3 startHitbox3;

    GameObject flipper;

    // Start is called before the first frame update
    void Start()
    {
        startHitbox1 = GameObject.Find("StartHitbox1").transform.position;
        startHitbox2 = GameObject.Find("StartHitbox2").transform.position;
        startHitbox3 = GameObject.Find("StartHitbox3").transform.position;

        flipper = GameObject.Find("FlipperHitbox");
    }

    // Update is called once per frame
    void Update()
    {  
        if (transform.position == startHitbox1 || transform.position == startHitbox2 || transform.position == startHitbox3)
        {
            GameObject.Find("Box").AddComponent<BoxMoving>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == flipper.GetComponent<Collider>())
        {
            Destroy(GetComponent<BoxMoving>());
        }
    }
}
