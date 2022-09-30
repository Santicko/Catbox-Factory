using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRotatingMovement : MonoBehaviour
{
    public float timePassed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        float rotationRate = 60f * Time.deltaTime;
        transform.Rotate(Vector3.down, rotationRate);

        if (timePassed >= 3f)
        {
            GameObject.Find("Player").transform.parent = null;
            GameObject.Find("Player").AddComponent<BoxLoweringMovement>();
            Destroy(GetComponent<BoxRotatingMovement>());
        }
    }
}
