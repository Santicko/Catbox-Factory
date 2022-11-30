using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontRotateMe : MonoBehaviour
{
    private Quaternion initialRot;
    // Start is called before the first frame update
    void Start()
    {
        initialRot = Quaternion.Euler(new Vector3(this.transform.localRotation.x ,this.transform.localRotation.y,this.transform.localRotation.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = initialRot;
    }
}
