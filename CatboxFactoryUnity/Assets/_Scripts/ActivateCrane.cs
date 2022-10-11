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

    private bool boxInHitbox;
    private bool boxWasInHitbox;

    private bool risingMovement;
    private bool rotatingMovement;
    private bool rotatingInProcess;

    public bool clickedCrane;
    private bool coolDownTimerActive;

    public float timePassed = 0f;
    public int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        boxInHitbox = false;
        boxWasInHitbox = false;

        upperHitbox.SetActive(false);

        risingMovement = false;
        rotatingMovement = false;
        rotatingInProcess = false;

        clickedCrane = false;
        coolDownTimerActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clickedCrane && boxInHitbox && coolDownTimerActive == false)
        {
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

            float moveRate = 2f * Time.deltaTime * speed;
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
            rotatingInProcess = true;
            timePassed += Time.deltaTime;

            float rotationRate = 90f*speed * Time.deltaTime;
            rotating.transform.Rotate(Vector3.down, rotationRate);

            if (timePassed >= 2f/speed)
            {
                rotationRate = 90f * Time.deltaTime;
                rotating.transform.Rotate(Vector3.down, rotationRate);
                
                rotatingMovement = false;
                clickedCrane = false;
                rotatingInProcess = false;
                timePassed = 0f;

                if (boxWasInHitbox)
                {
                    player.AddComponent<Rigidbody>();
                    player.GetComponent<PlayerController>().CreateRigidbody();
                    player.transform.parent = null;
                    boxWasInHitbox = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (rotatingInProcess == false && (other.tag == "Player" || other.tag == "Box"))
        {
            player = other.gameObject;
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
        }
    }

    public void ClickedCrane()
    {
        clickedCrane = true;
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
