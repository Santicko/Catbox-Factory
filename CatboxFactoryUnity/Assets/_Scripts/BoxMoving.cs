using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMoving : MonoBehaviour
{
    Vector3 startHitbox1;
    Vector3 startHitbox2;
    Vector3 startHitbox3;

    Vector3 endHitbox1;
    Vector3 endHitbox2;
    Vector3 endHitbox3;

    GameObject flipper;

    float moveRate;
    bool shouldMoveRight;
    bool shouldMoveUp;
    bool shouldMoveDown;

    // Start is called before the first frame update
    void Start()
    {
        startHitbox1 = GameObject.Find("StartHitbox1").transform.position;
        startHitbox2 = GameObject.Find("StartHitbox2").transform.position;
        startHitbox3 = GameObject.Find("StartHitbox3").transform.position;

        endHitbox1 = GameObject.Find("FlipperHitbox").transform.position;
        endHitbox2 = GameObject.Find("EndHitbox2").transform.position;
        endHitbox3 = GameObject.Find("EndHitbox3").transform.position;

        flipper = GameObject.Find("FlipperHitbox");

        moveRate = 1f * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position == startHitbox1)
        {
            shouldMoveRight = true;
        }

        if (shouldMoveRight == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endHitbox1, moveRate);
        }

        if (transform.position == startHitbox2)
        {
            shouldMoveDown = true;
        }

        if (shouldMoveDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endHitbox2, moveRate);
        }

        if (transform.position == endHitbox2) {
            shouldMoveDown = false;
        }

        if (transform.position == startHitbox3)
        {
            shouldMoveUp = true;
        }

        if (shouldMoveUp == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endHitbox3, moveRate);
        }

        if (transform.position == endHitbox3)
        {
            shouldMoveUp = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == flipper.GetComponent<Collider>())
        {
            shouldMoveRight = false;
            Destroy(GetComponent<BoxMoving>());
        }
    }
}
