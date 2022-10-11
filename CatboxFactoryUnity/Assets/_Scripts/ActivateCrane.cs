using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateCrane : MonoBehaviour
{
    GameObject player;
    public GameObject crane;
    public GameObject craneHitbox;
    public GameObject upperHitbox;
    public GameObject rotating;

    public Button pickUpBox;
    public Button rotateBox;
    public Button dropBox;

    private bool craneActivate;
    public bool rotatingDone;

    private bool risingMovement;
    private bool rotatingMovement;

    public bool clickedCrane;

    public float timePassed = 0f;
    public int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        craneActivate = false;
        rotatingDone = false;
        upperHitbox.SetActive(false);

        risingMovement = false;
        rotatingMovement = false;

        clickedCrane = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (clickedCrane && craneActivate)
        {
            craneActivate = false;
            risingMovement = true;
            player.GetComponent<PlayerController>().DestroyRigidbody();
        }
        if (clickedCrane && !craneActivate)
        {
            clickedCrane = false;
        }

        if (risingMovement)
        {
            Vector3 hitbox = upperHitbox.transform.position;
<<<<<<< HEAD
            float moveRate = 2f * Time.deltaTime *speed;
=======
            float moveRate = 2f * Time.deltaTime * speed;
>>>>>>> SanderLevelDesign
            player.transform.position = Vector3.MoveTowards(player.transform.position, hitbox, moveRate);

            if (player.transform.position.y > hitbox.y - 0.1 && player.transform.position.y < hitbox.y + 0.1)
            {
                player.transform.parent = rotating.transform;
                risingMovement = false;
                //rotatingMovement = true;
            }
        }

        if (rotatingMovement && rotatingDone == false)
        {
            timePassed += Time.deltaTime;
<<<<<<< HEAD
            float rotationRate = 90f*speed * Time.deltaTime;
            rotating.transform.Rotate(Vector3.down, rotationRate);

            if (timePassed >= 2f/speed)
            {
                rotationRate = 90f * Time.deltaTime;
                rotating.transform.Rotate(Vector3.down, rotationRate);
            }
            

            if (timePassed >= 2f)
=======
            float rotationRate = 90f * speed * Time.deltaTime;
            rotating.transform.Rotate(Vector3.down, rotationRate);

            if (timePassed >= 2f / speed)
>>>>>>> SanderLevelDesign
            {
                rotationRate = 0f * Time.deltaTime;
                rotating.transform.Rotate(Vector3.down, rotationRate);
                timePassed = 0f;
                rotatingDone = true;
                //craneHitbox.GetComponent<ActivateCrane>().rotatingDone = true;
                //player.transform.parent = null;
                //rotatingMovement = false;
                //clickedCrane = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            player = other.gameObject;
            craneActivate = true;
            upperHitbox.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            craneActivate = false;
            upperHitbox.SetActive(false);
        }
    }

    /*public void ClickedCrane()
    {
        clickedCrane = true;
    }*/

    public void ButtonPickUpBox()
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
    }
}
