using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveTrap : MonoBehaviour
{
    private bool spawn;
    public bool isCrusher;
    public GameObject lifeCounter;
    public GameObject crushedBox;
    public float dangerTime = 0.5f;
    public float safeTime = 2f;
    public float countdown;

    private bool safe;
    private bool playerDetected;
    private bool boxDetected;
    private GameObject screen;
    private GameObject playerInRange;
    private GameObject boxInRange;
    public AudioClip soundCatDeath;
    public GameObject cameraSystem;
    //private bool didChangeCamera;


    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.FindGameObjectWithTag("LoseManager");
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = soundCatDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if(!lifeCounter)
        {
            lifeCounter = GameObject.FindGameObjectWithTag("LifeCounter");
        }
        if ((playerDetected) && !safe) // Kill Player
        {
            /*if (!didChangeCamera)
            {
                cameraSystem.GetComponentInChildren<CameraSwitch>().Camera0();
            }
            didChangeCamera = true;*/

            playerDetected = false;
            GetComponent<AudioSource>().Play();
            if (isCrusher)
            {
                var go = Instantiate(crushedBox);
                go.transform.parent = null;
                go.transform.position = new Vector3 (playerInRange.transform.position.x,playerInRange.transform.position.y-0.6f,playerInRange.transform.position.z);
            }
            Destroy(playerInRange);
            //lifeCounter.GetComponent<PlayerLives>().life -= 1;
            screen.GetComponent<LooseControllerManager>().shouldLose = true;
            if(!isCrusher)
            {
                GetComponent<ParticleSystem>().Play();
                ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
                em.enabled = true;
            }
            
        }
        if ((boxDetected) && !safe) // kill box
        {
            boxDetected = false;
            Destroy(boxInRange.gameObject);
            boxInRange = null;
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
            em.enabled = true;
        }

        if (0 < countdown) { countdown -= Time.deltaTime; } // reduce the timer
        if (countdown <= 0) { countdown = dangerTime + safeTime; } // reset the timer
        if (0 < countdown && countdown < safeTime)
        {
            GetComponent<Renderer>().material.color = Color.green;
            safe = true;
        }
        if (safeTime <= countdown && countdown < dangerTime+ safeTime)
        {
            GetComponent<Renderer>().material.color = Color.red;
            safe = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = other.gameObject;
            playerDetected = true;
        }
        if (other.tag == "Box")
        {
            boxInRange = other.gameObject;
            boxDetected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = null;
            playerDetected = false;
        }
        if (other.tag == "Box")
        {
            boxInRange = null;
            boxDetected = false;
        }
    }
}
