using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateCrane : MonoBehaviour
{
    private GameObject[] cranesGreen;
    private GameObject[] cranesBlue;
    private GameObject[] cranesRed;
    private GameObject player;
    private GameObject controller;
    public GameObject craneHitbox;
    public GameObject upperHitbox;
    public GameObject rotating;

    public Button pickUpBox;
    public Button rotateBox;
    public Button dropBox;

    public bool boxInHitbox;
    private bool sizeUp;

    private bool risingMovement;
    private bool rotatingMovement;
    public bool turnAround;

    public bool clickedCrane;
    private bool coolDownTimerActive;
    private float coolDownTimer;

    private bool hasMovedBox;

    public int speed = 1;

    public int rotateDegrees = 180;
    public Vector3 targetRotation;
    private bool targetRotationSet;
    private float rotatedLength;
    private float startTime;

    Vector3 overallRotation, oldRotation;



    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("CraneController");

        boxInHitbox = false;

        upperHitbox.SetActive(false);

        risingMovement = false;
        rotatingMovement = false;
        //rotatingInProcess = false;

        clickedCrane = false;
        coolDownTimerActive = false;

        targetRotationSet = false;
        //turnAround = false;
        speed = 4;

        /*if (transform.eulerAngles.y >= 180)
        {
            turnAround = true;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (rotatingMovement == false && clickedCrane && boxInHitbox && coolDownTimerActive == false)
        {
            controller.GetComponent<CraneManager>().selectedCrane = gameObject;
            controller.GetComponent<CraneManager>().Activate();

            risingMovement = true;

            if (player.tag == "Player")
            {
                player.GetComponent<PlayerController>().DestroyRigidbody();
            }
        }

        else if (clickedCrane && !boxInHitbox && !risingMovement && coolDownTimerActive == false)
        {
            rotatingMovement = true;
        }

        if (risingMovement && coolDownTimerActive == false)
        {
            if (player.tag == "Player")
            {
                player.GetComponent<PlayerController>().DestroyRigidbody();
                boxInHitbox = false;
            }

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
        if (rotatingMovement && coolDownTimerActive == false)
        {
            if (!sizeUp)
            {
                gameObject.transform.localScale += new Vector3(2, 0, 0);
                sizeUp = true;
            }

            if (!targetRotationSet)
            {
                oldRotation = rotating.transform.rotation.eulerAngles;
                targetRotationSet = true;
            }
            
            if (oldRotation != rotating.transform.rotation.eulerAngles)
            {
                overallRotation += rotating.transform.rotation.eulerAngles - oldRotation;
            }

            if (turnAround)
            {
                rotating.transform.Rotate(0, rotating.transform.position.y * Time.deltaTime * -rotateDegrees * 3.3f, 0);
            }
            else
            {
                rotating.transform.Rotate(0, rotating.transform.position.y * Time.deltaTime * rotateDegrees * 3.3f, 0);
            }

            rotatedLength += rotateDegrees * Time.deltaTime;

            if (rotatedLength >= 180 || rotatedLength <= -180)
            {
                rotating.transform.eulerAngles = oldRotation + new Vector3(0, 180, 0);
                rotatedLength = 0;


                coolDownTimerActive = true;
                rotatingMovement = false;
                targetRotationSet = false;
                clickedCrane = false;
                turnAround = !turnAround;
                upperHitbox.SetActive(true);
                if (!boxInHitbox)
                {
                    if (player != null && player.tag == "Player")
                    {
                        player.AddComponent<Rigidbody>();
                        player.GetComponent<PlayerController>().CreateRigidbody();
                        player.transform.parent = null;

                        cranesGreen = GameObject.FindGameObjectsWithTag("CraneGreen");
                        cranesBlue = GameObject.FindGameObjectsWithTag("CraneBlue");
                        cranesRed = GameObject.FindGameObjectsWithTag("CraneRed");

                        foreach (GameObject crane in cranesGreen)
                        {
                            if (crane.GetComponentInChildren<ActivateCrane>().hasMovedBox)
                            {
                                crane.GetComponentInChildren<ActivateCrane>().player = null;
                            }
                            
                        }
                        foreach (GameObject crane in cranesBlue)
                        {
                            if (crane.GetComponentInChildren<ActivateCrane>().hasMovedBox)
                            {
                                crane.GetComponentInChildren<ActivateCrane>().player = null;
                            }
                        }
                        foreach (GameObject crane in cranesRed)
                        {
                            if (crane.GetComponentInChildren<ActivateCrane>().hasMovedBox)
                            {
                                crane.GetComponentInChildren<ActivateCrane>().player = null;
                            }
                        }


                    }
                    player = null;
                }

                if (sizeUp)
                {
                    gameObject.transform.localScale -= new Vector3(2, 0, 0);
                    sizeUp = false;
                }
            }
        }

        if (coolDownTimerActive)
        {
            coolDownTimer += Time.deltaTime;

            if (coolDownTimer > 1.2f)
            {
                coolDownTimerActive = false;
                coolDownTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" || other.tag == "Box")
        {
            if (player == null)
            {
                player = other.gameObject;
            }
        }

        if (rotatingMovement == false && boxInHitbox)
        {
            upperHitbox.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            boxInHitbox = true;
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
            player = null;


            /*if (!boxWasInHitbox)
            {
                player = null;
            }*/
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
