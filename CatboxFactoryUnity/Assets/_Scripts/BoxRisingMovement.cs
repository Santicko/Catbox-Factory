using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRisingMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 upperHitbox = GameObject.Find("UpperHitbox").transform.position;
        float moveRate = 1f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, upperHitbox, moveRate);

        if (transform.position.y > upperHitbox.y - 0.1 && transform.position.y < upperHitbox.y + 0.1)
        {
            GameObject.Find("Player").transform.parent = GameObject.Find("Rotating").transform;
            GameObject.Find("Rotating").AddComponent<BoxRotatingMovement>();
            Destroy(GetComponent<BoxRisingMovement>());
        }
    }
}
