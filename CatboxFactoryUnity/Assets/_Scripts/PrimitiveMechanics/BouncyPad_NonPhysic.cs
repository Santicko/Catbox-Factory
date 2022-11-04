using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPad_NonPhysic : MonoBehaviour
{
    // private parts
    private GameObject objOnTop;
    private float timer;
    private Vector3 tarRot;
    private bool setRotation;
    private float startTime;
    private float rotDeg = 180;
    private float rotLength;
    private GameObject rotObject;
    private float facingDir;
    public bool alert;
    private bool tossingTheBox;

    // public parts
    public float delay = 2f;
    public int speed;


    void Start()
    {
        tossingTheBox = false;
        timer = delay;
        setRotation = false;
    }

    void Update()
    {
        if(timer > 0 && alert)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0 && alert)
        {
            alert = false;
            timer = delay;
            tossingTheBox = true;
        }
        if(tossingTheBox)
        {
            if (objOnTop && (timer > 0f))
            {
                if (!rotObject)
                {
                    facingDir = Quaternion.identity.y;
                    rotObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    rotObject.transform.parent = gameObject.transform;
                    //rotObject.GetComponent<MeshRenderer>().enabled = false;
                    rotObject.transform.position = new Vector3(transform.position.x + 1, transform.position.y +1.3f, transform.position.z);
                    rotObject.transform.eulerAngles = new Vector3(rotObject.transform.eulerAngles.x, rotObject.transform.eulerAngles.y, rotObject.transform.eulerAngles.z);
                    }

                if (objOnTop.tag == "Player" || objOnTop.tag == "Box") // childing the object on top
                {
                    objOnTop.transform.parent = rotObject.transform;
                    objOnTop.GetComponent<PlayerController>().DestroyRigidbody();
                }
                if (setRotation == false) // rotating arc
                {
                    startTime = Time.time;
                    tarRot = transform.eulerAngles + 1f * -rotDeg * Vector3.up;
                    rotLength = Vector3.Distance(transform.eulerAngles, tarRot);
                    setRotation = true;
                }

                // doing the rotation?
                float rotationDone = (Time.time - startTime) * (speed * rotDeg * Time.deltaTime);
                float timeOfRotation = rotationDone / rotLength;
                rotObject.transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, tarRot, timeOfRotation);

                // checking if done, then resetting the contraption
                if (rotObject.transform.eulerAngles.y < tarRot.y + 1f && rotObject.transform.eulerAngles.y > tarRot.y - 1f)
                {
                    setRotation = false;
                    Destroy(rotObject);
                    objOnTop.AddComponent<Rigidbody>();
                    objOnTop.GetComponent<PlayerController>().CreateRigidbody();
                    objOnTop.transform.parent = null;
                    tossingTheBox = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            if (objOnTop == null)
            {
                alert = true;
                objOnTop = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            if (objOnTop == null)
            {
                objOnTop = other.gameObject;
            }
        }
    }
}
