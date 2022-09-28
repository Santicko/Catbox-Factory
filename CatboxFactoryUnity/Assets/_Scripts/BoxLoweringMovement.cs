using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLoweringMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lowerHitbox = GameObject.Find("LowerHitbox").transform.position;
        float moveRate = 1f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, lowerHitbox, moveRate);

        if (transform.position.y > lowerHitbox.y - 0.1 && transform.position.y < lowerHitbox.y + 0.1)
        {
            Destroy(GetComponent<BoxLoweringMovement>());
        }
    }
}
