using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateCrane : MonoBehaviour
{
    private GameObject player;
    private GameObject controller;
    public GameObject crane;
    public GameObject craneHitbox;
    public GameObject upperHitbox;
    public GameObject rotating;

    public Button pickUpBox;
    public Button rotateBox;
    public Button dropBox;

    public bool boxInHitbox;
    private bool boxWasInHitbox;

    private bool risingMovement;
    private bool rotatingMovement;
    //private bool rotatingInProcess;
    private bool turnAround;

    public bool clickedCrane;
    private bool coolDownTimerActive;

    public int speed = 1;

    public int rotateDegrees = 180;
    public Vector3 targetRotation;
    private bool targetRotationSet;
    private float rotatedLength;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("CraneController");

        boxInHitbox = false;
        boxWasInHitbox = false;

        upperHitbox.SetActive(false);

        risingMovement = false;
        rotatingMovement = false;
        //rotatingInProcess = false;

        clickedCrane = false;
        coolDownTimerActive = false;

        targetRotationSet = false;
        turnAround = false;
        speed = 4;

        if (transform.eulerAngles.y >= 180)
        {
            turnAround = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rotatingMovement == false && clickedCrane && boxInHitbox && coolDownTimerActive == false)
        //if (rotatingInProcess == false && clickedCrane && boxInHitbox && coolDownTimerActive == false)
        {
            controller.GetComponent<CraneManager>().selectedCrane = gameObject;
            controller.GetComponent<CraneManager>().Activate();
            
            coolDownTimerActive = true;
            risingMovement = true;
            player.GetComponent<PlayerController>().DestroyRigidbody();
            boxWasInHitbox = true;
        } else if (clickedCrane && !boxInHitbox)
        {
            rotatingMovement = true;
        }

        if (risingMovement)
        {
            Vector3 hitbox = upperHitbox.transform.position;

            float moveRate = Time.deltaTime * speed;
            player.transform.position = Vector3.MoveTowards(player.transform.position, hitbox, moveRate);

            if (player.transform.position.y > hitbox.y - 0.1 && player.transform.position.y < hitbox.y + 0.1)
            {
                player.transform.parent = rotating.transform;
                risingMovement = false;
                rotatingMovement = true;
            }
        }

        if (rotatingMovement)
        {
            //rotatingInProcess = true;

            if (targetRotationSet == false)
            {
                startTime = Time.time;
                if (turnAround)
                {
                    targetRotation = transform.eulerAngles + 1f * -rotateDegrees * Vector3.up; 
                } else
                {
                    targetRotation = transform.eulerAngles + 1f * rotateDegrees * Vector3.up;
                }

                rotatedLength = Vector3.Distance(transform.eulerAngles, targetRotation);
                targetRotationSet = true;
            }

            float rotationDone = (Time.time - startTime) * (speed * rotateDegrees * Time.deltaTime);
            float timeOfRotation = rotationDone / rotatedLength;
            rotating.transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, timeOfRotation);

            if (rotating.transform.eulerAngles.y < targetRotation.y + 1f && rotating.transform.eulerAngles.y > targetRotation.y - 1f)
            {
                rotating.transform.eulerAngles = targetRotation;

                if (boxWasInHitbox && !boxInHitbox)
                {
                    if (player == null)
                    {
                        player = gameObject.transform.parent.Find("Player").gameObject;
                    }
                    
                    player.AddComponent<Rigidbody>();
                    player.GetComponent<PlayerController>().CreateRigidbody();
                    player.transform.parent = null;
                    boxWasInHitbox = false;
                    boxInHitbox = true;
                    rotatingMovement = false;
                    clickedCrane = false;
                    targetRotationSet = false;
                    turnAround = !turnAround;
                    upperHitbox.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if ((other.tag == "Player" || other.tag == "Box"))
        {
            if (player == null)
            {
                player = other.gameObject;
                boxInHitbox = true;
            }
        }

        if (rotatingMovement == false && boxInHitbox)
        {
            upperHitbox.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            boxInHitbox = false;
            upperHitbox.SetActive(false);
            coolDownTimerActive = false;
            if (!boxWasInHitbox)
            {
                player = null;
            }
        }
    }

    public void ClickedCrane()
    {
        clickedCrane = true;
    }

    public void RemovePlayer()
    {
        boxInHitbox = false;
        upperHitbox.SetActive(false);
        coolDownTimerActive = false;
    }

    /*public void ButtonPickUpBox()
    {
        clickedCrane = true;
    }

    public void ButtonRotateCrane()
    {
        rotatingDone = false;
        rotatingMovement = true;
    }

    public void ButtonDropBox()
    {
        player.transform.parent = null;
        rotatingMovement = false;
        clickedCrane = false;
        player.AddComponent<Rigidbody>();
        player.GetComponent<PlayerController>().CreateRigidbody();
    }

    public void ShowButtons()
    {
        pickUpBox.gameObject.SetActive(true);
        rotateBox.gameObject.SetActive(true);
        dropBox.gameObject.SetActive(true);
    }

    public void HideButtons()
    {
        pickUpBox.gameObject.SetActive(false);
        rotateBox.gameObject.SetActive(false);
        dropBox.gameObject.SetActive(false);
    }*/
}
