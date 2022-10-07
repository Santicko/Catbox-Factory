using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveTrap : MonoBehaviour
{
    private float timer;
    private bool spawn;
    public GameObject lifeCounter;
    public float dangerTime = 0.5f;
    public float safeTime = 2f;
    public float countdown;

    private bool safe;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0.5f;
        spawn = false;
        lifeCounter = GameObject.FindGameObjectWithTag("LifeCounter");
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            /*  // "particle system
            timer -= Time.deltaTime;
            GameObject particle = GameObject.CreatePrimitive(PrimitiveType.Cube);
            particle.AddComponent<ParticleController>();
            particle.transform.position = transform.position;
            if (timer <= 0)
            {
                spawn = false;
            }
            */  // "particle system
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
        if (safe)
        {
            GetComponent<LoseScreen>().NotLoose();
        }
        if(!safe)
        {
            GetComponent<LoseScreen>().Loose();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Box") && !safe )
        {
            Destroy(other);
            spawn = true;
            lifeCounter.GetComponent<PlayerLives>().life -= 1;
        }
    }
}
