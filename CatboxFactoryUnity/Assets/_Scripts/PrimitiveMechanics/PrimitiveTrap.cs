using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveTrap : MonoBehaviour
{
    private float timer;
    private bool spawn;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0.5f;
        spawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            timer -= Time.deltaTime;
            GameObject particle = GameObject.CreatePrimitive(PrimitiveType.Cube);
            particle.AddComponent<ParticleController>();
            particle.transform.position = transform.position;
            if (timer <= 0)
            {
                spawn = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Box")
        {
            Destroy(other);
            spawn = true;
        }
    }
}
