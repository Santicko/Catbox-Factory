using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCrane : MonoBehaviour
{
    GameObject player;
    public GameObject craneHitbox;
    public GameObject upperHitbox;
    public GameObject rotating;
  
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

        if (rotatingDone)
        {
            player.AddComponent<Rigidbody>();
            player.GetComponent<PlayerController>().CreateRigidbody();
            rotatingDone = false;
        }

        if (risingMovement)
        {
            Vector3 hitbox = upperHitbox.transform.position;
            float moveRate = 2f * Time.deltaTime *speed;
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
            timePassed += Time.deltaTime;
            float rotationRate = 90f*speed * Time.deltaTime;
            rotating.transform.Rotate(Vector3.down, rotationRate);

            if (timePassed >= 2f/speed)
            {
                timePassed = 0f;
                craneHitbox.GetComponent<ActivateCrane>().rotatingDone = true;
                player.transform.parent = null;
                rotatingMovement = false;
                clickedCrane = false;
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

    public void ClickedCrane()
    {
        clickedCrane = true;
    }
}
